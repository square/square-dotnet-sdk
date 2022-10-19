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
    /// OrdersApi.
    /// </summary>
    internal class OrdersApi : BaseApi, IOrdersApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrdersApi"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal OrdersApi(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// Creates a new [order]($m/Order) that can include information about products for.
        /// purchase and settings to apply to the purchase.
        /// To pay for a created order, see.
        /// [Pay for Orders](https://developer.squareup.com/docs/orders-api/pay-for-orders).
        /// You can modify open orders using the [UpdateOrder]($e/Orders/UpdateOrder) endpoint.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateOrderResponse response from the API call.</returns>
        public Models.CreateOrderResponse CreateOrder(
                Models.CreateOrderRequest body)
        {
            Task<Models.CreateOrderResponse> t = this.CreateOrderAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Creates a new [order]($m/Order) that can include information about products for.
        /// purchase and settings to apply to the purchase.
        /// To pay for a created order, see.
        /// [Pay for Orders](https://developer.squareup.com/docs/orders-api/pay-for-orders).
        /// You can modify open orders using the [UpdateOrder]($e/Orders/UpdateOrder) endpoint.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateOrderResponse response from the API call.</returns>
        public async Task<Models.CreateOrderResponse> CreateOrderAsync(
                Models.CreateOrderRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/orders");

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

            var responseModel = ApiHelper.JsonDeserialize<Models.CreateOrderResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Retrieves a set of [orders]($m/Order) by their IDs.
        /// If a given order ID does not exist, the ID is ignored instead of generating an error.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BatchRetrieveOrdersResponse response from the API call.</returns>
        public Models.BatchRetrieveOrdersResponse BatchRetrieveOrders(
                Models.BatchRetrieveOrdersRequest body)
        {
            Task<Models.BatchRetrieveOrdersResponse> t = this.BatchRetrieveOrdersAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Retrieves a set of [orders]($m/Order) by their IDs.
        /// If a given order ID does not exist, the ID is ignored instead of generating an error.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BatchRetrieveOrdersResponse response from the API call.</returns>
        public async Task<Models.BatchRetrieveOrdersResponse> BatchRetrieveOrdersAsync(
                Models.BatchRetrieveOrdersRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/orders/batch-retrieve");

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

            var responseModel = ApiHelper.JsonDeserialize<Models.BatchRetrieveOrdersResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Enables applications to preview order pricing without creating an order.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CalculateOrderResponse response from the API call.</returns>
        public Models.CalculateOrderResponse CalculateOrder(
                Models.CalculateOrderRequest body)
        {
            Task<Models.CalculateOrderResponse> t = this.CalculateOrderAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Enables applications to preview order pricing without creating an order.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CalculateOrderResponse response from the API call.</returns>
        public async Task<Models.CalculateOrderResponse> CalculateOrderAsync(
                Models.CalculateOrderRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/orders/calculate");

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

            var responseModel = ApiHelper.JsonDeserialize<Models.CalculateOrderResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Creates a new order, in the `DRAFT` state, by duplicating an existing order. The newly created order has.
        /// only the core fields (such as line items, taxes, and discounts) copied from the original order.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CloneOrderResponse response from the API call.</returns>
        public Models.CloneOrderResponse CloneOrder(
                Models.CloneOrderRequest body)
        {
            Task<Models.CloneOrderResponse> t = this.CloneOrderAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Creates a new order, in the `DRAFT` state, by duplicating an existing order. The newly created order has.
        /// only the core fields (such as line items, taxes, and discounts) copied from the original order.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CloneOrderResponse response from the API call.</returns>
        public async Task<Models.CloneOrderResponse> CloneOrderAsync(
                Models.CloneOrderRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/orders/clone");

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

            var responseModel = ApiHelper.JsonDeserialize<Models.CloneOrderResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Search all orders for one or more locations. Orders include all sales,.
        /// returns, and exchanges regardless of how or when they entered the Square.
        /// ecosystem (such as Point of Sale, Invoices, and Connect APIs).
        /// `SearchOrders` requests need to specify which locations to search and define a.
        /// [SearchOrdersQuery]($m/SearchOrdersQuery) object that controls.
        /// how to sort or filter the results. Your `SearchOrdersQuery` can:.
        ///   Set filter criteria.
        ///   Set the sort order.
        ///   Determine whether to return results as complete `Order` objects or as.
        /// [OrderEntry]($m/OrderEntry) objects.
        /// Note that details for orders processed with Square Point of Sale while in.
        /// offline mode might not be transmitted to Square for up to 72 hours. Offline.
        /// orders have a `created_at` value that reflects the time the order was created,.
        /// not the time it was subsequently transmitted to Square.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.SearchOrdersResponse response from the API call.</returns>
        public Models.SearchOrdersResponse SearchOrders(
                Models.SearchOrdersRequest body)
        {
            Task<Models.SearchOrdersResponse> t = this.SearchOrdersAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Search all orders for one or more locations. Orders include all sales,.
        /// returns, and exchanges regardless of how or when they entered the Square.
        /// ecosystem (such as Point of Sale, Invoices, and Connect APIs).
        /// `SearchOrders` requests need to specify which locations to search and define a.
        /// [SearchOrdersQuery]($m/SearchOrdersQuery) object that controls.
        /// how to sort or filter the results. Your `SearchOrdersQuery` can:.
        ///   Set filter criteria.
        ///   Set the sort order.
        ///   Determine whether to return results as complete `Order` objects or as.
        /// [OrderEntry]($m/OrderEntry) objects.
        /// Note that details for orders processed with Square Point of Sale while in.
        /// offline mode might not be transmitted to Square for up to 72 hours. Offline.
        /// orders have a `created_at` value that reflects the time the order was created,.
        /// not the time it was subsequently transmitted to Square.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.SearchOrdersResponse response from the API call.</returns>
        public async Task<Models.SearchOrdersResponse> SearchOrdersAsync(
                Models.SearchOrdersRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/orders/search");

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

            var responseModel = ApiHelper.JsonDeserialize<Models.SearchOrdersResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Retrieves an [Order]($m/Order) by ID.
        /// </summary>
        /// <param name="orderId">Required parameter: The ID of the order to retrieve..</param>
        /// <returns>Returns the Models.RetrieveOrderResponse response from the API call.</returns>
        public Models.RetrieveOrderResponse RetrieveOrder(
                string orderId)
        {
            Task<Models.RetrieveOrderResponse> t = this.RetrieveOrderAsync(orderId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Retrieves an [Order]($m/Order) by ID.
        /// </summary>
        /// <param name="orderId">Required parameter: The ID of the order to retrieve..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveOrderResponse response from the API call.</returns>
        public async Task<Models.RetrieveOrderResponse> RetrieveOrderAsync(
                string orderId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/orders/{order_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
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

            var responseModel = ApiHelper.JsonDeserialize<Models.RetrieveOrderResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Updates an open [order]($m/Order) by adding, replacing, or deleting.
        /// fields. Orders with a `COMPLETED` or `CANCELED` state cannot be updated.
        /// An `UpdateOrder` request requires the following:.
        /// - The `order_id` in the endpoint path, identifying the order to update.
        /// - The latest `version` of the order to update.
        /// - The [sparse order](https://developer.squareup.com/docs/orders-api/manage-orders/update-orders#sparse-order-objects).
        /// containing only the fields to update and the version to which the update is.
        /// being applied.
        /// - If deleting fields, the [dot notation paths](https://developer.squareup.com/docs/orders-api/manage-orders#on-dot-notation).
        /// identifying the fields to clear.
        /// To pay for an order, see.
        /// [Pay for Orders](https://developer.squareup.com/docs/orders-api/pay-for-orders).
        /// </summary>
        /// <param name="orderId">Required parameter: The ID of the order to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpdateOrderResponse response from the API call.</returns>
        public Models.UpdateOrderResponse UpdateOrder(
                string orderId,
                Models.UpdateOrderRequest body)
        {
            Task<Models.UpdateOrderResponse> t = this.UpdateOrderAsync(orderId, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Updates an open [order]($m/Order) by adding, replacing, or deleting.
        /// fields. Orders with a `COMPLETED` or `CANCELED` state cannot be updated.
        /// An `UpdateOrder` request requires the following:.
        /// - The `order_id` in the endpoint path, identifying the order to update.
        /// - The latest `version` of the order to update.
        /// - The [sparse order](https://developer.squareup.com/docs/orders-api/manage-orders/update-orders#sparse-order-objects).
        /// containing only the fields to update and the version to which the update is.
        /// being applied.
        /// - If deleting fields, the [dot notation paths](https://developer.squareup.com/docs/orders-api/manage-orders#on-dot-notation).
        /// identifying the fields to clear.
        /// To pay for an order, see.
        /// [Pay for Orders](https://developer.squareup.com/docs/orders-api/pay-for-orders).
        /// </summary>
        /// <param name="orderId">Required parameter: The ID of the order to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpdateOrderResponse response from the API call.</returns>
        public async Task<Models.UpdateOrderResponse> UpdateOrderAsync(
                string orderId,
                Models.UpdateOrderRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/orders/{order_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
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

            var responseModel = ApiHelper.JsonDeserialize<Models.UpdateOrderResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Pay for an [order]($m/Order) using one or more approved [payments]($m/Payment).
        /// or settle an order with a total of `0`.
        /// The total of the `payment_ids` listed in the request must be equal to the order.
        /// total. Orders with a total amount of `0` can be marked as paid by specifying an empty.
        /// array of `payment_ids` in the request.
        /// To be used with `PayOrder`, a payment must:.
        /// - Reference the order by specifying the `order_id` when [creating the payment]($e/Payments/CreatePayment).
        /// Any approved payments that reference the same `order_id` not specified in the.
        /// `payment_ids` is canceled.
        /// - Be approved with [delayed capture](https://developer.squareup.com/docs/payments-api/take-payments/card-payments/delayed-capture).
        /// Using a delayed capture payment with `PayOrder` completes the approved payment.
        /// </summary>
        /// <param name="orderId">Required parameter: The ID of the order being paid..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.PayOrderResponse response from the API call.</returns>
        public Models.PayOrderResponse PayOrder(
                string orderId,
                Models.PayOrderRequest body)
        {
            Task<Models.PayOrderResponse> t = this.PayOrderAsync(orderId, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Pay for an [order]($m/Order) using one or more approved [payments]($m/Payment).
        /// or settle an order with a total of `0`.
        /// The total of the `payment_ids` listed in the request must be equal to the order.
        /// total. Orders with a total amount of `0` can be marked as paid by specifying an empty.
        /// array of `payment_ids` in the request.
        /// To be used with `PayOrder`, a payment must:.
        /// - Reference the order by specifying the `order_id` when [creating the payment]($e/Payments/CreatePayment).
        /// Any approved payments that reference the same `order_id` not specified in the.
        /// `payment_ids` is canceled.
        /// - Be approved with [delayed capture](https://developer.squareup.com/docs/payments-api/take-payments/card-payments/delayed-capture).
        /// Using a delayed capture payment with `PayOrder` completes the approved payment.
        /// </summary>
        /// <param name="orderId">Required parameter: The ID of the order being paid..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.PayOrderResponse response from the API call.</returns>
        public async Task<Models.PayOrderResponse> PayOrderAsync(
                string orderId,
                Models.PayOrderRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/orders/{order_id}/pay");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
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

            var responseModel = ApiHelper.JsonDeserialize<Models.PayOrderResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }
    }
}