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
    /// InventoryApi.
    /// </summary>
    internal class InventoryApi : BaseApi, IInventoryApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryApi"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal InventoryApi(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// Deprecated version of [RetrieveInventoryAdjustment]($e/Inventory/RetrieveInventoryAdjustment) after the endpoint URL.
        /// is updated to conform to the standard convention.
        /// </summary>
        /// <param name="adjustmentId">Required parameter: ID of the [InventoryAdjustment]($m/InventoryAdjustment) to retrieve..</param>
        /// <returns>Returns the Models.RetrieveInventoryAdjustmentResponse response from the API call.</returns>
        [Obsolete]
        public Models.RetrieveInventoryAdjustmentResponse DeprecatedRetrieveInventoryAdjustment(
                string adjustmentId)
        {
            Task<Models.RetrieveInventoryAdjustmentResponse> t = this.DeprecatedRetrieveInventoryAdjustmentAsync(adjustmentId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Deprecated version of [RetrieveInventoryAdjustment]($e/Inventory/RetrieveInventoryAdjustment) after the endpoint URL.
        /// is updated to conform to the standard convention.
        /// </summary>
        /// <param name="adjustmentId">Required parameter: ID of the [InventoryAdjustment]($m/InventoryAdjustment) to retrieve..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveInventoryAdjustmentResponse response from the API call.</returns>
        [Obsolete]
        public async Task<Models.RetrieveInventoryAdjustmentResponse> DeprecatedRetrieveInventoryAdjustmentAsync(
                string adjustmentId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/inventory/adjustment/{adjustment_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "adjustment_id", adjustmentId },
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
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.RetrieveInventoryAdjustmentResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Returns the [InventoryAdjustment]($m/InventoryAdjustment) object.
        /// with the provided `adjustment_id`.
        /// </summary>
        /// <param name="adjustmentId">Required parameter: ID of the [InventoryAdjustment]($m/InventoryAdjustment) to retrieve..</param>
        /// <returns>Returns the Models.RetrieveInventoryAdjustmentResponse response from the API call.</returns>
        public Models.RetrieveInventoryAdjustmentResponse RetrieveInventoryAdjustment(
                string adjustmentId)
        {
            Task<Models.RetrieveInventoryAdjustmentResponse> t = this.RetrieveInventoryAdjustmentAsync(adjustmentId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns the [InventoryAdjustment]($m/InventoryAdjustment) object.
        /// with the provided `adjustment_id`.
        /// </summary>
        /// <param name="adjustmentId">Required parameter: ID of the [InventoryAdjustment]($m/InventoryAdjustment) to retrieve..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveInventoryAdjustmentResponse response from the API call.</returns>
        public async Task<Models.RetrieveInventoryAdjustmentResponse> RetrieveInventoryAdjustmentAsync(
                string adjustmentId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/inventory/adjustments/{adjustment_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "adjustment_id", adjustmentId },
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
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.RetrieveInventoryAdjustmentResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Deprecated version of [BatchChangeInventory]($e/Inventory/BatchChangeInventory) after the endpoint URL.
        /// is updated to conform to the standard convention.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BatchChangeInventoryResponse response from the API call.</returns>
        [Obsolete]
        public Models.BatchChangeInventoryResponse DeprecatedBatchChangeInventory(
                Models.BatchChangeInventoryRequest body)
        {
            Task<Models.BatchChangeInventoryResponse> t = this.DeprecatedBatchChangeInventoryAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Deprecated version of [BatchChangeInventory]($e/Inventory/BatchChangeInventory) after the endpoint URL.
        /// is updated to conform to the standard convention.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BatchChangeInventoryResponse response from the API call.</returns>
        [Obsolete]
        public async Task<Models.BatchChangeInventoryResponse> DeprecatedBatchChangeInventoryAsync(
                Models.BatchChangeInventoryRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/inventory/batch-change");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Content-Type", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

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

            var responseModel = ApiHelper.JsonDeserialize<Models.BatchChangeInventoryResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Deprecated version of [BatchRetrieveInventoryChanges]($e/Inventory/BatchRetrieveInventoryChanges) after the endpoint URL.
        /// is updated to conform to the standard convention.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BatchRetrieveInventoryChangesResponse response from the API call.</returns>
        [Obsolete]
        public Models.BatchRetrieveInventoryChangesResponse DeprecatedBatchRetrieveInventoryChanges(
                Models.BatchRetrieveInventoryChangesRequest body)
        {
            Task<Models.BatchRetrieveInventoryChangesResponse> t = this.DeprecatedBatchRetrieveInventoryChangesAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Deprecated version of [BatchRetrieveInventoryChanges]($e/Inventory/BatchRetrieveInventoryChanges) after the endpoint URL.
        /// is updated to conform to the standard convention.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BatchRetrieveInventoryChangesResponse response from the API call.</returns>
        [Obsolete]
        public async Task<Models.BatchRetrieveInventoryChangesResponse> DeprecatedBatchRetrieveInventoryChangesAsync(
                Models.BatchRetrieveInventoryChangesRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/inventory/batch-retrieve-changes");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Content-Type", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

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

            var responseModel = ApiHelper.JsonDeserialize<Models.BatchRetrieveInventoryChangesResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Deprecated version of [BatchRetrieveInventoryCounts]($e/Inventory/BatchRetrieveInventoryCounts) after the endpoint URL.
        /// is updated to conform to the standard convention.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BatchRetrieveInventoryCountsResponse response from the API call.</returns>
        [Obsolete]
        public Models.BatchRetrieveInventoryCountsResponse DeprecatedBatchRetrieveInventoryCounts(
                Models.BatchRetrieveInventoryCountsRequest body)
        {
            Task<Models.BatchRetrieveInventoryCountsResponse> t = this.DeprecatedBatchRetrieveInventoryCountsAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Deprecated version of [BatchRetrieveInventoryCounts]($e/Inventory/BatchRetrieveInventoryCounts) after the endpoint URL.
        /// is updated to conform to the standard convention.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BatchRetrieveInventoryCountsResponse response from the API call.</returns>
        [Obsolete]
        public async Task<Models.BatchRetrieveInventoryCountsResponse> DeprecatedBatchRetrieveInventoryCountsAsync(
                Models.BatchRetrieveInventoryCountsRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/inventory/batch-retrieve-counts");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Content-Type", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

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

            var responseModel = ApiHelper.JsonDeserialize<Models.BatchRetrieveInventoryCountsResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Applies adjustments and counts to the provided item quantities.
        /// On success: returns the current calculated counts for all objects.
        /// referenced in the request.
        /// On failure: returns a list of related errors.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BatchChangeInventoryResponse response from the API call.</returns>
        public Models.BatchChangeInventoryResponse BatchChangeInventory(
                Models.BatchChangeInventoryRequest body)
        {
            Task<Models.BatchChangeInventoryResponse> t = this.BatchChangeInventoryAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Applies adjustments and counts to the provided item quantities.
        /// On success: returns the current calculated counts for all objects.
        /// referenced in the request.
        /// On failure: returns a list of related errors.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BatchChangeInventoryResponse response from the API call.</returns>
        public async Task<Models.BatchChangeInventoryResponse> BatchChangeInventoryAsync(
                Models.BatchChangeInventoryRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/inventory/changes/batch-create");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Content-Type", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

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

            var responseModel = ApiHelper.JsonDeserialize<Models.BatchChangeInventoryResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Returns historical physical counts and adjustments based on the.
        /// provided filter criteria.
        /// Results are paginated and sorted in ascending order according their.
        /// `occurred_at` timestamp (oldest first).
        /// BatchRetrieveInventoryChanges is a catch-all query endpoint for queries.
        /// that cannot be handled by other, simpler endpoints.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BatchRetrieveInventoryChangesResponse response from the API call.</returns>
        public Models.BatchRetrieveInventoryChangesResponse BatchRetrieveInventoryChanges(
                Models.BatchRetrieveInventoryChangesRequest body)
        {
            Task<Models.BatchRetrieveInventoryChangesResponse> t = this.BatchRetrieveInventoryChangesAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns historical physical counts and adjustments based on the.
        /// provided filter criteria.
        /// Results are paginated and sorted in ascending order according their.
        /// `occurred_at` timestamp (oldest first).
        /// BatchRetrieveInventoryChanges is a catch-all query endpoint for queries.
        /// that cannot be handled by other, simpler endpoints.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BatchRetrieveInventoryChangesResponse response from the API call.</returns>
        public async Task<Models.BatchRetrieveInventoryChangesResponse> BatchRetrieveInventoryChangesAsync(
                Models.BatchRetrieveInventoryChangesRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/inventory/changes/batch-retrieve");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Content-Type", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

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

            var responseModel = ApiHelper.JsonDeserialize<Models.BatchRetrieveInventoryChangesResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Returns current counts for the provided.
        /// [CatalogObject]($m/CatalogObject)s at the requested.
        /// [Location]($m/Location)s.
        /// Results are paginated and sorted in descending order according to their.
        /// `calculated_at` timestamp (newest first).
        /// When `updated_after` is specified, only counts that have changed since that.
        /// time (based on the server timestamp for the most recent change) are.
        /// returned. This allows clients to perform a "sync" operation, for example.
        /// in response to receiving a Webhook notification.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BatchRetrieveInventoryCountsResponse response from the API call.</returns>
        public Models.BatchRetrieveInventoryCountsResponse BatchRetrieveInventoryCounts(
                Models.BatchRetrieveInventoryCountsRequest body)
        {
            Task<Models.BatchRetrieveInventoryCountsResponse> t = this.BatchRetrieveInventoryCountsAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns current counts for the provided.
        /// [CatalogObject]($m/CatalogObject)s at the requested.
        /// [Location]($m/Location)s.
        /// Results are paginated and sorted in descending order according to their.
        /// `calculated_at` timestamp (newest first).
        /// When `updated_after` is specified, only counts that have changed since that.
        /// time (based on the server timestamp for the most recent change) are.
        /// returned. This allows clients to perform a "sync" operation, for example.
        /// in response to receiving a Webhook notification.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BatchRetrieveInventoryCountsResponse response from the API call.</returns>
        public async Task<Models.BatchRetrieveInventoryCountsResponse> BatchRetrieveInventoryCountsAsync(
                Models.BatchRetrieveInventoryCountsRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/inventory/counts/batch-retrieve");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Content-Type", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

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

            var responseModel = ApiHelper.JsonDeserialize<Models.BatchRetrieveInventoryCountsResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Deprecated version of [RetrieveInventoryPhysicalCount]($e/Inventory/RetrieveInventoryPhysicalCount) after the endpoint URL.
        /// is updated to conform to the standard convention.
        /// </summary>
        /// <param name="physicalCountId">Required parameter: ID of the [InventoryPhysicalCount]($m/InventoryPhysicalCount) to retrieve..</param>
        /// <returns>Returns the Models.RetrieveInventoryPhysicalCountResponse response from the API call.</returns>
        [Obsolete]
        public Models.RetrieveInventoryPhysicalCountResponse DeprecatedRetrieveInventoryPhysicalCount(
                string physicalCountId)
        {
            Task<Models.RetrieveInventoryPhysicalCountResponse> t = this.DeprecatedRetrieveInventoryPhysicalCountAsync(physicalCountId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Deprecated version of [RetrieveInventoryPhysicalCount]($e/Inventory/RetrieveInventoryPhysicalCount) after the endpoint URL.
        /// is updated to conform to the standard convention.
        /// </summary>
        /// <param name="physicalCountId">Required parameter: ID of the [InventoryPhysicalCount]($m/InventoryPhysicalCount) to retrieve..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveInventoryPhysicalCountResponse response from the API call.</returns>
        [Obsolete]
        public async Task<Models.RetrieveInventoryPhysicalCountResponse> DeprecatedRetrieveInventoryPhysicalCountAsync(
                string physicalCountId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/inventory/physical-count/{physical_count_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "physical_count_id", physicalCountId },
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
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.RetrieveInventoryPhysicalCountResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Returns the [InventoryPhysicalCount]($m/InventoryPhysicalCount).
        /// object with the provided `physical_count_id`.
        /// </summary>
        /// <param name="physicalCountId">Required parameter: ID of the [InventoryPhysicalCount]($m/InventoryPhysicalCount) to retrieve..</param>
        /// <returns>Returns the Models.RetrieveInventoryPhysicalCountResponse response from the API call.</returns>
        public Models.RetrieveInventoryPhysicalCountResponse RetrieveInventoryPhysicalCount(
                string physicalCountId)
        {
            Task<Models.RetrieveInventoryPhysicalCountResponse> t = this.RetrieveInventoryPhysicalCountAsync(physicalCountId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns the [InventoryPhysicalCount]($m/InventoryPhysicalCount).
        /// object with the provided `physical_count_id`.
        /// </summary>
        /// <param name="physicalCountId">Required parameter: ID of the [InventoryPhysicalCount]($m/InventoryPhysicalCount) to retrieve..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveInventoryPhysicalCountResponse response from the API call.</returns>
        public async Task<Models.RetrieveInventoryPhysicalCountResponse> RetrieveInventoryPhysicalCountAsync(
                string physicalCountId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/inventory/physical-counts/{physical_count_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "physical_count_id", physicalCountId },
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
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.RetrieveInventoryPhysicalCountResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Returns the [InventoryTransfer]($m/InventoryTransfer) object.
        /// with the provided `transfer_id`.
        /// </summary>
        /// <param name="transferId">Required parameter: ID of the [InventoryTransfer]($m/InventoryTransfer) to retrieve..</param>
        /// <returns>Returns the Models.RetrieveInventoryTransferResponse response from the API call.</returns>
        public Models.RetrieveInventoryTransferResponse RetrieveInventoryTransfer(
                string transferId)
        {
            Task<Models.RetrieveInventoryTransferResponse> t = this.RetrieveInventoryTransferAsync(transferId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns the [InventoryTransfer]($m/InventoryTransfer) object.
        /// with the provided `transfer_id`.
        /// </summary>
        /// <param name="transferId">Required parameter: ID of the [InventoryTransfer]($m/InventoryTransfer) to retrieve..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveInventoryTransferResponse response from the API call.</returns>
        public async Task<Models.RetrieveInventoryTransferResponse> RetrieveInventoryTransferAsync(
                string transferId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/inventory/transfers/{transfer_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "transfer_id", transferId },
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
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.RetrieveInventoryTransferResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Retrieves the current calculated stock count for a given.
        /// [CatalogObject]($m/CatalogObject) at a given set of.
        /// [Location]($m/Location)s. Responses are paginated and unsorted.
        /// For more sophisticated queries, use a batch endpoint.
        /// </summary>
        /// <param name="catalogObjectId">Required parameter: ID of the [CatalogObject]($m/CatalogObject) to retrieve..</param>
        /// <param name="locationIds">Optional parameter: The [Location]($m/Location) IDs to look up as a comma-separated list. An empty list queries all locations..</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for the original query.  See the [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination) guide for more information..</param>
        /// <returns>Returns the Models.RetrieveInventoryCountResponse response from the API call.</returns>
        public Models.RetrieveInventoryCountResponse RetrieveInventoryCount(
                string catalogObjectId,
                string locationIds = null,
                string cursor = null)
        {
            Task<Models.RetrieveInventoryCountResponse> t = this.RetrieveInventoryCountAsync(catalogObjectId, locationIds, cursor);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Retrieves the current calculated stock count for a given.
        /// [CatalogObject]($m/CatalogObject) at a given set of.
        /// [Location]($m/Location)s. Responses are paginated and unsorted.
        /// For more sophisticated queries, use a batch endpoint.
        /// </summary>
        /// <param name="catalogObjectId">Required parameter: ID of the [CatalogObject]($m/CatalogObject) to retrieve..</param>
        /// <param name="locationIds">Optional parameter: The [Location]($m/Location) IDs to look up as a comma-separated list. An empty list queries all locations..</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for the original query.  See the [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination) guide for more information..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveInventoryCountResponse response from the API call.</returns>
        public async Task<Models.RetrieveInventoryCountResponse> RetrieveInventoryCountAsync(
                string catalogObjectId,
                string locationIds = null,
                string cursor = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/inventory/{catalog_object_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "catalog_object_id", catalogObjectId },
            });

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "location_ids", locationIds },
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

            var responseModel = ApiHelper.JsonDeserialize<Models.RetrieveInventoryCountResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Returns a set of physical counts and inventory adjustments for the.
        /// provided [CatalogObject]($m/CatalogObject) at the requested.
        /// [Location]($m/Location)s.
        /// You can achieve the same result by calling [BatchRetrieveInventoryChanges]($e/Inventory/BatchRetrieveInventoryChanges).
        /// and having the `catalog_object_ids` list contain a single element of the `CatalogObject` ID.
        /// Results are paginated and sorted in descending order according to their.
        /// `occurred_at` timestamp (newest first).
        /// There are no limits on how far back the caller can page. This endpoint can be.
        /// used to display recent changes for a specific item. For more.
        /// sophisticated queries, use a batch endpoint.
        /// </summary>
        /// <param name="catalogObjectId">Required parameter: ID of the [CatalogObject]($m/CatalogObject) to retrieve..</param>
        /// <param name="locationIds">Optional parameter: The [Location]($m/Location) IDs to look up as a comma-separated list. An empty list queries all locations..</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for the original query.  See the [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination) guide for more information..</param>
        /// <returns>Returns the Models.RetrieveInventoryChangesResponse response from the API call.</returns>
        [Obsolete]
        public Models.RetrieveInventoryChangesResponse RetrieveInventoryChanges(
                string catalogObjectId,
                string locationIds = null,
                string cursor = null)
        {
            Task<Models.RetrieveInventoryChangesResponse> t = this.RetrieveInventoryChangesAsync(catalogObjectId, locationIds, cursor);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns a set of physical counts and inventory adjustments for the.
        /// provided [CatalogObject]($m/CatalogObject) at the requested.
        /// [Location]($m/Location)s.
        /// You can achieve the same result by calling [BatchRetrieveInventoryChanges]($e/Inventory/BatchRetrieveInventoryChanges).
        /// and having the `catalog_object_ids` list contain a single element of the `CatalogObject` ID.
        /// Results are paginated and sorted in descending order according to their.
        /// `occurred_at` timestamp (newest first).
        /// There are no limits on how far back the caller can page. This endpoint can be.
        /// used to display recent changes for a specific item. For more.
        /// sophisticated queries, use a batch endpoint.
        /// </summary>
        /// <param name="catalogObjectId">Required parameter: ID of the [CatalogObject]($m/CatalogObject) to retrieve..</param>
        /// <param name="locationIds">Optional parameter: The [Location]($m/Location) IDs to look up as a comma-separated list. An empty list queries all locations..</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for the original query.  See the [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination) guide for more information..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveInventoryChangesResponse response from the API call.</returns>
        [Obsolete]
        public async Task<Models.RetrieveInventoryChangesResponse> RetrieveInventoryChangesAsync(
                string catalogObjectId,
                string locationIds = null,
                string cursor = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/inventory/{catalog_object_id}/changes");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "catalog_object_id", catalogObjectId },
            });

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "location_ids", locationIds },
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

            var responseModel = ApiHelper.JsonDeserialize<Models.RetrieveInventoryChangesResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }
    }
}