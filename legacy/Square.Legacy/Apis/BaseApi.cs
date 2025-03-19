using System;
using APIMatic.Core;
using APIMatic.Core.Http.Configuration;
using APIMatic.Core.Response;
using Square.Legacy.Exceptions;
using Square.Legacy.Http.Client;
using Square.Legacy.Http.Request;
using Square.Legacy.Http.Response;
using Square.Legacy.Utilities;

namespace Square.Legacy.Apis
{
    /// <summary>
    /// The base class for all controller classes.
    /// </summary>
    internal class BaseApi
    {
        private readonly GlobalConfiguration globalConfiguration;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseApi"/> class.
        /// </summary>
        internal BaseApi(GlobalConfiguration config) => globalConfiguration = config;

        protected static ErrorCase<
            HttpRequest,
            HttpResponse,
            HttpContext,
            ApiException
        > CreateErrorCase(
            string reason,
            Func<string, HttpContext, ApiException> error,
            bool isErrorTemplate = false
        ) =>
            new ErrorCase<HttpRequest, HttpResponse, HttpContext, ApiException>(
                reason,
                error,
                isErrorTemplate
            );

        protected ApiCall<
            HttpRequest,
            HttpResponse,
            HttpContext,
            ApiException,
            T,
            T
        > CreateApiCall<T>(ArraySerialization arraySerialization = ArraySerialization.Indexed) =>
            new ApiCall<HttpRequest, HttpResponse, HttpContext, ApiException, T, T>(
                globalConfiguration,
                compatibilityFactory,
                serialization: arraySerialization
            );

        private static readonly CompatibilityFactory compatibilityFactory =
            new CompatibilityFactory();
    }
}
