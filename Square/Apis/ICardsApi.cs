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
    /// ICardsApi.
    /// </summary>
    public interface ICardsApi
    {
        /// <summary>
        /// Retrieves a list of cards owned by the account making the request..
        /// A max of 25 cards will be returned..
        /// </summary>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for your original query.  See [Pagination](https://developer.squareup.com/docs/basics/api101/pagination) for more information..</param>
        /// <param name="customerId">Optional parameter: Limit results to cards associated with the customer supplied. By default, all cards owned by the merchant are returned..</param>
        /// <param name="includeDisabled">Optional parameter: Includes disabled cards. By default, all enabled cards owned by the merchant are returned..</param>
        /// <param name="referenceId">Optional parameter: Limit results to cards associated with the reference_id supplied..</param>
        /// <param name="sortOrder">Optional parameter: Sorts the returned list by when the card was created with the specified order. This field defaults to ASC..</param>
        /// <returns>Returns the Models.ListCardsResponse response from the API call.</returns>
        Models.ListCardsResponse ListCards(
                string cursor = null,
                string customerId = null,
                bool? includeDisabled = false,
                string referenceId = null,
                string sortOrder = null);

        /// <summary>
        /// Retrieves a list of cards owned by the account making the request..
        /// A max of 25 cards will be returned..
        /// </summary>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for your original query.  See [Pagination](https://developer.squareup.com/docs/basics/api101/pagination) for more information..</param>
        /// <param name="customerId">Optional parameter: Limit results to cards associated with the customer supplied. By default, all cards owned by the merchant are returned..</param>
        /// <param name="includeDisabled">Optional parameter: Includes disabled cards. By default, all enabled cards owned by the merchant are returned..</param>
        /// <param name="referenceId">Optional parameter: Limit results to cards associated with the reference_id supplied..</param>
        /// <param name="sortOrder">Optional parameter: Sorts the returned list by when the card was created with the specified order. This field defaults to ASC..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListCardsResponse response from the API call.</returns>
        Task<Models.ListCardsResponse> ListCardsAsync(
                string cursor = null,
                string customerId = null,
                bool? includeDisabled = false,
                string referenceId = null,
                string sortOrder = null,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds a card on file to an existing merchant..
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateCardResponse response from the API call.</returns>
        Models.CreateCardResponse CreateCard(
                Models.CreateCardRequest body);

        /// <summary>
        /// Adds a card on file to an existing merchant..
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateCardResponse response from the API call.</returns>
        Task<Models.CreateCardResponse> CreateCardAsync(
                Models.CreateCardRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves details for a specific Card..
        /// </summary>
        /// <param name="cardId">Required parameter: Unique ID for the desired Card..</param>
        /// <returns>Returns the Models.RetrieveCardResponse response from the API call.</returns>
        Models.RetrieveCardResponse RetrieveCard(
                string cardId);

        /// <summary>
        /// Retrieves details for a specific Card..
        /// </summary>
        /// <param name="cardId">Required parameter: Unique ID for the desired Card..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveCardResponse response from the API call.</returns>
        Task<Models.RetrieveCardResponse> RetrieveCardAsync(
                string cardId,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Disables the card, preventing any further updates or charges..
        /// Disabling an already disabled card is allowed but has no effect..
        /// </summary>
        /// <param name="cardId">Required parameter: Unique ID for the desired Card..</param>
        /// <returns>Returns the Models.DisableCardResponse response from the API call.</returns>
        Models.DisableCardResponse DisableCard(
                string cardId);

        /// <summary>
        /// Disables the card, preventing any further updates or charges..
        /// Disabling an already disabled card is allowed but has no effect..
        /// </summary>
        /// <param name="cardId">Required parameter: Unique ID for the desired Card..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.DisableCardResponse response from the API call.</returns>
        Task<Models.DisableCardResponse> DisableCardAsync(
                string cardId,
                CancellationToken cancellationToken = default);
    }
}