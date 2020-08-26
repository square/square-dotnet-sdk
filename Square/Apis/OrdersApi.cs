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
using Square.Utilities;
using Square.Http.Request;
using Square.Http.Response;
using Square.Http.Client;
using Square.Authentication;
using Square.Exceptions;

namespace Square.Apis
{
    internal class OrdersApi: BaseApi, IOrdersApi
    {
        internal OrdersApi(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null) :
            base(config, httpClient, authManagers, httpCallBack)
        { }

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
        public Models.CreateOrderResponse CreateOrder(Models.CreateOrderRequest body)
        {
            Task<Models.CreateOrderResponse> t = CreateOrderAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

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
        public async Task<Models.CreateOrderResponse> CreateOrderAsync(Models.CreateOrderRequest body, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/orders");

            //validate and preprocess url
            string _queryUrl = ApiHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string, string>()
            { 
                { "user-agent", userAgent },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" },
                { "Square-Version", config.SquareVersion }
            };

            //append body params
            var _body = ApiHelper.JsonSerialize(body);

            //prepare the API call request to fetch the response
            HttpRequest _request = GetClientInstance().PostBody(_queryUrl, _headers, _body);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnBeforeHttpRequestEventHandler(GetClientInstance(), _request);
            }

            _request = await authManagers["default"].ApplyAsync(_request).ConfigureAwait(false);

            //invoke request and get response
            HttpStringResponse _response = await GetClientInstance().ExecuteAsStringAsync(_request, cancellationToken).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnAfterHttpResponseEventHandler(GetClientInstance(), _response);
            }

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            var _responseModel = ApiHelper.JsonDeserialize<Models.CreateOrderResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Retrieves a set of [Order](#type-order)s by their IDs.
        /// If a given Order ID does not exist, the ID is ignored instead of generating an error.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.BatchRetrieveOrdersResponse response from the API call</return>
        public Models.BatchRetrieveOrdersResponse BatchRetrieveOrders(Models.BatchRetrieveOrdersRequest body)
        {
            Task<Models.BatchRetrieveOrdersResponse> t = BatchRetrieveOrdersAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Retrieves a set of [Order](#type-order)s by their IDs.
        /// If a given Order ID does not exist, the ID is ignored instead of generating an error.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.BatchRetrieveOrdersResponse response from the API call</return>
        public async Task<Models.BatchRetrieveOrdersResponse> BatchRetrieveOrdersAsync(Models.BatchRetrieveOrdersRequest body, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/orders/batch-retrieve");

            //validate and preprocess url
            string _queryUrl = ApiHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string, string>()
            { 
                { "user-agent", userAgent },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" },
                { "Square-Version", config.SquareVersion }
            };

            //append body params
            var _body = ApiHelper.JsonSerialize(body);

            //prepare the API call request to fetch the response
            HttpRequest _request = GetClientInstance().PostBody(_queryUrl, _headers, _body);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnBeforeHttpRequestEventHandler(GetClientInstance(), _request);
            }

            _request = await authManagers["default"].ApplyAsync(_request).ConfigureAwait(false);

            //invoke request and get response
            HttpStringResponse _response = await GetClientInstance().ExecuteAsStringAsync(_request, cancellationToken).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnAfterHttpResponseEventHandler(GetClientInstance(), _response);
            }

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            var _responseModel = ApiHelper.JsonDeserialize<Models.BatchRetrieveOrdersResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Calculates an [Order](#type-order).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CalculateOrderResponse response from the API call</return>
        public Models.CalculateOrderResponse CalculateOrder(Models.CalculateOrderRequest body)
        {
            Task<Models.CalculateOrderResponse> t = CalculateOrderAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Calculates an [Order](#type-order).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CalculateOrderResponse response from the API call</return>
        public async Task<Models.CalculateOrderResponse> CalculateOrderAsync(Models.CalculateOrderRequest body, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/orders/calculate");

            //validate and preprocess url
            string _queryUrl = ApiHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string, string>()
            { 
                { "user-agent", userAgent },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" },
                { "Square-Version", config.SquareVersion }
            };

            //append body params
            var _body = ApiHelper.JsonSerialize(body);

            //prepare the API call request to fetch the response
            HttpRequest _request = GetClientInstance().PostBody(_queryUrl, _headers, _body);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnBeforeHttpRequestEventHandler(GetClientInstance(), _request);
            }

            _request = await authManagers["default"].ApplyAsync(_request).ConfigureAwait(false);

            //invoke request and get response
            HttpStringResponse _response = await GetClientInstance().ExecuteAsStringAsync(_request, cancellationToken).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnAfterHttpResponseEventHandler(GetClientInstance(), _response);
            }

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            var _responseModel = ApiHelper.JsonDeserialize<Models.CalculateOrderResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

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
        public Models.SearchOrdersResponse SearchOrders(Models.SearchOrdersRequest body)
        {
            Task<Models.SearchOrdersResponse> t = SearchOrdersAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

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
        public async Task<Models.SearchOrdersResponse> SearchOrdersAsync(Models.SearchOrdersRequest body, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/orders/search");

            //validate and preprocess url
            string _queryUrl = ApiHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string, string>()
            { 
                { "user-agent", userAgent },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" },
                { "Square-Version", config.SquareVersion }
            };

            //append body params
            var _body = ApiHelper.JsonSerialize(body);

            //prepare the API call request to fetch the response
            HttpRequest _request = GetClientInstance().PostBody(_queryUrl, _headers, _body);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnBeforeHttpRequestEventHandler(GetClientInstance(), _request);
            }

            _request = await authManagers["default"].ApplyAsync(_request).ConfigureAwait(false);

            //invoke request and get response
            HttpStringResponse _response = await GetClientInstance().ExecuteAsStringAsync(_request, cancellationToken).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnAfterHttpResponseEventHandler(GetClientInstance(), _response);
            }

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            var _responseModel = ApiHelper.JsonDeserialize<Models.SearchOrdersResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

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
        public Models.UpdateOrderResponse UpdateOrder(string orderId, Models.UpdateOrderRequest body)
        {
            Task<Models.UpdateOrderResponse> t = UpdateOrderAsync(orderId, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

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
        public async Task<Models.UpdateOrderResponse> UpdateOrderAsync(string orderId, Models.UpdateOrderRequest body, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/orders/{order_id}");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "order_id", orderId }
            });

            //validate and preprocess url
            string _queryUrl = ApiHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string, string>()
            { 
                { "user-agent", userAgent },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" },
                { "Square-Version", config.SquareVersion }
            };

            //append body params
            var _body = ApiHelper.JsonSerialize(body);

            //prepare the API call request to fetch the response
            HttpRequest _request = GetClientInstance().PutBody(_queryUrl, _headers, _body);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnBeforeHttpRequestEventHandler(GetClientInstance(), _request);
            }

            _request = await authManagers["default"].ApplyAsync(_request).ConfigureAwait(false);

            //invoke request and get response
            HttpStringResponse _response = await GetClientInstance().ExecuteAsStringAsync(_request, cancellationToken).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnAfterHttpResponseEventHandler(GetClientInstance(), _response);
            }

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            var _responseModel = ApiHelper.JsonDeserialize<Models.UpdateOrderResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

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
        public Models.PayOrderResponse PayOrder(string orderId, Models.PayOrderRequest body)
        {
            Task<Models.PayOrderResponse> t = PayOrderAsync(orderId, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

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
        public async Task<Models.PayOrderResponse> PayOrderAsync(string orderId, Models.PayOrderRequest body, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/orders/{order_id}/pay");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "order_id", orderId }
            });

            //validate and preprocess url
            string _queryUrl = ApiHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string, string>()
            { 
                { "user-agent", userAgent },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" },
                { "Square-Version", config.SquareVersion }
            };

            //append body params
            var _body = ApiHelper.JsonSerialize(body);

            //prepare the API call request to fetch the response
            HttpRequest _request = GetClientInstance().PostBody(_queryUrl, _headers, _body);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnBeforeHttpRequestEventHandler(GetClientInstance(), _request);
            }

            _request = await authManagers["default"].ApplyAsync(_request).ConfigureAwait(false);

            //invoke request and get response
            HttpStringResponse _response = await GetClientInstance().ExecuteAsStringAsync(_request, cancellationToken).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnAfterHttpResponseEventHandler(GetClientInstance(), _response);
            }

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            var _responseModel = ApiHelper.JsonDeserialize<Models.PayOrderResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

    }
}