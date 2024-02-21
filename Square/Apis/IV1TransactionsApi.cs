namespace Square.Apis
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Square;
    using Square.Http.Client;
    using Square.Http.Request;
    using Square.Http.Response;
    using Square.Utilities;

    /// <summary>
    /// IV1TransactionsApi.
    /// </summary>
    public interface IV1TransactionsApi
    {
        /// <summary>
        /// Provides summary information for a merchant's online store orders.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to list online store orders for..</param>
        /// <param name="order">Optional parameter: The order in which payments are listed in the response..</param>
        /// <param name="limit">Optional parameter: The maximum number of payments to return in a single response. This value cannot exceed 200..</param>
        /// <param name="batchToken">Optional parameter: A pagination cursor to retrieve the next set of results for your original query to the endpoint..</param>
        /// <returns><![CDATA[Returns the List<Models.V1Order> response from the API call.]]></returns>
        [Obsolete]
        List<Models.V1Order> V1ListOrders(
                string locationId,
                string order = null,
                int? limit = null,
                string batchToken = null);

        /// <summary>
        /// Provides summary information for a merchant's online store orders.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to list online store orders for..</param>
        /// <param name="order">Optional parameter: The order in which payments are listed in the response..</param>
        /// <param name="limit">Optional parameter: The maximum number of payments to return in a single response. This value cannot exceed 200..</param>
        /// <param name="batchToken">Optional parameter: A pagination cursor to retrieve the next set of results for your original query to the endpoint..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns><![CDATA[Returns the List<Models.V1Order> response from the API call.]]></returns>
        [Obsolete]
        Task<List<Models.V1Order>> V1ListOrdersAsync(
                string locationId,
                string order = null,
                int? limit = null,
                string batchToken = null,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Provides comprehensive information for a single online store order, including the order's history.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the order's associated location..</param>
        /// <param name="orderId">Required parameter: The order's Square-issued ID. You obtain this value from Order objects returned by the List Orders endpoint.</param>
        /// <returns>Returns the Models.V1Order response from the API call.</returns>
        [Obsolete]
        Models.V1Order V1RetrieveOrder(
                string locationId,
                string orderId);

        /// <summary>
        /// Provides comprehensive information for a single online store order, including the order's history.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the order's associated location..</param>
        /// <param name="orderId">Required parameter: The order's Square-issued ID. You obtain this value from Order objects returned by the List Orders endpoint.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.V1Order response from the API call.</returns>
        [Obsolete]
        Task<Models.V1Order> V1RetrieveOrderAsync(
                string locationId,
                string orderId,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates the details of an online store order. Every update you perform on an order corresponds to one of three actions:.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the order's associated location..</param>
        /// <param name="orderId">Required parameter: The order's Square-issued ID. You obtain this value from Order objects returned by the List Orders endpoint.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.V1Order response from the API call.</returns>
        [Obsolete]
        Models.V1Order V1UpdateOrder(
                string locationId,
                string orderId,
                Models.V1UpdateOrderRequest body);

        /// <summary>
        /// Updates the details of an online store order. Every update you perform on an order corresponds to one of three actions:.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the order's associated location..</param>
        /// <param name="orderId">Required parameter: The order's Square-issued ID. You obtain this value from Order objects returned by the List Orders endpoint.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.V1Order response from the API call.</returns>
        [Obsolete]
        Task<Models.V1Order> V1UpdateOrderAsync(
                string locationId,
                string orderId,
                Models.V1UpdateOrderRequest body,
                CancellationToken cancellationToken = default);
    }
}