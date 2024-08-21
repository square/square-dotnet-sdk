namespace Square.Apis
{
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

    /// <summary>
    /// CardsApi.
    /// </summary>
    internal class CardsApi : BaseApi, ICardsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CardsApi"/> class.
        /// </summary>
        internal CardsApi(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// Retrieves a list of cards owned by the account making the request.
        /// A max of 25 cards will be returned.
        /// </summary>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for your original query.  See [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination) for more information..</param>
        /// <param name="customerId">Optional parameter: Limit results to cards associated with the customer supplied. By default, all cards owned by the merchant are returned..</param>
        /// <param name="includeDisabled">Optional parameter: Includes disabled cards. By default, all enabled cards owned by the merchant are returned..</param>
        /// <param name="referenceId">Optional parameter: Limit results to cards associated with the reference_id supplied..</param>
        /// <param name="sortOrder">Optional parameter: Sorts the returned list by when the card was created with the specified order. This field defaults to ASC..</param>
        /// <returns>Returns the Models.ListCardsResponse response from the API call.</returns>
        public Models.ListCardsResponse ListCards(
                string cursor = null,
                string customerId = null,
                bool? includeDisabled = false,
                string referenceId = null,
                string sortOrder = null)
            => CoreHelper.RunTask(ListCardsAsync(cursor, customerId, includeDisabled, referenceId, sortOrder));

        /// <summary>
        /// Retrieves a list of cards owned by the account making the request.
        /// A max of 25 cards will be returned.
        /// </summary>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for your original query.  See [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination) for more information..</param>
        /// <param name="customerId">Optional parameter: Limit results to cards associated with the customer supplied. By default, all cards owned by the merchant are returned..</param>
        /// <param name="includeDisabled">Optional parameter: Includes disabled cards. By default, all enabled cards owned by the merchant are returned..</param>
        /// <param name="referenceId">Optional parameter: Limit results to cards associated with the reference_id supplied..</param>
        /// <param name="sortOrder">Optional parameter: Sorts the returned list by when the card was created with the specified order. This field defaults to ASC..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListCardsResponse response from the API call.</returns>
        public async Task<Models.ListCardsResponse> ListCardsAsync(
                string cursor = null,
                string customerId = null,
                bool? includeDisabled = false,
                string referenceId = null,
                string sortOrder = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ListCardsResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/cards")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("cursor", cursor))
                      .Query(_query => _query.Setup("customer_id", customerId))
                      .Query(_query => _query.Setup("include_disabled", includeDisabled ?? false))
                      .Query(_query => _query.Setup("reference_id", referenceId))
                      .Query(_query => _query.Setup("sort_order", sortOrder))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Adds a card on file to an existing merchant.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateCardResponse response from the API call.</returns>
        public Models.CreateCardResponse CreateCard(
                Models.CreateCardRequest body)
            => CoreHelper.RunTask(CreateCardAsync(body));

        /// <summary>
        /// Adds a card on file to an existing merchant.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateCardResponse response from the API call.</returns>
        public async Task<Models.CreateCardResponse> CreateCardAsync(
                Models.CreateCardRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.CreateCardResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/cards")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Retrieves details for a specific Card.
        /// </summary>
        /// <param name="cardId">Required parameter: Unique ID for the desired Card..</param>
        /// <returns>Returns the Models.RetrieveCardResponse response from the API call.</returns>
        public Models.RetrieveCardResponse RetrieveCard(
                string cardId)
            => CoreHelper.RunTask(RetrieveCardAsync(cardId));

        /// <summary>
        /// Retrieves details for a specific Card.
        /// </summary>
        /// <param name="cardId">Required parameter: Unique ID for the desired Card..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveCardResponse response from the API call.</returns>
        public async Task<Models.RetrieveCardResponse> RetrieveCardAsync(
                string cardId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.RetrieveCardResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/cards/{card_id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("card_id", cardId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Disables the card, preventing any further updates or charges.
        /// Disabling an already disabled card is allowed but has no effect.
        /// </summary>
        /// <param name="cardId">Required parameter: Unique ID for the desired Card..</param>
        /// <returns>Returns the Models.DisableCardResponse response from the API call.</returns>
        public Models.DisableCardResponse DisableCard(
                string cardId)
            => CoreHelper.RunTask(DisableCardAsync(cardId));

        /// <summary>
        /// Disables the card, preventing any further updates or charges.
        /// Disabling an already disabled card is allowed but has no effect.
        /// </summary>
        /// <param name="cardId">Required parameter: Unique ID for the desired Card..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.DisableCardResponse response from the API call.</returns>
        public async Task<Models.DisableCardResponse> DisableCardAsync(
                string cardId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.DisableCardResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/cards/{card_id}/disable")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("card_id", cardId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);
    }
}