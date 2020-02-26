using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Square.Http.Request;
using Square.Http.Response;
using Square.Utilities;

namespace Square.Http.Client
{
    internal sealed class HttpClientWrapper : IHttpClient
    {
        private readonly static object syncObject = new Object();
        private static HttpClient defaultHttpClient;
        private HttpClient client;
        public HttpClientWrapper()
        {
            this.client = GetDefaultHttpClient();
        }

        public HttpClientWrapper(HttpClientConfiguration httpClientConfig)
        {
            this.client = new HttpClient()
            {
                Timeout = httpClientConfig.Timeout
            };
        }

        private HttpClient GetDefaultHttpClient()
        {
            if (defaultHttpClient == null)
            {
                lock(syncObject)
                {
                    if (defaultHttpClient == null)
                    {
                        defaultHttpClient = new HttpClient()
                        {
                            Timeout = TimeSpan.FromSeconds(60)
                        };
                    }
                }
            }
            return defaultHttpClient;
        }

        #region Execute methods

        public HttpStringResponse ExecuteAsString(HttpRequest request)
        {
            Task<HttpStringResponse> t = ExecuteAsStringAsync(request);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        public async Task<HttpStringResponse> ExecuteAsStringAsync(HttpRequest request,
            CancellationToken cancellationToken = default)
        {
            //raise the on before request event
            RaiseOnBeforeHttpRequestEvent(request);

            HttpResponseMessage responseMessage = await HttpResponseMessage(request, cancellationToken)
                .ConfigureAwait(false);

            int StatusCode = (int)responseMessage.StatusCode;
            var Headers = GetCombinedResponseHeaders(responseMessage);
            Stream RawBody = await responseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false);
            string Body = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

            var response = new HttpStringResponse(StatusCode, Headers, RawBody, Body);

            //raise the on after response event
            RaiseOnAfterHttpResponseEvent(response);
            return response;
        }

        public HttpResponse ExecuteAsBinary(HttpRequest request)
        {
            Task<HttpResponse> t = ExecuteAsBinaryAsync(request);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        public async Task<HttpResponse> ExecuteAsBinaryAsync(HttpRequest request,
            CancellationToken cancellationToken = default)
        {
            //raise the on before request event
            RaiseOnBeforeHttpRequestEvent(request);

            HttpResponseMessage responseMessage = await HttpResponseMessage(request, cancellationToken)
                .ConfigureAwait(false);

            int StatusCode = (int)responseMessage.StatusCode;
            var Headers = GetCombinedResponseHeaders(responseMessage);
            Stream RawBody = await responseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false);

            HttpResponse response = new HttpResponse(StatusCode, Headers, RawBody);

            //raise the on after response event
            RaiseOnAfterHttpResponseEvent(response);
            return response;
        }

        #endregion


        #region Http request and response events

        public event OnBeforeHttpRequestEventHandler OnBeforeHttpRequestEvent;
        public event OnAfterHttpResponseEventHandler OnAfterHttpResponseEvent;

        private void RaiseOnBeforeHttpRequestEvent(HttpRequest request)
        {
            if ((null != OnBeforeHttpRequestEvent) && (null != request))
            {
                OnBeforeHttpRequestEvent(this, request);
            }
        }

        private void RaiseOnAfterHttpResponseEvent(HttpResponse response)
        {
            if ((null != OnAfterHttpResponseEvent) && (null != response))
            {
                OnAfterHttpResponseEvent(this, response);
            }
        }

        #endregion


        #region Http methods

        public HttpRequest Get(string queryUrl, Dictionary<string, string> headers, string username = null, string password = null)
        {
            return new HttpRequest(HttpMethod.Get, queryUrl, headers, username, password);
        }

        public HttpRequest Get(string queryUrl)
        {
            return new HttpRequest(HttpMethod.Get, queryUrl);
        }

        public HttpRequest Post(string queryUrl)
        {
            return new HttpRequest(HttpMethod.Post, queryUrl);
        }

        public HttpRequest Put(string queryUrl)
        {
            return new HttpRequest(HttpMethod.Put, queryUrl);
        }

        public HttpRequest Delete(string queryUrl)
        {
            return new HttpRequest(HttpMethod.Delete, queryUrl);
        }

        public HttpRequest Patch(string queryUrl)
        {
            return new HttpRequest(new HttpMethod("PATCH"), queryUrl);
        }

        public HttpRequest Post(string queryUrl, Dictionary<string, string> headers, List<KeyValuePair<string, object>> formParameters, string username = null,
            string password = null)
        {
            return new HttpRequest(HttpMethod.Post, queryUrl, headers, formParameters, username, password);
        }

        public HttpRequest PostBody(string queryUrl, Dictionary<string, string> headers, object body, string username = null, string password = null)
        {
            return new HttpRequest(HttpMethod.Post, queryUrl, headers, body, username, password);
        }

        public HttpRequest Put(string queryUrl, Dictionary<string, string> headers, List<KeyValuePair<string, object>> formParameters, string username = null,
            string password = null)
        {
            return new HttpRequest(HttpMethod.Put, queryUrl, headers, formParameters, username, password);
        }

        public HttpRequest PutBody(string queryUrl, Dictionary<string, string> headers, object body, string username = null, string password = null)
        {
            return new HttpRequest(HttpMethod.Put, queryUrl, headers, body, username, password);
        }

        public HttpRequest Patch(string queryUrl, Dictionary<string, string> headers, List<KeyValuePair<string, object>> formParameters, string username = null,
            string password = null)
        {
            return new HttpRequest(new HttpMethod("PATCH"), queryUrl, headers, formParameters, username, password);
        }

        public HttpRequest PatchBody(string queryUrl, Dictionary<string, string> headers, object body, string username = null, string password = null)
        {
            return new HttpRequest(new HttpMethod("PATCH"), queryUrl, headers, body, username, password);
        }

        public HttpRequest Delete(string queryUrl, Dictionary<string, string> headers, List<KeyValuePair<string, object>> formParameters, string username = null,
            string password = null)
        {
            return new HttpRequest(HttpMethod.Delete, queryUrl, headers, formParameters, username, password);
        }

        public HttpRequest DeleteBody(string queryUrl, Dictionary<string, string> headers, object body, string username = null, string password = null)
        {
            return new HttpRequest(HttpMethod.Delete, queryUrl, headers, body, username, password);
        }

        #endregion

        #region Helper methods

        private async Task<HttpResponseMessage> HttpResponseMessage(HttpRequest request, CancellationToken cancellationToken)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage
            {
                RequestUri = new Uri(request.QueryUrl),
                Method = request.HttpMethod,
            };

            if (request.Headers != null) {
                foreach (var headers in request.Headers)
                {
                    requestMessage.Headers.TryAddWithoutValidation(headers.Key, headers.Value);
                }
            }

            if (!string.IsNullOrEmpty(request.Username))
            {
                var byteArray = Encoding.UTF8.GetBytes(request.Username + ":" + request.Password);
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Basic",
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
                        requestMessage.Content = new StreamContent(file.FileStream);
                        if (!string.IsNullOrWhiteSpace(file.ContentType))
                        {
                            requestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
                        }
                        else if (request.Headers.Any(h => h.Key.Equals("content-type", StringComparison.OrdinalIgnoreCase)))
                        {
                            requestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue(request.Headers["content-type"]);
                        }
                        else
                        {
                            requestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                        }
                    }
                    else if (request.Headers.ContainsKey("content-type") && string.Equals(request.Headers["content-type"],
                        "application/json; charset=utf-8", StringComparison.OrdinalIgnoreCase))
                    {
                        requestMessage.Content = new StringContent((string)request.Body ?? string.Empty, Encoding.UTF8,
                            "application/json");
                    }
                    else if (request.Headers.ContainsKey("content-type"))
                    {
                        byte[] bytes = null;

                        if (request.Body is Stream)
                        {
                            Stream s = (Stream)request.Body;
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
                        } catch(Exception)
                        {
                            requestMessage.Content.Headers.TryAddWithoutValidation("content-type", request.Headers["content-type"]);
                        }
                    }
                    else
                    {
                        requestMessage.Content = new StringContent(request.Body.ToString() ?? string.Empty, Encoding.UTF8,
                            "text/plain");
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
                            formContent.Add(fileContent.ToHttpContent(param.Key));
                        }
                        else if (param.Value is MultipartContent wrapperObject)
                        {
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
            return await client.SendAsync(requestMessage, cancellationToken).ConfigureAwait(false);
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

        #endregion
    }
}
