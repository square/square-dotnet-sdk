namespace Square.Apis
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Square;
    using Square.Authentication;
    using Square.Exceptions;
    using Square.Http.Client;
    using Square.Http.Response;
    using Square.Utilities;

    /// <summary>
    /// The base class for all controller classes.
    /// </summary>
    internal class BaseApi
    {
        /// <summary>
        /// HttpClient instance.
        /// </summary>
        private readonly IHttpClient httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseApi"/> class.
        /// </summary>
        /// <param name="config">Configuration for the API.</param>
        /// <param name="httpCallBack">HTTP callback to catch before/after HTTP request/response events.</param>
        /// <param name="httpClient">HttpClient for the API.</param>
        /// <param name="authManagers">AuthManagers for the API.</param>
        internal BaseApi(
            IConfiguration config,
            IHttpClient httpClient,
            IDictionary<string, IAuthManager> authManagers,
            HttpCallBack httpCallBack = null)
        {
            this.Config = config;
            this.httpClient = httpClient;
            this.AuthManagers = authManagers;
            this.HttpCallBack = httpCallBack;
        }

        /// <summary>
        /// Gets AuthManager instance.
        /// </summary>
        internal IDictionary<string, IAuthManager> AuthManagers { get; }

        /// <summary>
        /// Gets HttpCallBack instance.
        /// </summary>
        internal HttpCallBack HttpCallBack { get; }

        /// <summary>
        /// Gets array deserialization format.
        /// </summary>
        protected ArrayDeserialization ArrayDeserializationFormat => ArrayDeserialization.Indexed;

        /// <summary>
        /// Gets configuration instance.
        /// </summary>
        protected IConfiguration Config { get; }

        /// <summary>
        ///  Gets User-Agent header value.
        /// </summary>
        protected string UserAgent => "Square-DotNet-SDK/13.1.0";

        /// <summary>
        /// Create JSON-encoded multipart content from input.
        /// </summary>
        /// <param name="input"> input object. </param>
        /// <param name="headers"> Headers dictionary. </param>
        /// <returns> MultipartContent. </returns>
        internal static MultipartContent CreateJsonEncodedMultipartContent(object input, Dictionary<string, IReadOnlyCollection<string>> headers)
        {
            return new MultipartByteArrayContent(Encoding.ASCII.GetBytes(ApiHelper.JsonSerialize(input)), headers);
        }

        /// <summary>
        /// Create binary multipart content from file.
        /// </summary>
        /// <param name="input"> FileStreamInfo object. </param>
        /// <param name="headers"> Headers dictionary. </param>
        /// <returns> MultipartContent. </returns>
        internal static MultipartContent CreateFileMultipartContent(FileStreamInfo input, Dictionary<string, IReadOnlyCollection<string>> headers = null)
        {
            if (headers == null)
            {
                return new MultipartFileContent(input);
            }
            else
            {
                return new MultipartFileContent(input, headers);
            }
        }

        /// <summary>
        /// Get default HTTP client instance.
        /// </summary>
        /// <returns> IHttpClient. </returns>
        internal IHttpClient GetClientInstance()
        {
            return this.httpClient;
        }

        /// <summary>
        /// Validates the response against HTTP errors defined at the API level.
        /// </summary>
        /// <param name="response">The response recieved.</param>
        /// <param name="context">Context of the request and the recieved response.</param>
        protected void ValidateResponse(HttpResponse response, HttpContext context)
        {
            // [200, 208] = HTTP OK
            if ((response.StatusCode < 200) || (response.StatusCode > 208))
            {
                throw new ApiException(@"HTTP Response Not OK", context);
            }
        }
    }
}