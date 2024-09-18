using System.Net.Http;
using System.Collections.Generic;
using APIMatic.Core.Types.Sdk;

namespace Square.Http.Request
{
    /// <summary>
    /// HttpRequest stores necessary information about the http request.
    /// </summary>
    public sealed class HttpRequest : CoreRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpRequest"/> class.
        /// </summary>
        /// <param name="method">Http verb to use for the http request.</param>
        /// <param name="queryUrl">The query url for the http request.</param>
        public HttpRequest(HttpMethod method, string queryUrl)
            : base(method, queryUrl, null, null, null, null, null) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpRequest"/> class.
        /// </summary>
        /// <param name="method">Http verb to use for the http request.</param>
        /// <param name="queryUrl">The query url for the http request.</param>
        /// <param name="headers">Headers to send with the request.</param>
        /// <param name="username">Basic auth username.</param>
        /// <param name="password">Basic auth password.</param>
        /// <param name="queryParameters">QueryParameters.</param>
        public HttpRequest(
            HttpMethod method,
            string queryUrl,
            Dictionary<string, string> headers,
            string username,
            string password,
            Dictionary<string, object> queryParameters = null)
            : base(method, queryUrl, headers, null, null, queryParameters, username, password) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpRequest"/> class.
        /// </summary>
        /// <param name="method">Http verb to use for the http request.</param>
        /// <param name="queryUrl">The query url for the http request.</param>
        /// <param name="headers">Headers to send with the request.</param>
        /// <param name="body">The string to use as raw body of the http request.</param>
        /// <param name="username">Basic auth username.</param>
        /// <param name="password">Basic auth password.</param>
        /// <param name="queryParameters">QueryParameters.</param>
        public HttpRequest(
            HttpMethod method,
            string queryUrl,
            Dictionary<string, string> headers,
            object body,
            string username,
            string password,
            Dictionary<string, object> queryParameters = null)
            : base(method, queryUrl, headers, body, null, queryParameters, username, password) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpRequest"/> class.
        /// </summary>
        /// <param name="method">Http verb to use for the http request.</param>
        /// <param name="queryUrl">The query url for the http request.</param>
        /// <param name="headers">Headers to send with the request.</param>
        /// <param name="formParameters">Form parameters collection for the request.</param>
        /// <param name="username">Basic auth username.</param>
        /// <param name="password">Basic auth password.</param>
        /// <param name="queryParameters">QueryParameters.</param>
        public HttpRequest(
            HttpMethod method,
            string queryUrl,
            Dictionary<string, string> headers,
            List<KeyValuePair<string, object>> formParameters,
            string username,
            string password,
            Dictionary<string, object> queryParameters = null)
            : base(method, queryUrl, headers, null, formParameters, queryParameters, username, password) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpRequest"/> class.
        /// </summary>
        /// <param name="method">Http verb to use for the http request.</param>
        /// <param name="queryUrl">The query url for the http request.</param>
        /// <param name="headers">Headers to send with the request.</param>
        /// <param name="body">The string to use as raw body of the http request.</param>
        /// <param name="formParameters">Form parameters collection for the request.</param>
        /// <param name="username">Basic auth username.</param>
        /// <param name="password">Basic auth password.</param>
        /// <param name="queryParameters">QueryParameters.</param>
        public HttpRequest(
            HttpMethod method,
            string queryUrl,
            Dictionary<string, string> headers,
            object body,
            List<KeyValuePair<string, object>> formParameters,
            string username,
            string password,
            Dictionary<string, object> queryParameters = null)
            : base(method, queryUrl, headers, body, formParameters, queryParameters, username, password) { }
    }
}
