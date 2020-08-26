using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Square;
using Square.Utilities;
using Square.Http.Request;
using Square.Http.Response;
using Square.Http.Client;

namespace Square.Apis
{
    public interface IOrdersApi
    {
        /// <summary>
        /// Creates a new [Order](#type-order) which can include information on products for
        /// purchase and settings to apply to the purchase.
        /// To pay for a created order, please refer to the [Pay for Orders](https://developer.squareup.com/docs/orders-api/pay-for-orders)
        /// guide.
        /// You can modify open orders using the [UpdateOrder](#endpoint-orders-updateorder) endpoint.
        /// To learn more about the Orders API, see the
        /// [Orders API Overview](https://developer.squareup.com/docs/orders-api/what-it-does).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreateOrderResponse response from the API call</return>
        Models.CreateOrderResponse CreateOrder(Models.CreateOrderRequest body);

        /// <summary>
        /// Creates a new [Order](#type-order) which can include information on products for
        /// purchase and settings to apply to the purchase.
        /// To pay for a created order, please refer to the [Pay for Orders](https://developer.squareup.com/docs/orders-api/pay-for-orders)
        /// guide.
        /// You can modify open orders using the [UpdateOrder](#endpoint-orders-updateorder) endpoint.
        /// To learn more about the Orders API, see the
        /// [Orders API Overview](https://developer.squareup.com/docs/orders-api/what-it-does).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreateOrderResponse response from the API call</return>
        Task<Models.CreateOrderResponse> CreateOrderAsync(Models.CreateOrderRequest body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a set of [Order](#type-order)s by their IDs.
        /// If a given Order ID does not exist, the ID is ignored instead of generating an error.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.BatchRetrieveOrdersResponse response from the API call</return>
        Models.BatchRetrieveOrdersResponse BatchRetrieveOrders(Models.BatchRetrieveOrdersRequest body);

        /// <summary>
        /// Retrieves a set of [Order](#type-order)s by their IDs.
        /// If a given Order ID does not exist, the ID is ignored instead of generating an error.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.BatchRetrieveOrdersResponse response from the API call</return>
        Task<Models.BatchRetrieveOrdersResponse> BatchRetrieveOrdersAsync(Models.BatchRetrieveOrdersRequest body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Calculates an [Order](#type-order).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CalculateOrderResponse response from the API call</return>
        Models.CalculateOrderResponse CalculateOrder(Models.CalculateOrderRequest body);

        /// <summary>
        /// Calculates an [Order](#type-order).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CalculateOrderResponse response from the API call</return>
        Task<Models.CalculateOrderResponse> CalculateOrderAsync(Models.CalculateOrderRequest body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Search all orders for one or more locations. Orders include all sales,
        /// returns, and exchanges regardless of how or when they entered the Square
        /// Ecosystem (e.g. Point of Sale, Invoices, Connect APIs, etc).
        /// SearchOrders requests need to specify which locations to search and define a
        /// [`SearchOrdersQuery`](#type-searchordersquery) object which controls
        /// how to sort or filter the results. Your SearchOrdersQuery can:
        ///   Set filter criteria.
        ///   Set sort order.
        ///   Determine whether to return results as complete Order objects, or as
        /// [OrderEntry](#type-orderentry) objects.
        /// Note that details for orders processed with Square Point of Sale while in
        /// offline mode may not be transmitted to Square for up to 72 hours. Offline
        /// orders have a `created_at` value that reflects the time the order was created,
        /// not the time it was subsequently transmitted to Square.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.SearchOrdersResponse response from the API call</return>
        Models.SearchOrdersResponse SearchOrders(Models.SearchOrdersRequest body);

        /// <summary>
        /// Search all orders for one or more locations. Orders include all sales,
        /// returns, and exchanges regardless of how or when they entered the Square
        /// Ecosystem (e.g. Point of Sale, Invoices, Connect APIs, etc).
        /// SearchOrders requests need to specify which locations to search and define a
        /// [`SearchOrdersQuery`](#type-searchordersquery) object which controls
        /// how to sort or filter the results. Your SearchOrdersQuery can:
        ///   Set filter criteria.
        ///   Set sort order.
        ///   Determine whether to return results as complete Order objects, or as
        /// [OrderEntry](#type-orderentry) objects.
        /// Note that details for orders processed with Square Point of Sale while in
        /// offline mode may not be transmitted to Square for up to 72 hours. Offline
        /// orders have a `created_at` value that reflects the time the order was created,
        /// not the time it was subsequently transmitted to Square.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.SearchOrdersResponse response from the API call</return>
        Task<Models.SearchOrdersResponse> SearchOrdersAsync(Models.SearchOrdersRequest body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an open [Order](#type-order) by adding, replacing, or deleting
        /// fields. Orders with a `COMPLETED` or `CANCELED` state cannot be updated.
        /// An UpdateOrder request requires the following:
        /// - The `order_id` in the endpoint path, identifying the order to update.
        /// - The latest `version` of the order to update.
        /// - The [sparse order](https://developer.squareup.com/docs/orders-api/manage-orders#sparse-order-objects)
        /// containing only the fields to update and the version the update is
        /// being applied to.
        /// - If deleting fields, the [dot notation paths](https://developer.squareup.com/docs/orders-api/manage-orders#on-dot-notation)
        /// identifying fields to clear.
        /// To pay for an order, please refer to the [Pay for Orders](https://developer.squareup.com/docs/orders-api/pay-for-orders) guide.
        /// To learn more about the Orders API, see the
        /// [Orders API Overview](https://developer.squareup.com/docs/orders-api/what-it-does).
        /// </summary>
        /// <param name="orderId">Required parameter: The ID of the order to update.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.UpdateOrderResponse response from the API call</return>
        Models.UpdateOrderResponse UpdateOrder(string orderId, Models.UpdateOrderRequest body);

        /// <summary>
        /// Updates an open [Order](#type-order) by adding, replacing, or deleting
        /// fields. Orders with a `COMPLETED` or `CANCELED` state cannot be updated.
        /// An UpdateOrder request requires the following:
        /// - The `order_id` in the endpoint path, identifying the order to update.
        /// - The latest `version` of the order to update.
        /// - The [sparse order](https://developer.squareup.com/docs/orders-api/manage-orders#sparse-order-objects)
        /// containing only the fields to update and the version the update is
        /// being applied to.
        /// - If deleting fields, the [dot notation paths](https://developer.squareup.com/docs/orders-api/manage-orders#on-dot-notation)
        /// identifying fields to clear.
        /// To pay for an order, please refer to the [Pay for Orders](https://developer.squareup.com/docs/orders-api/pay-for-orders) guide.
        /// To learn more about the Orders API, see the
        /// [Orders API Overview](https://developer.squareup.com/docs/orders-api/what-it-does).
        /// </summary>
        /// <param name="orderId">Required parameter: The ID of the order to update.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.UpdateOrderResponse response from the API call</return>
        Task<Models.UpdateOrderResponse> UpdateOrderAsync(string orderId, Models.UpdateOrderRequest body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Pay for an [order](#type-order) using one or more approved [payments](#type-payment),
        /// or settle an order with a total of `0`.
        /// The total of the `payment_ids` listed in the request must be equal to the order
        /// total. Orders with a total amount of `0` can be marked as paid by specifying an empty
        /// array of `payment_ids` in the request.
        /// To be used with PayOrder, a payment must:
        /// - Reference the order by specifying the `order_id` when [creating the payment](#endpoint-payments-createpayment).
        /// Any approved payments that reference the same `order_id` not specified in the
        /// `payment_ids` will be canceled.
        /// - Be approved with [delayed capture](https://developer.squareup.com/docs/payments-api/take-payments#delayed-capture).
        /// Using a delayed capture payment with PayOrder will complete the approved payment.
        /// Learn how to [pay for orders with a single payment using the Payments API](https://developer.squareup.com/docs/orders-api/pay-for-orders).
        /// </summary>
        /// <param name="orderId">Required parameter: The ID of the order being paid.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.PayOrderResponse response from the API call</return>
        Models.PayOrderResponse PayOrder(string orderId, Models.PayOrderRequest body);

        /// <summary>
        /// Pay for an [order](#type-order) using one or more approved [payments](#type-payment),
        /// or settle an order with a total of `0`.
        /// The total of the `payment_ids` listed in the request must be equal to the order
        /// total. Orders with a total amount of `0` can be marked as paid by specifying an empty
        /// array of `payment_ids` in the request.
        /// To be used with PayOrder, a payment must:
        /// - Reference the order by specifying the `order_id` when [creating the payment](#endpoint-payments-createpayment).
        /// Any approved payments that reference the same `order_id` not specified in the
        /// `payment_ids` will be canceled.
        /// - Be approved with [delayed capture](https://developer.squareup.com/docs/payments-api/take-payments#delayed-capture).
        /// Using a delayed capture payment with PayOrder will complete the approved payment.
        /// Learn how to [pay for orders with a single payment using the Payments API](https://developer.squareup.com/docs/orders-api/pay-for-orders).
        /// </summary>
        /// <param name="orderId">Required parameter: The ID of the order being paid.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.PayOrderResponse response from the API call</return>
        Task<Models.PayOrderResponse> PayOrderAsync(string orderId, Models.PayOrderRequest body, CancellationToken cancellationToken = default);

    }
}