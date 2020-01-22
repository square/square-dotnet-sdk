using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Square;
using Square.Utilities;
using Square.Http.Request;
using Square.Http.Response;
using Square.Http.Client;

namespace Square.Apis
{
    public interface IApplePayApi
    {
        /// <summary>
        /// Activates a domain for use with Web Apple Pay and Square. A validation
        /// will be performed on this domain by Apple to ensure is it properly set up as
        /// an Apple Pay enabled domain.
        /// This endpoint provides an easy way for platform developers to bulk activate
        /// Web Apple Pay with Square for merchants using their platform.
        /// To learn more about Apple Pay on Web see the Apple Pay section in the
        /// [Square Payment Form Walkthrough](https://developer.squareup.com/docs/docs/payment-form/payment-form-walkthrough).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.RegisterDomainResponse response from the API call</return>
        Models.RegisterDomainResponse RegisterDomain(Models.RegisterDomainRequest body);

        /// <summary>
        /// Activates a domain for use with Web Apple Pay and Square. A validation
        /// will be performed on this domain by Apple to ensure is it properly set up as
        /// an Apple Pay enabled domain.
        /// This endpoint provides an easy way for platform developers to bulk activate
        /// Web Apple Pay with Square for merchants using their platform.
        /// To learn more about Apple Pay on Web see the Apple Pay section in the
        /// [Square Payment Form Walkthrough](https://developer.squareup.com/docs/docs/payment-form/payment-form-walkthrough).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.RegisterDomainResponse response from the API call</return>
        Task<Models.RegisterDomainResponse> RegisterDomainAsync(Models.RegisterDomainRequest body, CancellationToken cancellationToken = default);

    }
}