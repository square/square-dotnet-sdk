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
    /// GiftCardsApi.
    /// </summary>
    internal class GiftCardsApi : BaseApi, IGiftCardsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GiftCardsApi"/> class.
        /// </summary>
        internal GiftCardsApi(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

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
        public Models.ListGiftCardsResponse ListGiftCards(
                string type = null,
                string state = null,
                int? limit = null,
                string cursor = null,
                string customerId = null)
            => CoreHelper.RunTask(ListGiftCardsAsync(type, state, limit, cursor, customerId));

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
        public async Task<Models.ListGiftCardsResponse> ListGiftCardsAsync(
                string type = null,
                string state = null,
                int? limit = null,
                string cursor = null,
                string customerId = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ListGiftCardsResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/gift-cards")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("type", type))
                      .Query(_query => _query.Setup("state", state))
                      .Query(_query => _query.Setup("limit", limit))
                      .Query(_query => _query.Setup("cursor", cursor))
                      .Query(_query => _query.Setup("customer_id", customerId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Creates a digital gift card or registers a physical (plastic) gift card. The resulting gift card.
        /// has a `PENDING` state. To activate a gift card so that it can be redeemed for purchases, call.
        /// [CreateGiftCardActivity]($e/GiftCardActivities/CreateGiftCardActivity) and create an `ACTIVATE`.
        /// activity with the initial balance. Alternatively, you can use [RefundPayment]($e/Refunds/RefundPayment).
        /// to refund a payment to the new gift card.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateGiftCardResponse response from the API call.</returns>
        public Models.CreateGiftCardResponse CreateGiftCard(
                Models.CreateGiftCardRequest body)
            => CoreHelper.RunTask(CreateGiftCardAsync(body));

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
        public async Task<Models.CreateGiftCardResponse> CreateGiftCardAsync(
                Models.CreateGiftCardRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.CreateGiftCardResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/gift-cards")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Retrieves a gift card using the gift card account number (GAN).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.RetrieveGiftCardFromGANResponse response from the API call.</returns>
        public Models.RetrieveGiftCardFromGANResponse RetrieveGiftCardFromGAN(
                Models.RetrieveGiftCardFromGANRequest body)
            => CoreHelper.RunTask(RetrieveGiftCardFromGANAsync(body));

        /// <summary>
        /// Retrieves a gift card using the gift card account number (GAN).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveGiftCardFromGANResponse response from the API call.</returns>
        public async Task<Models.RetrieveGiftCardFromGANResponse> RetrieveGiftCardFromGANAsync(
                Models.RetrieveGiftCardFromGANRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.RetrieveGiftCardFromGANResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/gift-cards/from-gan")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Retrieves a gift card using a secure payment token that represents the gift card.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.RetrieveGiftCardFromNonceResponse response from the API call.</returns>
        public Models.RetrieveGiftCardFromNonceResponse RetrieveGiftCardFromNonce(
                Models.RetrieveGiftCardFromNonceRequest body)
            => CoreHelper.RunTask(RetrieveGiftCardFromNonceAsync(body));

        /// <summary>
        /// Retrieves a gift card using a secure payment token that represents the gift card.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveGiftCardFromNonceResponse response from the API call.</returns>
        public async Task<Models.RetrieveGiftCardFromNonceResponse> RetrieveGiftCardFromNonceAsync(
                Models.RetrieveGiftCardFromNonceRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.RetrieveGiftCardFromNonceResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/gift-cards/from-nonce")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Links a customer to a gift card, which is also referred to as adding a card on file.
        /// </summary>
        /// <param name="giftCardId">Required parameter: The ID of the gift card to be linked..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.LinkCustomerToGiftCardResponse response from the API call.</returns>
        public Models.LinkCustomerToGiftCardResponse LinkCustomerToGiftCard(
                string giftCardId,
                Models.LinkCustomerToGiftCardRequest body)
            => CoreHelper.RunTask(LinkCustomerToGiftCardAsync(giftCardId, body));

        /// <summary>
        /// Links a customer to a gift card, which is also referred to as adding a card on file.
        /// </summary>
        /// <param name="giftCardId">Required parameter: The ID of the gift card to be linked..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.LinkCustomerToGiftCardResponse response from the API call.</returns>
        public async Task<Models.LinkCustomerToGiftCardResponse> LinkCustomerToGiftCardAsync(
                string giftCardId,
                Models.LinkCustomerToGiftCardRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.LinkCustomerToGiftCardResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/gift-cards/{gift_card_id}/link-customer")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Template(_template => _template.Setup("gift_card_id", giftCardId))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Unlinks a customer from a gift card, which is also referred to as removing a card on file.
        /// </summary>
        /// <param name="giftCardId">Required parameter: The ID of the gift card to be unlinked..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UnlinkCustomerFromGiftCardResponse response from the API call.</returns>
        public Models.UnlinkCustomerFromGiftCardResponse UnlinkCustomerFromGiftCard(
                string giftCardId,
                Models.UnlinkCustomerFromGiftCardRequest body)
            => CoreHelper.RunTask(UnlinkCustomerFromGiftCardAsync(giftCardId, body));

        /// <summary>
        /// Unlinks a customer from a gift card, which is also referred to as removing a card on file.
        /// </summary>
        /// <param name="giftCardId">Required parameter: The ID of the gift card to be unlinked..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UnlinkCustomerFromGiftCardResponse response from the API call.</returns>
        public async Task<Models.UnlinkCustomerFromGiftCardResponse> UnlinkCustomerFromGiftCardAsync(
                string giftCardId,
                Models.UnlinkCustomerFromGiftCardRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.UnlinkCustomerFromGiftCardResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/gift-cards/{gift_card_id}/unlink-customer")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Template(_template => _template.Setup("gift_card_id", giftCardId))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Retrieves a gift card using the gift card ID.
        /// </summary>
        /// <param name="id">Required parameter: The ID of the gift card to retrieve..</param>
        /// <returns>Returns the Models.RetrieveGiftCardResponse response from the API call.</returns>
        public Models.RetrieveGiftCardResponse RetrieveGiftCard(
                string id)
            => CoreHelper.RunTask(RetrieveGiftCardAsync(id));

        /// <summary>
        /// Retrieves a gift card using the gift card ID.
        /// </summary>
        /// <param name="id">Required parameter: The ID of the gift card to retrieve..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveGiftCardResponse response from the API call.</returns>
        public async Task<Models.RetrieveGiftCardResponse> RetrieveGiftCardAsync(
                string id,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.RetrieveGiftCardResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/gift-cards/{id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("id", id))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);
    }
}