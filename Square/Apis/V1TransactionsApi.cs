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
    /// V1TransactionsApi.
    /// </summary>
    internal class V1TransactionsApi : BaseApi, IV1TransactionsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="V1TransactionsApi"/> class.
        /// </summary>
        internal V1TransactionsApi(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

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
            => CoreHelper.RunTask(V1ListOrdersAsync(locationId, order, limit, batchToken));

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
            => await CreateApiCall<List<Models.V1Order>>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v1/{location_id}/orders")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("location_id", locationId))
                      .Query(_query => _query.Setup("order", order))
                      .Query(_query => _query.Setup("limit", limit))
                      .Query(_query => _query.Setup("batch_token", batchToken))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => 
                  {
                      _result.ForEach(model => model.ContextSetter(_context));
                      return _result;
                  }))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

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
            => CoreHelper.RunTask(V1RetrieveOrderAsync(locationId, orderId));

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
            => await CreateApiCall<Models.V1Order>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v1/{location_id}/orders/{order_id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("location_id", locationId))
                      .Template(_template => _template.Setup("order_id", orderId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

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
            => CoreHelper.RunTask(V1UpdateOrderAsync(locationId, orderId, body));

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
            => await CreateApiCall<Models.V1Order>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Put, "/v1/{location_id}/orders/{order_id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Template(_template => _template.Setup("location_id", locationId))
                      .Template(_template => _template.Setup("order_id", orderId))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

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
            => CoreHelper.RunTask(V1ListPaymentsAsync(locationId, order, beginTime, endTime, limit, batchToken, includePartial));

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
            => await CreateApiCall<List<Models.V1Payment>>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v1/{location_id}/payments")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("location_id", locationId))
                      .Query(_query => _query.Setup("order", order))
                      .Query(_query => _query.Setup("begin_time", beginTime))
                      .Query(_query => _query.Setup("end_time", endTime))
                      .Query(_query => _query.Setup("limit", limit))
                      .Query(_query => _query.Setup("batch_token", batchToken))
                      .Query(_query => _query.Setup("include_partial", (includePartial != null) ? includePartial : false))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => 
                  {
                      _result.ForEach(model => model.ContextSetter(_context));
                      return _result;
                  }))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

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
            => CoreHelper.RunTask(V1RetrievePaymentAsync(locationId, paymentId));

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
            => await CreateApiCall<Models.V1Payment>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v1/{location_id}/payments/{payment_id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("location_id", locationId))
                      .Template(_template => _template.Setup("payment_id", paymentId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

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
            => CoreHelper.RunTask(V1ListRefundsAsync(locationId, order, beginTime, endTime, limit, batchToken));

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
            => await CreateApiCall<List<Models.V1Refund>>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v1/{location_id}/refunds")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("location_id", locationId))
                      .Query(_query => _query.Setup("order", order))
                      .Query(_query => _query.Setup("begin_time", beginTime))
                      .Query(_query => _query.Setup("end_time", endTime))
                      .Query(_query => _query.Setup("limit", limit))
                      .Query(_query => _query.Setup("batch_token", batchToken))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => 
                  {
                      _result.ForEach(model => model.ContextSetter(_context));
                      return _result;
                  }))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

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
            => CoreHelper.RunTask(V1CreateRefundAsync(locationId, body));

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
            => await CreateApiCall<Models.V1Refund>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v1/{location_id}/refunds")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Template(_template => _template.Setup("location_id", locationId))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

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
            => CoreHelper.RunTask(V1ListSettlementsAsync(locationId, order, beginTime, endTime, limit, status, batchToken));

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
            => await CreateApiCall<List<Models.V1Settlement>>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v1/{location_id}/settlements")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("location_id", locationId))
                      .Query(_query => _query.Setup("order", order))
                      .Query(_query => _query.Setup("begin_time", beginTime))
                      .Query(_query => _query.Setup("end_time", endTime))
                      .Query(_query => _query.Setup("limit", limit))
                      .Query(_query => _query.Setup("status", status))
                      .Query(_query => _query.Setup("batch_token", batchToken))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => 
                  {
                      _result.ForEach(model => model.ContextSetter(_context));
                      return _result;
                  }))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

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
            => CoreHelper.RunTask(V1RetrieveSettlementAsync(locationId, settlementId));

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
            => await CreateApiCall<Models.V1Settlement>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v1/{location_id}/settlements/{settlement_id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("location_id", locationId))
                      .Template(_template => _template.Setup("settlement_id", settlementId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);
    }
}