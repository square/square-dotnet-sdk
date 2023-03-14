namespace Square.Http.Client
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;
    using System.Net.Http;
    using APIMatic.Core.Http.Configuration;

    /// <summary>
    /// HttpClientConfiguration represents the current state of the Http Client.
    /// </summary>
    public class HttpClientConfiguration : IHttpClientConfiguration
    {
        private CoreHttpClientConfiguration coreHttpClientConfiguration;
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpClientConfiguration"/>
        /// class.
        /// </summary>
        private HttpClientConfiguration(
            CoreHttpClientConfiguration.Builder coreHttpClientConfigurationBuilder)
        {
            coreHttpClientConfiguration = coreHttpClientConfigurationBuilder.Build();
        }

        /// <summary>
        /// Gets Http client timeout.
        /// </summary>
        public TimeSpan Timeout { get => coreHttpClientConfiguration.Timeout; }

        /// <summary>
        /// Gets Number of times the request is retried.
        /// </summary>
        public int NumberOfRetries { get => coreHttpClientConfiguration.NumberOfRetries; }

        /// <summary>
        /// Gets Exponential backoff factor for duration between retry calls.
        /// </summary>
        public int BackoffFactor { get => coreHttpClientConfiguration.BackoffFactor; }

        /// <summary>
        /// Gets The time interval between the endpoint calls.
        /// </summary>
        public double RetryInterval { get => coreHttpClientConfiguration.RetryInterval; }

        /// <summary>
        /// Gets The maximum retry wait time.
        /// </summary>
        public TimeSpan MaximumRetryWaitTime { get => coreHttpClientConfiguration.MaximumRetryWaitTime; }

        /// <summary>
        /// Gets List of Http status codes to invoke retry.
        /// </summary>
        public IList<int> StatusCodesToRetry { get => coreHttpClientConfiguration.StatusCodesToRetry; }

        /// <summary>
        /// Gets List of Http request methods to invoke retry.
        /// </summary>
        public IList<HttpMethod> RequestMethodsToRetry { get => coreHttpClientConfiguration.RequestMethodsToRetry; }

        /// <summary>
        /// Gets HttpClient instance used to make the HTTP calls
        /// </summary>
        public HttpClient HttpClientInstance { get => coreHttpClientConfiguration.HttpClientInstance; }

        /// <summary>
        /// Gets Boolean which allows the SDK to override http client instance's settings used for features like retries, timeouts etc.
        /// </summary>
        public bool OverrideHttpClientConfiguration { get => coreHttpClientConfiguration.OverrideHttpClientConfiguration; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return "HttpClientConfiguration: " +
                $"{Timeout} , " +
                $"{NumberOfRetries} , " +
                $"{BackoffFactor} , " +
                $"{RetryInterval} , " +
                $"{MaximumRetryWaitTime} , " +
                $"{StatusCodesToRetry} , " +
                $"{RequestMethodsToRetry} , " +
                $"{HttpClientInstance} , " +
                $"{OverrideHttpClientConfiguration} ";
        }

        /// <summary>
        /// Creates an object of the HttpClientConfiguration using the values provided for the builder.
        /// </summary>
        /// <returns>Builder.</returns>
        public Builder ToBuilder()
          => new Builder()
          {
              CoreHttpClientConfigurationBuilder = coreHttpClientConfiguration.ToBuilder()
          };

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            internal CoreHttpClientConfiguration.Builder CoreHttpClientConfigurationBuilder { private get; set; } = new CoreHttpClientConfiguration.Builder();
            /// <summary>
            /// Sets the Timeout.
            /// </summary>
            /// <param name="timeout"> Timeout. </param>
            /// <returns>Builder.</returns>
            public Builder Timeout(TimeSpan timeout)
            {
                CoreHttpClientConfigurationBuilder = CoreHttpClientConfigurationBuilder.Timeout(timeout);
                return this;
            }

            /// <summary>
            /// Sets the NumberOfRetries.
            /// </summary>
            /// <param name="numberOfRetries"> NumberOfRetries. </param>
            /// <returns>Builder.</returns>
            public Builder NumberOfRetries(int numberOfRetries)
            {
                CoreHttpClientConfigurationBuilder = CoreHttpClientConfigurationBuilder.NumberOfRetries(numberOfRetries);
                return this;
            }

            /// <summary>
            /// Sets the BackoffFactor.
            /// </summary>
            /// <param name="backoffFactor"> BackoffFactor. </param>
            /// <returns>Builder.</returns>
            public Builder BackoffFactor(int backoffFactor)
            {
                CoreHttpClientConfigurationBuilder = CoreHttpClientConfigurationBuilder.BackoffFactor(backoffFactor);
                return this;
            }

            /// <summary>
            /// Sets the RetryInterval.
            /// </summary>
            /// <param name="retryInterval"> RetryInterval. </param>
            /// <returns>Builder.</returns>
            public Builder RetryInterval(double retryInterval)
            {
                CoreHttpClientConfigurationBuilder = CoreHttpClientConfigurationBuilder.RetryInterval(retryInterval);
                return this;
            }

            /// <summary>
            /// Sets the MaximumRetryWaitTime.
            /// </summary>
            /// <param name="maximumRetryWaitTime"> MaximumRetryWaitTime. </param>
            /// <returns>Builder.</returns>
            public Builder MaximumRetryWaitTime(TimeSpan maximumRetryWaitTime)
            {
                CoreHttpClientConfigurationBuilder = CoreHttpClientConfigurationBuilder.MaximumRetryWaitTime(maximumRetryWaitTime);
                return this;
            }

            /// <summary>
            /// Sets the StatusCodesToRetry.
            /// </summary>
            /// <param name="statusCodesToRetry"> StatusCodesToRetry. </param>
            /// <returns>Builder.</returns>
            public Builder StatusCodesToRetry(IList<int> statusCodesToRetry)
            {
                CoreHttpClientConfigurationBuilder = CoreHttpClientConfigurationBuilder.StatusCodesToRetry(statusCodesToRetry);
                return this;
            }

            /// <summary>
            /// Sets the RequestMethodsToRetry.
            /// </summary>
            /// <param name="requestMethodsToRetry"> RequestMethodsToRetry. </param>
            /// <returns>Builder.</returns>
            public Builder RequestMethodsToRetry(IList<HttpMethod> requestMethodsToRetry)
            {
                CoreHttpClientConfigurationBuilder = CoreHttpClientConfigurationBuilder.RequestMethodsToRetry(requestMethodsToRetry);
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
                CoreHttpClientConfigurationBuilder = CoreHttpClientConfigurationBuilder.HttpClientInstance(httpClientInstance, overrideHttpClientConfiguration);
                return this;
            }

            /// <summary>
            /// Creates an object of the HttpClientConfiguration using the values provided for the builder.
            /// </summary>
            /// <returns>HttpClientConfiguration.</returns>
            public HttpClientConfiguration Build()
            {
                return new HttpClientConfiguration(CoreHttpClientConfigurationBuilder);
            }
        }
    }
}
