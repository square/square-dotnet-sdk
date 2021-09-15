namespace Square.Http.Client
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;
    using System.Net.Http;

    /// <summary>
    /// HttpClientConfiguration represents the current state of the Http Client.
    /// </summary>
    public class HttpClientConfiguration : IHttpClientConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpClientConfiguration"/>
        /// class.
        /// </summary>
        private HttpClientConfiguration(
            TimeSpan timeout,
            int numberOfRetries,
            int backoffFactor,
            double retryInterval,
            TimeSpan maximumRetryWaitTime,
            IList<int> statusCodesToRetry,
            IList<HttpMethod> requestMethodsToRetry,
            HttpClient httpClientInstance,
            bool overrideHttpClientConfiguration)
        {
            this.Timeout = timeout;
            this.NumberOfRetries = numberOfRetries;
            this.BackoffFactor = backoffFactor;
            this.RetryInterval = retryInterval;
            this.MaximumRetryWaitTime = maximumRetryWaitTime;
            this.StatusCodesToRetry = statusCodesToRetry;
            this.RequestMethodsToRetry = requestMethodsToRetry;
            this.HttpClientInstance = httpClientInstance;
            this.OverrideHttpClientConfiguration = overrideHttpClientConfiguration;
        }

        /// <summary>
        /// Gets Http client timeout.
        /// </summary>
        public TimeSpan Timeout { get; }

        /// <summary>
        /// Gets Number of times the request is retried.
        /// </summary>
        public int NumberOfRetries { get; }

        /// <summary>
        /// Gets Exponential backoff factor for duration between retry calls.
        /// </summary>
        public int BackoffFactor { get; }

        /// <summary>
        /// Gets The time interval between the endpoint calls.
        /// </summary>
        public double RetryInterval { get; }

        /// <summary>
        /// Gets The maximum retry wait time.
        /// </summary>
        public TimeSpan MaximumRetryWaitTime { get; }

        /// <summary>
        /// Gets List of Http status codes to invoke retry.
        /// </summary>
        public IList<int> StatusCodesToRetry { get; }

        /// <summary>
        /// Gets List of Http request methods to invoke retry.
        /// </summary>
        public IList<HttpMethod> RequestMethodsToRetry { get; }

        /// <summary>
        /// Gets HttpClient instance used to make the HTTP calls
        /// </summary>
        public HttpClient HttpClientInstance { get; }

        /// <summary>
        /// Gets Boolean which allows the SDK to override http client instance's settings used for features like retries, timeouts etc.
        /// </summary>
        public bool OverrideHttpClientConfiguration { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return "HttpClientConfiguration: " +
                $"{this.Timeout} , " +
                $"{this.NumberOfRetries} , " +
                $"{this.BackoffFactor} , " +
                $"{this.RetryInterval} , " +
                $"{this.MaximumRetryWaitTime} , " +
                $"{this.StatusCodesToRetry} , " +
                $"{this.RequestMethodsToRetry} , " +
                $"{this.HttpClientInstance} , " +
                $"{this.OverrideHttpClientConfiguration} ";
        }

        /// <summary>
        /// Creates an object of the HttpClientConfiguration using the values provided for the builder.
        /// </summary>
        /// <returns>Builder.</returns>
        public Builder ToBuilder()
        {
            Builder builder = new Builder()
                .Timeout(this.Timeout)
                .NumberOfRetries(this.NumberOfRetries)
                .BackoffFactor(this.BackoffFactor)
                .RetryInterval(this.RetryInterval)
                .MaximumRetryWaitTime(this.MaximumRetryWaitTime)
                .StatusCodesToRetry(this.StatusCodesToRetry)
                .RequestMethodsToRetry(this.RequestMethodsToRetry)
                .HttpClientInstance(this.HttpClientInstance, this.OverrideHttpClientConfiguration);

            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private TimeSpan timeout = TimeSpan.FromSeconds(60);
            private int numberOfRetries = 0;
            private int backoffFactor = 2;
            private double retryInterval = 1;
            private TimeSpan maximumRetryWaitTime = TimeSpan.FromSeconds(0);
            private IList<int> statusCodesToRetry = new List<int>
            {
                408, 413, 429, 500, 502, 503, 504, 521, 522, 524
            }.ToImmutableList();
            private IList<HttpMethod> requestMethodsToRetry = new List<string>
            {
                "GET", "PUT"
            }.Select(val => new HttpMethod(val)).ToImmutableList();
            private HttpClient httpClientInstance = new HttpClient();
            private bool overrideHttpClientConfiguration = true;

            /// <summary>
            /// Sets the Timeout.
            /// </summary>
            /// <param name="timeout"> Timeout. </param>
            /// <returns>Builder.</returns>
            public Builder Timeout(TimeSpan timeout)
            {
                this.timeout = timeout.TotalSeconds <= 0 ? TimeSpan.FromSeconds(60) : timeout;
                return this;
            }

            /// <summary>
            /// Sets the NumberOfRetries.
            /// </summary>
            /// <param name="numberOfRetries"> NumberOfRetries. </param>
            /// <returns>Builder.</returns>
            public Builder NumberOfRetries(int numberOfRetries)
            {
                this.numberOfRetries = numberOfRetries < 0 ? 0 : numberOfRetries;
                return this;
            }

            /// <summary>
            /// Sets the BackoffFactor.
            /// </summary>
            /// <param name="backoffFactor"> BackoffFactor. </param>
            /// <returns>Builder.</returns>
            public Builder BackoffFactor(int backoffFactor)
            {
                this.backoffFactor = backoffFactor < 1 ? 2 : backoffFactor;
                return this;
            }

            /// <summary>
            /// Sets the RetryInterval.
            /// </summary>
            /// <param name="retryInterval"> RetryInterval. </param>
            /// <returns>Builder.</returns>
            public Builder RetryInterval(double retryInterval)
            {
                this.retryInterval = retryInterval < 0 ? 1 : retryInterval;
                return this;
            }

            /// <summary>
            /// Sets the MaximumRetryWaitTime.
            /// </summary>
            /// <param name="maximumRetryWaitTime"> MaximumRetryWaitTime. </param>
            /// <returns>Builder.</returns>
            public Builder MaximumRetryWaitTime(TimeSpan maximumRetryWaitTime)
            {
                this.maximumRetryWaitTime = maximumRetryWaitTime.TotalSeconds < 0 ? TimeSpan.FromSeconds(0) : maximumRetryWaitTime;
                return this;
            }

            /// <summary>
            /// Sets the StatusCodesToRetry.
            /// </summary>
            /// <param name="statusCodesToRetry"> StatusCodesToRetry. </param>
            /// <returns>Builder.</returns>
            public Builder StatusCodesToRetry(IList<int> statusCodesToRetry)
            {
                this.statusCodesToRetry = statusCodesToRetry ?? new List<int>().ToImmutableList();
                return this;
            }

            /// <summary>
            /// Sets the RequestMethodsToRetry.
            /// </summary>
            /// <param name="requestMethodsToRetry"> RequestMethodsToRetry. </param>
            /// <returns>Builder.</returns>
            public Builder RequestMethodsToRetry(IList<HttpMethod> requestMethodsToRetry)
            {
                this.requestMethodsToRetry = requestMethodsToRetry ?? new List<HttpMethod>().ToImmutableList();
                return this;
            }

            /// <summary>
            /// Sets the HttpClientInstance.
            /// </summary>
            /// <param name="httpClientInstance"> HttpClientInstance. </param>
            /// <param name="overrideHttpClientConfiguration"> OverrideHttpClientConfiguration. </param>
            /// <returns>Builder.</returns>
            public Builder HttpClientInstance(HttpClient httpClientInstance, bool overrideHttpClientConfiguration = true)
            {
                this.httpClientInstance = httpClientInstance ?? new HttpClient();
                this.overrideHttpClientConfiguration = overrideHttpClientConfiguration;
                return this;
            }

            /// <summary>
            /// Creates an object of the HttpClientConfiguration using the values provided for the builder.
            /// </summary>
            /// <returns>HttpClientConfiguration.</returns>
            public HttpClientConfiguration Build()
            {
                return new HttpClientConfiguration(
                        this.timeout,
                        this.numberOfRetries,
                        this.backoffFactor,
                        this.retryInterval,
                        this.maximumRetryWaitTime,
                        this.statusCodesToRetry,
                        this.requestMethodsToRetry,
                        this.httpClientInstance,
                        this.overrideHttpClientConfiguration);
            }
        }
    }
}
