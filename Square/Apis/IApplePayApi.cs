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
        /// Activates a domain for use with Apple Pay on the Web and Square. A validation
        /// is performed on this domain by Apple to ensure that it is properly set up as
        /// an Apple Pay enabled domain.
        /// This endpoint provides an easy way for platform developers to bulk activate
        /// Apple Pay on the Web with Square for merchants using their platform.
        /// To learn more about Web Apple Pay, see
        /// [Add the Apple Pay on the Web Button](https://developer.squareup.com/docs/payment-form/add-digital-wallets/apple-pay).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.RegisterDomainResponse response from the API call</return>
        Models.RegisterDomainResponse RegisterDomain(Models.RegisterDomainRequest body);

        /// <summary>
        /// Activates a domain for use with Apple Pay on the Web and Square. A validation
        /// is performed on this domain by Apple to ensure that it is properly set up as
        /// an Apple Pay enabled domain.
        /// This endpoint provides an easy way for platform developers to bulk activate
        /// Apple Pay on the Web with Square for merchants using their platform.
        /// To learn more about Web Apple Pay, see
        /// [Add the Apple Pay on the Web Button](https://developer.squareup.com/docs/payment-form/add-digital-wallets/apple-pay).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.RegisterDomainResponse response from the API call</return>
        Task<Models.RegisterDomainResponse> RegisterDomainAsync(Models.RegisterDomainRequest body, CancellationToken cancellationToken = default);

    }
}