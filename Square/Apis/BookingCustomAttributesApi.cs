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
    /// BookingCustomAttributesApi.
    /// </summary>
    internal class BookingCustomAttributesApi : BaseApi, IBookingCustomAttributesApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookingCustomAttributesApi"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal BookingCustomAttributesApi(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// Get all bookings custom attribute definitions.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.
        /// </summary>
        /// <param name="limit">Optional parameter: The maximum number of results to return in a single paged response. This limit is advisory. The response might contain more or fewer results. The minimum value is 1 and the maximum value is 100. The default value is 20. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="cursor">Optional parameter: The cursor returned in the paged response from the previous call to this endpoint. Provide this cursor to retrieve the next page of results for your original request. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <returns>Returns the Models.ListBookingCustomAttributeDefinitionsResponse response from the API call.</returns>
        public Models.ListBookingCustomAttributeDefinitionsResponse ListBookingCustomAttributeDefinitions(
                int? limit = null,
                string cursor = null)
        {
            Task<Models.ListBookingCustomAttributeDefinitionsResponse> t = this.ListBookingCustomAttributeDefinitionsAsync(limit, cursor);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Get all bookings custom attribute definitions.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.
        /// </summary>
        /// <param name="limit">Optional parameter: The maximum number of results to return in a single paged response. This limit is advisory. The response might contain more or fewer results. The minimum value is 1 and the maximum value is 100. The default value is 20. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="cursor">Optional parameter: The cursor returned in the paged response from the previous call to this endpoint. Provide this cursor to retrieve the next page of results for your original request. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListBookingCustomAttributeDefinitionsResponse response from the API call.</returns>
        public async Task<Models.ListBookingCustomAttributeDefinitionsResponse> ListBookingCustomAttributeDefinitionsAsync(
                int? limit = null,
                string cursor = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/bookings/custom-attribute-definitions");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
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
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.ListBookingCustomAttributeDefinitionsResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Creates a bookings custom attribute definition.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.
        /// For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*.
        /// or *Appointments Premium*.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateBookingCustomAttributeDefinitionResponse response from the API call.</returns>
        public Models.CreateBookingCustomAttributeDefinitionResponse CreateBookingCustomAttributeDefinition(
                Models.CreateBookingCustomAttributeDefinitionRequest body)
        {
            Task<Models.CreateBookingCustomAttributeDefinitionResponse> t = this.CreateBookingCustomAttributeDefinitionAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Creates a bookings custom attribute definition.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.
        /// For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*.
        /// or *Appointments Premium*.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateBookingCustomAttributeDefinitionResponse response from the API call.</returns>
        public async Task<Models.CreateBookingCustomAttributeDefinitionResponse> CreateBookingCustomAttributeDefinitionAsync(
                Models.CreateBookingCustomAttributeDefinitionRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/bookings/custom-attribute-definitions");

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

            var responseModel = ApiHelper.JsonDeserialize<Models.CreateBookingCustomAttributeDefinitionResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Deletes a bookings custom attribute definition.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.
        /// For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*.
        /// or *Appointments Premium*.
        /// </summary>
        /// <param name="key">Required parameter: The key of the custom attribute definition to delete..</param>
        /// <returns>Returns the Models.DeleteBookingCustomAttributeDefinitionResponse response from the API call.</returns>
        public Models.DeleteBookingCustomAttributeDefinitionResponse DeleteBookingCustomAttributeDefinition(
                string key)
        {
            Task<Models.DeleteBookingCustomAttributeDefinitionResponse> t = this.DeleteBookingCustomAttributeDefinitionAsync(key);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Deletes a bookings custom attribute definition.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.
        /// For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*.
        /// or *Appointments Premium*.
        /// </summary>
        /// <param name="key">Required parameter: The key of the custom attribute definition to delete..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.DeleteBookingCustomAttributeDefinitionResponse response from the API call.</returns>
        public async Task<Models.DeleteBookingCustomAttributeDefinitionResponse> DeleteBookingCustomAttributeDefinitionAsync(
                string key,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/bookings/custom-attribute-definitions/{key}");

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

            var responseModel = ApiHelper.JsonDeserialize<Models.DeleteBookingCustomAttributeDefinitionResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Retrieves a bookings custom attribute definition.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.
        /// </summary>
        /// <param name="key">Required parameter: The key of the custom attribute definition to retrieve. If the requesting application is not the definition owner, you must use the qualified key..</param>
        /// <param name="version">Optional parameter: The current version of the custom attribute definition, which is used for strongly consistent reads to guarantee that you receive the most up-to-date data. When included in the request, Square returns the specified version or a higher version if one exists. If the specified version is higher than the current version, Square returns a `BAD_REQUEST` error..</param>
        /// <returns>Returns the Models.RetrieveBookingCustomAttributeDefinitionResponse response from the API call.</returns>
        public Models.RetrieveBookingCustomAttributeDefinitionResponse RetrieveBookingCustomAttributeDefinition(
                string key,
                int? version = null)
        {
            Task<Models.RetrieveBookingCustomAttributeDefinitionResponse> t = this.RetrieveBookingCustomAttributeDefinitionAsync(key, version);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Retrieves a bookings custom attribute definition.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.
        /// </summary>
        /// <param name="key">Required parameter: The key of the custom attribute definition to retrieve. If the requesting application is not the definition owner, you must use the qualified key..</param>
        /// <param name="version">Optional parameter: The current version of the custom attribute definition, which is used for strongly consistent reads to guarantee that you receive the most up-to-date data. When included in the request, Square returns the specified version or a higher version if one exists. If the specified version is higher than the current version, Square returns a `BAD_REQUEST` error..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveBookingCustomAttributeDefinitionResponse response from the API call.</returns>
        public async Task<Models.RetrieveBookingCustomAttributeDefinitionResponse> RetrieveBookingCustomAttributeDefinitionAsync(
                string key,
                int? version = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/bookings/custom-attribute-definitions/{key}");

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

            var responseModel = ApiHelper.JsonDeserialize<Models.RetrieveBookingCustomAttributeDefinitionResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Updates a bookings custom attribute definition.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.
        /// For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*.
        /// or *Appointments Premium*.
        /// </summary>
        /// <param name="key">Required parameter: The key of the custom attribute definition to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpdateBookingCustomAttributeDefinitionResponse response from the API call.</returns>
        public Models.UpdateBookingCustomAttributeDefinitionResponse UpdateBookingCustomAttributeDefinition(
                string key,
                Models.UpdateBookingCustomAttributeDefinitionRequest body)
        {
            Task<Models.UpdateBookingCustomAttributeDefinitionResponse> t = this.UpdateBookingCustomAttributeDefinitionAsync(key, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Updates a bookings custom attribute definition.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.
        /// For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*.
        /// or *Appointments Premium*.
        /// </summary>
        /// <param name="key">Required parameter: The key of the custom attribute definition to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpdateBookingCustomAttributeDefinitionResponse response from the API call.</returns>
        public async Task<Models.UpdateBookingCustomAttributeDefinitionResponse> UpdateBookingCustomAttributeDefinitionAsync(
                string key,
                Models.UpdateBookingCustomAttributeDefinitionRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/bookings/custom-attribute-definitions/{key}");

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

            var responseModel = ApiHelper.JsonDeserialize<Models.UpdateBookingCustomAttributeDefinitionResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Bulk deletes bookings custom attributes.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.
        /// For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*.
        /// or *Appointments Premium*.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BulkDeleteBookingCustomAttributesResponse response from the API call.</returns>
        public Models.BulkDeleteBookingCustomAttributesResponse BulkDeleteBookingCustomAttributes(
                Models.BulkDeleteBookingCustomAttributesRequest body)
        {
            Task<Models.BulkDeleteBookingCustomAttributesResponse> t = this.BulkDeleteBookingCustomAttributesAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Bulk deletes bookings custom attributes.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.
        /// For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*.
        /// or *Appointments Premium*.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BulkDeleteBookingCustomAttributesResponse response from the API call.</returns>
        public async Task<Models.BulkDeleteBookingCustomAttributesResponse> BulkDeleteBookingCustomAttributesAsync(
                Models.BulkDeleteBookingCustomAttributesRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/bookings/custom-attributes/bulk-delete");

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

            var responseModel = ApiHelper.JsonDeserialize<Models.BulkDeleteBookingCustomAttributesResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Bulk upserts bookings custom attributes.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.
        /// For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*.
        /// or *Appointments Premium*.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BulkUpsertBookingCustomAttributesResponse response from the API call.</returns>
        public Models.BulkUpsertBookingCustomAttributesResponse BulkUpsertBookingCustomAttributes(
                Models.BulkUpsertBookingCustomAttributesRequest body)
        {
            Task<Models.BulkUpsertBookingCustomAttributesResponse> t = this.BulkUpsertBookingCustomAttributesAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Bulk upserts bookings custom attributes.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.
        /// For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*.
        /// or *Appointments Premium*.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BulkUpsertBookingCustomAttributesResponse response from the API call.</returns>
        public async Task<Models.BulkUpsertBookingCustomAttributesResponse> BulkUpsertBookingCustomAttributesAsync(
                Models.BulkUpsertBookingCustomAttributesRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/bookings/custom-attributes/bulk-upsert");

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

            var responseModel = ApiHelper.JsonDeserialize<Models.BulkUpsertBookingCustomAttributesResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Lists a booking's custom attributes.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.
        /// </summary>
        /// <param name="bookingId">Required parameter: The ID of the target [booking]($m/Booking)..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to return in a single paged response. This limit is advisory. The response might contain more or fewer results. The minimum value is 1 and the maximum value is 100. The default value is 20. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="cursor">Optional parameter: The cursor returned in the paged response from the previous call to this endpoint. Provide this cursor to retrieve the next page of results for your original request. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="withDefinitions">Optional parameter: Indicates whether to return the [custom attribute definition]($m/CustomAttributeDefinition) in the `definition` field of each custom attribute. Set this parameter to `true` to get the name and description of each custom attribute, information about the data type, or other definition details. The default value is `false`..</param>
        /// <returns>Returns the Models.ListBookingCustomAttributesResponse response from the API call.</returns>
        public Models.ListBookingCustomAttributesResponse ListBookingCustomAttributes(
                string bookingId,
                int? limit = null,
                string cursor = null,
                bool? withDefinitions = false)
        {
            Task<Models.ListBookingCustomAttributesResponse> t = this.ListBookingCustomAttributesAsync(bookingId, limit, cursor, withDefinitions);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Lists a booking's custom attributes.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.
        /// </summary>
        /// <param name="bookingId">Required parameter: The ID of the target [booking]($m/Booking)..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to return in a single paged response. This limit is advisory. The response might contain more or fewer results. The minimum value is 1 and the maximum value is 100. The default value is 20. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="cursor">Optional parameter: The cursor returned in the paged response from the previous call to this endpoint. Provide this cursor to retrieve the next page of results for your original request. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="withDefinitions">Optional parameter: Indicates whether to return the [custom attribute definition]($m/CustomAttributeDefinition) in the `definition` field of each custom attribute. Set this parameter to `true` to get the name and description of each custom attribute, information about the data type, or other definition details. The default value is `false`..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListBookingCustomAttributesResponse response from the API call.</returns>
        public async Task<Models.ListBookingCustomAttributesResponse> ListBookingCustomAttributesAsync(
                string bookingId,
                int? limit = null,
                string cursor = null,
                bool? withDefinitions = false,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/bookings/{booking_id}/custom-attributes");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "booking_id", bookingId },
            });

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "limit", limit },
                { "cursor", cursor },
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

            var responseModel = ApiHelper.JsonDeserialize<Models.ListBookingCustomAttributesResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Deletes a bookings custom attribute.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.
        /// For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*.
        /// or *Appointments Premium*.
        /// </summary>
        /// <param name="bookingId">Required parameter: The ID of the target [booking]($m/Booking)..</param>
        /// <param name="key">Required parameter: The key of the custom attribute to delete. This key must match the `key` of a custom attribute definition in the Square seller account. If the requesting application is not the definition owner, you must use the qualified key..</param>
        /// <returns>Returns the Models.DeleteBookingCustomAttributeResponse response from the API call.</returns>
        public Models.DeleteBookingCustomAttributeResponse DeleteBookingCustomAttribute(
                string bookingId,
                string key)
        {
            Task<Models.DeleteBookingCustomAttributeResponse> t = this.DeleteBookingCustomAttributeAsync(bookingId, key);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Deletes a bookings custom attribute.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.
        /// For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*.
        /// or *Appointments Premium*.
        /// </summary>
        /// <param name="bookingId">Required parameter: The ID of the target [booking]($m/Booking)..</param>
        /// <param name="key">Required parameter: The key of the custom attribute to delete. This key must match the `key` of a custom attribute definition in the Square seller account. If the requesting application is not the definition owner, you must use the qualified key..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.DeleteBookingCustomAttributeResponse response from the API call.</returns>
        public async Task<Models.DeleteBookingCustomAttributeResponse> DeleteBookingCustomAttributeAsync(
                string bookingId,
                string key,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/bookings/{booking_id}/custom-attributes/{key}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "booking_id", bookingId },
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

            var responseModel = ApiHelper.JsonDeserialize<Models.DeleteBookingCustomAttributeResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Retrieves a bookings custom attribute.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.
        /// </summary>
        /// <param name="bookingId">Required parameter: The ID of the target [booking]($m/Booking)..</param>
        /// <param name="key">Required parameter: The key of the custom attribute to retrieve. This key must match the `key` of a custom attribute definition in the Square seller account. If the requesting application is not the definition owner, you must use the qualified key..</param>
        /// <param name="withDefinition">Optional parameter: Indicates whether to return the [custom attribute definition]($m/CustomAttributeDefinition) in the `definition` field of the custom attribute. Set this parameter to `true` to get the name and description of the custom attribute, information about the data type, or other definition details. The default value is `false`..</param>
        /// <param name="version">Optional parameter: The current version of the custom attribute, which is used for strongly consistent reads to guarantee that you receive the most up-to-date data. When included in the request, Square returns the specified version or a higher version if one exists. If the specified version is higher than the current version, Square returns a `BAD_REQUEST` error..</param>
        /// <returns>Returns the Models.RetrieveBookingCustomAttributeResponse response from the API call.</returns>
        public Models.RetrieveBookingCustomAttributeResponse RetrieveBookingCustomAttribute(
                string bookingId,
                string key,
                bool? withDefinition = false,
                int? version = null)
        {
            Task<Models.RetrieveBookingCustomAttributeResponse> t = this.RetrieveBookingCustomAttributeAsync(bookingId, key, withDefinition, version);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Retrieves a bookings custom attribute.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.
        /// </summary>
        /// <param name="bookingId">Required parameter: The ID of the target [booking]($m/Booking)..</param>
        /// <param name="key">Required parameter: The key of the custom attribute to retrieve. This key must match the `key` of a custom attribute definition in the Square seller account. If the requesting application is not the definition owner, you must use the qualified key..</param>
        /// <param name="withDefinition">Optional parameter: Indicates whether to return the [custom attribute definition]($m/CustomAttributeDefinition) in the `definition` field of the custom attribute. Set this parameter to `true` to get the name and description of the custom attribute, information about the data type, or other definition details. The default value is `false`..</param>
        /// <param name="version">Optional parameter: The current version of the custom attribute, which is used for strongly consistent reads to guarantee that you receive the most up-to-date data. When included in the request, Square returns the specified version or a higher version if one exists. If the specified version is higher than the current version, Square returns a `BAD_REQUEST` error..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveBookingCustomAttributeResponse response from the API call.</returns>
        public async Task<Models.RetrieveBookingCustomAttributeResponse> RetrieveBookingCustomAttributeAsync(
                string bookingId,
                string key,
                bool? withDefinition = false,
                int? version = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/bookings/{booking_id}/custom-attributes/{key}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "booking_id", bookingId },
                { "key", key },
            });

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "with_definition", (withDefinition != null) ? withDefinition : false },
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

            var responseModel = ApiHelper.JsonDeserialize<Models.RetrieveBookingCustomAttributeResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Upserts a bookings custom attribute.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.
        /// For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*.
        /// or *Appointments Premium*.
        /// </summary>
        /// <param name="bookingId">Required parameter: The ID of the target [booking]($m/Booking)..</param>
        /// <param name="key">Required parameter: The key of the custom attribute to create or update. This key must match the `key` of a custom attribute definition in the Square seller account. If the requesting application is not the definition owner, you must use the qualified key..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpsertBookingCustomAttributeResponse response from the API call.</returns>
        public Models.UpsertBookingCustomAttributeResponse UpsertBookingCustomAttribute(
                string bookingId,
                string key,
                Models.UpsertBookingCustomAttributeRequest body)
        {
            Task<Models.UpsertBookingCustomAttributeResponse> t = this.UpsertBookingCustomAttributeAsync(bookingId, key, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Upserts a bookings custom attribute.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.
        /// For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*.
        /// or *Appointments Premium*.
        /// </summary>
        /// <param name="bookingId">Required parameter: The ID of the target [booking]($m/Booking)..</param>
        /// <param name="key">Required parameter: The key of the custom attribute to create or update. This key must match the `key` of a custom attribute definition in the Square seller account. If the requesting application is not the definition owner, you must use the qualified key..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpsertBookingCustomAttributeResponse response from the API call.</returns>
        public async Task<Models.UpsertBookingCustomAttributeResponse> UpsertBookingCustomAttributeAsync(
                string bookingId,
                string key,
                Models.UpsertBookingCustomAttributeRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/bookings/{booking_id}/custom-attributes/{key}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "booking_id", bookingId },
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

            var responseModel = ApiHelper.JsonDeserialize<Models.UpsertBookingCustomAttributeResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }
    }
}