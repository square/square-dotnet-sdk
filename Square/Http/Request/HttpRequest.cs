using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Square.Http.Request
{
    public sealed class HttpRequest
    {
        /// <summary>
        /// The HTTP verb to use for this request
        /// </summary>
        public HttpMethod HttpMethod { get; }

        /// <summary>
        /// The query url for the http request
        /// </summary>
        public string QueryUrl { get; }

        /// <summary>
        /// Headers collection for the current http request
        /// </summary>
        public Dictionary<string, string> Headers { get; private set; }

        /// <summary>
        /// Form parameters for the current http request
        /// </summary>
        public List<KeyValuePair<string, object>> FormParameters { get; }

        /// <summary>
        /// Optional raw string to send as request body
        /// </summary>
        public object Body { get; }

        /// <summary>
        /// Optional username for Basic Auth
        /// </summary>
        public string Username { get; }

        /// <summary>
        /// Optional password for Basic Auth
        /// </summary>
        public string Password { get; }

        /// <summary>
        /// Constructor to initialize the http request obejct
        /// </summary>
        /// <param name="method">Http verb to use for the http request</param>
        /// <param name="queryUrl">The query url for the http request</param>
        public HttpRequest(HttpMethod method, string queryUrl)
        {
            this.HttpMethod = method;
            this.QueryUrl = queryUrl;
        }

        /// <summary>
        /// Constructor to initialize the http request with headers and optional Basic auth params
        /// </summary>
        /// <param name="method">Http verb to use for the http request</param>
        /// <param name="queryUrl">The query url for the http request</param>
        /// <param name="headers">Headers to send with the request</param>
        /// <param name="username">Basic auth username</param>
        /// <param name="password">Basic auth password</param>
        public HttpRequest(HttpMethod method, string queryUrl, Dictionary<string, string> headers, string username, string password)
            : this(method, queryUrl)
        {
            this.Headers = headers;
            this.Username = username;
            this.Password = password;
        }

        /// <summary>
        /// Constructor to initialize the http request with headers, body and optional Basic auth params
        /// </summary>
        /// <param name="method">Http verb to use for the http request</param>
        /// <param name="queryUrl">The query url for the http request</param>
        /// <param name="headers">Headers to send with the request</param>
        /// <param name="body">The string to use as raw body of the http request</param>
        /// <param name="username">Basic auth username</param>
        /// <param name="password">Basic auth password</param>
        public HttpRequest(HttpMethod method, string queryUrl, Dictionary<string, string> headers, object body, string username, string password)
            : this(method, queryUrl, headers, username, password)
        {
            this.Body = body;
        }

        /// <summary>
        /// Constructor to initialize the http request with headers, form parameters and optional Basic auth params
        /// </summary>
        /// <param name="method">Http verb to use for the http request</param>
        /// <param name="queryUrl">The query url for the http request</param>
        /// <param name="headers">Headers to send with the request</param>
        /// <param name="formParameters">Form parameters collection for the request</param>
        /// <param name="username">Basic auth username</param>
        /// <param name="password">Basic auth password</param>
        public HttpRequest(HttpMethod method, string queryUrl, Dictionary<string, string> headers, List<KeyValuePair<string, Object>> formParameters, string username, string password)
            : this(method, queryUrl, headers, username, password)
        {
            this.FormParameters = formParameters;
        }

        /// <summary>
        /// Concatenate values from a Dictionary to this object
        /// </summary>
        public Dictionary<string, string> AddHeaders(Dictionary<string, string> HeadersToAdd)
        {
            Headers = Headers.Concat(HeadersToAdd).ToDictionary(x => x.Key, x => x.Value);
            return Headers;
        }
    }
}
