using System;

namespace Square.Http.Client
{
    /// <summary>
    /// Represents the current state of the Http Client
    /// </summary>
    public interface IHttpClientConfiguration
    {
        /// <summary>
        /// Http client timeout
        /// </summary>
        TimeSpan Timeout { get; }
    }
}
