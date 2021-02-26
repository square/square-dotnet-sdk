
using System;
using System.Collections.Generic;
using System.IO;
using Square.Utilities;

namespace Square.Http.Response
{
    /// <summary>
    /// HttpStringResponse inherits from HttpResponse and has additional property 
    /// of string body.
    /// </summary>
    public sealed class HttpStringResponse : HttpResponse
    {
        /// <summary>
        /// Raw string body of the http response.
        /// </summary>
        public string Body { get; }

        /// <summary>
        /// Initializes a new HttpStringResponse object with the specified parameters.
        /// </summary>
        public HttpStringResponse(int statusCode, Dictionary<string, string> headers, Stream rawBody, string body) : base(statusCode, headers, rawBody)
        {
            this.Body = body;
        }

        public override string ToString()
        {
            return $"Body = {Body}" +
                $"{base.ToString()}: ";
        }
    }
}