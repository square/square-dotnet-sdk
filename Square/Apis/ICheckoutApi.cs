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
    public interface ICheckoutApi
    {
        /// <summary>
        /// Links a `checkoutId` to a `checkout_page_url` that customers will
        /// be directed to in order to provide their payment information using a
        /// payment processing workflow hosted on connect.squareup.com.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the business location to associate the checkout with.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreateCheckoutResponse response from the API call</return>
        Models.CreateCheckoutResponse CreateCheckout(string locationId, Models.CreateCheckoutRequest body);

        /// <summary>
        /// Links a `checkoutId` to a `checkout_page_url` that customers will
        /// be directed to in order to provide their payment information using a
        /// payment processing workflow hosted on connect.squareup.com.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the business location to associate the checkout with.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreateCheckoutResponse response from the API call</return>
        Task<Models.CreateCheckoutResponse> CreateCheckoutAsync(string locationId, Models.CreateCheckoutRequest body, CancellationToken cancellationToken = default);

    }
}