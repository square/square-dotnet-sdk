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
    using Square.Http.Request.Configuration;
    using Square.Http.Response;
    using Square.Utilities;

    /// <summary>
    /// PayoutsApi.
    /// </summary>
    internal class PayoutsApi : BaseApi, IPayoutsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PayoutsApi"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal PayoutsApi(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// Retrieves a list of all payouts for the default location. .
        /// You can filter payouts by location ID, status, time range, and order them in ascending or descending order. .
        /// To call this endpoint, set `PAYOUTS_READ` for the OAuth scope.
        /// </summary>
        /// <param name="locationId">Optional parameter: The ID of the location for which to list the payouts.  By default, payouts are returned for the default (main) location associated with the seller..</param>
        /// <param name="status">Optional parameter: If provided, only payouts with the given status are returned..</param>
        /// <param name="beginTime">Optional parameter: The timestamp for the beginning of the payout creation time, in RFC 3339 format. Inclusive. Default: The current time minus one year..</param>
        /// <param name="endTime">Optional parameter: The timestamp for the end of the payout creation time, in RFC 3339 format. Default: The current time..</param>
        /// <param name="sortOrder">Optional parameter: The order in which payouts are listed..</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this cursor to retrieve the next set of results for the original query. For more information, see [Pagination](https://developer.squareup.com/docs/basics/api101/pagination). If request parameters change between requests, subsequent results may contain duplicates or missing records..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to be returned in a single page. It is possible to receive fewer results than the specified limit on a given page. The default value of 100 is also the maximum allowed value. If the provided value is greater than 100, it is ignored and the default value is used instead. Default: `100`.</param>
        /// <returns>Returns the Models.ListPayoutsResponse response from the API call.</returns>
        public Models.ListPayoutsResponse ListPayouts(
                string locationId = null,
                string status = null,
                string beginTime = null,
                string endTime = null,
                string sortOrder = null,
                string cursor = null,
                int? limit = null)
        {
            Task<Models.ListPayoutsResponse> t = this.ListPayoutsAsync(locationId, status, beginTime, endTime, sortOrder, cursor, limit);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Retrieves a list of all payouts for the default location. .
        /// You can filter payouts by location ID, status, time range, and order them in ascending or descending order. .
        /// To call this endpoint, set `PAYOUTS_READ` for the OAuth scope.
        /// </summary>
        /// <param name="locationId">Optional parameter: The ID of the location for which to list the payouts.  By default, payouts are returned for the default (main) location associated with the seller..</param>
        /// <param name="status">Optional parameter: If provided, only payouts with the given status are returned..</param>
        /// <param name="beginTime">Optional parameter: The timestamp for the beginning of the payout creation time, in RFC 3339 format. Inclusive. Default: The current time minus one year..</param>
        /// <param name="endTime">Optional parameter: The timestamp for the end of the payout creation time, in RFC 3339 format. Default: The current time..</param>
        /// <param name="sortOrder">Optional parameter: The order in which payouts are listed..</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this cursor to retrieve the next set of results for the original query. For more information, see [Pagination](https://developer.squareup.com/docs/basics/api101/pagination). If request parameters change between requests, subsequent results may contain duplicates or missing records..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to be returned in a single page. It is possible to receive fewer results than the specified limit on a given page. The default value of 100 is also the maximum allowed value. If the provided value is greater than 100, it is ignored and the default value is used instead. Default: `100`.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListPayoutsResponse response from the API call.</returns>
        public async Task<Models.ListPayoutsResponse> ListPayoutsAsync(
                string locationId = null,
                string status = null,
                string beginTime = null,
                string endTime = null,
                string sortOrder = null,
                string cursor = null,
                int? limit = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/payouts");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "location_id", locationId },
                { "status", status },
                { "begin_time", beginTime },
                { "end_time", endTime },
                { "sort_order", sortOrder },
                { "cursor", cursor },
                { "limit", limit },
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
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.ListPayoutsResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Retrieves details of a specific payout identified by a payout ID. .
        /// To call this endpoint, set `PAYOUTS_READ` for the OAuth scope.
        /// </summary>
        /// <param name="payoutId">Required parameter: The ID of the payout to retrieve the information for..</param>
        /// <returns>Returns the Models.GetPayoutResponse response from the API call.</returns>
        public Models.GetPayoutResponse GetPayout(
                string payoutId)
        {
            Task<Models.GetPayoutResponse> t = this.GetPayoutAsync(payoutId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Retrieves details of a specific payout identified by a payout ID. .
        /// To call this endpoint, set `PAYOUTS_READ` for the OAuth scope.
        /// </summary>
        /// <param name="payoutId">Required parameter: The ID of the payout to retrieve the information for..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.GetPayoutResponse response from the API call.</returns>
        public async Task<Models.GetPayoutResponse> GetPayoutAsync(
                string payoutId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/payouts/{payout_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "payout_id", payoutId },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.GetPayoutResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Retrieves a list of all payout entries for a specific payout.
        /// To call this endpoint, set `PAYOUTS_READ` for the OAuth scope.
        /// </summary>
        /// <param name="payoutId">Required parameter: The ID of the payout to retrieve the information for..</param>
        /// <param name="sortOrder">Optional parameter: The order in which payout entries are listed..</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this cursor to retrieve the next set of results for the original query. For more information, see [Pagination](https://developer.squareup.com/docs/basics/api101/pagination). If request parameters change between requests, subsequent results may contain duplicates or missing records..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to be returned in a single page. It is possible to receive fewer results than the specified limit on a given page. The default value of 100 is also the maximum allowed value. If the provided value is greater than 100, it is ignored and the default value is used instead. Default: `100`.</param>
        /// <returns>Returns the Models.ListPayoutEntriesResponse response from the API call.</returns>
        public Models.ListPayoutEntriesResponse ListPayoutEntries(
                string payoutId,
                string sortOrder = null,
                string cursor = null,
                int? limit = null)
        {
            Task<Models.ListPayoutEntriesResponse> t = this.ListPayoutEntriesAsync(payoutId, sortOrder, cursor, limit);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Retrieves a list of all payout entries for a specific payout.
        /// To call this endpoint, set `PAYOUTS_READ` for the OAuth scope.
        /// </summary>
        /// <param name="payoutId">Required parameter: The ID of the payout to retrieve the information for..</param>
        /// <param name="sortOrder">Optional parameter: The order in which payout entries are listed..</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this cursor to retrieve the next set of results for the original query. For more information, see [Pagination](https://developer.squareup.com/docs/basics/api101/pagination). If request parameters change between requests, subsequent results may contain duplicates or missing records..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to be returned in a single page. It is possible to receive fewer results than the specified limit on a given page. The default value of 100 is also the maximum allowed value. If the provided value is greater than 100, it is ignored and the default value is used instead. Default: `100`.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListPayoutEntriesResponse response from the API call.</returns>
        public async Task<Models.ListPayoutEntriesResponse> ListPayoutEntriesAsync(
                string payoutId,
                string sortOrder = null,
                string cursor = null,
                int? limit = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/payouts/{payout_id}/payout-entries");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "payout_id", payoutId },
            });

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "sort_order", sortOrder },
                { "cursor", cursor },
                { "limit", limit },
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
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.ListPayoutEntriesResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }
    }
}