namespace Square.Http.Client
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Polly;
    using Polly.Retry;
    using Polly.Timeout;
    using Polly.Wrap;
    using Square.Http.Request;
    using Square.Http.Response;
    using Square.Utilities;

    /// <summary>
    /// HttpClientWrapper.
    /// </summary>
    internal sealed class HttpClientWrapper : IHttpClient
    {
        private static readonly object SyncObject = new object();
        private static HttpClient defaultHttpClient;
        private static char parameterSeparator = '&';
        private readonly int numberOfRetries;
        private readonly int backoffFactor;
        private readonly double retryInterval;
        private readonly TimeSpan backoffMax;
        private ArrayDeserialization arrayDeserializationFormat = ArrayDeserialization.Indexed;
        private HttpClient client;
        private IList<HttpStatusCode> statusCodesToRetry;
        private IList<HttpMethod> requestMethodsToRetry;

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpClientWrapper"/> class.
        /// </summary>
        public HttpClientWrapper()
        {
            HttpClientConfiguration httpClientConfig = new HttpClientConfiguration();
            this.statusCodesToRetry = httpClientConfig.StatusCodesToRetry
                .Where(val => Enum.IsDefined(typeof(HttpStatusCode), val))
                .Select(val => (HttpStatusCode)val).ToImmutableList();

            this.requestMethodsToRetry = httpClientConfig.RequestMethodsToRetry
                .Select(method => new HttpMethod(method.ToString())).ToList();

            this.numberOfRetries = httpClientConfig.NumberOfRetries;
            this.backoffFactor = httpClientConfig.BackoffFactor;
            this.retryInterval = httpClientConfig.RetryInterval;
            this.backoffMax = httpClientConfig.BackoffMax;
            this.client = this.GetDefaultHttpClient();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpClientWrapper"/> class.
        /// </summary>
        /// <param name="httpClientConfig"> HttpClientConfiguration object.</param>
        public HttpClientWrapper(HttpClientConfiguration httpClientConfig)
        {
            this.statusCodesToRetry = httpClientConfig.StatusCodesToRetry
                .Where(val => Enum.IsDefined(typeof(HttpStatusCode), val))
                .Select(val => (HttpStatusCode)val).ToImmutableList();

            this.requestMethodsToRetry = httpClientConfig.RequestMethodsToRetry
                .Select(method => new HttpMethod(method.ToString())).ToList();

            this.numberOfRetries = httpClientConfig.NumberOfRetries;
            this.backoffFactor = httpClientConfig.BackoffFactor;
            this.retryInterval = httpClientConfig.RetryInterval;
            this.backoffMax = httpClientConfig.BackoffMax;
            this.client = new HttpClient()
            {
                Timeout = httpClientConfig.Timeout,
            };
        }

        /// <summary>
        /// OnBeforeHttpRequestEvent.
        /// </summary>
        public event OnBeforeHttpRequestEventHandler OnBeforeHttpRequestEvent;

        /// <summary>
        /// OnAfterHttpResponseEvent.
        /// </summary>
        public event OnAfterHttpResponseEventHandler OnAfterHttpResponseEvent;

        /// <summary>
        /// Executes the http request.
        /// </summary>
        /// <param name="request">Http request.</param>
        /// <returns>HttpStringResponse.</returns>
        public HttpStringResponse ExecuteAsString(HttpRequest request)
        {
            Task<HttpStringResponse> t = this.ExecuteAsStringAsync(request);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Executes the http request asynchronously.
        /// </summary>
        /// <param name="request">Http request.</param>
        /// <param name="cancellationToken"> cancellationToken.</param>
        /// <returns>Returns the HttpStringResponse.</returns>
        public async Task<HttpStringResponse> ExecuteAsStringAsync(
            HttpRequest request,
            CancellationToken cancellationToken = default)
        {
            // raise the on before request event.
            this.RaiseOnBeforeHttpRequestEvent(request);

            HttpResponseMessage responseMessage = await this.GetCombinedPolicy().ExecuteAsync(
                async (cancellation) => await this.HttpResponseMessage(request, cancellation).ConfigureAwait(false), cancellationToken)
                .ConfigureAwait(false);

            int statusCode = (int)responseMessage.StatusCode;
            var headers = GetCombinedResponseHeaders(responseMessage);
            Stream rawBody = await responseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false);
            string body = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

            var response = new HttpStringResponse(statusCode, headers, rawBody, body);

            // raise the on after response event.
            this.RaiseOnAfterHttpResponseEvent(response);

            return response;
        }

        /// <summary>
        /// Executes the http request.
        /// </summary>
        /// <param name="request">Http request.</param>
        /// <returns>HttpResponse.</returns>
        public HttpResponse ExecuteAsBinary(HttpRequest request)
        {
            Task<HttpResponse> t = this.ExecuteAsBinaryAsync(request);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Executes the http request asynchronously.
        /// </summary>
        /// <param name="request">Http request.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>HttpResponse.</returns>
        public async Task<HttpResponse> ExecuteAsBinaryAsync(
            HttpRequest request,
            CancellationToken cancellationToken = default)
        {
            // raise the on before request event.
            this.RaiseOnBeforeHttpRequestEvent(request);

            HttpResponseMessage responseMessage = await this.GetCombinedPolicy().ExecuteAsync(
                async (cancellation) => await this.HttpResponseMessage(request, cancellation).ConfigureAwait(false), cancellationToken)
                .ConfigureAwait(false);

            int statusCode = (int)responseMessage.StatusCode;
            var headers = GetCombinedResponseHeaders(responseMessage);
            Stream rawBody = await responseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false);

            HttpResponse response = new HttpResponse(statusCode, headers, rawBody);

            // raise the on after response event.
            this.RaiseOnAfterHttpResponseEvent(response);

            return response;
        }

        /// <summary>
        /// Get http request.
        /// </summary>
        /// <param name="queryUrl">queryUrl.</param>
        /// <param name="headers">headers.</param>
        /// <param name="queryParameters">queryParameters.</param>
        /// <param name="username">username.</param>
        /// <param name="password">password.</param>
        /// <returns>HttpRequest.</returns>
        public HttpRequest Get(
            string queryUrl,
            Dictionary<string, string> headers,
            Dictionary<string, object> queryParameters = null,
            string username = null,
            string password = null)
        {
            return new HttpRequest(HttpMethod.Get, queryUrl, headers, username, password, queryParameters: queryParameters);
        }

        /// <summary>
        /// Get http request.
        /// </summary>
        /// <param name="queryUrl">queryUrl.</param>
        /// <returns>HttpRequest.</returns>
        public HttpRequest Get(string queryUrl)
        {
            return new HttpRequest(HttpMethod.Get, queryUrl);
        }

        /// <summary>
        /// Post http request.
        /// </summary>
        /// <param name="queryUrl">queryUrl.</param>
        /// <returns>HttpRequest.</returns>
        public HttpRequest Post(string queryUrl)
        {
            return new HttpRequest(HttpMethod.Post, queryUrl);
        }

        /// <summary>
        /// Put http request.
        /// </summary>
        /// <param name="queryUrl">queryUrl.</param>
        /// <returns>HttpRequest.</returns>
        public HttpRequest Put(string queryUrl)
        {
            return new HttpRequest(HttpMethod.Put, queryUrl);
        }

        /// <summary>
        /// Delete http request.
        /// </summary>
        /// <param name="queryUrl">queryUrl.</param>
        /// <returns>HttpRequest.</returns>
        public HttpRequest Delete(string queryUrl)
        {
            return new HttpRequest(HttpMethod.Delete, queryUrl);
        }

        /// <summary>
        /// Patch http request.
        /// </summary>
        /// <param name="queryUrl">queryUrl.</param>
        /// <returns>HttpRequest.</returns>
        public HttpRequest Patch(string queryUrl)
        {
            return new HttpRequest(new HttpMethod("PATCH"), queryUrl);
        }

        /// <summary>
        /// Post http request.
        /// </summary>
        /// <param name="queryUrl">queryUrl.</param>
        /// <param name="headers">headers.</param>
        /// <param name="formParameters">formParameters.</param>
        /// <param name="queryParameters">queryParameters.</param>
        /// <param name="username">username.</param>
        /// <param name="password">password.</param>
        /// <returns>HttpRequest.</returns>
        public HttpRequest Post(
            string queryUrl,
            Dictionary<string, string> headers,
            List<KeyValuePair<string, object>> formParameters,
            Dictionary<string, object> queryParameters = null,
            string username = null,
            string password = null)
        {
            return new HttpRequest(HttpMethod.Post, queryUrl, headers, formParameters, username, password, queryParameters: queryParameters);
        }

        /// <summary>
        /// Post http request.
        /// </summary>
        /// <param name="queryUrl">queryUrl.</param>
        /// <param name="headers">headers.</param>
        /// <param name="body">body.</param>
        /// <param name="queryParameters">queryParameters.</param>
        /// <param name="username">username.</param>
        /// <param name="password">password.</param>
        /// <returns>HttpRequest.</returns>
        public HttpRequest PostBody(
            string queryUrl,
            Dictionary<string, string> headers,
            object body,
            Dictionary<string, object> queryParameters = null,
            string username = null,
            string password = null)
        {
            return new HttpRequest(HttpMethod.Post, queryUrl, headers, body, username, password, queryParameters: queryParameters);
        }

         /// <summary>
        /// Put http request.
        /// </summary>
        /// <param name="queryUrl">queryUrl.</param>
        /// <param name="headers">headers.</param>
        /// <param name="formParameters">formParameters.</param>
        /// <param name="queryParameters">queryParameters.</param>
        /// <param name="username">username.</param>
        /// <param name="password">password.</param>
        /// <returns>HttpRequest.</returns>
        public HttpRequest Put(
            string queryUrl,
            Dictionary<string, string> headers,
            List<KeyValuePair<string, object>> formParameters,
            Dictionary<string, object> queryParameters = null,
            string username = null,
            string password = null)
        {
            return new HttpRequest(HttpMethod.Put, queryUrl, headers, formParameters, username, password, queryParameters: queryParameters);
        }

         /// <summary>
        /// Put http request.
        /// </summary>
        /// <param name="queryUrl">queryUrl.</param>
        /// <param name="headers">headers.</param>
        /// <param name="body">body.</param>
        /// <param name="queryParameters">queryParameters.</param>
        /// <param name="username">username.</param>
        /// <param name="password">password.</param>
        /// <returns>HttpRequest.</returns>
        public HttpRequest PutBody(
            string queryUrl,
            Dictionary<string, string> headers,
            object body,
            Dictionary<string, object> queryParameters = null,
            string username = null,
            string password = null)
        {
            return new HttpRequest(HttpMethod.Put, queryUrl, headers, body, username, password, queryParameters: queryParameters);
        }

        /// <summary>
        /// Patch http request.
        /// </summary>
        /// <param name="queryUrl">queryUrl.</param>
        /// <param name="headers">headers.</param>
        /// <param name="formParameters">formParameters.</param>
        /// <param name="queryParameters">queryParameters.</param>
        /// <param name="username">username.</param>
        /// <param name="password">password.</param>
        /// <returns>HttpRequest.</returns>
        public HttpRequest Patch(
            string queryUrl,
            Dictionary<string, string> headers,
            List<KeyValuePair<string, object>> formParameters,
            Dictionary<string, object> queryParameters = null,
            string username = null,
            string password = null)
        {
            return new HttpRequest(new HttpMethod("PATCH"), queryUrl, headers, formParameters, username, password, queryParameters: queryParameters);
        }

        /// <summary>
        /// Patch http request.
        /// </summary>
        /// <param name="queryUrl">queryUrl.</param>
        /// <param name="headers">headers.</param>
        /// <param name="body">body.</param>
        /// <param name="queryParameters">queryParameters.</param>
        /// <param name="username">username.</param>
        /// <param name="password">password.</param>
        /// <returns>HttpRequest.</returns>
        public HttpRequest PatchBody(
            string queryUrl,
            Dictionary<string, string> headers,
            object body,
            Dictionary<string, object> queryParameters = null,
            string username = null,
            string password = null)
        {
            return new HttpRequest(new HttpMethod("PATCH"), queryUrl, headers, body, username, password, queryParameters: queryParameters);
        }

        /// <summary>
        /// Delete http request.
        /// </summary>
        /// <param name="queryUrl">queryUrl.</param>
        /// <param name="headers">headers.</param>
        /// <param name="formParameters">formParameters.</param>
        /// <param name="queryParameters">queryParameters.</param>
        /// <param name="username">username.</param>
        /// <param name="password">password.</param>
        /// <returns>HttpRequest.</returns>
        public HttpRequest Delete(
            string queryUrl,
            Dictionary<string, string> headers,
            List<KeyValuePair<string, object>> formParameters,
            Dictionary<string, object> queryParameters = null,
            string username = null,
            string password = null)
        {
            return new HttpRequest(HttpMethod.Delete, queryUrl, headers, formParameters, username, password, queryParameters: queryParameters);
        }

        /// <summary>
        /// Delete http request.
        /// </summary>
        /// <param name="queryUrl">queryUrl.</param>
        /// <param name="headers">headers.</param>
        /// <param name="body">body.</param>
        /// <param name="queryParameters">queryParameters.</param>
        /// <param name="username">username.</param>
        /// <param name="password">password.</param>
        /// <returns>HttpRequest.</returns>
        public HttpRequest DeleteBody(
            string queryUrl,
            Dictionary<string, string> headers,
            object body,
            Dictionary<string, object> queryParameters = null,
            string username = null,
            string password = null)
        {
            return new HttpRequest(HttpMethod.Delete, queryUrl, headers, body, username, password, queryParameters: queryParameters);
        }

        private static Dictionary<string, string> GetCombinedResponseHeaders(HttpResponseMessage responseMessage)
        {
            var headers = responseMessage.Headers.ToDictionary(l => l.Key, k => k.Value.First());
            if (responseMessage.Content != null)
            {
                foreach (var contentHeader in responseMessage.Content.Headers)
                {
                    if (headers.ContainsKey(contentHeader.Key))
                    {
                        continue;
                    }

                    headers.Add(contentHeader.Key, contentHeader.Value.First());
                }
            }

            return headers;
        }

        private void RaiseOnBeforeHttpRequestEvent(HttpRequest request)
        {
            if ((this.OnBeforeHttpRequestEvent != null) && (request != null))
            {
                this.OnBeforeHttpRequestEvent(this, request);
            }
        }

        private void RaiseOnAfterHttpResponseEvent(HttpResponse response)
        {
            if ((this.OnAfterHttpResponseEvent != null) && (response != null))
            {
                this.OnAfterHttpResponseEvent(this, response);
            }
        }

        private async Task<HttpResponseMessage> HttpResponseMessage(
            HttpRequest request,
            CancellationToken cancellationToken)
        {
            var queryBuilder = new StringBuilder(request.QueryUrl);

            if (request.QueryParameters != null)
            {
                ApiHelper.AppendUrlWithQueryParameters(queryBuilder, request.QueryParameters, this.arrayDeserializationFormat, parameterSeparator);
            }

            // validate and preprocess url.
            string queryUrl = ApiHelper.CleanUrl(queryBuilder);

            HttpRequestMessage requestMessage = new HttpRequestMessage
            {
                RequestUri = new Uri(queryUrl),
                Method = request.HttpMethod,
            };

            if (request.Headers != null)
            {
                foreach (var headers in request.Headers)
                {
                    requestMessage.Headers.TryAddWithoutValidation(headers.Key, headers.Value);
                }
            }

            if (!string.IsNullOrEmpty(request.Username))
            {
                var byteArray = Encoding.UTF8.GetBytes(request.Username + ":" + request.Password);
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue(
                    "Basic",
                    Convert.ToBase64String(byteArray));
            }

            if (request.HttpMethod.Equals(HttpMethod.Delete) || request.HttpMethod.Equals(HttpMethod.Post) || request.HttpMethod.Equals(HttpMethod.Put) || request.HttpMethod.Equals(new HttpMethod("PATCH")))
            {
                bool multipartRequest = request.FormParameters != null &&
                    (request.FormParameters.Any(f => f.Value is MultipartContent) || request.FormParameters.Any(f => f.Value is FileStreamInfo));

                if (request.Body != null)
                {
                    if (request.Body is FileStreamInfo file)
                    {
                        file.FileStream.Position = 0;
                        requestMessage.Content = new StreamContent(file.FileStream);
                        if (!string.IsNullOrWhiteSpace(file.ContentType))
                        {
                            requestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
                        }
                        else if (request.Headers.Any(h => h.Key.Equals("content-type", StringComparison.OrdinalIgnoreCase)))
                        {
                            requestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue(
                                request.Headers.First(h =>
                                    h.Key.Equals("content-type", StringComparison.OrdinalIgnoreCase)).Value);
                        }
                        else
                        {
                            requestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                        }
                    }
                    else if (request.Headers.ContainsKey("content-type") && string.Equals(
                        request.Headers["content-type"],
                        "application/json; charset=utf-8",
                        StringComparison.OrdinalIgnoreCase))
                    {
                        requestMessage.Content = new StringContent((string)request.Body ?? string.Empty, Encoding.UTF8, "application/json");
                    }
                    else if (request.Headers.ContainsKey("content-type"))
                    {
                        byte[] bytes = null;

                        if (request.Body is Stream)
                        {
                            Stream s = (Stream)request.Body;
                            s.Position = 0;
                            using (BinaryReader br = new BinaryReader(s))
                            {
                                bytes = br.ReadBytes((int)s.Length);
                            }
                        }
                        else if (request.Body is byte[])
                        {
                            bytes = (byte[])request.Body;
                        }
                        else
                        {
                            bytes = Encoding.UTF8.GetBytes((string)request.Body);
                        }

                        requestMessage.Content = new ByteArrayContent(bytes ?? Array.Empty<byte>());

                        try
                        {
                            requestMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse(request.Headers["content-type"]);
                        }
                        catch (Exception)
                        {
                            requestMessage.Content.Headers.TryAddWithoutValidation("content-type", request.Headers["content-type"]);
                        }
                    }
                    else
                    {
                        requestMessage.Content = new StringContent(request.Body.ToString() ?? string.Empty, Encoding.UTF8, "text/plain");
                    }
                }
                else if (multipartRequest)
                {
                    MultipartFormDataContent formContent = new MultipartFormDataContent();

                    foreach (var param in request.FormParameters)
                    {
                        if (param.Value is FileStreamInfo fileParam)
                        {
                            var fileContent = new MultipartFileContent(fileParam);
                            fileContent.Rewind();
                            formContent.Add(fileContent.ToHttpContent(param.Key));
                        }
                        else if (param.Value is MultipartContent wrapperObject)
                        {
                            wrapperObject.Rewind();
                            formContent.Add(wrapperObject.ToHttpContent(param.Key));
                        }
                        else
                        {
                            formContent.Add(new StringContent(param.Value.ToString()), param.Key);
                        }
                    }

                    requestMessage.Content = formContent;
                }
                else if (request.FormParameters != null)
                {
                    var parameters = new List<KeyValuePair<string, string>>();
                    foreach (var param in request.FormParameters)
                    {
                        parameters.Add(new KeyValuePair<string, string>(param.Key, param.Value.ToString()));
                    }

                    requestMessage.Content = new FormUrlEncodedContent(parameters);
                }
            }

            return await this.client.SendAsync(requestMessage, cancellationToken).ConfigureAwait(false);
        }

        private HttpClient GetDefaultHttpClient()
        {
            if (defaultHttpClient == null)
            {
                lock (SyncObject)
                {
                    if (defaultHttpClient == null)
                    {
                        defaultHttpClient = new HttpClient();
                    }
                }
            }

            return defaultHttpClient;
        }

        private bool ShouldRetry(HttpResponseMessage r)
        {
            return this.requestMethodsToRetry.Contains(r.RequestMessage.Method) &&
                (this.statusCodesToRetry.Contains(r.StatusCode) ||
                r?.Headers?.RetryAfter != null);
        }

        private TimeSpan GetServerWaitDuration(DelegateResult<HttpResponseMessage> response)
        {
            var retryAfter = response?.Result?.Headers?.RetryAfter;
            if (retryAfter == null)
            {
                return TimeSpan.Zero;
            }

            return retryAfter.Date.HasValue
                ? retryAfter.Date.Value - DateTime.UtcNow
                : retryAfter.Delta.GetValueOrDefault(TimeSpan.Zero);
        }

        private AsyncRetryPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return Policy.HandleResult<HttpResponseMessage>(r => this.ShouldRetry(r))
                .Or<TaskCanceledException>()
                .Or<HttpRequestException>()
                .WaitAndRetryAsync(
                retryCount: this.numberOfRetries,
                sleepDurationProvider: (retryAttempt, result, context) =>
                TimeSpan.FromMilliseconds(Math.Max(this.GetExponentialWaitTime(retryAttempt), this.GetServerWaitDuration(result).TotalMilliseconds)),
                onRetryAsync: async (result, timespan, retryAttempt, context) => await Task.CompletedTask);
        }

        private AsyncTimeoutPolicy GetTimeoutPolicy()
        {
            return this.backoffMax.TotalSeconds == 0
                ? Policy.TimeoutAsync(Timeout.InfiniteTimeSpan)
                : Policy.TimeoutAsync(this.backoffMax);
        }

        private AsyncPolicyWrap<HttpResponseMessage> GetCombinedPolicy()
        {
            return this.GetTimeoutPolicy().WrapAsync(this.GetRetryPolicy());
        }

        private double GetExponentialWaitTime(int retryAttempt)
        {
            double noise = new Random().NextDouble() * 100;
            return (1000 * this.retryInterval * Math.Pow(this.backoffFactor, retryAttempt - 1)) + noise;

        }
    }
}
