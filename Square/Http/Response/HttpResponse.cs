using System;
using System.Collections.Generic;
using System.IO;

namespace Square.Http.Response
{
    public class HttpResponse
    {
        /// <summary>
        /// HTTP Status code of the http response
        /// </summary>
        public int StatusCode { get; }

        /// <summary>
        /// Headers of the http response
        /// </summary>
        public Dictionary<string,string> Headers { get; }

        /// <summary>
        /// Stream of the body
        /// </summary>
        public Stream RawBody { get; }

        public HttpResponse(int statusCode, Dictionary<string,string> headers, Stream rawBody)
        {
            this.StatusCode = statusCode;
            this.Headers = headers;
            this.RawBody = rawBody;
        }
    }
}
