using System.Collections.Generic;
using System.IO;

namespace Square.Legacy.Http.Response
{
    /// <summary>
    /// HttpStringResponse inherits from HttpResponse and has additional property
    /// of string body.
    /// </summary>
    public sealed class HttpStringResponse : HttpResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpStringResponse"/> class.
        /// </summary>
        /// <param name="statusCode">statusCode.</param>
        /// <param name="headers">headers.</param>
        /// <param name="rawBody">rawBody.</param>
        /// <param name="body">body.</param>
        public HttpStringResponse(
            int statusCode,
            Dictionary<string, string> headers,
            Stream rawBody,
            string body
        )
            : base(statusCode, headers, rawBody, body) { }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"Body = {this.Body}" + $"{base.ToString()}: ";
        }
    }
}
