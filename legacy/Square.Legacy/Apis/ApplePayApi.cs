using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using APIMatic.Core;
using APIMatic.Core.Types;
using APIMatic.Core.Utilities;
using APIMatic.Core.Utilities.Date.Xml;
using Newtonsoft.Json.Converters;
using Square.Legacy;
using Square.Legacy.Http.Client;
using Square.Legacy.Utilities;

namespace Square.Legacy.Apis
{
    /// <summary>
    /// ApplePayApi.
    /// </summary>
    internal class ApplePayApi : BaseApi, IApplePayApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplePayApi"/> class.
        /// </summary>
        internal ApplePayApi(GlobalConfiguration globalConfiguration)
            : base(globalConfiguration) { }

        /// <summary>
        /// Activates a domain for use with Apple Pay on the Web and Square.Legacy. A validation.
        /// is performed on this domain by Apple to ensure that it is properly set up as.
        /// an Apple Pay enabled domain.
        /// This endpoint provides an easy way for platform developers to bulk activate.
        /// Apple Pay on the Web with Square for merchants using their platform.
        /// Note: You will need to host a valid domain verification file on your domain to support Apple Pay.  The.
        /// current version of this file is always available at https://app.squareup.com/digital-wallets/apple-pay/apple-developer-merchantid-domain-association,.
        /// and should be hosted at `.well_known/apple-developer-merchantid-domain-association` on your.
        /// domain.  This file is subject to change; we strongly recommend checking for updates regularly and avoiding.
        /// long-lived caches that might not keep in sync with the correct file version.
        /// To learn more about the Web Payments SDK and how to add Apple Pay, see [Take an Apple Pay Payment](https://developer.squareup.com/docs/web-payments/apple-pay).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.RegisterDomainResponse response from the API call.</returns>
        public Models.RegisterDomainResponse RegisterDomain(Models.RegisterDomainRequest body) =>
            CoreHelper.RunTask(RegisterDomainAsync(body));

        /// <summary>
        /// Activates a domain for use with Apple Pay on the Web and Square.Legacy. A validation.
        /// is performed on this domain by Apple to ensure that it is properly set up as.
        /// an Apple Pay enabled domain.
        /// This endpoint provides an easy way for platform developers to bulk activate.
        /// Apple Pay on the Web with Square for merchants using their platform.
        /// Note: You will need to host a valid domain verification file on your domain to support Apple Pay.  The.
        /// current version of this file is always available at https://app.squareup.com/digital-wallets/apple-pay/apple-developer-merchantid-domain-association,.
        /// and should be hosted at `.well_known/apple-developer-merchantid-domain-association` on your.
        /// domain.  This file is subject to change; we strongly recommend checking for updates regularly and avoiding.
        /// long-lived caches that might not keep in sync with the correct file version.
        /// To learn more about the Web Payments SDK and how to add Apple Pay, see [Take an Apple Pay Payment](https://developer.squareup.com/docs/web-payments/apple-pay).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RegisterDomainResponse response from the API call.</returns>
        public async Task<Models.RegisterDomainResponse> RegisterDomainAsync(
            Models.RegisterDomainRequest body,
            CancellationToken cancellationToken = default
        ) =>
            await CreateApiCall<Models.RegisterDomainResponse>()
                .RequestBuilder(_requestBuilder =>
                    _requestBuilder
                        .Setup(HttpMethod.Post, "/v2/apple-pay/domains")
                        .WithAuth("global")
                        .Parameters(_parameters =>
                            _parameters
                                .Body(_bodyParameter => _bodyParameter.Setup(body))
                                .Header(_header =>
                                    _header.Setup("Content-Type", "application/json")
                                )
                        )
                )
                .ResponseHandler(_responseHandler =>
                    _responseHandler.ContextAdder(
                        (_result, _context) => _result.ContextSetter(_context)
                    )
                )
                .ExecuteAsync(cancellationToken)
                .ConfigureAwait(false);
    }
}
