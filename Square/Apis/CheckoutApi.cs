using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using APIMatic.Core;
using APIMatic.Core.Types;
using APIMatic.Core.Utilities;
using APIMatic.Core.Utilities.Date.Xml;
using Newtonsoft.Json.Converters;
using Square;
using Square.Http.Client;
using Square.Utilities;
using System.Net.Http;

namespace Square.Apis
{
    /// <summary>
    /// CheckoutApi.
    /// </summary>
    internal class CheckoutApi : BaseApi, ICheckoutApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CheckoutApi"/> class.
        /// </summary>
        internal CheckoutApi(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// Links a `checkoutId` to a `checkout_page_url` that customers are.
        /// directed to in order to provide their payment information using a.
        /// payment processing workflow hosted on connect.squareup.com. .
        /// NOTE: The Checkout API has been updated with new features. .
        /// For more information, see [Checkout API highlights](https://developer.squareup.com/docs/checkout-api#checkout-api-highlights).
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the business location to associate the checkout with..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateCheckoutResponse response from the API call.</returns>
        [Obsolete]
        public Models.CreateCheckoutResponse CreateCheckout(
                string locationId,
                Models.CreateCheckoutRequest body)
            => CoreHelper.RunTask(CreateCheckoutAsync(locationId, body));

        /// <summary>
        /// Links a `checkoutId` to a `checkout_page_url` that customers are.
        /// directed to in order to provide their payment information using a.
        /// payment processing workflow hosted on connect.squareup.com. .
        /// NOTE: The Checkout API has been updated with new features. .
        /// For more information, see [Checkout API highlights](https://developer.squareup.com/docs/checkout-api#checkout-api-highlights).
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the business location to associate the checkout with..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateCheckoutResponse response from the API call.</returns>
        [Obsolete]
        public async Task<Models.CreateCheckoutResponse> CreateCheckoutAsync(
                string locationId,
                Models.CreateCheckoutRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.CreateCheckoutResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/locations/{location_id}/checkouts")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Template(_template => _template.Setup("location_id", locationId))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Retrieves the location-level settings for a Square-hosted checkout page.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location for which to retrieve settings..</param>
        /// <returns>Returns the Models.RetrieveLocationSettingsResponse response from the API call.</returns>
        public Models.RetrieveLocationSettingsResponse RetrieveLocationSettings(
                string locationId)
            => CoreHelper.RunTask(RetrieveLocationSettingsAsync(locationId));

        /// <summary>
        /// Retrieves the location-level settings for a Square-hosted checkout page.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location for which to retrieve settings..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveLocationSettingsResponse response from the API call.</returns>
        public async Task<Models.RetrieveLocationSettingsResponse> RetrieveLocationSettingsAsync(
                string locationId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.RetrieveLocationSettingsResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/online-checkout/location-settings/{location_id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("location_id", locationId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Updates the location-level settings for a Square-hosted checkout page.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location for which to retrieve settings..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpdateLocationSettingsResponse response from the API call.</returns>
        public Models.UpdateLocationSettingsResponse UpdateLocationSettings(
                string locationId,
                Models.UpdateLocationSettingsRequest body)
            => CoreHelper.RunTask(UpdateLocationSettingsAsync(locationId, body));

        /// <summary>
        /// Updates the location-level settings for a Square-hosted checkout page.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location for which to retrieve settings..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpdateLocationSettingsResponse response from the API call.</returns>
        public async Task<Models.UpdateLocationSettingsResponse> UpdateLocationSettingsAsync(
                string locationId,
                Models.UpdateLocationSettingsRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.UpdateLocationSettingsResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Put, "/v2/online-checkout/location-settings/{location_id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Template(_template => _template.Setup("location_id", locationId))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Retrieves the merchant-level settings for a Square-hosted checkout page.
        /// </summary>
        /// <returns>Returns the Models.RetrieveMerchantSettingsResponse response from the API call.</returns>
        public Models.RetrieveMerchantSettingsResponse RetrieveMerchantSettings()
            => CoreHelper.RunTask(RetrieveMerchantSettingsAsync());

        /// <summary>
        /// Retrieves the merchant-level settings for a Square-hosted checkout page.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveMerchantSettingsResponse response from the API call.</returns>
        public async Task<Models.RetrieveMerchantSettingsResponse> RetrieveMerchantSettingsAsync(CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.RetrieveMerchantSettingsResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/online-checkout/merchant-settings")
                  .WithAuth("global"))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Updates the merchant-level settings for a Square-hosted checkout page.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpdateMerchantSettingsResponse response from the API call.</returns>
        public Models.UpdateMerchantSettingsResponse UpdateMerchantSettings(
                Models.UpdateMerchantSettingsRequest body)
            => CoreHelper.RunTask(UpdateMerchantSettingsAsync(body));

        /// <summary>
        /// Updates the merchant-level settings for a Square-hosted checkout page.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpdateMerchantSettingsResponse response from the API call.</returns>
        public async Task<Models.UpdateMerchantSettingsResponse> UpdateMerchantSettingsAsync(
                Models.UpdateMerchantSettingsRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.UpdateMerchantSettingsResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Put, "/v2/online-checkout/merchant-settings")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Lists all payment links.
        /// </summary>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this cursor to retrieve the next set of results for the original query. If a cursor is not provided, the endpoint returns the first page of the results. For more  information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="limit">Optional parameter: A limit on the number of results to return per page. The limit is advisory and the implementation might return more or less results. If the supplied limit is negative, zero, or greater than the maximum limit of 1000, it is ignored.  Default value: `100`.</param>
        /// <returns>Returns the Models.ListPaymentLinksResponse response from the API call.</returns>
        public Models.ListPaymentLinksResponse ListPaymentLinks(
                string cursor = null,
                int? limit = null)
            => CoreHelper.RunTask(ListPaymentLinksAsync(cursor, limit));

        /// <summary>
        /// Lists all payment links.
        /// </summary>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this cursor to retrieve the next set of results for the original query. If a cursor is not provided, the endpoint returns the first page of the results. For more  information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="limit">Optional parameter: A limit on the number of results to return per page. The limit is advisory and the implementation might return more or less results. If the supplied limit is negative, zero, or greater than the maximum limit of 1000, it is ignored.  Default value: `100`.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListPaymentLinksResponse response from the API call.</returns>
        public async Task<Models.ListPaymentLinksResponse> ListPaymentLinksAsync(
                string cursor = null,
                int? limit = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ListPaymentLinksResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/online-checkout/payment-links")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("cursor", cursor))
                      .Query(_query => _query.Setup("limit", limit))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Creates a Square-hosted checkout page. Applications can share the resulting payment link with their buyer to pay for goods and services.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreatePaymentLinkResponse response from the API call.</returns>
        public Models.CreatePaymentLinkResponse CreatePaymentLink(
                Models.CreatePaymentLinkRequest body)
            => CoreHelper.RunTask(CreatePaymentLinkAsync(body));

        /// <summary>
        /// Creates a Square-hosted checkout page. Applications can share the resulting payment link with their buyer to pay for goods and services.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreatePaymentLinkResponse response from the API call.</returns>
        public async Task<Models.CreatePaymentLinkResponse> CreatePaymentLinkAsync(
                Models.CreatePaymentLinkRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.CreatePaymentLinkResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/online-checkout/payment-links")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Deletes a payment link.
        /// </summary>
        /// <param name="id">Required parameter: The ID of the payment link to delete..</param>
        /// <returns>Returns the Models.DeletePaymentLinkResponse response from the API call.</returns>
        public Models.DeletePaymentLinkResponse DeletePaymentLink(
                string id)
            => CoreHelper.RunTask(DeletePaymentLinkAsync(id));

        /// <summary>
        /// Deletes a payment link.
        /// </summary>
        /// <param name="id">Required parameter: The ID of the payment link to delete..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.DeletePaymentLinkResponse response from the API call.</returns>
        public async Task<Models.DeletePaymentLinkResponse> DeletePaymentLinkAsync(
                string id,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.DeletePaymentLinkResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Delete, "/v2/online-checkout/payment-links/{id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("id", id))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Retrieves a payment link.
        /// </summary>
        /// <param name="id">Required parameter: The ID of link to retrieve..</param>
        /// <returns>Returns the Models.RetrievePaymentLinkResponse response from the API call.</returns>
        public Models.RetrievePaymentLinkResponse RetrievePaymentLink(
                string id)
            => CoreHelper.RunTask(RetrievePaymentLinkAsync(id));

        /// <summary>
        /// Retrieves a payment link.
        /// </summary>
        /// <param name="id">Required parameter: The ID of link to retrieve..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrievePaymentLinkResponse response from the API call.</returns>
        public async Task<Models.RetrievePaymentLinkResponse> RetrievePaymentLinkAsync(
                string id,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.RetrievePaymentLinkResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/online-checkout/payment-links/{id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("id", id))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Updates a payment link. You can update the `payment_link` fields such as.
        /// `description`, `checkout_options`, and  `pre_populated_data`.
        /// You cannot update other fields such as the `order_id`, `version`, `URL`, or `timestamp` field.
        /// </summary>
        /// <param name="id">Required parameter: The ID of the payment link to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpdatePaymentLinkResponse response from the API call.</returns>
        public Models.UpdatePaymentLinkResponse UpdatePaymentLink(
                string id,
                Models.UpdatePaymentLinkRequest body)
            => CoreHelper.RunTask(UpdatePaymentLinkAsync(id, body));

        /// <summary>
        /// Updates a payment link. You can update the `payment_link` fields such as.
        /// `description`, `checkout_options`, and  `pre_populated_data`.
        /// You cannot update other fields such as the `order_id`, `version`, `URL`, or `timestamp` field.
        /// </summary>
        /// <param name="id">Required parameter: The ID of the payment link to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpdatePaymentLinkResponse response from the API call.</returns>
        public async Task<Models.UpdatePaymentLinkResponse> UpdatePaymentLinkAsync(
                string id,
                Models.UpdatePaymentLinkRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.UpdatePaymentLinkResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Put, "/v2/online-checkout/payment-links/{id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Template(_template => _template.Setup("id", id))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);
    }
}