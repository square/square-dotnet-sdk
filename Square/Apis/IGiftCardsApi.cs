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
    /// IGiftCardsApi.
    /// </summary>
    public interface IGiftCardsApi
    {
        /// <summary>
        /// Lists all gift cards. You can specify optional filters to retrieve .
        /// a subset of the gift cards..
        /// </summary>
        /// <param name="type">Optional parameter: If a type is provided, gift cards of this type are returned  (see [GiftCardType]($m/GiftCardType)). If no type is provided, it returns gift cards of all types..</param>
        /// <param name="state">Optional parameter: If the state is provided, it returns the gift cards in the specified state  (see [GiftCardStatus]($m/GiftCardStatus)). Otherwise, it returns the gift cards of all states..</param>
        /// <param name="limit">Optional parameter: If a value is provided, it returns only that number of results per page. The maximum number of results allowed per page is 50. The default value is 30..</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this cursor to retrieve the next set of results for the original query. If a cursor is not provided, it returns the first page of the results.  For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination)..</param>
        /// <param name="customerId">Optional parameter: If a value is provided, returns only the gift cards linked to the specified customer.</param>
        /// <returns>Returns the Models.ListGiftCardsResponse response from the API call.</returns>
        Models.ListGiftCardsResponse ListGiftCards(
                string type = null,
                string state = null,
                int? limit = null,
                string cursor = null,
                string customerId = null);

        /// <summary>
        /// Lists all gift cards. You can specify optional filters to retrieve .
        /// a subset of the gift cards..
        /// </summary>
        /// <param name="type">Optional parameter: If a type is provided, gift cards of this type are returned  (see [GiftCardType]($m/GiftCardType)). If no type is provided, it returns gift cards of all types..</param>
        /// <param name="state">Optional parameter: If the state is provided, it returns the gift cards in the specified state  (see [GiftCardStatus]($m/GiftCardStatus)). Otherwise, it returns the gift cards of all states..</param>
        /// <param name="limit">Optional parameter: If a value is provided, it returns only that number of results per page. The maximum number of results allowed per page is 50. The default value is 30..</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this cursor to retrieve the next set of results for the original query. If a cursor is not provided, it returns the first page of the results.  For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination)..</param>
        /// <param name="customerId">Optional parameter: If a value is provided, returns only the gift cards linked to the specified customer.</param>
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
        /// Creates a digital gift card. You must activate the gift card before .
        /// it can be used. For more information, see .
        /// [Selling gift cards](https://developer.squareup.com/docs/gift-cards/using-gift-cards-api#selling-square-gift-cards)..
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateGiftCardResponse response from the API call.</returns>
        Models.CreateGiftCardResponse CreateGiftCard(
                Models.CreateGiftCardRequest body);

        /// <summary>
        /// Creates a digital gift card. You must activate the gift card before .
        /// it can be used. For more information, see .
        /// [Selling gift cards](https://developer.squareup.com/docs/gift-cards/using-gift-cards-api#selling-square-gift-cards)..
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateGiftCardResponse response from the API call.</returns>
        Task<Models.CreateGiftCardResponse> CreateGiftCardAsync(
                Models.CreateGiftCardRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a gift card using the gift card account number (GAN)..
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.RetrieveGiftCardFromGANResponse response from the API call.</returns>
        Models.RetrieveGiftCardFromGANResponse RetrieveGiftCardFromGAN(
                Models.RetrieveGiftCardFromGANRequest body);

        /// <summary>
        /// Retrieves a gift card using the gift card account number (GAN)..
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveGiftCardFromGANResponse response from the API call.</returns>
        Task<Models.RetrieveGiftCardFromGANResponse> RetrieveGiftCardFromGANAsync(
                Models.RetrieveGiftCardFromGANRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a gift card using a nonce (a secure token) that represents the gift card..
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.RetrieveGiftCardFromNonceResponse response from the API call.</returns>
        Models.RetrieveGiftCardFromNonceResponse RetrieveGiftCardFromNonce(
                Models.RetrieveGiftCardFromNonceRequest body);

        /// <summary>
        /// Retrieves a gift card using a nonce (a secure token) that represents the gift card..
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveGiftCardFromNonceResponse response from the API call.</returns>
        Task<Models.RetrieveGiftCardFromNonceResponse> RetrieveGiftCardFromNonceAsync(
                Models.RetrieveGiftCardFromNonceRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Links a customer to a gift card.
        /// </summary>
        /// <param name="giftCardId">Required parameter: The ID of the gift card to link..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.LinkCustomerToGiftCardResponse response from the API call.</returns>
        Models.LinkCustomerToGiftCardResponse LinkCustomerToGiftCard(
                string giftCardId,
                Models.LinkCustomerToGiftCardRequest body);

        /// <summary>
        /// Links a customer to a gift card.
        /// </summary>
        /// <param name="giftCardId">Required parameter: The ID of the gift card to link..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.LinkCustomerToGiftCardResponse response from the API call.</returns>
        Task<Models.LinkCustomerToGiftCardResponse> LinkCustomerToGiftCardAsync(
                string giftCardId,
                Models.LinkCustomerToGiftCardRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Unlinks a customer from a gift card.
        /// </summary>
        /// <param name="giftCardId">Required parameter: Example: .</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UnlinkCustomerFromGiftCardResponse response from the API call.</returns>
        Models.UnlinkCustomerFromGiftCardResponse UnlinkCustomerFromGiftCard(
                string giftCardId,
                Models.UnlinkCustomerFromGiftCardRequest body);

        /// <summary>
        /// Unlinks a customer from a gift card.
        /// </summary>
        /// <param name="giftCardId">Required parameter: Example: .</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UnlinkCustomerFromGiftCardResponse response from the API call.</returns>
        Task<Models.UnlinkCustomerFromGiftCardResponse> UnlinkCustomerFromGiftCardAsync(
                string giftCardId,
                Models.UnlinkCustomerFromGiftCardRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a gift card using its ID..
        /// </summary>
        /// <param name="id">Required parameter: The ID of the gift card to retrieve..</param>
        /// <returns>Returns the Models.RetrieveGiftCardResponse response from the API call.</returns>
        Models.RetrieveGiftCardResponse RetrieveGiftCard(
                string id);

        /// <summary>
        /// Retrieves a gift card using its ID..
        /// </summary>
        /// <param name="id">Required parameter: The ID of the gift card to retrieve..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveGiftCardResponse response from the API call.</returns>
        Task<Models.RetrieveGiftCardResponse> RetrieveGiftCardAsync(
                string id,
                CancellationToken cancellationToken = default);
    }
}