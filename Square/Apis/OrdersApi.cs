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
    using APIMatic.Core;
    using APIMatic.Core.Types;
    using APIMatic.Core.Utilities;
    using APIMatic.Core.Utilities.Date.Xml;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Authentication;
    using Square.Http.Client;
    using Square.Utilities;
    using System.Net.Http;

    /// <summary>
    /// OrdersApi.
    /// </summary>
    internal class OrdersApi : BaseApi, IOrdersApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrdersApi"/> class.
        /// </summary>
        internal OrdersApi(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

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
            => CoreHelper.RunTask(CreateOrderAsync(body));

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
            => await CreateApiCall<Models.CreateOrderResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/orders")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Retrieves a set of [orders]($m/Order) by their IDs.
        /// If a given order ID does not exist, the ID is ignored instead of generating an error.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BatchRetrieveOrdersResponse response from the API call.</returns>
        public Models.BatchRetrieveOrdersResponse BatchRetrieveOrders(
                Models.BatchRetrieveOrdersRequest body)
            => CoreHelper.RunTask(BatchRetrieveOrdersAsync(body));

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
            => await CreateApiCall<Models.BatchRetrieveOrdersResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/orders/batch-retrieve")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Enables applications to preview order pricing without creating an order.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CalculateOrderResponse response from the API call.</returns>
        public Models.CalculateOrderResponse CalculateOrder(
                Models.CalculateOrderRequest body)
            => CoreHelper.RunTask(CalculateOrderAsync(body));

        /// <summary>
        /// Enables applications to preview order pricing without creating an order.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CalculateOrderResponse response from the API call.</returns>
        public async Task<Models.CalculateOrderResponse> CalculateOrderAsync(
                Models.CalculateOrderRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.CalculateOrderResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/orders/calculate")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Creates a new order, in the `DRAFT` state, by duplicating an existing order. The newly created order has.
        /// only the core fields (such as line items, taxes, and discounts) copied from the original order.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CloneOrderResponse response from the API call.</returns>
        public Models.CloneOrderResponse CloneOrder(
                Models.CloneOrderRequest body)
            => CoreHelper.RunTask(CloneOrderAsync(body));

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
            => await CreateApiCall<Models.CloneOrderResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/orders/clone")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

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
            => CoreHelper.RunTask(SearchOrdersAsync(body));

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
            => await CreateApiCall<Models.SearchOrdersResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/orders/search")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Retrieves an [Order]($m/Order) by ID.
        /// </summary>
        /// <param name="orderId">Required parameter: The ID of the order to retrieve..</param>
        /// <returns>Returns the Models.RetrieveOrderResponse response from the API call.</returns>
        public Models.RetrieveOrderResponse RetrieveOrder(
                string orderId)
            => CoreHelper.RunTask(RetrieveOrderAsync(orderId));

        /// <summary>
        /// Retrieves an [Order]($m/Order) by ID.
        /// </summary>
        /// <param name="orderId">Required parameter: The ID of the order to retrieve..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveOrderResponse response from the API call.</returns>
        public async Task<Models.RetrieveOrderResponse> RetrieveOrderAsync(
                string orderId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.RetrieveOrderResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/orders/{order_id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("order_id", orderId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Updates an open [order]($m/Order) by adding, replacing, or deleting.
        /// fields. Orders with a `COMPLETED` or `CANCELED` state cannot be updated.
        /// An `UpdateOrder` request requires the following:.
        /// - The `order_id` in the endpoint path, identifying the order to update.
        /// - The latest `version` of the order to update.
        /// - The [sparse order](https://developer.squareup.com/docs/orders-api/manage-orders/update-orders#sparse-order-objects).
        /// containing only the fields to update and the version to which the update is.
        /// being applied.
        /// - If deleting fields, the [dot notation paths](https://developer.squareup.com/docs/orders-api/manage-orders/update-orders#identifying-fields-to-delete).
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
            => CoreHelper.RunTask(UpdateOrderAsync(orderId, body));

        /// <summary>
        /// Updates an open [order]($m/Order) by adding, replacing, or deleting.
        /// fields. Orders with a `COMPLETED` or `CANCELED` state cannot be updated.
        /// An `UpdateOrder` request requires the following:.
        /// - The `order_id` in the endpoint path, identifying the order to update.
        /// - The latest `version` of the order to update.
        /// - The [sparse order](https://developer.squareup.com/docs/orders-api/manage-orders/update-orders#sparse-order-objects).
        /// containing only the fields to update and the version to which the update is.
        /// being applied.
        /// - If deleting fields, the [dot notation paths](https://developer.squareup.com/docs/orders-api/manage-orders/update-orders#identifying-fields-to-delete).
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
            => await CreateApiCall<Models.UpdateOrderResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Put, "/v2/orders/{order_id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Template(_template => _template.Setup("order_id", orderId))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

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
            => CoreHelper.RunTask(PayOrderAsync(orderId, body));

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
            => await CreateApiCall<Models.PayOrderResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/orders/{order_id}/pay")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Template(_template => _template.Setup("order_id", orderId))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);
    }
}