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
    /// CustomerSegmentsApi.
    /// </summary>
    internal class CustomerSegmentsApi : BaseApi, ICustomerSegmentsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerSegmentsApi"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal CustomerSegmentsApi(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// Retrieves the list of customer segments of a business.
        /// </summary>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by previous calls to `ListCustomerSegments`. This cursor is used to retrieve the next set of query results.  For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to return in a single page. This limit is advisory. The response might contain more or fewer results. If the specified limit is less than 1 or greater than 50, Square returns a `400 VALUE_TOO_LOW` or `400 VALUE_TOO_HIGH` error. The default value is 50.  For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <returns>Returns the Models.ListCustomerSegmentsResponse response from the API call.</returns>
        public Models.ListCustomerSegmentsResponse ListCustomerSegments(
                string cursor = null,
                int? limit = null)
        {
            Task<Models.ListCustomerSegmentsResponse> t = this.ListCustomerSegmentsAsync(cursor, limit);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Retrieves the list of customer segments of a business.
        /// </summary>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by previous calls to `ListCustomerSegments`. This cursor is used to retrieve the next set of query results.  For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to return in a single page. This limit is advisory. The response might contain more or fewer results. If the specified limit is less than 1 or greater than 50, Square returns a `400 VALUE_TOO_LOW` or `400 VALUE_TOO_HIGH` error. The default value is 50.  For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListCustomerSegmentsResponse response from the API call.</returns>
        public async Task<Models.ListCustomerSegmentsResponse> ListCustomerSegmentsAsync(
                string cursor = null,
                int? limit = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/customers/segments");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
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

            var responseModel = ApiHelper.JsonDeserialize<Models.ListCustomerSegmentsResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Retrieves a specific customer segment as identified by the `segment_id` value.
        /// </summary>
        /// <param name="segmentId">Required parameter: The Square-issued ID of the customer segment..</param>
        /// <returns>Returns the Models.RetrieveCustomerSegmentResponse response from the API call.</returns>
        public Models.RetrieveCustomerSegmentResponse RetrieveCustomerSegment(
                string segmentId)
        {
            Task<Models.RetrieveCustomerSegmentResponse> t = this.RetrieveCustomerSegmentAsync(segmentId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Retrieves a specific customer segment as identified by the `segment_id` value.
        /// </summary>
        /// <param name="segmentId">Required parameter: The Square-issued ID of the customer segment..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveCustomerSegmentResponse response from the API call.</returns>
        public async Task<Models.RetrieveCustomerSegmentResponse> RetrieveCustomerSegmentAsync(
                string segmentId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/customers/segments/{segment_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "segment_id", segmentId },
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

            var responseModel = ApiHelper.JsonDeserialize<Models.RetrieveCustomerSegmentResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }
    }
}