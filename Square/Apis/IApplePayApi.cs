namespace Square.Apis
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Square;
    using Square.Http.Client;
    using Square.Http.Request;
    using Square.Http.Response;
    using Square.Utilities;

    /// <summary>
    /// IApplePayApi.
    /// </summary>
    public interface IApplePayApi
    {
        /// <summary>
        /// Activates a domain for use with Apple Pay on the Web and Square. A validation.
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
        Models.RegisterDomainResponse RegisterDomain(
                Models.RegisterDomainRequest body);

        /// <summary>
        /// Activates a domain for use with Apple Pay on the Web and Square. A validation.
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
        Task<Models.RegisterDomainResponse> RegisterDomainAsync(
                Models.RegisterDomainRequest body,
                CancellationToken cancellationToken = default);
    }
}