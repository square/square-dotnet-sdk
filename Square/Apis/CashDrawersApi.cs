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
    using Square.Authentication;
    using Square.Http.Client;
    using Square.Utilities;
    using System.Net.Http;

    /// <summary>
    /// CashDrawersApi.
    /// </summary>
    internal class CashDrawersApi : BaseApi, ICashDrawersApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CashDrawersApi"/> class.
        /// </summary>
        internal CashDrawersApi(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// Provides the details for all of the cash drawer shifts for a location.
        /// in a date range.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to query for a list of cash drawer shifts..</param>
        /// <param name="sortOrder">Optional parameter: The order in which cash drawer shifts are listed in the response, based on their opened_at field. Default value: ASC.</param>
        /// <param name="beginTime">Optional parameter: The inclusive start time of the query on opened_at, in ISO 8601 format..</param>
        /// <param name="endTime">Optional parameter: The exclusive end date of the query on opened_at, in ISO 8601 format..</param>
        /// <param name="limit">Optional parameter: Number of cash drawer shift events in a page of results (200 by default, 1000 max)..</param>
        /// <param name="cursor">Optional parameter: Opaque cursor for fetching the next page of results..</param>
        /// <returns>Returns the Models.ListCashDrawerShiftsResponse response from the API call.</returns>
        public Models.ListCashDrawerShiftsResponse ListCashDrawerShifts(
                string locationId,
                string sortOrder = null,
                string beginTime = null,
                string endTime = null,
                int? limit = null,
                string cursor = null)
            => CoreHelper.RunTask(ListCashDrawerShiftsAsync(locationId, sortOrder, beginTime, endTime, limit, cursor));

        /// <summary>
        /// Provides the details for all of the cash drawer shifts for a location.
        /// in a date range.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to query for a list of cash drawer shifts..</param>
        /// <param name="sortOrder">Optional parameter: The order in which cash drawer shifts are listed in the response, based on their opened_at field. Default value: ASC.</param>
        /// <param name="beginTime">Optional parameter: The inclusive start time of the query on opened_at, in ISO 8601 format..</param>
        /// <param name="endTime">Optional parameter: The exclusive end date of the query on opened_at, in ISO 8601 format..</param>
        /// <param name="limit">Optional parameter: Number of cash drawer shift events in a page of results (200 by default, 1000 max)..</param>
        /// <param name="cursor">Optional parameter: Opaque cursor for fetching the next page of results..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListCashDrawerShiftsResponse response from the API call.</returns>
        public async Task<Models.ListCashDrawerShiftsResponse> ListCashDrawerShiftsAsync(
                string locationId,
                string sortOrder = null,
                string beginTime = null,
                string endTime = null,
                int? limit = null,
                string cursor = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ListCashDrawerShiftsResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/cash-drawers/shifts")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("location_id", locationId))
                      .Query(_query => _query.Setup("sort_order", sortOrder))
                      .Query(_query => _query.Setup("begin_time", beginTime))
                      .Query(_query => _query.Setup("end_time", endTime))
                      .Query(_query => _query.Setup("limit", limit))
                      .Query(_query => _query.Setup("cursor", cursor))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context))
                  .Deserializer(_response => ApiHelper.JsonDeserialize<Models.ListCashDrawerShiftsResponse>(_response)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Provides the summary details for a single cash drawer shift. See.
        /// [ListCashDrawerShiftEvents]($e/CashDrawers/ListCashDrawerShiftEvents) for a list of cash drawer shift events.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to retrieve cash drawer shifts from..</param>
        /// <param name="shiftId">Required parameter: The shift ID..</param>
        /// <returns>Returns the Models.RetrieveCashDrawerShiftResponse response from the API call.</returns>
        public Models.RetrieveCashDrawerShiftResponse RetrieveCashDrawerShift(
                string locationId,
                string shiftId)
            => CoreHelper.RunTask(RetrieveCashDrawerShiftAsync(locationId, shiftId));

        /// <summary>
        /// Provides the summary details for a single cash drawer shift. See.
        /// [ListCashDrawerShiftEvents]($e/CashDrawers/ListCashDrawerShiftEvents) for a list of cash drawer shift events.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to retrieve cash drawer shifts from..</param>
        /// <param name="shiftId">Required parameter: The shift ID..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveCashDrawerShiftResponse response from the API call.</returns>
        public async Task<Models.RetrieveCashDrawerShiftResponse> RetrieveCashDrawerShiftAsync(
                string locationId,
                string shiftId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.RetrieveCashDrawerShiftResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/cash-drawers/shifts/{shift_id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("location_id", locationId))
                      .Template(_template => _template.Setup("shift_id", shiftId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context))
                  .Deserializer(_response => ApiHelper.JsonDeserialize<Models.RetrieveCashDrawerShiftResponse>(_response)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Provides a paginated list of events for a single cash drawer shift.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to list cash drawer shifts for..</param>
        /// <param name="shiftId">Required parameter: The shift ID..</param>
        /// <param name="limit">Optional parameter: Number of resources to be returned in a page of results (200 by default, 1000 max)..</param>
        /// <param name="cursor">Optional parameter: Opaque cursor for fetching the next page of results..</param>
        /// <returns>Returns the Models.ListCashDrawerShiftEventsResponse response from the API call.</returns>
        public Models.ListCashDrawerShiftEventsResponse ListCashDrawerShiftEvents(
                string locationId,
                string shiftId,
                int? limit = null,
                string cursor = null)
            => CoreHelper.RunTask(ListCashDrawerShiftEventsAsync(locationId, shiftId, limit, cursor));

        /// <summary>
        /// Provides a paginated list of events for a single cash drawer shift.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to list cash drawer shifts for..</param>
        /// <param name="shiftId">Required parameter: The shift ID..</param>
        /// <param name="limit">Optional parameter: Number of resources to be returned in a page of results (200 by default, 1000 max)..</param>
        /// <param name="cursor">Optional parameter: Opaque cursor for fetching the next page of results..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListCashDrawerShiftEventsResponse response from the API call.</returns>
        public async Task<Models.ListCashDrawerShiftEventsResponse> ListCashDrawerShiftEventsAsync(
                string locationId,
                string shiftId,
                int? limit = null,
                string cursor = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ListCashDrawerShiftEventsResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/cash-drawers/shifts/{shift_id}/events")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("location_id", locationId))
                      .Template(_template => _template.Setup("shift_id", shiftId))
                      .Query(_query => _query.Setup("limit", limit))
                      .Query(_query => _query.Setup("cursor", cursor))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context))
                  .Deserializer(_response => ApiHelper.JsonDeserialize<Models.ListCashDrawerShiftEventsResponse>(_response)))
              .ExecuteAsync(cancellationToken);
    }
}