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
    public interface ICashDrawersApi
    {
        /// <summary>
        /// Provides the details for all of the cash drawer shifts for a location
        /// in a date range.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to query for a list of cash drawer shifts.</param>
        /// <param name="sortOrder">Optional parameter: The order in which cash drawer shifts are listed in the response, based on their opened_at field. Default value: ASC</param>
        /// <param name="beginTime">Optional parameter: The inclusive start time of the query on opened_at, in ISO 8601 format.</param>
        /// <param name="endTime">Optional parameter: The exclusive end date of the query on opened_at, in ISO 8601 format.</param>
        /// <param name="limit">Optional parameter: Number of cash drawer shift events in a page of results (200 by default, 1000 max).</param>
        /// <param name="cursor">Optional parameter: Opaque cursor for fetching the next page of results.</param>
        /// <return>Returns the Models.ListCashDrawerShiftsResponse response from the API call</return>
        Models.ListCashDrawerShiftsResponse ListCashDrawerShifts(
                string locationId,
                string sortOrder = null,
                string beginTime = null,
                string endTime = null,
                int? limit = null,
                string cursor = null);

        /// <summary>
        /// Provides the details for all of the cash drawer shifts for a location
        /// in a date range.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to query for a list of cash drawer shifts.</param>
        /// <param name="sortOrder">Optional parameter: The order in which cash drawer shifts are listed in the response, based on their opened_at field. Default value: ASC</param>
        /// <param name="beginTime">Optional parameter: The inclusive start time of the query on opened_at, in ISO 8601 format.</param>
        /// <param name="endTime">Optional parameter: The exclusive end date of the query on opened_at, in ISO 8601 format.</param>
        /// <param name="limit">Optional parameter: Number of cash drawer shift events in a page of results (200 by default, 1000 max).</param>
        /// <param name="cursor">Optional parameter: Opaque cursor for fetching the next page of results.</param>
        /// <return>Returns the Models.ListCashDrawerShiftsResponse response from the API call</return>
        Task<Models.ListCashDrawerShiftsResponse> ListCashDrawerShiftsAsync(
                string locationId,
                string sortOrder = null,
                string beginTime = null,
                string endTime = null,
                int? limit = null,
                string cursor = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Provides the summary details for a single cash drawer shift. See
        /// RetrieveCashDrawerShiftEvents for a list of cash drawer shift events.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to retrieve cash drawer shifts from.</param>
        /// <param name="shiftId">Required parameter: The shift ID.</param>
        /// <return>Returns the Models.RetrieveCashDrawerShiftResponse response from the API call</return>
        Models.RetrieveCashDrawerShiftResponse RetrieveCashDrawerShift(string locationId, string shiftId);

        /// <summary>
        /// Provides the summary details for a single cash drawer shift. See
        /// RetrieveCashDrawerShiftEvents for a list of cash drawer shift events.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to retrieve cash drawer shifts from.</param>
        /// <param name="shiftId">Required parameter: The shift ID.</param>
        /// <return>Returns the Models.RetrieveCashDrawerShiftResponse response from the API call</return>
        Task<Models.RetrieveCashDrawerShiftResponse> RetrieveCashDrawerShiftAsync(string locationId, string shiftId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Provides a paginated list of events for a single cash drawer shift.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to list cash drawer shifts for.</param>
        /// <param name="shiftId">Required parameter: The shift ID.</param>
        /// <param name="limit">Optional parameter: Number of resources to be returned in a page of results (200 by default, 1000 max).</param>
        /// <param name="cursor">Optional parameter: Opaque cursor for fetching the next page of results.</param>
        /// <return>Returns the Models.ListCashDrawerShiftEventsResponse response from the API call</return>
        Models.ListCashDrawerShiftEventsResponse ListCashDrawerShiftEvents(
                string locationId,
                string shiftId,
                int? limit = null,
                string cursor = null);

        /// <summary>
        /// Provides a paginated list of events for a single cash drawer shift.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to list cash drawer shifts for.</param>
        /// <param name="shiftId">Required parameter: The shift ID.</param>
        /// <param name="limit">Optional parameter: Number of resources to be returned in a page of results (200 by default, 1000 max).</param>
        /// <param name="cursor">Optional parameter: Opaque cursor for fetching the next page of results.</param>
        /// <return>Returns the Models.ListCashDrawerShiftEventsResponse response from the API call</return>
        Task<Models.ListCashDrawerShiftEventsResponse> ListCashDrawerShiftEventsAsync(
                string locationId,
                string shiftId,
                int? limit = null,
                string cursor = null, CancellationToken cancellationToken = default);

    }
}