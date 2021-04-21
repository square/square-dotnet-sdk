namespace Square.Http.Request
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using Square.Utilities;

    /// <summary>
    /// HttpRequest stores necessary information about the http request.
    /// </summary>
    public sealed class HttpRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpRequest"/> class.
        /// </summary>
        /// <param name="method">Http verb to use for the http request.</param>
        /// <param name="queryUrl">The query url for the http request.</param>
        public HttpRequest(HttpMethod method, string queryUrl)
        {
            this.HttpMethod = method;
            this.QueryUrl = queryUrl;
        }

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
            : this(method, queryUrl)
        {
            this.QueryParameters = queryParameters;
            this.Headers = headers;
            this.Username = username;
            this.Password = password;
        }

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
            : this(method, queryUrl, headers, username, password, queryParameters: queryParameters)
        {
            this.Body = body;
        }

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
            Dictionary<string,
            object> queryParameters = null)
            : this(method, queryUrl, headers, username, password, queryParameters: queryParameters)
        {
            this.FormParameters = formParameters;
        }

        /// <summary>
        /// Gets the HTTP verb to use for this request.
        /// </summary>
        public HttpMethod HttpMethod { get; }

        /// <summary>
        /// Gets the query url for the http request.
        /// </summary>
        public string QueryUrl { get; }

        /// <summary>
        /// Gets the query parameters collection for the current http request.
        /// </summary>
        public Dictionary<string, object> QueryParameters { get; private set; }

        /// <summary>
        /// Gets the headers collection for the current http request.
        /// </summary>
        public Dictionary<string, string> Headers { get; private set; }

        /// <summary>
        /// Gets the form parameters for the current http request.
        /// </summary>
        public List<KeyValuePair<string, object>> FormParameters { get; }

        /// <summary>
        /// Gets the optional raw string to send as request body.
        /// </summary>
        public object Body { get; }

        /// <summary>
        /// Gets the optional username for Basic Auth.
        /// </summary>
        public string Username { get; }

        /// <summary>
        /// Gets the optional password for Basic Auth.
        /// </summary>
        public string Password { get; }

        /// <summary>
        /// Concatenate values from a Dictionary to this object.
        /// </summary>
        /// <param name="headersToAdd"> headersToAdd. </param>
        /// <returns>Dictionary.</returns>
        public Dictionary<string, string> AddHeaders(Dictionary<string, string> headersToAdd)
        {
            if (this.Headers == null)
            {
                this.Headers = new Dictionary<string, string>(headersToAdd);
            }
            else
            {
                this.Headers = this.Headers.Concat(headersToAdd).ToDictionary(x => x.Key, x => x.Value);
            }

            return this.Headers;
        }

        /// <summary>
        /// Concatenate values from a Dictionary to query parameters dictionary.
        /// </summary>
        /// <param name="queryParamaters"> queryParamaters. </param>
        public void AddQueryParameters(Dictionary<string, object> queryParamaters)
        {
            if (this.QueryParameters == null)
            {
                this.QueryParameters = new Dictionary<string, object>(queryParamaters);
            }
            else
            {
                this.QueryParameters = this.QueryParameters.Concat(queryParamaters).ToDictionary(x => x.Key, x => x.Value);
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $" HttpMethod = {this.HttpMethod}, " +
                $" QueryUrl = {this.QueryUrl}, " +
                $" QueryParameters = {ApiHelper.JsonSerialize(this.QueryParameters)}, " +
                $" Headers = {ApiHelper.JsonSerialize(this.Headers)}, " +
                $" FormParameters = {ApiHelper.JsonSerialize(this.FormParameters)}, " +
                $" Body = {this.Body}, " +
                $" Username = {this.Username}, " +
                $" Password = {this.Password}";
        }
    }
}
