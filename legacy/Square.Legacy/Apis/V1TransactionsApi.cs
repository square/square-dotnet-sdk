using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using APIMatic.Core;
using APIMatic.Core.Types;
using APIMatic.Core.Utilities;
using APIMatic.Core.Utilities.Date.Xml;
using Newtonsoft.Json.Converters;
using Square.Legacy;
using Square.Legacy.Http.Client;
using Square.Legacy.Utilities;

namespace Square.Legacy.Apis
{
    /// <summary>
    /// V1TransactionsApi.
    /// </summary>
    internal class V1TransactionsApi : BaseApi, IV1TransactionsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="V1TransactionsApi"/> class.
        /// </summary>
        internal V1TransactionsApi(GlobalConfiguration globalConfiguration)
            : base(globalConfiguration) { }

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
            string batchToken = null
        ) => CoreHelper.RunTask(V1ListOrdersAsync(locationId, order, limit, batchToken));

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
            CancellationToken cancellationToken = default
        ) =>
            await CreateApiCall<List<Models.V1Order>>()
                .RequestBuilder(_requestBuilder =>
                    _requestBuilder
                        .Setup(HttpMethod.Get, "/v1/{location_id}/orders")
                        .WithAuth("global")
                        .Parameters(_parameters =>
                            _parameters
                                .Template(_template => _template.Setup("location_id", locationId))
                                .Query(_query => _query.Setup("order", order))
                                .Query(_query => _query.Setup("limit", limit))
                                .Query(_query => _query.Setup("batch_token", batchToken))
                        )
                )
                .ResponseHandler(_responseHandler =>
                    _responseHandler.ContextAdder(
                        (_result, _context) =>
                        {
                            _result.ForEach(model => model.ContextSetter(_context));
                            return _result;
                        }
                    )
                )
                .ExecuteAsync(cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Provides comprehensive information for a single online store order, including the order's history.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the order's associated location..</param>
        /// <param name="orderId">Required parameter: The order's Square-issued ID. You obtain this value from Order objects returned by the List Orders endpoint.</param>
        /// <returns>Returns the Models.V1Order response from the API call.</returns>
        [Obsolete]
        public Models.V1Order V1RetrieveOrder(string locationId, string orderId) =>
            CoreHelper.RunTask(V1RetrieveOrderAsync(locationId, orderId));

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
            CancellationToken cancellationToken = default
        ) =>
            await CreateApiCall<Models.V1Order>()
                .RequestBuilder(_requestBuilder =>
                    _requestBuilder
                        .Setup(HttpMethod.Get, "/v1/{location_id}/orders/{order_id}")
                        .WithAuth("global")
                        .Parameters(_parameters =>
                            _parameters
                                .Template(_template => _template.Setup("location_id", locationId))
                                .Template(_template => _template.Setup("order_id", orderId))
                        )
                )
                .ResponseHandler(_responseHandler =>
                    _responseHandler.ContextAdder(
                        (_result, _context) => _result.ContextSetter(_context)
                    )
                )
                .ExecuteAsync(cancellationToken)
                .ConfigureAwait(false);

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
            Models.V1UpdateOrderRequest body
        ) => CoreHelper.RunTask(V1UpdateOrderAsync(locationId, orderId, body));

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
            CancellationToken cancellationToken = default
        ) =>
            await CreateApiCall<Models.V1Order>()
                .RequestBuilder(_requestBuilder =>
                    _requestBuilder
                        .Setup(HttpMethod.Put, "/v1/{location_id}/orders/{order_id}")
                        .WithAuth("global")
                        .Parameters(_parameters =>
                            _parameters
                                .Body(_bodyParameter => _bodyParameter.Setup(body))
                                .Template(_template => _template.Setup("location_id", locationId))
                                .Template(_template => _template.Setup("order_id", orderId))
                                .Header(_header =>
                                    _header.Setup("Content-Type", "application/json")
                                )
                        )
                )
                .ResponseHandler(_responseHandler =>
                    _responseHandler.ContextAdder(
                        (_result, _context) => _result.ContextSetter(_context)
                    )
                )
                .ExecuteAsync(cancellationToken)
                .ConfigureAwait(false);
    }
}
