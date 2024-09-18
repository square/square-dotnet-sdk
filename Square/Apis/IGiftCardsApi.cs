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

namespace Square.Apis
{
    /// <summary>
    /// IGiftCardsApi.
    /// </summary>
    public interface IGiftCardsApi
    {
        /// <summary>
        /// Lists all gift cards. You can specify optional filters to retrieve .
        /// a subset of the gift cards. Results are sorted by `created_at` in ascending order.
        /// </summary>
        /// <param name="type">Optional parameter: If a [type](entity:GiftCardType) is provided, the endpoint returns gift cards of the specified type. Otherwise, the endpoint returns gift cards of all types..</param>
        /// <param name="state">Optional parameter: If a [state](entity:GiftCardStatus) is provided, the endpoint returns the gift cards in the specified state. Otherwise, the endpoint returns the gift cards of all states..</param>
        /// <param name="limit">Optional parameter: If a limit is provided, the endpoint returns only the specified number of results per page. The maximum value is 200. The default value is 30. For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination)..</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this cursor to retrieve the next set of results for the original query. If a cursor is not provided, the endpoint returns the first page of the results.  For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination)..</param>
        /// <param name="customerId">Optional parameter: If a customer ID is provided, the endpoint returns only the gift cards linked to the specified customer..</param>
        /// <returns>Returns the Models.ListGiftCardsResponse response from the API call.</returns>
        Models.ListGiftCardsResponse ListGiftCards(
                string type = null,
                string state = null,
                int? limit = null,
                string cursor = null,
                string customerId = null);

        /// <summary>
        /// Lists all gift cards. You can specify optional filters to retrieve .
        /// a subset of the gift cards. Results are sorted by `created_at` in ascending order.
        /// </summary>
        /// <param name="type">Optional parameter: If a [type](entity:GiftCardType) is provided, the endpoint returns gift cards of the specified type. Otherwise, the endpoint returns gift cards of all types..</param>
        /// <param name="state">Optional parameter: If a [state](entity:GiftCardStatus) is provided, the endpoint returns the gift cards in the specified state. Otherwise, the endpoint returns the gift cards of all states..</param>
        /// <param name="limit">Optional parameter: If a limit is provided, the endpoint returns only the specified number of results per page. The maximum value is 200. The default value is 30. For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination)..</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this cursor to retrieve the next set of results for the original query. If a cursor is not provided, the endpoint returns the first page of the results.  For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination)..</param>
        /// <param name="customerId">Optional parameter: If a customer ID is provided, the endpoint returns only the gift cards linked to the specified customer..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListGiftCardsResponse response from the API call.</returns>
        Task<Models.ListGiftCardsResponse> ListGiftCardsAsync(
                string type = null,
                string state = null,
                int? limit = null,
                string cursor = null,
                string customerId = null,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a digital gift card or registers a physical (plastic) gift card. The resulting gift card.
        /// has a `PENDING` state. To activate a gift card so that it can be redeemed for purchases, call.
        /// [CreateGiftCardActivity]($e/GiftCardActivities/CreateGiftCardActivity) and create an `ACTIVATE`.
        /// activity with the initial balance. Alternatively, you can use [RefundPayment]($e/Refunds/RefundPayment).
        /// to refund a payment to the new gift card.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateGiftCardResponse response from the API call.</returns>
        Models.CreateGiftCardResponse CreateGiftCard(
                Models.CreateGiftCardRequest body);

        /// <summary>
        /// Creates a digital gift card or registers a physical (plastic) gift card. The resulting gift card.
        /// has a `PENDING` state. To activate a gift card so that it can be redeemed for purchases, call.
        /// [CreateGiftCardActivity]($e/GiftCardActivities/CreateGiftCardActivity) and create an `ACTIVATE`.
        /// activity with the initial balance. Alternatively, you can use [RefundPayment]($e/Refunds/RefundPayment).
        /// to refund a payment to the new gift card.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateGiftCardResponse response from the API call.</returns>
        Task<Models.CreateGiftCardResponse> CreateGiftCardAsync(
                Models.CreateGiftCardRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a gift card using the gift card account number (GAN).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.RetrieveGiftCardFromGANResponse response from the API call.</returns>
        Models.RetrieveGiftCardFromGANResponse RetrieveGiftCardFromGAN(
                Models.RetrieveGiftCardFromGANRequest body);

        /// <summary>
        /// Retrieves a gift card using the gift card account number (GAN).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveGiftCardFromGANResponse response from the API call.</returns>
        Task<Models.RetrieveGiftCardFromGANResponse> RetrieveGiftCardFromGANAsync(
                Models.RetrieveGiftCardFromGANRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a gift card using a secure payment token that represents the gift card.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.RetrieveGiftCardFromNonceResponse response from the API call.</returns>
        Models.RetrieveGiftCardFromNonceResponse RetrieveGiftCardFromNonce(
                Models.RetrieveGiftCardFromNonceRequest body);

        /// <summary>
        /// Retrieves a gift card using a secure payment token that represents the gift card.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveGiftCardFromNonceResponse response from the API call.</returns>
        Task<Models.RetrieveGiftCardFromNonceResponse> RetrieveGiftCardFromNonceAsync(
                Models.RetrieveGiftCardFromNonceRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Links a customer to a gift card, which is also referred to as adding a card on file.
        /// </summary>
        /// <param name="giftCardId">Required parameter: The ID of the gift card to be linked..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.LinkCustomerToGiftCardResponse response from the API call.</returns>
        Models.LinkCustomerToGiftCardResponse LinkCustomerToGiftCard(
                string giftCardId,
                Models.LinkCustomerToGiftCardRequest body);

        /// <summary>
        /// Links a customer to a gift card, which is also referred to as adding a card on file.
        /// </summary>
        /// <param name="giftCardId">Required parameter: The ID of the gift card to be linked..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.LinkCustomerToGiftCardResponse response from the API call.</returns>
        Task<Models.LinkCustomerToGiftCardResponse> LinkCustomerToGiftCardAsync(
                string giftCardId,
                Models.LinkCustomerToGiftCardRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Unlinks a customer from a gift card, which is also referred to as removing a card on file.
        /// </summary>
        /// <param name="giftCardId">Required parameter: The ID of the gift card to be unlinked..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UnlinkCustomerFromGiftCardResponse response from the API call.</returns>
        Models.UnlinkCustomerFromGiftCardResponse UnlinkCustomerFromGiftCard(
                string giftCardId,
                Models.UnlinkCustomerFromGiftCardRequest body);

        /// <summary>
        /// Unlinks a customer from a gift card, which is also referred to as removing a card on file.
        /// </summary>
        /// <param name="giftCardId">Required parameter: The ID of the gift card to be unlinked..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UnlinkCustomerFromGiftCardResponse response from the API call.</returns>
        Task<Models.UnlinkCustomerFromGiftCardResponse> UnlinkCustomerFromGiftCardAsync(
                string giftCardId,
                Models.UnlinkCustomerFromGiftCardRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a gift card using the gift card ID.
        /// </summary>
        /// <param name="id">Required parameter: The ID of the gift card to retrieve..</param>
        /// <returns>Returns the Models.RetrieveGiftCardResponse response from the API call.</returns>
        Models.RetrieveGiftCardResponse RetrieveGiftCard(
                string id);

        /// <summary>
        /// Retrieves a gift card using the gift card ID.
        /// </summary>
        /// <param name="id">Required parameter: The ID of the gift card to retrieve..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveGiftCardResponse response from the API call.</returns>
        Task<Models.RetrieveGiftCardResponse> RetrieveGiftCardAsync(
                string id,
                CancellationToken cancellationToken = default);
    }
}