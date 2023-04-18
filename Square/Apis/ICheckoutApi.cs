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
    /// ICheckoutApi.
    /// </summary>
    public interface ICheckoutApi
    {
        /// <summary>
        /// Links a `checkoutId` to a `checkout_page_url` that customers are.
        /// directed to in order to provide their payment information using a.
        /// payment processing workflow hosted on connect.squareup.com. .
        /// NOTE: The Checkout API has been updated with new features. .
        /// For more information, see [Checkout API highlights](https://developer.squareup.com/docs/checkout-api#checkout-api-highlights).
        /// We recommend that you use the new [CreatePaymentLink](api-endpoint:Checkout-CreatePaymentLink) .
        /// endpoint in place of this previously released endpoint.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the business location to associate the checkout with..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateCheckoutResponse response from the API call.</returns>
        [Obsolete]
        Models.CreateCheckoutResponse CreateCheckout(
                string locationId,
                Models.CreateCheckoutRequest body);

        /// <summary>
        /// Links a `checkoutId` to a `checkout_page_url` that customers are.
        /// directed to in order to provide their payment information using a.
        /// payment processing workflow hosted on connect.squareup.com. .
        /// NOTE: The Checkout API has been updated with new features. .
        /// For more information, see [Checkout API highlights](https://developer.squareup.com/docs/checkout-api#checkout-api-highlights).
        /// We recommend that you use the new [CreatePaymentLink](api-endpoint:Checkout-CreatePaymentLink) .
        /// endpoint in place of this previously released endpoint.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the business location to associate the checkout with..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateCheckoutResponse response from the API call.</returns>
        [Obsolete]
        Task<Models.CreateCheckoutResponse> CreateCheckoutAsync(
                string locationId,
                Models.CreateCheckoutRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Lists all payment links.
        /// </summary>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this cursor to retrieve the next set of results for the original query. If a cursor is not provided, the endpoint returns the first page of the results. For more  information, see [Pagination](https://developer.squareup.com/docs/basics/api101/pagination)..</param>
        /// <param name="limit">Optional parameter: A limit on the number of results to return per page. The limit is advisory and the implementation might return more or less results. If the supplied limit is negative, zero, or greater than the maximum limit of 1000, it is ignored.  Default value: `100`.</param>
        /// <returns>Returns the Models.ListPaymentLinksResponse response from the API call.</returns>
        Models.ListPaymentLinksResponse ListPaymentLinks(
                string cursor = null,
                int? limit = null);

        /// <summary>
        /// Lists all payment links.
        /// </summary>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this cursor to retrieve the next set of results for the original query. If a cursor is not provided, the endpoint returns the first page of the results. For more  information, see [Pagination](https://developer.squareup.com/docs/basics/api101/pagination)..</param>
        /// <param name="limit">Optional parameter: A limit on the number of results to return per page. The limit is advisory and the implementation might return more or less results. If the supplied limit is negative, zero, or greater than the maximum limit of 1000, it is ignored.  Default value: `100`.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListPaymentLinksResponse response from the API call.</returns>
        Task<Models.ListPaymentLinksResponse> ListPaymentLinksAsync(
                string cursor = null,
                int? limit = null,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a Square-hosted checkout page. Applications can share the resulting payment link with their buyer to pay for goods and services.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreatePaymentLinkResponse response from the API call.</returns>
        Models.CreatePaymentLinkResponse CreatePaymentLink(
                Models.CreatePaymentLinkRequest body);

        /// <summary>
        /// Creates a Square-hosted checkout page. Applications can share the resulting payment link with their buyer to pay for goods and services.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreatePaymentLinkResponse response from the API call.</returns>
        Task<Models.CreatePaymentLinkResponse> CreatePaymentLinkAsync(
                Models.CreatePaymentLinkRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a payment link.
        /// </summary>
        /// <param name="id">Required parameter: The ID of the payment link to delete..</param>
        /// <returns>Returns the Models.DeletePaymentLinkResponse response from the API call.</returns>
        Models.DeletePaymentLinkResponse DeletePaymentLink(
                string id);

        /// <summary>
        /// Deletes a payment link.
        /// </summary>
        /// <param name="id">Required parameter: The ID of the payment link to delete..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.DeletePaymentLinkResponse response from the API call.</returns>
        Task<Models.DeletePaymentLinkResponse> DeletePaymentLinkAsync(
                string id,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a payment link.
        /// </summary>
        /// <param name="id">Required parameter: The ID of link to retrieve..</param>
        /// <returns>Returns the Models.RetrievePaymentLinkResponse response from the API call.</returns>
        Models.RetrievePaymentLinkResponse RetrievePaymentLink(
                string id);

        /// <summary>
        /// Retrieves a payment link.
        /// </summary>
        /// <param name="id">Required parameter: The ID of link to retrieve..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrievePaymentLinkResponse response from the API call.</returns>
        Task<Models.RetrievePaymentLinkResponse> RetrievePaymentLinkAsync(
                string id,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates a payment link. You can update the `payment_link` fields such as.
        /// `description`, `checkout_options`, and  `pre_populated_data`.
        /// You cannot update other fields such as the `order_id`, `version`, `URL`, or `timestamp` field.
        /// </summary>
        /// <param name="id">Required parameter: The ID of the payment link to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpdatePaymentLinkResponse response from the API call.</returns>
        Models.UpdatePaymentLinkResponse UpdatePaymentLink(
                string id,
                Models.UpdatePaymentLinkRequest body);

        /// <summary>
        /// Updates a payment link. You can update the `payment_link` fields such as.
        /// `description`, `checkout_options`, and  `pre_populated_data`.
        /// You cannot update other fields such as the `order_id`, `version`, `URL`, or `timestamp` field.
        /// </summary>
        /// <param name="id">Required parameter: The ID of the payment link to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpdatePaymentLinkResponse response from the API call.</returns>
        Task<Models.UpdatePaymentLinkResponse> UpdatePaymentLinkAsync(
                string id,
                Models.UpdatePaymentLinkRequest body,
                CancellationToken cancellationToken = default);
    }
}