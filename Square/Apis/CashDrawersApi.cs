using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;
using Square;
using Square.Utilities;
using Square.Http.Request;
using Square.Http.Response;
using Square.Http.Client;
using Square.Authentication;
using Square.Exceptions;

namespace Square.Apis
{
    internal class CashDrawersApi: BaseApi, ICashDrawersApi
    {
        internal CashDrawersApi(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null) :
            base(config, httpClient, authManagers, httpCallBack)
        { }

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
        public Models.ListCashDrawerShiftsResponse ListCashDrawerShifts(
                string locationId,
                string sortOrder = null,
                string beginTime = null,
                string endTime = null,
                int? limit = null,
                string cursor = null)
        {
            Task<Models.ListCashDrawerShiftsResponse> t = ListCashDrawerShiftsAsync(locationId, sortOrder, beginTime, endTime, limit, cursor);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

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
        public async Task<Models.ListCashDrawerShiftsResponse> ListCashDrawerShiftsAsync(
                string locationId,
                string sortOrder = null,
                string beginTime = null,
                string endTime = null,
                int? limit = null,
                string cursor = null, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/cash-drawers/shifts");

            //process optional query parameters
            ApiHelper.AppendUrlWithQueryParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "location_id", locationId },
                { "sort_order", sortOrder },
                { "begin_time", beginTime },
                { "end_time", endTime },
                { "limit", limit },
                { "cursor", cursor }
            }, ArrayDeserializationFormat, ParameterSeparator);

            //validate and preprocess url
            string _queryUrl = ApiHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string, string>()
            { 
                { "user-agent", userAgent },
                { "accept", "application/json" },
                { "Square-Version", config.SquareVersion }
            };

            //prepare the API call request to fetch the response
            HttpRequest _request = GetClientInstance().Get(_queryUrl,_headers);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnBeforeHttpRequestEventHandler(GetClientInstance(), _request);
            }

            _request = await authManagers["default"].ApplyAsync(_request).ConfigureAwait(false);

            //invoke request and get response
            HttpStringResponse _response = await GetClientInstance().ExecuteAsStringAsync(_request, cancellationToken).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnAfterHttpResponseEventHandler(GetClientInstance(), _response);
            }

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            var _responseModel = ApiHelper.JsonDeserialize<Models.ListCashDrawerShiftsResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Provides the summary details for a single cash drawer shift. See
        /// RetrieveCashDrawerShiftEvents for a list of cash drawer shift events.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to retrieve cash drawer shifts from.</param>
        /// <param name="shiftId">Required parameter: The shift ID.</param>
        /// <return>Returns the Models.RetrieveCashDrawerShiftResponse response from the API call</return>
        public Models.RetrieveCashDrawerShiftResponse RetrieveCashDrawerShift(string locationId, string shiftId)
        {
            Task<Models.RetrieveCashDrawerShiftResponse> t = RetrieveCashDrawerShiftAsync(locationId, shiftId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Provides the summary details for a single cash drawer shift. See
        /// RetrieveCashDrawerShiftEvents for a list of cash drawer shift events.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to retrieve cash drawer shifts from.</param>
        /// <param name="shiftId">Required parameter: The shift ID.</param>
        /// <return>Returns the Models.RetrieveCashDrawerShiftResponse response from the API call</return>
        public async Task<Models.RetrieveCashDrawerShiftResponse> RetrieveCashDrawerShiftAsync(string locationId, string shiftId, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/cash-drawers/shifts/{shift_id}");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "shift_id", shiftId }
            });

            //process optional query parameters
            ApiHelper.AppendUrlWithQueryParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "location_id", locationId }
            }, ArrayDeserializationFormat, ParameterSeparator);

            //validate and preprocess url
            string _queryUrl = ApiHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string, string>()
            { 
                { "user-agent", userAgent },
                { "accept", "application/json" },
                { "Square-Version", config.SquareVersion }
            };

            //prepare the API call request to fetch the response
            HttpRequest _request = GetClientInstance().Get(_queryUrl,_headers);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnBeforeHttpRequestEventHandler(GetClientInstance(), _request);
            }

            _request = await authManagers["default"].ApplyAsync(_request).ConfigureAwait(false);

            //invoke request and get response
            HttpStringResponse _response = await GetClientInstance().ExecuteAsStringAsync(_request, cancellationToken).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnAfterHttpResponseEventHandler(GetClientInstance(), _response);
            }

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            var _responseModel = ApiHelper.JsonDeserialize<Models.RetrieveCashDrawerShiftResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Provides a paginated list of events for a single cash drawer shift.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to list cash drawer shifts for.</param>
        /// <param name="shiftId">Required parameter: The shift ID.</param>
        /// <param name="limit">Optional parameter: Number of resources to be returned in a page of results (200 by default, 1000 max).</param>
        /// <param name="cursor">Optional parameter: Opaque cursor for fetching the next page of results.</param>
        /// <return>Returns the Models.ListCashDrawerShiftEventsResponse response from the API call</return>
        public Models.ListCashDrawerShiftEventsResponse ListCashDrawerShiftEvents(
                string locationId,
                string shiftId,
                int? limit = null,
                string cursor = null)
        {
            Task<Models.ListCashDrawerShiftEventsResponse> t = ListCashDrawerShiftEventsAsync(locationId, shiftId, limit, cursor);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Provides a paginated list of events for a single cash drawer shift.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to list cash drawer shifts for.</param>
        /// <param name="shiftId">Required parameter: The shift ID.</param>
        /// <param name="limit">Optional parameter: Number of resources to be returned in a page of results (200 by default, 1000 max).</param>
        /// <param name="cursor">Optional parameter: Opaque cursor for fetching the next page of results.</param>
        /// <return>Returns the Models.ListCashDrawerShiftEventsResponse response from the API call</return>
        public async Task<Models.ListCashDrawerShiftEventsResponse> ListCashDrawerShiftEventsAsync(
                string locationId,
                string shiftId,
                int? limit = null,
                string cursor = null, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/cash-drawers/shifts/{shift_id}/events");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "shift_id", shiftId }
            });

            //process optional query parameters
            ApiHelper.AppendUrlWithQueryParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "location_id", locationId },
                { "limit", limit },
                { "cursor", cursor }
            }, ArrayDeserializationFormat, ParameterSeparator);

            //validate and preprocess url
            string _queryUrl = ApiHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string, string>()
            { 
                { "user-agent", userAgent },
                { "accept", "application/json" },
                { "Square-Version", config.SquareVersion }
            };

            //prepare the API call request to fetch the response
            HttpRequest _request = GetClientInstance().Get(_queryUrl,_headers);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnBeforeHttpRequestEventHandler(GetClientInstance(), _request);
            }

            _request = await authManagers["default"].ApplyAsync(_request).ConfigureAwait(false);

            //invoke request and get response
            HttpStringResponse _response = await GetClientInstance().ExecuteAsStringAsync(_request, cancellationToken).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnAfterHttpResponseEventHandler(GetClientInstance(), _response);
            }

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            var _responseModel = ApiHelper.JsonDeserialize<Models.ListCashDrawerShiftEventsResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

    }
}