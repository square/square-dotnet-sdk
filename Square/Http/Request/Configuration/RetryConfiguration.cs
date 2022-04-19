namespace Square.Http.Request.Configuration
{
    /// <summary>
    /// Holds configurations for a particular HTTP request.
    /// </summary>
    internal class RetryConfiguration
    {
        /// <summary>
        /// The option to override HTTP method whitelist configuration for the request in retries.
        /// </summary>
        public RetryOption RetryOption { get; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="retryOption">The option to override retry configurations for a particular request.</param>
        private RetryConfiguration(RetryOption retryOption)
        {
            this.RetryOption = retryOption;
        }

        public override string ToString()
        {
            return "RetryConfiguration [retryOption=" + RetryOption + "]";
        }

        /// <summary>
        /// Class to build instances of <see cref="RetryConfiguration"/>.
        /// </summary>
        public class Builder
        {
            private RetryOption retryOption = Configuration.RetryOption.Default;

            /// <summary>
            /// The option to override retry configurations for a particular request.
            /// </summary>
            /// <param name="retryOption">The RetryOption to set.</param>
            /// <returns><see cref="Builder"/></returns>
            public Builder RetryOption(RetryOption retryOption)
            {
                this.retryOption = retryOption;
                return this;
            }

            /// <summary>
            /// Builds a new RetryConfiguration object using the set fields.
            /// </summary>
            /// <returns><see cref="RetryConfiguration"/></returns>
            public RetryConfiguration Build()
            {
                return new RetryConfiguration(retryOption);
            }
        }
    }

    /// <summary>
    /// Holds default <see cref="RetryConfiguration"/>  for HTTP requests.
    /// </summary>
    internal sealed class DefaultRetryConfiguration
    {
        /// <summary>
        /// The default instance of <see cref="RetryConfiguration"/> for the retries in request.
        /// </summary>
        private static readonly RetryConfiguration retryConfiguration = new RetryConfiguration.Builder().Build();

        /// <summary>
        /// Static constructor.
        /// </summary>
        static DefaultRetryConfiguration() 
        {
        }

        /// <summary>
        /// Returns default <see cref="RetryConfiguration"/>.
        /// </summary>
        public static RetryConfiguration RetryConfiguration
        {
            get
            {
                return retryConfiguration;
            }
        }
    }
}
