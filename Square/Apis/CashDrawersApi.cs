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
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Authentication;
    using Square.Http.Client;
    using Square.Http.Request;
    using Square.Http.Response;
    using Square.Utilities;

    /// <summary>
    /// CashDrawersApi.
    /// </summary>
    internal class CashDrawersApi : BaseApi, ICashDrawersApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CashDrawersApi"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal CashDrawersApi(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// Provides the details for all of the cash drawer shifts for a location.
        /// in a date range..
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
        {
            Task<Models.ListCashDrawerShiftsResponse> t = this.ListCashDrawerShiftsAsync(locationId, sortOrder, beginTime, endTime, limit, cursor);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Provides the details for all of the cash drawer shifts for a location.
        /// in a date range..
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
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/cash-drawers/shifts");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "location_id", locationId },
                { "sort_order", sortOrder },
                { "begin_time", beginTime },
                { "end_time", endTime },
                { "limit", limit },
                { "cursor", cursor },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers, queryParameters: queryParams);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.ListCashDrawerShiftsResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Provides the summary details for a single cash drawer shift. See.
        /// [ListCashDrawerShiftEvents]($e/CashDrawers/ListCashDrawerShiftEvents) for a list of cash drawer shift events..
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to retrieve cash drawer shifts from..</param>
        /// <param name="shiftId">Required parameter: The shift ID..</param>
        /// <returns>Returns the Models.RetrieveCashDrawerShiftResponse response from the API call.</returns>
        public Models.RetrieveCashDrawerShiftResponse RetrieveCashDrawerShift(
                string locationId,
                string shiftId)
        {
            Task<Models.RetrieveCashDrawerShiftResponse> t = this.RetrieveCashDrawerShiftAsync(locationId, shiftId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Provides the summary details for a single cash drawer shift. See.
        /// [ListCashDrawerShiftEvents]($e/CashDrawers/ListCashDrawerShiftEvents) for a list of cash drawer shift events..
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to retrieve cash drawer shifts from..</param>
        /// <param name="shiftId">Required parameter: The shift ID..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveCashDrawerShiftResponse response from the API call.</returns>
        public async Task<Models.RetrieveCashDrawerShiftResponse> RetrieveCashDrawerShiftAsync(
                string locationId,
                string shiftId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/cash-drawers/shifts/{shift_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "shift_id", shiftId },
            });

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "location_id", locationId },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers, queryParameters: queryParams);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.RetrieveCashDrawerShiftResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Provides a paginated list of events for a single cash drawer shift..
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
        {
            Task<Models.ListCashDrawerShiftEventsResponse> t = this.ListCashDrawerShiftEventsAsync(locationId, shiftId, limit, cursor);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Provides a paginated list of events for a single cash drawer shift..
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
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/cash-drawers/shifts/{shift_id}/events");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "shift_id", shiftId },
            });

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "location_id", locationId },
                { "limit", limit },
                { "cursor", cursor },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers, queryParameters: queryParams);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.ListCashDrawerShiftEventsResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }
    }
}