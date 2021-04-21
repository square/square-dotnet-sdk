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
        internal HttpClientConfiguration()
        {
            this.Timeout = TimeSpan.FromSeconds(60);
            this.NumberOfRetries = 0;
            this.BackoffFactor = 2;
            this.RetryInterval = 1;
            this.BackoffMax = TimeSpan.FromSeconds(0);
            this.StatusCodesToRetry = new List<int>
            {
                408, 413, 429, 500, 502, 503, 504, 521, 522, 524,
            }.ToImmutableList();
            this.RequestMethodsToRetry = new List<string>
            {
                "GET", "PUT",
            }.Select(val => new HttpMethod(val)).ToImmutableList();
        }

        private HttpClientConfiguration(
            TimeSpan timeout,
            int numberOfRetries,
            int backoffFactor,
            double retryInterval,
            TimeSpan backoffMax,
            IList<int> statusCodesToRetry,
            IList<HttpMethod> requestMethodsToRetry)
        {
            this.Timeout = timeout;
            this.NumberOfRetries = numberOfRetries;
            this.BackoffFactor = backoffFactor;
            this.RetryInterval = retryInterval;
            this.BackoffMax = backoffMax;
            this.StatusCodesToRetry = statusCodesToRetry;
            this.RequestMethodsToRetry = requestMethodsToRetry;
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
        /// Gets The maximum back off time.
        /// </summary>
        public TimeSpan BackoffMax { get; }

        /// <summary>
        /// Gets List of Http status codes to invoke retry.
        /// </summary>
        public IList<int> StatusCodesToRetry { get; }

        /// <summary>
        /// Gets List of Http request methods to invoke retry.
        /// </summary>
        public IList<HttpMethod> RequestMethodsToRetry { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return "HttpClientConfiguration: " +
                $"{this.Timeout} , " +
                $"{this.NumberOfRetries} , " +
                $"{this.BackoffFactor} , " +
                $"{this.RetryInterval} , " +
                $"{this.BackoffMax} , " +
                $"{this.StatusCodesToRetry} , " +
                $"{this.RequestMethodsToRetry} ";
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
                .BackoffMax(this.BackoffMax)
                .StatusCodesToRetry(this.StatusCodesToRetry)
                .RequestMethodsToRetry(this.RequestMethodsToRetry);

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
            private TimeSpan backoffMax = TimeSpan.FromSeconds(0);
            private IList<int> statusCodesToRetry = new List<int>
            {
                408, 413, 429, 500, 502, 503, 504, 521, 522, 524,
            }.ToImmutableList();
            private IList<HttpMethod> requestMethodsToRetry = new List<string>
            {
                "GET", "PUT",
            }.Select(val => new HttpMethod(val)).ToImmutableList();

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
            /// Sets the BackoffMax.
            /// </summary>
            /// <param name="backoffMax"> BackoffMax. </param>
            /// <returns>Builder.</returns>
            public Builder BackoffMax(TimeSpan backoffMax)
            {
                this.backoffMax = backoffMax.TotalSeconds < 0 ? TimeSpan.FromSeconds(0) : backoffMax;
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
                        this.backoffMax,
                        this.statusCodesToRetry,
                        this.requestMethodsToRetry);
            }
        }
    }
}
