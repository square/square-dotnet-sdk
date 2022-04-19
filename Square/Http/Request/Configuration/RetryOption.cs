namespace Square.Http.Request.Configuration
{

    /// <summary>
    /// Retry options enumeration for HTTP request.
    /// </summary>
    internal enum RetryOption
    {
        /// <summary>
        /// To retry request, ignoring httpMethods whitelist.
        /// </summary>
        EnableForHttpMethod,

        /// <summary>
        /// To disable retries for the request.
        /// </summary>
        Disable,

        /// <summary>
        /// To use global httpMethods whitelist to determine if request needs retrying.
        /// </summary>
        Default
    }

    /// <summary>
    /// RetryOption enumeration extention class.
    /// </summary>
    internal static class RetryOptionExtensions
    {
        /// <summary>
        /// Determines whether retrying for the request is allowed or not.
        /// </summary>
        /// <param name="retryOption">Enum to run the validation on.</param>
        /// <param name="isWhitelistedRequestMethod">Flag if the global list of HTTP method contains the request method.</param>
        /// <returns>True if retrying for the request is allowed.</returns>
        public static bool IsRetryAllowed(this RetryOption retryOption, bool isWhitelistedRequestMethod)
        {
            switch (retryOption)
            {
                case RetryOption.EnableForHttpMethod:
                    return true;
                case RetryOption.Disable:
                    return false;
                case RetryOption.Default:
                    return isWhitelistedRequestMethod;
            }
            return isWhitelistedRequestMethod;
        }
    }
}
