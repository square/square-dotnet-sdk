using System;

namespace Square.Http.Client
{
    /// <summary>
    /// Represents the current state of the Http Client
    /// </summary>
    internal class HttpClientConfiguration : IHttpClientConfiguration
    {
        public HttpClientConfiguration()
        {
            Timeout = TimeSpan.FromSeconds(60);
        }

        /// <summary>
        /// Http client timeout
        /// </summary>
        public TimeSpan Timeout { get; internal set; }
    }
}
