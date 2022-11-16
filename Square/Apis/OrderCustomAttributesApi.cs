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
    /// OrderCustomAttributesApi.
    /// </summary>
    internal class OrderCustomAttributesApi : BaseApi, IOrderCustomAttributesApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderCustomAttributesApi"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal OrderCustomAttributesApi(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// Lists the order-related [custom attribute definitions]($m/CustomAttributeDefinition) that belong to a Square seller account.
        /// When all response pages are retrieved, the results include all custom attribute definitions.
        /// that are visible to the requesting application, including those that are created by other.
        /// applications and set to `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`. Note that.
        /// seller-defined custom attributes (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="visibilityFilter">Optional parameter: Requests that all of the custom attributes be returned, or only those that are read-only or read-write..</param>
        /// <param name="cursor">Optional parameter: The cursor returned in the paged response from the previous call to this endpoint.  Provide this cursor to retrieve the next page of results for your original request.  For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination)..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to return in a single paged response. This limit is advisory.  The response might contain more or fewer results. The minimum value is 1 and the maximum value is 100.  The default value is 20. For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination)..</param>
        /// <returns>Returns the Models.ListOrderCustomAttributeDefinitionsResponse response from the API call.</returns>
        public Models.ListOrderCustomAttributeDefinitionsResponse ListOrderCustomAttributeDefinitions(
                string visibilityFilter = null,
                string cursor = null,
                int? limit = null)
        {
            Task<Models.ListOrderCustomAttributeDefinitionsResponse> t = this.ListOrderCustomAttributeDefinitionsAsync(visibilityFilter, cursor, limit);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Lists the order-related [custom attribute definitions]($m/CustomAttributeDefinition) that belong to a Square seller account.
        /// When all response pages are retrieved, the results include all custom attribute definitions.
        /// that are visible to the requesting application, including those that are created by other.
        /// applications and set to `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`. Note that.
        /// seller-defined custom attributes (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="visibilityFilter">Optional parameter: Requests that all of the custom attributes be returned, or only those that are read-only or read-write..</param>
        /// <param name="cursor">Optional parameter: The cursor returned in the paged response from the previous call to this endpoint.  Provide this cursor to retrieve the next page of results for your original request.  For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination)..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to return in a single paged response. This limit is advisory.  The response might contain more or fewer results. The minimum value is 1 and the maximum value is 100.  The default value is 20. For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination)..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListOrderCustomAttributeDefinitionsResponse response from the API call.</returns>
        public async Task<Models.ListOrderCustomAttributeDefinitionsResponse> ListOrderCustomAttributeDefinitionsAsync(
                string visibilityFilter = null,
                string cursor = null,
                int? limit = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/orders/custom-attribute-definitions");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "visibility_filter", visibilityFilter },
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

            var responseModel = ApiHelper.JsonDeserialize<Models.ListOrderCustomAttributeDefinitionsResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Creates an order-related custom attribute definition.  Use this endpoint to.
        /// define a custom attribute that can be associated with orders.
        /// After creating a custom attribute definition, you can set the custom attribute for orders.
        /// in the Square seller account.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateOrderCustomAttributeDefinitionResponse response from the API call.</returns>
        public Models.CreateOrderCustomAttributeDefinitionResponse CreateOrderCustomAttributeDefinition(
                Models.CreateOrderCustomAttributeDefinitionRequest body)
        {
            Task<Models.CreateOrderCustomAttributeDefinitionResponse> t = this.CreateOrderCustomAttributeDefinitionAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Creates an order-related custom attribute definition.  Use this endpoint to.
        /// define a custom attribute that can be associated with orders.
        /// After creating a custom attribute definition, you can set the custom attribute for orders.
        /// in the Square seller account.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateOrderCustomAttributeDefinitionResponse response from the API call.</returns>
        public async Task<Models.CreateOrderCustomAttributeDefinitionResponse> CreateOrderCustomAttributeDefinitionAsync(
                Models.CreateOrderCustomAttributeDefinitionRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/orders/custom-attribute-definitions");

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
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.CreateOrderCustomAttributeDefinitionResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Deletes an order-related [custom attribute definition]($m/CustomAttributeDefinition) from a Square seller account.
        /// Only the definition owner can delete a custom attribute definition.
        /// </summary>
        /// <param name="key">Required parameter: The key of the custom attribute definition to delete..</param>
        /// <returns>Returns the Models.DeleteOrderCustomAttributeDefinitionResponse response from the API call.</returns>
        public Models.DeleteOrderCustomAttributeDefinitionResponse DeleteOrderCustomAttributeDefinition(
                string key)
        {
            Task<Models.DeleteOrderCustomAttributeDefinitionResponse> t = this.DeleteOrderCustomAttributeDefinitionAsync(key);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Deletes an order-related [custom attribute definition]($m/CustomAttributeDefinition) from a Square seller account.
        /// Only the definition owner can delete a custom attribute definition.
        /// </summary>
        /// <param name="key">Required parameter: The key of the custom attribute definition to delete..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.DeleteOrderCustomAttributeDefinitionResponse response from the API call.</returns>
        public async Task<Models.DeleteOrderCustomAttributeDefinitionResponse> DeleteOrderCustomAttributeDefinitionAsync(
                string key,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/orders/custom-attribute-definitions/{key}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "key", key },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Delete(queryBuilder.ToString(), headers, null);

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

            var responseModel = ApiHelper.JsonDeserialize<Models.DeleteOrderCustomAttributeDefinitionResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Retrieves an order-related [custom attribute definition]($m/CustomAttributeDefinition) from a Square seller account.
        /// To retrieve a custom attribute definition created by another application, the `visibility`.
        /// setting must be `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes.
        /// (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="key">Required parameter: The key of the custom attribute definition to retrieve..</param>
        /// <param name="version">Optional parameter: To enable [optimistic concurrency](https://developer.squareup.com/docs/build-basics/common-api-patterns/optimistic-concurrency) control, include this optional field and specify the current version of the custom attribute..</param>
        /// <returns>Returns the Models.RetrieveOrderCustomAttributeDefinitionResponse response from the API call.</returns>
        public Models.RetrieveOrderCustomAttributeDefinitionResponse RetrieveOrderCustomAttributeDefinition(
                string key,
                int? version = null)
        {
            Task<Models.RetrieveOrderCustomAttributeDefinitionResponse> t = this.RetrieveOrderCustomAttributeDefinitionAsync(key, version);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Retrieves an order-related [custom attribute definition]($m/CustomAttributeDefinition) from a Square seller account.
        /// To retrieve a custom attribute definition created by another application, the `visibility`.
        /// setting must be `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes.
        /// (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="key">Required parameter: The key of the custom attribute definition to retrieve..</param>
        /// <param name="version">Optional parameter: To enable [optimistic concurrency](https://developer.squareup.com/docs/build-basics/common-api-patterns/optimistic-concurrency) control, include this optional field and specify the current version of the custom attribute..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveOrderCustomAttributeDefinitionResponse response from the API call.</returns>
        public async Task<Models.RetrieveOrderCustomAttributeDefinitionResponse> RetrieveOrderCustomAttributeDefinitionAsync(
                string key,
                int? version = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/orders/custom-attribute-definitions/{key}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "key", key },
            });

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "version", version },
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

            var responseModel = ApiHelper.JsonDeserialize<Models.RetrieveOrderCustomAttributeDefinitionResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Updates an order-related custom attribute definition for a Square seller account.
        /// Only the definition owner can update a custom attribute definition. Note that sellers can view all custom attributes in exported customer data, including those set to `VISIBILITY_HIDDEN`.
        /// </summary>
        /// <param name="key">Required parameter: The key of the custom attribute definition to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpdateOrderCustomAttributeDefinitionResponse response from the API call.</returns>
        public Models.UpdateOrderCustomAttributeDefinitionResponse UpdateOrderCustomAttributeDefinition(
                string key,
                Models.UpdateOrderCustomAttributeDefinitionRequest body)
        {
            Task<Models.UpdateOrderCustomAttributeDefinitionResponse> t = this.UpdateOrderCustomAttributeDefinitionAsync(key, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Updates an order-related custom attribute definition for a Square seller account.
        /// Only the definition owner can update a custom attribute definition. Note that sellers can view all custom attributes in exported customer data, including those set to `VISIBILITY_HIDDEN`.
        /// </summary>
        /// <param name="key">Required parameter: The key of the custom attribute definition to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpdateOrderCustomAttributeDefinitionResponse response from the API call.</returns>
        public async Task<Models.UpdateOrderCustomAttributeDefinitionResponse> UpdateOrderCustomAttributeDefinitionAsync(
                string key,
                Models.UpdateOrderCustomAttributeDefinitionRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/orders/custom-attribute-definitions/{key}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "key", key },
            });

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
            HttpRequest httpRequest = this.GetClientInstance().PutBody(queryBuilder.ToString(), headers, bodyText);

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

            var responseModel = ApiHelper.JsonDeserialize<Models.UpdateOrderCustomAttributeDefinitionResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Deletes order [custom attributes]($m/CustomAttribute) as a bulk operation.
        /// Use this endpoint to delete one or more custom attributes from one or more orders.
        /// A custom attribute is based on a custom attribute definition in a Square seller account.  (To create a.
        /// custom attribute definition, use the [CreateOrderCustomAttributeDefinition]($e/OrderCustomAttributes/CreateOrderCustomAttributeDefinition) endpoint.).
        /// This `BulkDeleteOrderCustomAttributes` endpoint accepts a map of 1 to 25 individual delete.
        /// requests and returns a map of individual delete responses. Each delete request has a unique ID.
        /// and provides an order ID and custom attribute. Each delete response is returned with the ID.
        /// of the corresponding request.
        /// To delete a custom attribute owned by another application, the `visibility` setting.
        /// must be `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes.
        /// (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BulkDeleteOrderCustomAttributesResponse response from the API call.</returns>
        public Models.BulkDeleteOrderCustomAttributesResponse BulkDeleteOrderCustomAttributes(
                Models.BulkDeleteOrderCustomAttributesRequest body)
        {
            Task<Models.BulkDeleteOrderCustomAttributesResponse> t = this.BulkDeleteOrderCustomAttributesAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Deletes order [custom attributes]($m/CustomAttribute) as a bulk operation.
        /// Use this endpoint to delete one or more custom attributes from one or more orders.
        /// A custom attribute is based on a custom attribute definition in a Square seller account.  (To create a.
        /// custom attribute definition, use the [CreateOrderCustomAttributeDefinition]($e/OrderCustomAttributes/CreateOrderCustomAttributeDefinition) endpoint.).
        /// This `BulkDeleteOrderCustomAttributes` endpoint accepts a map of 1 to 25 individual delete.
        /// requests and returns a map of individual delete responses. Each delete request has a unique ID.
        /// and provides an order ID and custom attribute. Each delete response is returned with the ID.
        /// of the corresponding request.
        /// To delete a custom attribute owned by another application, the `visibility` setting.
        /// must be `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes.
        /// (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BulkDeleteOrderCustomAttributesResponse response from the API call.</returns>
        public async Task<Models.BulkDeleteOrderCustomAttributesResponse> BulkDeleteOrderCustomAttributesAsync(
                Models.BulkDeleteOrderCustomAttributesRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/orders/custom-attributes/bulk-delete");

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
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.BulkDeleteOrderCustomAttributesResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Creates or updates order [custom attributes]($m/CustomAttribute) as a bulk operation.
        /// Use this endpoint to delete one or more custom attributes from one or more orders.
        /// A custom attribute is based on a custom attribute definition in a Square seller account.  (To create a.
        /// custom attribute definition, use the [CreateOrderCustomAttributeDefinition]($e/OrderCustomAttributes/CreateOrderCustomAttributeDefinition) endpoint.).
        /// This `BulkUpsertOrderCustomAttributes` endpoint accepts a map of 1 to 25 individual upsert.
        /// requests and returns a map of individual upsert responses. Each upsert request has a unique ID.
        /// and provides an order ID and custom attribute. Each upsert response is returned with the ID.
        /// of the corresponding request.
        /// To create or update a custom attribute owned by another application, the `visibility` setting.
        /// must be `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes.
        /// (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BulkUpsertOrderCustomAttributesResponse response from the API call.</returns>
        public Models.BulkUpsertOrderCustomAttributesResponse BulkUpsertOrderCustomAttributes(
                Models.BulkUpsertOrderCustomAttributesRequest body)
        {
            Task<Models.BulkUpsertOrderCustomAttributesResponse> t = this.BulkUpsertOrderCustomAttributesAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Creates or updates order [custom attributes]($m/CustomAttribute) as a bulk operation.
        /// Use this endpoint to delete one or more custom attributes from one or more orders.
        /// A custom attribute is based on a custom attribute definition in a Square seller account.  (To create a.
        /// custom attribute definition, use the [CreateOrderCustomAttributeDefinition]($e/OrderCustomAttributes/CreateOrderCustomAttributeDefinition) endpoint.).
        /// This `BulkUpsertOrderCustomAttributes` endpoint accepts a map of 1 to 25 individual upsert.
        /// requests and returns a map of individual upsert responses. Each upsert request has a unique ID.
        /// and provides an order ID and custom attribute. Each upsert response is returned with the ID.
        /// of the corresponding request.
        /// To create or update a custom attribute owned by another application, the `visibility` setting.
        /// must be `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes.
        /// (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BulkUpsertOrderCustomAttributesResponse response from the API call.</returns>
        public async Task<Models.BulkUpsertOrderCustomAttributesResponse> BulkUpsertOrderCustomAttributesAsync(
                Models.BulkUpsertOrderCustomAttributesRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/orders/custom-attributes/bulk-upsert");

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
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.BulkUpsertOrderCustomAttributesResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Lists the [custom attributes]($m/CustomAttribute) associated with an order.
        /// You can use the `with_definitions` query parameter to also retrieve custom attribute definitions.
        /// in the same call.
        /// When all response pages are retrieved, the results include all custom attributes that are.
        /// visible to the requesting application, including those that are owned by other applications.
        /// and set to `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="orderId">Required parameter: The ID of the target [order]($m/Order)..</param>
        /// <param name="visibilityFilter">Optional parameter: Requests that all of the custom attributes be returned, or only those that are read-only or read-write..</param>
        /// <param name="cursor">Optional parameter: The cursor returned in the paged response from the previous call to this endpoint.  Provide this cursor to retrieve the next page of results for your original request.  For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination)..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to return in a single paged response. This limit is advisory.  The response might contain more or fewer results. The minimum value is 1 and the maximum value is 100.  The default value is 20. For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination)..</param>
        /// <param name="withDefinitions">Optional parameter: Indicates whether to return the [custom attribute definition]($m/CustomAttributeDefinition) in the `definition` field of each custom attribute. Set this parameter to `true` to get the name and description of each custom attribute,  information about the data type, or other definition details. The default value is `false`..</param>
        /// <returns>Returns the Models.ListOrderCustomAttributesResponse response from the API call.</returns>
        public Models.ListOrderCustomAttributesResponse ListOrderCustomAttributes(
                string orderId,
                string visibilityFilter = null,
                string cursor = null,
                int? limit = null,
                bool? withDefinitions = false)
        {
            Task<Models.ListOrderCustomAttributesResponse> t = this.ListOrderCustomAttributesAsync(orderId, visibilityFilter, cursor, limit, withDefinitions);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Lists the [custom attributes]($m/CustomAttribute) associated with an order.
        /// You can use the `with_definitions` query parameter to also retrieve custom attribute definitions.
        /// in the same call.
        /// When all response pages are retrieved, the results include all custom attributes that are.
        /// visible to the requesting application, including those that are owned by other applications.
        /// and set to `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="orderId">Required parameter: The ID of the target [order]($m/Order)..</param>
        /// <param name="visibilityFilter">Optional parameter: Requests that all of the custom attributes be returned, or only those that are read-only or read-write..</param>
        /// <param name="cursor">Optional parameter: The cursor returned in the paged response from the previous call to this endpoint.  Provide this cursor to retrieve the next page of results for your original request.  For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination)..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to return in a single paged response. This limit is advisory.  The response might contain more or fewer results. The minimum value is 1 and the maximum value is 100.  The default value is 20. For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination)..</param>
        /// <param name="withDefinitions">Optional parameter: Indicates whether to return the [custom attribute definition]($m/CustomAttributeDefinition) in the `definition` field of each custom attribute. Set this parameter to `true` to get the name and description of each custom attribute,  information about the data type, or other definition details. The default value is `false`..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListOrderCustomAttributesResponse response from the API call.</returns>
        public async Task<Models.ListOrderCustomAttributesResponse> ListOrderCustomAttributesAsync(
                string orderId,
                string visibilityFilter = null,
                string cursor = null,
                int? limit = null,
                bool? withDefinitions = false,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/orders/{order_id}/custom-attributes");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "order_id", orderId },
            });

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "visibility_filter", visibilityFilter },
                { "cursor", cursor },
                { "limit", limit },
                { "with_definitions", (withDefinitions != null) ? withDefinitions : false },
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

            var responseModel = ApiHelper.JsonDeserialize<Models.ListOrderCustomAttributesResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Deletes a [custom attribute]($m/CustomAttribute) associated with a customer profile.
        /// To delete a custom attribute owned by another application, the `visibility` setting must be.
        /// `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes.
        /// (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="orderId">Required parameter: The ID of the target [order]($m/Order)..</param>
        /// <param name="customAttributeKey">Required parameter: The key of the custom attribute to delete.  This key must match the key of an existing custom attribute definition..</param>
        /// <returns>Returns the Models.DeleteOrderCustomAttributeResponse response from the API call.</returns>
        public Models.DeleteOrderCustomAttributeResponse DeleteOrderCustomAttribute(
                string orderId,
                string customAttributeKey)
        {
            Task<Models.DeleteOrderCustomAttributeResponse> t = this.DeleteOrderCustomAttributeAsync(orderId, customAttributeKey);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Deletes a [custom attribute]($m/CustomAttribute) associated with a customer profile.
        /// To delete a custom attribute owned by another application, the `visibility` setting must be.
        /// `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes.
        /// (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="orderId">Required parameter: The ID of the target [order]($m/Order)..</param>
        /// <param name="customAttributeKey">Required parameter: The key of the custom attribute to delete.  This key must match the key of an existing custom attribute definition..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.DeleteOrderCustomAttributeResponse response from the API call.</returns>
        public async Task<Models.DeleteOrderCustomAttributeResponse> DeleteOrderCustomAttributeAsync(
                string orderId,
                string customAttributeKey,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/orders/{order_id}/custom-attributes/{custom_attribute_key}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "order_id", orderId },
                { "custom_attribute_key", customAttributeKey },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Delete(queryBuilder.ToString(), headers, null);

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

            var responseModel = ApiHelper.JsonDeserialize<Models.DeleteOrderCustomAttributeResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Retrieves a [custom attribute]($m/CustomAttribute) associated with an order.
        /// You can use the `with_definition` query parameter to also retrieve the custom attribute definition.
        /// in the same call.
        /// To retrieve a custom attribute owned by another application, the `visibility` setting must be.
        /// `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes.
        /// also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="orderId">Required parameter: The ID of the target [order]($m/Order)..</param>
        /// <param name="customAttributeKey">Required parameter: The key of the custom attribute to retrieve.  This key must match the key of an existing custom attribute definition..</param>
        /// <param name="version">Optional parameter: To enable [optimistic concurrency](https://developer.squareup.com/docs/build-basics/common-api-patterns/optimistic-concurrency) control, include this optional field and specify the current version of the custom attribute..</param>
        /// <param name="withDefinition">Optional parameter: Indicates whether to return the [custom attribute definition]($m/CustomAttributeDefinition) in the `definition` field of each  custom attribute. Set this parameter to `true` to get the name and description of each custom attribute,  information about the data type, or other definition details. The default value is `false`..</param>
        /// <returns>Returns the Models.RetrieveOrderCustomAttributeResponse response from the API call.</returns>
        public Models.RetrieveOrderCustomAttributeResponse RetrieveOrderCustomAttribute(
                string orderId,
                string customAttributeKey,
                int? version = null,
                bool? withDefinition = false)
        {
            Task<Models.RetrieveOrderCustomAttributeResponse> t = this.RetrieveOrderCustomAttributeAsync(orderId, customAttributeKey, version, withDefinition);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Retrieves a [custom attribute]($m/CustomAttribute) associated with an order.
        /// You can use the `with_definition` query parameter to also retrieve the custom attribute definition.
        /// in the same call.
        /// To retrieve a custom attribute owned by another application, the `visibility` setting must be.
        /// `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes.
        /// also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="orderId">Required parameter: The ID of the target [order]($m/Order)..</param>
        /// <param name="customAttributeKey">Required parameter: The key of the custom attribute to retrieve.  This key must match the key of an existing custom attribute definition..</param>
        /// <param name="version">Optional parameter: To enable [optimistic concurrency](https://developer.squareup.com/docs/build-basics/common-api-patterns/optimistic-concurrency) control, include this optional field and specify the current version of the custom attribute..</param>
        /// <param name="withDefinition">Optional parameter: Indicates whether to return the [custom attribute definition]($m/CustomAttributeDefinition) in the `definition` field of each  custom attribute. Set this parameter to `true` to get the name and description of each custom attribute,  information about the data type, or other definition details. The default value is `false`..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveOrderCustomAttributeResponse response from the API call.</returns>
        public async Task<Models.RetrieveOrderCustomAttributeResponse> RetrieveOrderCustomAttributeAsync(
                string orderId,
                string customAttributeKey,
                int? version = null,
                bool? withDefinition = false,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/orders/{order_id}/custom-attributes/{custom_attribute_key}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "order_id", orderId },
                { "custom_attribute_key", customAttributeKey },
            });

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "version", version },
                { "with_definition", (withDefinition != null) ? withDefinition : false },
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

            var responseModel = ApiHelper.JsonDeserialize<Models.RetrieveOrderCustomAttributeResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Creates or updates a [custom attribute]($m/CustomAttribute) for an order.
        /// Use this endpoint to set the value of a custom attribute for a specific order.
        /// A custom attribute is based on a custom attribute definition in a Square seller account. (To create a.
        /// custom attribute definition, use the [CreateOrderCustomAttributeDefinition]($e/OrderCustomAttributes/CreateOrderCustomAttributeDefinition) endpoint.).
        /// To create or update a custom attribute owned by another application, the `visibility` setting.
        /// must be `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes.
        /// (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="orderId">Required parameter: The ID of the target [order]($m/Order)..</param>
        /// <param name="customAttributeKey">Required parameter: The key of the custom attribute to create or update.  This key must match the key  of an existing custom attribute definition..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpsertOrderCustomAttributeResponse response from the API call.</returns>
        public Models.UpsertOrderCustomAttributeResponse UpsertOrderCustomAttribute(
                string orderId,
                string customAttributeKey,
                Models.UpsertOrderCustomAttributeRequest body)
        {
            Task<Models.UpsertOrderCustomAttributeResponse> t = this.UpsertOrderCustomAttributeAsync(orderId, customAttributeKey, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Creates or updates a [custom attribute]($m/CustomAttribute) for an order.
        /// Use this endpoint to set the value of a custom attribute for a specific order.
        /// A custom attribute is based on a custom attribute definition in a Square seller account. (To create a.
        /// custom attribute definition, use the [CreateOrderCustomAttributeDefinition]($e/OrderCustomAttributes/CreateOrderCustomAttributeDefinition) endpoint.).
        /// To create or update a custom attribute owned by another application, the `visibility` setting.
        /// must be `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes.
        /// (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="orderId">Required parameter: The ID of the target [order]($m/Order)..</param>
        /// <param name="customAttributeKey">Required parameter: The key of the custom attribute to create or update.  This key must match the key  of an existing custom attribute definition..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpsertOrderCustomAttributeResponse response from the API call.</returns>
        public async Task<Models.UpsertOrderCustomAttributeResponse> UpsertOrderCustomAttributeAsync(
                string orderId,
                string customAttributeKey,
                Models.UpsertOrderCustomAttributeRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/orders/{order_id}/custom-attributes/{custom_attribute_key}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "order_id", orderId },
                { "custom_attribute_key", customAttributeKey },
            });

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
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.UpsertOrderCustomAttributeResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }
    }
}