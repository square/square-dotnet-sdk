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
using Square.Http.Client;
using Square.Utilities;
using System.Net.Http;

namespace Square.Apis
{
    /// <summary>
    /// RefundsApi.
    /// </summary>
    internal class RefundsApi : BaseApi, IRefundsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RefundsApi"/> class.
        /// </summary>
        internal RefundsApi(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// Retrieves a list of refunds for the account making the request.
        /// Results are eventually consistent, and new refunds or changes to refunds might take several.
        /// seconds to appear.
        /// The maximum results per page is 100.
        /// </summary>
        /// <param name="beginTime">Optional parameter: Indicates the start of the time range to retrieve each `PaymentRefund` for, in RFC 3339  format.  The range is determined using the `created_at` field for each `PaymentRefund`.   Default: The current time minus one year..</param>
        /// <param name="endTime">Optional parameter: Indicates the end of the time range to retrieve each `PaymentRefund` for, in RFC 3339  format.  The range is determined using the `created_at` field for each `PaymentRefund`.  Default: The current time..</param>
        /// <param name="sortOrder">Optional parameter: The order in which results are listed by `PaymentRefund.created_at`: - `ASC` - Oldest to newest. - `DESC` - Newest to oldest (default)..</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this cursor to retrieve the next set of results for the original query.  For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="locationId">Optional parameter: Limit results to the location supplied. By default, results are returned for all locations associated with the seller..</param>
        /// <param name="status">Optional parameter: If provided, only refunds with the given status are returned. For a list of refund status values, see [PaymentRefund](entity:PaymentRefund).  Default: If omitted, refunds are returned regardless of their status..</param>
        /// <param name="sourceType">Optional parameter: If provided, only returns refunds whose payments have the indicated source type. Current values include `CARD`, `BANK_ACCOUNT`, `WALLET`, `CASH`, and `EXTERNAL`. For information about these payment source types, see [Take Payments](https://developer.squareup.com/docs/payments-api/take-payments).  Default: If omitted, refunds are returned regardless of the source type..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to be returned in a single page.  It is possible to receive fewer results than the specified limit on a given page.  If the supplied value is greater than 100, no more than 100 results are returned.  Default: 100.</param>
        /// <returns>Returns the Models.ListPaymentRefundsResponse response from the API call.</returns>
        public Models.ListPaymentRefundsResponse ListPaymentRefunds(
                string beginTime = null,
                string endTime = null,
                string sortOrder = null,
                string cursor = null,
                string locationId = null,
                string status = null,
                string sourceType = null,
                int? limit = null)
            => CoreHelper.RunTask(ListPaymentRefundsAsync(beginTime, endTime, sortOrder, cursor, locationId, status, sourceType, limit));

        /// <summary>
        /// Retrieves a list of refunds for the account making the request.
        /// Results are eventually consistent, and new refunds or changes to refunds might take several.
        /// seconds to appear.
        /// The maximum results per page is 100.
        /// </summary>
        /// <param name="beginTime">Optional parameter: Indicates the start of the time range to retrieve each `PaymentRefund` for, in RFC 3339  format.  The range is determined using the `created_at` field for each `PaymentRefund`.   Default: The current time minus one year..</param>
        /// <param name="endTime">Optional parameter: Indicates the end of the time range to retrieve each `PaymentRefund` for, in RFC 3339  format.  The range is determined using the `created_at` field for each `PaymentRefund`.  Default: The current time..</param>
        /// <param name="sortOrder">Optional parameter: The order in which results are listed by `PaymentRefund.created_at`: - `ASC` - Oldest to newest. - `DESC` - Newest to oldest (default)..</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this cursor to retrieve the next set of results for the original query.  For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="locationId">Optional parameter: Limit results to the location supplied. By default, results are returned for all locations associated with the seller..</param>
        /// <param name="status">Optional parameter: If provided, only refunds with the given status are returned. For a list of refund status values, see [PaymentRefund](entity:PaymentRefund).  Default: If omitted, refunds are returned regardless of their status..</param>
        /// <param name="sourceType">Optional parameter: If provided, only returns refunds whose payments have the indicated source type. Current values include `CARD`, `BANK_ACCOUNT`, `WALLET`, `CASH`, and `EXTERNAL`. For information about these payment source types, see [Take Payments](https://developer.squareup.com/docs/payments-api/take-payments).  Default: If omitted, refunds are returned regardless of the source type..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to be returned in a single page.  It is possible to receive fewer results than the specified limit on a given page.  If the supplied value is greater than 100, no more than 100 results are returned.  Default: 100.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListPaymentRefundsResponse response from the API call.</returns>
        public async Task<Models.ListPaymentRefundsResponse> ListPaymentRefundsAsync(
                string beginTime = null,
                string endTime = null,
                string sortOrder = null,
                string cursor = null,
                string locationId = null,
                string status = null,
                string sourceType = null,
                int? limit = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ListPaymentRefundsResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/refunds")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("begin_time", beginTime))
                      .Query(_query => _query.Setup("end_time", endTime))
                      .Query(_query => _query.Setup("sort_order", sortOrder))
                      .Query(_query => _query.Setup("cursor", cursor))
                      .Query(_query => _query.Setup("location_id", locationId))
                      .Query(_query => _query.Setup("status", status))
                      .Query(_query => _query.Setup("source_type", sourceType))
                      .Query(_query => _query.Setup("limit", limit))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Refunds a payment. You can refund the entire payment amount or a.
        /// portion of it. You can use this endpoint to refund a card payment or record a .
        /// refund of a cash or external payment. For more information, see.
        /// [Refund Payment](https://developer.squareup.com/docs/payments-api/refund-payments).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.RefundPaymentResponse response from the API call.</returns>
        public Models.RefundPaymentResponse RefundPayment(
                Models.RefundPaymentRequest body)
            => CoreHelper.RunTask(RefundPaymentAsync(body));

        /// <summary>
        /// Refunds a payment. You can refund the entire payment amount or a.
        /// portion of it. You can use this endpoint to refund a card payment or record a .
        /// refund of a cash or external payment. For more information, see.
        /// [Refund Payment](https://developer.squareup.com/docs/payments-api/refund-payments).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RefundPaymentResponse response from the API call.</returns>
        public async Task<Models.RefundPaymentResponse> RefundPaymentAsync(
                Models.RefundPaymentRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.RefundPaymentResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/refunds")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Retrieves a specific refund using the `refund_id`.
        /// </summary>
        /// <param name="refundId">Required parameter: The unique ID for the desired `PaymentRefund`..</param>
        /// <returns>Returns the Models.GetPaymentRefundResponse response from the API call.</returns>
        public Models.GetPaymentRefundResponse GetPaymentRefund(
                string refundId)
            => CoreHelper.RunTask(GetPaymentRefundAsync(refundId));

        /// <summary>
        /// Retrieves a specific refund using the `refund_id`.
        /// </summary>
        /// <param name="refundId">Required parameter: The unique ID for the desired `PaymentRefund`..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.GetPaymentRefundResponse response from the API call.</returns>
        public async Task<Models.GetPaymentRefundResponse> GetPaymentRefundAsync(
                string refundId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.GetPaymentRefundResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/refunds/{refund_id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("refund_id", refundId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);
    }
}