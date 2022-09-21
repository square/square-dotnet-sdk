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
    /// V1TransactionsApi.
    /// </summary>
    internal class V1TransactionsApi : BaseApi, IV1TransactionsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="V1TransactionsApi"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal V1TransactionsApi(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// Provides summary information for a merchant's online store orders.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to list online store orders for..</param>
        /// <param name="order">Optional parameter: The order in which payments are listed in the response..</param>
        /// <param name="limit">Optional parameter: The maximum number of payments to return in a single response. This value cannot exceed 200..</param>
        /// <param name="batchToken">Optional parameter: A pagination cursor to retrieve the next set of results for your original query to the endpoint..</param>
        /// <returns>Returns the List of Models.V1Order response from the API call.</returns>
        [Obsolete]
        public List<Models.V1Order> V1ListOrders(
                string locationId,
                string order = null,
                int? limit = null,
                string batchToken = null)
        {
            Task<List<Models.V1Order>> t = this.V1ListOrdersAsync(locationId, order, limit, batchToken);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Provides summary information for a merchant's online store orders.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to list online store orders for..</param>
        /// <param name="order">Optional parameter: The order in which payments are listed in the response..</param>
        /// <param name="limit">Optional parameter: The maximum number of payments to return in a single response. This value cannot exceed 200..</param>
        /// <param name="batchToken">Optional parameter: A pagination cursor to retrieve the next set of results for your original query to the endpoint..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the List of Models.V1Order response from the API call.</returns>
        [Obsolete]
        public async Task<List<Models.V1Order>> V1ListOrdersAsync(
                string locationId,
                string order = null,
                int? limit = null,
                string batchToken = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/{location_id}/orders");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "location_id", locationId },
            });

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "order", order },
                { "limit", limit },
                { "batch_token", batchToken },
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

            var responseModels = ApiHelper.JsonDeserialize<List<Models.V1Order>>(response.Body);
            responseModels.ForEach(r => r.Context = context);
            return responseModels;
        }

        /// <summary>
        /// Provides comprehensive information for a single online store order, including the order's history.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the order's associated location..</param>
        /// <param name="orderId">Required parameter: The order's Square-issued ID. You obtain this value from Order objects returned by the List Orders endpoint.</param>
        /// <returns>Returns the Models.V1Order response from the API call.</returns>
        [Obsolete]
        public Models.V1Order V1RetrieveOrder(
                string locationId,
                string orderId)
        {
            Task<Models.V1Order> t = this.V1RetrieveOrderAsync(locationId, orderId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Provides comprehensive information for a single online store order, including the order's history.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the order's associated location..</param>
        /// <param name="orderId">Required parameter: The order's Square-issued ID. You obtain this value from Order objects returned by the List Orders endpoint.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.V1Order response from the API call.</returns>
        [Obsolete]
        public async Task<Models.V1Order> V1RetrieveOrderAsync(
                string locationId,
                string orderId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/{location_id}/orders/{order_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "location_id", locationId },
                { "order_id", orderId },
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

            var responseModel = ApiHelper.JsonDeserialize<Models.V1Order>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Updates the details of an online store order. Every update you perform on an order corresponds to one of three actions:.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the order's associated location..</param>
        /// <param name="orderId">Required parameter: The order's Square-issued ID. You obtain this value from Order objects returned by the List Orders endpoint.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.V1Order response from the API call.</returns>
        [Obsolete]
        public Models.V1Order V1UpdateOrder(
                string locationId,
                string orderId,
                Models.V1UpdateOrderRequest body)
        {
            Task<Models.V1Order> t = this.V1UpdateOrderAsync(locationId, orderId, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Updates the details of an online store order. Every update you perform on an order corresponds to one of three actions:.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the order's associated location..</param>
        /// <param name="orderId">Required parameter: The order's Square-issued ID. You obtain this value from Order objects returned by the List Orders endpoint.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.V1Order response from the API call.</returns>
        [Obsolete]
        public async Task<Models.V1Order> V1UpdateOrderAsync(
                string locationId,
                string orderId,
                Models.V1UpdateOrderRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/{location_id}/orders/{order_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "location_id", locationId },
                { "order_id", orderId },
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

            var responseModel = ApiHelper.JsonDeserialize<Models.V1Order>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Provides summary information for all payments taken for a given.
        /// Square account during a date range. Date ranges cannot exceed 1 year in.
        /// length. See Date ranges for details of inclusive and exclusive dates.
        /// *Note**: Details for payments processed with Square Point of Sale while.
        /// in offline mode may not be transmitted to Square for up to 72 hours.
        /// Offline payments have a `created_at` value that reflects the time the.
        /// payment was originally processed, not the time it was subsequently.
        /// transmitted to Square. Consequently, the ListPayments endpoint might.
        /// list an offline payment chronologically between online payments that.
        /// were seen in a previous request.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to list payments for. If you specify me, this endpoint returns payments aggregated from all of the business's locations..</param>
        /// <param name="order">Optional parameter: The order in which payments are listed in the response..</param>
        /// <param name="beginTime">Optional parameter: The beginning of the requested reporting period, in ISO 8601 format. If this value is before January 1, 2013 (2013-01-01T00:00:00Z), this endpoint returns an error. Default value: The current time minus one year..</param>
        /// <param name="endTime">Optional parameter: The end of the requested reporting period, in ISO 8601 format. If this value is more than one year greater than begin_time, this endpoint returns an error. Default value: The current time..</param>
        /// <param name="limit">Optional parameter: The maximum number of payments to return in a single response. This value cannot exceed 200..</param>
        /// <param name="batchToken">Optional parameter: A pagination cursor to retrieve the next set of results for your original query to the endpoint..</param>
        /// <param name="includePartial">Optional parameter: Indicates whether or not to include partial payments in the response. Partial payments will have the tenders collected so far, but the itemizations will be empty until the payment is completed..</param>
        /// <returns>Returns the List of Models.V1Payment response from the API call.</returns>
        [Obsolete]
        public List<Models.V1Payment> V1ListPayments(
                string locationId,
                string order = null,
                string beginTime = null,
                string endTime = null,
                int? limit = null,
                string batchToken = null,
                bool? includePartial = false)
        {
            Task<List<Models.V1Payment>> t = this.V1ListPaymentsAsync(locationId, order, beginTime, endTime, limit, batchToken, includePartial);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Provides summary information for all payments taken for a given.
        /// Square account during a date range. Date ranges cannot exceed 1 year in.
        /// length. See Date ranges for details of inclusive and exclusive dates.
        /// *Note**: Details for payments processed with Square Point of Sale while.
        /// in offline mode may not be transmitted to Square for up to 72 hours.
        /// Offline payments have a `created_at` value that reflects the time the.
        /// payment was originally processed, not the time it was subsequently.
        /// transmitted to Square. Consequently, the ListPayments endpoint might.
        /// list an offline payment chronologically between online payments that.
        /// were seen in a previous request.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to list payments for. If you specify me, this endpoint returns payments aggregated from all of the business's locations..</param>
        /// <param name="order">Optional parameter: The order in which payments are listed in the response..</param>
        /// <param name="beginTime">Optional parameter: The beginning of the requested reporting period, in ISO 8601 format. If this value is before January 1, 2013 (2013-01-01T00:00:00Z), this endpoint returns an error. Default value: The current time minus one year..</param>
        /// <param name="endTime">Optional parameter: The end of the requested reporting period, in ISO 8601 format. If this value is more than one year greater than begin_time, this endpoint returns an error. Default value: The current time..</param>
        /// <param name="limit">Optional parameter: The maximum number of payments to return in a single response. This value cannot exceed 200..</param>
        /// <param name="batchToken">Optional parameter: A pagination cursor to retrieve the next set of results for your original query to the endpoint..</param>
        /// <param name="includePartial">Optional parameter: Indicates whether or not to include partial payments in the response. Partial payments will have the tenders collected so far, but the itemizations will be empty until the payment is completed..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the List of Models.V1Payment response from the API call.</returns>
        [Obsolete]
        public async Task<List<Models.V1Payment>> V1ListPaymentsAsync(
                string locationId,
                string order = null,
                string beginTime = null,
                string endTime = null,
                int? limit = null,
                string batchToken = null,
                bool? includePartial = false,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/{location_id}/payments");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "location_id", locationId },
            });

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "order", order },
                { "begin_time", beginTime },
                { "end_time", endTime },
                { "limit", limit },
                { "batch_token", batchToken },
                { "include_partial", (includePartial != null) ? includePartial : false },
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

            var responseModels = ApiHelper.JsonDeserialize<List<Models.V1Payment>>(response.Body);
            responseModels.ForEach(r => r.Context = context);
            return responseModels;
        }

        /// <summary>
        /// Provides comprehensive information for a single payment.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the payment's associated location..</param>
        /// <param name="paymentId">Required parameter: The Square-issued payment ID. payment_id comes from Payment objects returned by the List Payments endpoint, Settlement objects returned by the List Settlements endpoint, or Refund objects returned by the List Refunds endpoint..</param>
        /// <returns>Returns the Models.V1Payment response from the API call.</returns>
        [Obsolete]
        public Models.V1Payment V1RetrievePayment(
                string locationId,
                string paymentId)
        {
            Task<Models.V1Payment> t = this.V1RetrievePaymentAsync(locationId, paymentId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Provides comprehensive information for a single payment.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the payment's associated location..</param>
        /// <param name="paymentId">Required parameter: The Square-issued payment ID. payment_id comes from Payment objects returned by the List Payments endpoint, Settlement objects returned by the List Settlements endpoint, or Refund objects returned by the List Refunds endpoint..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.V1Payment response from the API call.</returns>
        [Obsolete]
        public async Task<Models.V1Payment> V1RetrievePaymentAsync(
                string locationId,
                string paymentId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/{location_id}/payments/{payment_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "location_id", locationId },
                { "payment_id", paymentId },
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

            var responseModel = ApiHelper.JsonDeserialize<Models.V1Payment>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Provides the details for all refunds initiated by a merchant or any of the merchant's mobile staff during a date range. Date ranges cannot exceed one year in length.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to list refunds for..</param>
        /// <param name="order">Optional parameter: The order in which payments are listed in the response..</param>
        /// <param name="beginTime">Optional parameter: The beginning of the requested reporting period, in ISO 8601 format. If this value is before January 1, 2013 (2013-01-01T00:00:00Z), this endpoint returns an error. Default value: The current time minus one year..</param>
        /// <param name="endTime">Optional parameter: The end of the requested reporting period, in ISO 8601 format. If this value is more than one year greater than begin_time, this endpoint returns an error. Default value: The current time..</param>
        /// <param name="limit">Optional parameter: The approximate number of refunds to return in a single response. Default: 100. Max: 200. Response may contain more results than the prescribed limit when refunds are made simultaneously to multiple tenders in a payment or when refunds are generated in an exchange to account for the value of returned goods..</param>
        /// <param name="batchToken">Optional parameter: A pagination cursor to retrieve the next set of results for your original query to the endpoint..</param>
        /// <returns>Returns the List of Models.V1Refund response from the API call.</returns>
        [Obsolete]
        public List<Models.V1Refund> V1ListRefunds(
                string locationId,
                string order = null,
                string beginTime = null,
                string endTime = null,
                int? limit = null,
                string batchToken = null)
        {
            Task<List<Models.V1Refund>> t = this.V1ListRefundsAsync(locationId, order, beginTime, endTime, limit, batchToken);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Provides the details for all refunds initiated by a merchant or any of the merchant's mobile staff during a date range. Date ranges cannot exceed one year in length.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to list refunds for..</param>
        /// <param name="order">Optional parameter: The order in which payments are listed in the response..</param>
        /// <param name="beginTime">Optional parameter: The beginning of the requested reporting period, in ISO 8601 format. If this value is before January 1, 2013 (2013-01-01T00:00:00Z), this endpoint returns an error. Default value: The current time minus one year..</param>
        /// <param name="endTime">Optional parameter: The end of the requested reporting period, in ISO 8601 format. If this value is more than one year greater than begin_time, this endpoint returns an error. Default value: The current time..</param>
        /// <param name="limit">Optional parameter: The approximate number of refunds to return in a single response. Default: 100. Max: 200. Response may contain more results than the prescribed limit when refunds are made simultaneously to multiple tenders in a payment or when refunds are generated in an exchange to account for the value of returned goods..</param>
        /// <param name="batchToken">Optional parameter: A pagination cursor to retrieve the next set of results for your original query to the endpoint..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the List of Models.V1Refund response from the API call.</returns>
        [Obsolete]
        public async Task<List<Models.V1Refund>> V1ListRefundsAsync(
                string locationId,
                string order = null,
                string beginTime = null,
                string endTime = null,
                int? limit = null,
                string batchToken = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/{location_id}/refunds");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "location_id", locationId },
            });

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "order", order },
                { "begin_time", beginTime },
                { "end_time", endTime },
                { "limit", limit },
                { "batch_token", batchToken },
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

            var responseModels = ApiHelper.JsonDeserialize<List<Models.V1Refund>>(response.Body);
            responseModels.ForEach(r => r.Context = context);
            return responseModels;
        }

        /// <summary>
        /// Issues a refund for a previously processed payment. You must issue.
        /// a refund within 60 days of the associated payment.
        /// You cannot issue a partial refund for a split tender payment. You must.
        /// instead issue a full or partial refund for a particular tender, by.
        /// providing the applicable tender id to the V1CreateRefund endpoint.
        /// Issuing a full refund for a split tender payment refunds all tenders.
        /// associated with the payment.
        /// Issuing a refund for a card payment is not reversible. For development.
        /// purposes, you can create fake cash payments in Square Point of Sale and.
        /// refund them.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the original payment's associated location..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.V1Refund response from the API call.</returns>
        [Obsolete]
        public Models.V1Refund V1CreateRefund(
                string locationId,
                Models.V1CreateRefundRequest body)
        {
            Task<Models.V1Refund> t = this.V1CreateRefundAsync(locationId, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Issues a refund for a previously processed payment. You must issue.
        /// a refund within 60 days of the associated payment.
        /// You cannot issue a partial refund for a split tender payment. You must.
        /// instead issue a full or partial refund for a particular tender, by.
        /// providing the applicable tender id to the V1CreateRefund endpoint.
        /// Issuing a full refund for a split tender payment refunds all tenders.
        /// associated with the payment.
        /// Issuing a refund for a card payment is not reversible. For development.
        /// purposes, you can create fake cash payments in Square Point of Sale and.
        /// refund them.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the original payment's associated location..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.V1Refund response from the API call.</returns>
        [Obsolete]
        public async Task<Models.V1Refund> V1CreateRefundAsync(
                string locationId,
                Models.V1CreateRefundRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/{location_id}/refunds");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "location_id", locationId },
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

            var responseModel = ApiHelper.JsonDeserialize<Models.V1Refund>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Provides summary information for all deposits and withdrawals.
        /// initiated by Square to a linked bank account during a date range. Date.
        /// ranges cannot exceed one year in length.
        /// *Note**: the ListSettlements endpoint does not provide entry.
        /// information.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to list settlements for. If you specify me, this endpoint returns settlements aggregated from all of the business's locations..</param>
        /// <param name="order">Optional parameter: The order in which settlements are listed in the response..</param>
        /// <param name="beginTime">Optional parameter: The beginning of the requested reporting period, in ISO 8601 format. If this value is before January 1, 2013 (2013-01-01T00:00:00Z), this endpoint returns an error. Default value: The current time minus one year..</param>
        /// <param name="endTime">Optional parameter: The end of the requested reporting period, in ISO 8601 format. If this value is more than one year greater than begin_time, this endpoint returns an error. Default value: The current time..</param>
        /// <param name="limit">Optional parameter: The maximum number of settlements to return in a single response. This value cannot exceed 200..</param>
        /// <param name="status">Optional parameter: Provide this parameter to retrieve only settlements with a particular status (SENT or FAILED)..</param>
        /// <param name="batchToken">Optional parameter: A pagination cursor to retrieve the next set of results for your original query to the endpoint..</param>
        /// <returns>Returns the List of Models.V1Settlement response from the API call.</returns>
        [Obsolete]
        public List<Models.V1Settlement> V1ListSettlements(
                string locationId,
                string order = null,
                string beginTime = null,
                string endTime = null,
                int? limit = null,
                string status = null,
                string batchToken = null)
        {
            Task<List<Models.V1Settlement>> t = this.V1ListSettlementsAsync(locationId, order, beginTime, endTime, limit, status, batchToken);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Provides summary information for all deposits and withdrawals.
        /// initiated by Square to a linked bank account during a date range. Date.
        /// ranges cannot exceed one year in length.
        /// *Note**: the ListSettlements endpoint does not provide entry.
        /// information.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to list settlements for. If you specify me, this endpoint returns settlements aggregated from all of the business's locations..</param>
        /// <param name="order">Optional parameter: The order in which settlements are listed in the response..</param>
        /// <param name="beginTime">Optional parameter: The beginning of the requested reporting period, in ISO 8601 format. If this value is before January 1, 2013 (2013-01-01T00:00:00Z), this endpoint returns an error. Default value: The current time minus one year..</param>
        /// <param name="endTime">Optional parameter: The end of the requested reporting period, in ISO 8601 format. If this value is more than one year greater than begin_time, this endpoint returns an error. Default value: The current time..</param>
        /// <param name="limit">Optional parameter: The maximum number of settlements to return in a single response. This value cannot exceed 200..</param>
        /// <param name="status">Optional parameter: Provide this parameter to retrieve only settlements with a particular status (SENT or FAILED)..</param>
        /// <param name="batchToken">Optional parameter: A pagination cursor to retrieve the next set of results for your original query to the endpoint..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the List of Models.V1Settlement response from the API call.</returns>
        [Obsolete]
        public async Task<List<Models.V1Settlement>> V1ListSettlementsAsync(
                string locationId,
                string order = null,
                string beginTime = null,
                string endTime = null,
                int? limit = null,
                string status = null,
                string batchToken = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/{location_id}/settlements");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "location_id", locationId },
            });

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "order", order },
                { "begin_time", beginTime },
                { "end_time", endTime },
                { "limit", limit },
                { "status", status },
                { "batch_token", batchToken },
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

            var responseModels = ApiHelper.JsonDeserialize<List<Models.V1Settlement>>(response.Body);
            responseModels.ForEach(r => r.Context = context);
            return responseModels;
        }

        /// <summary>
        /// Provides comprehensive information for a single settlement.
        /// The returned `Settlement` objects include an `entries` field that lists.
        /// the transactions that contribute to the settlement total. Most.
        /// settlement entries correspond to a payment payout, but settlement.
        /// entries are also generated for less common events, like refunds, manual.
        /// adjustments, or chargeback holds.
        /// Square initiates its regular deposits as indicated in the.
        /// [Deposit Options with Square](https://squareup.com/help/us/en/article/3807).
        /// help article. Details for a regular deposit are usually not available.
        /// from Connect API endpoints before 10 p.m. PST the same day.
        /// Square does not know when an initiated settlement **completes**, only.
        /// whether it has failed. A completed settlement is typically reflected in.
        /// a bank account within 3 business days, but in exceptional cases it may.
        /// take longer.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the settlements's associated location..</param>
        /// <param name="settlementId">Required parameter: The settlement's Square-issued ID. You obtain this value from Settlement objects returned by the List Settlements endpoint..</param>
        /// <returns>Returns the Models.V1Settlement response from the API call.</returns>
        [Obsolete]
        public Models.V1Settlement V1RetrieveSettlement(
                string locationId,
                string settlementId)
        {
            Task<Models.V1Settlement> t = this.V1RetrieveSettlementAsync(locationId, settlementId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Provides comprehensive information for a single settlement.
        /// The returned `Settlement` objects include an `entries` field that lists.
        /// the transactions that contribute to the settlement total. Most.
        /// settlement entries correspond to a payment payout, but settlement.
        /// entries are also generated for less common events, like refunds, manual.
        /// adjustments, or chargeback holds.
        /// Square initiates its regular deposits as indicated in the.
        /// [Deposit Options with Square](https://squareup.com/help/us/en/article/3807).
        /// help article. Details for a regular deposit are usually not available.
        /// from Connect API endpoints before 10 p.m. PST the same day.
        /// Square does not know when an initiated settlement **completes**, only.
        /// whether it has failed. A completed settlement is typically reflected in.
        /// a bank account within 3 business days, but in exceptional cases it may.
        /// take longer.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the settlements's associated location..</param>
        /// <param name="settlementId">Required parameter: The settlement's Square-issued ID. You obtain this value from Settlement objects returned by the List Settlements endpoint..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.V1Settlement response from the API call.</returns>
        [Obsolete]
        public async Task<Models.V1Settlement> V1RetrieveSettlementAsync(
                string locationId,
                string settlementId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/{location_id}/settlements/{settlement_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "location_id", locationId },
                { "settlement_id", settlementId },
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

            var responseModel = ApiHelper.JsonDeserialize<Models.V1Settlement>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }
    }
}