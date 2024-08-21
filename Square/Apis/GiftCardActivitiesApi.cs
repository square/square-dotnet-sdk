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
    /// GiftCardActivitiesApi.
    /// </summary>
    internal class GiftCardActivitiesApi : BaseApi, IGiftCardActivitiesApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GiftCardActivitiesApi"/> class.
        /// </summary>
        internal GiftCardActivitiesApi(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// Lists gift card activities. By default, you get gift card activities for all.
        /// gift cards in the seller's account. You can optionally specify query parameters to.
        /// filter the list. For example, you can get a list of gift card activities for a gift card,.
        /// for all gift cards in a specific region, or for activities within a time window.
        /// </summary>
        /// <param name="giftCardId">Optional parameter: If a gift card ID is provided, the endpoint returns activities related  to the specified gift card. Otherwise, the endpoint returns all gift card activities for  the seller..</param>
        /// <param name="type">Optional parameter: If a [type](entity:GiftCardActivityType) is provided, the endpoint returns gift card activities of the specified type.  Otherwise, the endpoint returns all types of gift card activities..</param>
        /// <param name="locationId">Optional parameter: If a location ID is provided, the endpoint returns gift card activities for the specified location.  Otherwise, the endpoint returns gift card activities for all locations..</param>
        /// <param name="beginTime">Optional parameter: The timestamp for the beginning of the reporting period, in RFC 3339 format. This start time is inclusive. The default value is the current time minus one year..</param>
        /// <param name="endTime">Optional parameter: The timestamp for the end of the reporting period, in RFC 3339 format. This end time is inclusive. The default value is the current time..</param>
        /// <param name="limit">Optional parameter: If a limit is provided, the endpoint returns the specified number  of results (or fewer) per page. The maximum value is 100. The default value is 50. For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination)..</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this cursor to retrieve the next set of results for the original query. If a cursor is not provided, the endpoint returns the first page of the results. For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination)..</param>
        /// <param name="sortOrder">Optional parameter: The order in which the endpoint returns the activities, based on `created_at`. - `ASC` - Oldest to newest. - `DESC` - Newest to oldest (default)..</param>
        /// <returns>Returns the Models.ListGiftCardActivitiesResponse response from the API call.</returns>
        public Models.ListGiftCardActivitiesResponse ListGiftCardActivities(
                string giftCardId = null,
                string type = null,
                string locationId = null,
                string beginTime = null,
                string endTime = null,
                int? limit = null,
                string cursor = null,
                string sortOrder = null)
            => CoreHelper.RunTask(ListGiftCardActivitiesAsync(giftCardId, type, locationId, beginTime, endTime, limit, cursor, sortOrder));

        /// <summary>
        /// Lists gift card activities. By default, you get gift card activities for all.
        /// gift cards in the seller's account. You can optionally specify query parameters to.
        /// filter the list. For example, you can get a list of gift card activities for a gift card,.
        /// for all gift cards in a specific region, or for activities within a time window.
        /// </summary>
        /// <param name="giftCardId">Optional parameter: If a gift card ID is provided, the endpoint returns activities related  to the specified gift card. Otherwise, the endpoint returns all gift card activities for  the seller..</param>
        /// <param name="type">Optional parameter: If a [type](entity:GiftCardActivityType) is provided, the endpoint returns gift card activities of the specified type.  Otherwise, the endpoint returns all types of gift card activities..</param>
        /// <param name="locationId">Optional parameter: If a location ID is provided, the endpoint returns gift card activities for the specified location.  Otherwise, the endpoint returns gift card activities for all locations..</param>
        /// <param name="beginTime">Optional parameter: The timestamp for the beginning of the reporting period, in RFC 3339 format. This start time is inclusive. The default value is the current time minus one year..</param>
        /// <param name="endTime">Optional parameter: The timestamp for the end of the reporting period, in RFC 3339 format. This end time is inclusive. The default value is the current time..</param>
        /// <param name="limit">Optional parameter: If a limit is provided, the endpoint returns the specified number  of results (or fewer) per page. The maximum value is 100. The default value is 50. For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination)..</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this cursor to retrieve the next set of results for the original query. If a cursor is not provided, the endpoint returns the first page of the results. For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination)..</param>
        /// <param name="sortOrder">Optional parameter: The order in which the endpoint returns the activities, based on `created_at`. - `ASC` - Oldest to newest. - `DESC` - Newest to oldest (default)..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListGiftCardActivitiesResponse response from the API call.</returns>
        public async Task<Models.ListGiftCardActivitiesResponse> ListGiftCardActivitiesAsync(
                string giftCardId = null,
                string type = null,
                string locationId = null,
                string beginTime = null,
                string endTime = null,
                int? limit = null,
                string cursor = null,
                string sortOrder = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ListGiftCardActivitiesResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/gift-cards/activities")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("gift_card_id", giftCardId))
                      .Query(_query => _query.Setup("type", type))
                      .Query(_query => _query.Setup("location_id", locationId))
                      .Query(_query => _query.Setup("begin_time", beginTime))
                      .Query(_query => _query.Setup("end_time", endTime))
                      .Query(_query => _query.Setup("limit", limit))
                      .Query(_query => _query.Setup("cursor", cursor))
                      .Query(_query => _query.Setup("sort_order", sortOrder))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Creates a gift card activity to manage the balance or state of a [gift card]($m/GiftCard).
        /// For example, create an `ACTIVATE` activity to activate a gift card with an initial balance before first use.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateGiftCardActivityResponse response from the API call.</returns>
        public Models.CreateGiftCardActivityResponse CreateGiftCardActivity(
                Models.CreateGiftCardActivityRequest body)
            => CoreHelper.RunTask(CreateGiftCardActivityAsync(body));

        /// <summary>
        /// Creates a gift card activity to manage the balance or state of a [gift card]($m/GiftCard).
        /// For example, create an `ACTIVATE` activity to activate a gift card with an initial balance before first use.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateGiftCardActivityResponse response from the API call.</returns>
        public async Task<Models.CreateGiftCardActivityResponse> CreateGiftCardActivityAsync(
                Models.CreateGiftCardActivityRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.CreateGiftCardActivityResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/gift-cards/activities")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);
    }
}