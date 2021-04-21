namespace Square.Http.Response
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Square.Utilities;

    /// <summary>
    /// HttpResponse stores necessary information about the http response.
    /// </summary>
    public class HttpResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpResponse"/> class.
        /// </summary>
        /// <param name="statusCode">statusCode.</param>
        /// <param name="headers">headers.</param>
        /// <param name="rawBody">rawBody.</param>
        public HttpResponse(int statusCode, Dictionary<string, string> headers, Stream rawBody)
        {
            this.StatusCode = statusCode;
            this.Headers = headers;
            this.RawBody = rawBody;
        }

        /// <summary>
        /// Gets the HTTP Status code of the http response.
        /// </summary>
        public int StatusCode { get; }

        /// <summary>
        /// Gets the headers of the http response.
        /// </summary>
        public Dictionary<string, string> Headers { get; }

        /// <summary>
        /// Gets the stream of the body.
        /// </summary>
        public Stream RawBody { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $" StatusCode = {this.StatusCode}, " +
                $" Headers = {ApiHelper.JsonSerialize(this.Headers)}, " +
                $" RawBody = {this.RawBody}";
        }
    }
}
