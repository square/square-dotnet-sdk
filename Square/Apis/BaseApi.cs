using System;
using System.Text;
using System.Collections.Generic;
using Square;
using Square.Utilities;
using Square.Http.Client;
using Square.Http.Response;
using Square.Authentication;
using Square.Exceptions;

namespace Square.Apis
{
    internal class BaseApi
    {
        protected ArrayDeserialization ArrayDeserializationFormat = ArrayDeserialization.Indexed;
        protected static char ParameterSeparator = '&';

        /// <summary>
        /// Configuration instance
        /// </summary>
        protected IConfiguration config;

        /// <summary>
        /// User-Agent header value
        /// </summary>
        internal string userAgent = "Square-DotNet-SDK/6.3.0";
        
        /// <summary>
        /// HttpClient instance
        /// </summary>
        internal IHttpClient httpClient;

        /// <summary>
        /// AuthManager instance
        /// </summary>
        internal IDictionary<string, IAuthManager> authManagers;
        /// <summary>
        /// HttpCallBack instance
        /// </summary>
        internal HttpCallBack HttpCallBack { get; }
        /// <summary>
        /// Contructor to initialize the controller with the specified configuration and HTTP callback
        /// </summary>
        /// <param name="config">Configuration for the API</param>
        /// <param name="httpCallBack">HTTP callback to catch before/after HTTP request/response events</param>

        internal BaseApi(IConfiguration config, IHttpClient httpClient,
            IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
        {
            this.config = config;
            this.httpClient = httpClient;
            this.authManagers = authManagers;
            this.HttpCallBack = httpCallBack;
        }

        /// <summary>
        /// Create JSON-encoded multipart content from input.
        /// </summary>
        internal static MultipartContent CreateJsonEncodedMultipartContent(object input, Dictionary<string, IReadOnlyCollection<string>> headers)
        {
            return new MultipartByteArrayContent(Encoding.ASCII.GetBytes(ApiHelper.JsonSerialize(input)), headers);
        }

        /// <summary>
        /// Create binary multipart content from file.
        /// </summary>
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
        /// Get default HTTP client instance
        /// </summary>
        internal IHttpClient GetClientInstance()
        {
            return httpClient;
        }

        /// <summary>
        /// Validates the response against HTTP errors defined at the API level
        /// </summary>
        /// <param name="_response">The response recieved</param>
        /// <param name="_context">Context of the request and the recieved response</param>
        protected void ValidateResponse(HttpResponse _response, HttpContext _context)
        {
            if ((_response.StatusCode < 200) || (_response.StatusCode > 208)) //[200, 208] = HTTP OK
            {
                throw new ApiException(@"HTTP Response Not OK", _context);
            }
        }
    }
}