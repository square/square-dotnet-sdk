namespace Square.Http.Client
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;

    /// <summary>
    /// Represents the current state of the Http Client.
    /// </summary>
    public interface IHttpClientConfiguration
    {
        /// <summary>
        /// Http client timeout.
        /// </summary>
        TimeSpan Timeout { get; }

        /// <summary>
        /// Number of times the request is retried.
        /// </summary>
        int NumberOfRetries { get; }

        /// <summary>
        /// Exponential backoff factor for duration between retry calls.
        /// </summary>
        int BackoffFactor { get; }

        /// <summary>
        /// The time interval between the endpoint calls.
        /// </summary>
        double RetryInterval { get; }

        /// <summary>
        /// The maximum back off time.
        /// </summary>
        TimeSpan BackoffMax { get; }

        /// <summary>
        /// List of Http status codes to invoke retry.
        /// </summary>
        IList<int> StatusCodesToRetry { get; }

        /// <summary>
        /// List of Http request methods to invoke retry.
        /// </summary>
        IList<HttpMethod> RequestMethodsToRetry { get; }
    }
}
