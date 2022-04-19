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
    /// CustomersApi.
    /// </summary>
    internal class CustomersApi : BaseApi, ICustomersApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomersApi"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal CustomersApi(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// Lists customer profiles associated with a Square account.
        /// Under normal operating conditions, newly created or updated customer profiles become available.
        /// for the listing operation in well under 30 seconds. Occasionally, propagation of the new or updated.
        /// profiles can take closer to one minute or longer, especially during network incidents and outages.
        /// </summary>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this cursor to retrieve the next set of results for your original query.  For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to return in a single page. This limit is advisory. The response might contain more or fewer results. If the specified limit is less than 1 or greater than 100, Square returns a `400 VALUE_TOO_LOW` or `400 VALUE_TOO_HIGH` error. The default value is 100.  For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="sortField">Optional parameter: Indicates how customers should be sorted.  The default value is `DEFAULT`..</param>
        /// <param name="sortOrder">Optional parameter: Indicates whether customers should be sorted in ascending (`ASC`) or descending (`DESC`) order.  The default value is `ASC`..</param>
        /// <returns>Returns the Models.ListCustomersResponse response from the API call.</returns>
        public Models.ListCustomersResponse ListCustomers(
                string cursor = null,
                int? limit = null,
                string sortField = null,
                string sortOrder = null)
        {
            Task<Models.ListCustomersResponse> t = this.ListCustomersAsync(cursor, limit, sortField, sortOrder);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Lists customer profiles associated with a Square account.
        /// Under normal operating conditions, newly created or updated customer profiles become available.
        /// for the listing operation in well under 30 seconds. Occasionally, propagation of the new or updated.
        /// profiles can take closer to one minute or longer, especially during network incidents and outages.
        /// </summary>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this cursor to retrieve the next set of results for your original query.  For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to return in a single page. This limit is advisory. The response might contain more or fewer results. If the specified limit is less than 1 or greater than 100, Square returns a `400 VALUE_TOO_LOW` or `400 VALUE_TOO_HIGH` error. The default value is 100.  For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="sortField">Optional parameter: Indicates how customers should be sorted.  The default value is `DEFAULT`..</param>
        /// <param name="sortOrder">Optional parameter: Indicates whether customers should be sorted in ascending (`ASC`) or descending (`DESC`) order.  The default value is `ASC`..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListCustomersResponse response from the API call.</returns>
        public async Task<Models.ListCustomersResponse> ListCustomersAsync(
                string cursor = null,
                int? limit = null,
                string sortField = null,
                string sortOrder = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/customers");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "cursor", cursor },
                { "limit", limit },
                { "sort_field", sortField },
                { "sort_order", sortOrder },
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

            var responseModel = ApiHelper.JsonDeserialize<Models.ListCustomersResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Creates a new customer for a business.
        /// You must provide at least one of the following values in your request to this.
        /// endpoint:.
        /// - `given_name`.
        /// - `family_name`.
        /// - `company_name`.
        /// - `email_address`.
        /// - `phone_number`.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateCustomerResponse response from the API call.</returns>
        public Models.CreateCustomerResponse CreateCustomer(
                Models.CreateCustomerRequest body)
        {
            Task<Models.CreateCustomerResponse> t = this.CreateCustomerAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Creates a new customer for a business.
        /// You must provide at least one of the following values in your request to this.
        /// endpoint:.
        /// - `given_name`.
        /// - `family_name`.
        /// - `company_name`.
        /// - `email_address`.
        /// - `phone_number`.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateCustomerResponse response from the API call.</returns>
        public async Task<Models.CreateCustomerResponse> CreateCustomerAsync(
                Models.CreateCustomerRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/customers");

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

            var responseModel = ApiHelper.JsonDeserialize<Models.CreateCustomerResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Searches the customer profiles associated with a Square account using a supported query filter.
        /// Calling `SearchCustomers` without any explicit query filter returns all.
        /// customer profiles ordered alphabetically based on `given_name` and.
        /// `family_name`.
        /// Under normal operating conditions, newly created or updated customer profiles become available.
        /// for the search operation in well under 30 seconds. Occasionally, propagation of the new or updated.
        /// profiles can take closer to one minute or longer, especially during network incidents and outages.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.SearchCustomersResponse response from the API call.</returns>
        public Models.SearchCustomersResponse SearchCustomers(
                Models.SearchCustomersRequest body)
        {
            Task<Models.SearchCustomersResponse> t = this.SearchCustomersAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Searches the customer profiles associated with a Square account using a supported query filter.
        /// Calling `SearchCustomers` without any explicit query filter returns all.
        /// customer profiles ordered alphabetically based on `given_name` and.
        /// `family_name`.
        /// Under normal operating conditions, newly created or updated customer profiles become available.
        /// for the search operation in well under 30 seconds. Occasionally, propagation of the new or updated.
        /// profiles can take closer to one minute or longer, especially during network incidents and outages.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.SearchCustomersResponse response from the API call.</returns>
        public async Task<Models.SearchCustomersResponse> SearchCustomersAsync(
                Models.SearchCustomersRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/customers/search");

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

            var responseModel = ApiHelper.JsonDeserialize<Models.SearchCustomersResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Deletes a customer profile from a business. This operation also unlinks any associated cards on file. .
        /// As a best practice, you should include the `version` field in the request to enable [optimistic concurrency](https://developer.squareup.com/docs/working-with-apis/optimistic-concurrency) control. The value must be set to the current version of the customer profile. .
        /// To delete a customer profile that was created by merging existing profiles, you must use the ID of the newly created profile.
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the customer to delete..</param>
        /// <param name="version">Optional parameter: The current version of the customer profile.  As a best practice, you should include this parameter to enable [optimistic concurrency](https://developer.squareup.com/docs/build-basics/common-api-patterns/optimistic-concurrency) control.  For more information, see [Delete a customer profile](https://developer.squareup.com/docs/customers-api/use-the-api/keep-records#delete-customer-profile)..</param>
        /// <returns>Returns the Models.DeleteCustomerResponse response from the API call.</returns>
        public Models.DeleteCustomerResponse DeleteCustomer(
                string customerId,
                long? version = null)
        {
            Task<Models.DeleteCustomerResponse> t = this.DeleteCustomerAsync(customerId, version);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Deletes a customer profile from a business. This operation also unlinks any associated cards on file. .
        /// As a best practice, you should include the `version` field in the request to enable [optimistic concurrency](https://developer.squareup.com/docs/working-with-apis/optimistic-concurrency) control. The value must be set to the current version of the customer profile. .
        /// To delete a customer profile that was created by merging existing profiles, you must use the ID of the newly created profile.
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the customer to delete..</param>
        /// <param name="version">Optional parameter: The current version of the customer profile.  As a best practice, you should include this parameter to enable [optimistic concurrency](https://developer.squareup.com/docs/build-basics/common-api-patterns/optimistic-concurrency) control.  For more information, see [Delete a customer profile](https://developer.squareup.com/docs/customers-api/use-the-api/keep-records#delete-customer-profile)..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.DeleteCustomerResponse response from the API call.</returns>
        public async Task<Models.DeleteCustomerResponse> DeleteCustomerAsync(
                string customerId,
                long? version = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/customers/{customer_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "customer_id", customerId },
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
            HttpRequest httpRequest = this.GetClientInstance().Delete(queryBuilder.ToString(), headers, null, queryParameters: queryParams);

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

            var responseModel = ApiHelper.JsonDeserialize<Models.DeleteCustomerResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Returns details for a single customer.
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the customer to retrieve..</param>
        /// <returns>Returns the Models.RetrieveCustomerResponse response from the API call.</returns>
        public Models.RetrieveCustomerResponse RetrieveCustomer(
                string customerId)
        {
            Task<Models.RetrieveCustomerResponse> t = this.RetrieveCustomerAsync(customerId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns details for a single customer.
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the customer to retrieve..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveCustomerResponse response from the API call.</returns>
        public async Task<Models.RetrieveCustomerResponse> RetrieveCustomerAsync(
                string customerId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/customers/{customer_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "customer_id", customerId },
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

            var responseModel = ApiHelper.JsonDeserialize<Models.RetrieveCustomerResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Updates a customer profile. To change an attribute, specify the new value. To remove an attribute, specify the value as an empty string or empty object.
        /// As a best practice, you should include the `version` field in the request to enable [optimistic concurrency](https://developer.squareup.com/docs/working-with-apis/optimistic-concurrency) control. The value must be set to the current version of the customer profile.
        /// To update a customer profile that was created by merging existing profiles, you must use the ID of the newly created profile.
        /// You cannot use this endpoint to change cards on file. To make changes, use the [Cards API]($e/Cards) or [Gift Cards API]($e/GiftCards).
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the customer to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpdateCustomerResponse response from the API call.</returns>
        public Models.UpdateCustomerResponse UpdateCustomer(
                string customerId,
                Models.UpdateCustomerRequest body)
        {
            Task<Models.UpdateCustomerResponse> t = this.UpdateCustomerAsync(customerId, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Updates a customer profile. To change an attribute, specify the new value. To remove an attribute, specify the value as an empty string or empty object.
        /// As a best practice, you should include the `version` field in the request to enable [optimistic concurrency](https://developer.squareup.com/docs/working-with-apis/optimistic-concurrency) control. The value must be set to the current version of the customer profile.
        /// To update a customer profile that was created by merging existing profiles, you must use the ID of the newly created profile.
        /// You cannot use this endpoint to change cards on file. To make changes, use the [Cards API]($e/Cards) or [Gift Cards API]($e/GiftCards).
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the customer to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpdateCustomerResponse response from the API call.</returns>
        public async Task<Models.UpdateCustomerResponse> UpdateCustomerAsync(
                string customerId,
                Models.UpdateCustomerRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/customers/{customer_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "customer_id", customerId },
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

            var responseModel = ApiHelper.JsonDeserialize<Models.UpdateCustomerResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Adds a card on file to an existing customer.
        /// As with charges, calls to `CreateCustomerCard` are idempotent. Multiple.
        /// calls with the same card nonce return the same card record that was created.
        /// with the provided nonce during the _first_ call.
        /// </summary>
        /// <param name="customerId">Required parameter: The Square ID of the customer profile the card is linked to..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateCustomerCardResponse response from the API call.</returns>
        [Obsolete]
        public Models.CreateCustomerCardResponse CreateCustomerCard(
                string customerId,
                Models.CreateCustomerCardRequest body)
        {
            Task<Models.CreateCustomerCardResponse> t = this.CreateCustomerCardAsync(customerId, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Adds a card on file to an existing customer.
        /// As with charges, calls to `CreateCustomerCard` are idempotent. Multiple.
        /// calls with the same card nonce return the same card record that was created.
        /// with the provided nonce during the _first_ call.
        /// </summary>
        /// <param name="customerId">Required parameter: The Square ID of the customer profile the card is linked to..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateCustomerCardResponse response from the API call.</returns>
        [Obsolete]
        public async Task<Models.CreateCustomerCardResponse> CreateCustomerCardAsync(
                string customerId,
                Models.CreateCustomerCardRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/customers/{customer_id}/cards");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "customer_id", customerId },
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

            var responseModel = ApiHelper.JsonDeserialize<Models.CreateCustomerCardResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Removes a card on file from a customer.
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the customer that the card on file belongs to..</param>
        /// <param name="cardId">Required parameter: The ID of the card on file to delete..</param>
        /// <returns>Returns the Models.DeleteCustomerCardResponse response from the API call.</returns>
        [Obsolete]
        public Models.DeleteCustomerCardResponse DeleteCustomerCard(
                string customerId,
                string cardId)
        {
            Task<Models.DeleteCustomerCardResponse> t = this.DeleteCustomerCardAsync(customerId, cardId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Removes a card on file from a customer.
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the customer that the card on file belongs to..</param>
        /// <param name="cardId">Required parameter: The ID of the card on file to delete..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.DeleteCustomerCardResponse response from the API call.</returns>
        [Obsolete]
        public async Task<Models.DeleteCustomerCardResponse> DeleteCustomerCardAsync(
                string customerId,
                string cardId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/customers/{customer_id}/cards/{card_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "customer_id", customerId },
                { "card_id", cardId },
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

            var responseModel = ApiHelper.JsonDeserialize<Models.DeleteCustomerCardResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Removes a group membership from a customer.
        /// The customer is identified by the `customer_id` value.
        /// and the customer group is identified by the `group_id` value.
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the customer to remove from the group..</param>
        /// <param name="groupId">Required parameter: The ID of the customer group to remove the customer from..</param>
        /// <returns>Returns the Models.RemoveGroupFromCustomerResponse response from the API call.</returns>
        public Models.RemoveGroupFromCustomerResponse RemoveGroupFromCustomer(
                string customerId,
                string groupId)
        {
            Task<Models.RemoveGroupFromCustomerResponse> t = this.RemoveGroupFromCustomerAsync(customerId, groupId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Removes a group membership from a customer.
        /// The customer is identified by the `customer_id` value.
        /// and the customer group is identified by the `group_id` value.
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the customer to remove from the group..</param>
        /// <param name="groupId">Required parameter: The ID of the customer group to remove the customer from..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RemoveGroupFromCustomerResponse response from the API call.</returns>
        public async Task<Models.RemoveGroupFromCustomerResponse> RemoveGroupFromCustomerAsync(
                string customerId,
                string groupId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/customers/{customer_id}/groups/{group_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "customer_id", customerId },
                { "group_id", groupId },
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

            var responseModel = ApiHelper.JsonDeserialize<Models.RemoveGroupFromCustomerResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Adds a group membership to a customer.
        /// The customer is identified by the `customer_id` value.
        /// and the customer group is identified by the `group_id` value.
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the customer to add to a group..</param>
        /// <param name="groupId">Required parameter: The ID of the customer group to add the customer to..</param>
        /// <returns>Returns the Models.AddGroupToCustomerResponse response from the API call.</returns>
        public Models.AddGroupToCustomerResponse AddGroupToCustomer(
                string customerId,
                string groupId)
        {
            Task<Models.AddGroupToCustomerResponse> t = this.AddGroupToCustomerAsync(customerId, groupId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Adds a group membership to a customer.
        /// The customer is identified by the `customer_id` value.
        /// and the customer group is identified by the `group_id` value.
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the customer to add to a group..</param>
        /// <param name="groupId">Required parameter: The ID of the customer group to add the customer to..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.AddGroupToCustomerResponse response from the API call.</returns>
        public async Task<Models.AddGroupToCustomerResponse> AddGroupToCustomerAsync(
                string customerId,
                string groupId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/customers/{customer_id}/groups/{group_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "customer_id", customerId },
                { "group_id", groupId },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Put(queryBuilder.ToString(), headers, null);

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

            var responseModel = ApiHelper.JsonDeserialize<Models.AddGroupToCustomerResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }
    }
}