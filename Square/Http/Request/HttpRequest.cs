using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Square.Utilities;

namespace Square.Http.Request
{
    /// <summary>
    /// HttpRequest stores necessary information about the http request.
    /// </summary>
    public sealed class HttpRequest
    {
        /// <summary>
        /// The HTTP verb to use for this request.
        /// </summary>
        public HttpMethod HttpMethod { get; }

        /// <summary>
        /// The query url for the http request.
        /// </summary>
        public string QueryUrl { get; }

        /// <summary>
        /// Query parameters collection for the current http request.
        /// </summary>
        public Dictionary<string, object> QueryParameters { get; private set; }

        /// <summary>
        /// Headers collection for the current http request.
        /// </summary>
        public Dictionary<string, string> Headers { get; private set; }

        /// <summary>
        /// Form parameters for the current http request.
        /// </summary>
        public List<KeyValuePair<string, object>> FormParameters { get; }

        /// <summary>
        /// Optional raw string to send as request body.
        /// </summary>
        public object Body { get; }

        /// <summary>
        /// Optional username for Basic Auth.
        /// </summary>
        public string Username { get; }

        /// <summary>
        /// Optional password for Basic Auth.
        /// </summary>
        public string Password { get; }

        /// <summary>
        /// Constructor to initialize the http request object.
        /// </summary>
        /// <param name="method">Http verb to use for the http request</param>
        /// <param name="queryUrl">The query url for the http request</param>
        public HttpRequest(HttpMethod method, string queryUrl)
        {
            this.HttpMethod = method;
            this.QueryUrl = queryUrl;
        }

        /// <summary>
        /// Constructor to initialize the http request with headers and optional Basic auth params.
        /// </summary>
        /// <param name="method">Http verb to use for the http request</param>
        /// <param name="queryUrl">The query url for the http request</param>
        /// <param name="headers">Headers to send with the request</param>
        /// <param name="username">Basic auth username</param>
        /// <param name="password">Basic auth password</param>
        public HttpRequest(HttpMethod method, string queryUrl, Dictionary<string, string> headers, string username, string password, Dictionary<string, object> queryParameters = null)
            : this(method, queryUrl)
        {
            this.QueryParameters = queryParameters;
            this.Headers = headers;
            this.Username = username;
            this.Password = password;
        }

        /// <summary>
        /// Constructor to initialize the http request with headers, body and optional Basic auth params.
        /// </summary>
        /// <param name="method">Http verb to use for the http request</param>
        /// <param name="queryUrl">The query url for the http request</param>
        /// <param name="headers">Headers to send with the request</param>
        /// <param name="body">The string to use as raw body of the http request</param>
        /// <param name="username">Basic auth username</param>
        /// <param name="password">Basic auth password</param>
        public HttpRequest(HttpMethod method, string queryUrl, Dictionary<string, string> headers, object body, string username, string password, Dictionary<string, object> queryParameters = null)
            : this(method, queryUrl, headers, username, password, queryParameters: queryParameters)
        {
            this.Body = body;
        }

        /// <summary>
        /// Constructor to initialize the http request with headers, form parameters and optional Basic auth params.
        /// </summary>
        /// <param name="method">Http verb to use for the http request</param>
        /// <param name="queryUrl">The query url for the http request</param>
        /// <param name="headers">Headers to send with the request</param>
        /// <param name="formParameters">Form parameters collection for the request</param>
        /// <param name="username">Basic auth username</param>
        /// <param name="password">Basic auth password</param>
        public HttpRequest(HttpMethod method, string queryUrl, Dictionary<string, string> headers, List<KeyValuePair<string, Object>> formParameters, string username, string password, Dictionary<string, object> queryParameters = null)
            : this(method, queryUrl, headers, username, password, queryParameters: queryParameters)
        {
            this.FormParameters = formParameters;
        }

        /// <summary>
        /// Concatenate values from a Dictionary to this object.
        /// </summary>
        public Dictionary<string, string> AddHeaders(Dictionary<string, string> HeadersToAdd)
        {
            if (Headers == null)
            {
                Headers = new Dictionary<string, string>(HeadersToAdd);
            }
            else
            {
                Headers = Headers.Concat(HeadersToAdd).ToDictionary(x => x.Key, x => x.Value);
            }
            return Headers;
        }

        /// <summary>
        /// Concatenate values from a Dictionary to query parameters dictionary.
        /// </summary>
        public void AddQueryParameters(Dictionary<string, object> queryParamaters)
        {
            if (QueryParameters == null)
            {
                QueryParameters = new Dictionary<string, object>(queryParamaters);
            }
            else
            {
                QueryParameters = QueryParameters.Concat(queryParamaters).ToDictionary(x => x.Key, x => x.Value);
            }
        }

        public override string ToString()
        {
            return $" HttpMethod = {HttpMethod}, " +
                $" QueryUrl = {QueryUrl}, " +
                $" QueryParameters = {ApiHelper.JsonSerialize(QueryParameters)}, " +
                $" Headers = {ApiHelper.JsonSerialize(Headers)}, " +
                $" FormParameters = {ApiHelper.JsonSerialize(FormParameters)}, " +
                $" Body = {Body}, " +
                $" Username = {Username}, " +
                $" Password = {Password}";
        }
    }
}
