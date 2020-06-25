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
    public interface IRefundsApi
    {
        /// <summary>
        /// Retrieves a list of refunds for the account making the request.
        /// Max results per page: 100
        /// </summary>
        /// <param name="beginTime">Optional parameter: Timestamp for the beginning of the requested reporting period, in RFC 3339 format.  Default: The current time minus one year.</param>
        /// <param name="endTime">Optional parameter: Timestamp for the end of the requested reporting period, in RFC 3339 format.  Default: The current time.</param>
        /// <param name="sortOrder">Optional parameter: The order in which results are listed. - `ASC` - oldest to newest - `DESC` - newest to oldest (default).</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for the original query.  See [Pagination](https://developer.squareup.com/docs/basics/api101/pagination) for more information.</param>
        /// <param name="locationId">Optional parameter: Limit results to the location supplied. By default, results are returned for all locations associated with the merchant.</param>
        /// <param name="status">Optional parameter: If provided, only refunds with the given status are returned. For a list of refund status values, see [PaymentRefund](#type-paymentrefund).  Default: If omitted refunds are returned regardless of status.</param>
        /// <param name="sourceType">Optional parameter: If provided, only refunds with the given source type are returned. - `CARD` - List refunds only for payments where card was specified as payment source.  Default: If omitted refunds are returned regardless of source type.</param>
        /// <return>Returns the Models.ListPaymentRefundsResponse response from the API call</return>
        Models.ListPaymentRefundsResponse ListPaymentRefunds(
                string beginTime = null,
                string endTime = null,
                string sortOrder = null,
                string cursor = null,
                string locationId = null,
                string status = null,
                string sourceType = null);

        /// <summary>
        /// Retrieves a list of refunds for the account making the request.
        /// Max results per page: 100
        /// </summary>
        /// <param name="beginTime">Optional parameter: Timestamp for the beginning of the requested reporting period, in RFC 3339 format.  Default: The current time minus one year.</param>
        /// <param name="endTime">Optional parameter: Timestamp for the end of the requested reporting period, in RFC 3339 format.  Default: The current time.</param>
        /// <param name="sortOrder">Optional parameter: The order in which results are listed. - `ASC` - oldest to newest - `DESC` - newest to oldest (default).</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for the original query.  See [Pagination](https://developer.squareup.com/docs/basics/api101/pagination) for more information.</param>
        /// <param name="locationId">Optional parameter: Limit results to the location supplied. By default, results are returned for all locations associated with the merchant.</param>
        /// <param name="status">Optional parameter: If provided, only refunds with the given status are returned. For a list of refund status values, see [PaymentRefund](#type-paymentrefund).  Default: If omitted refunds are returned regardless of status.</param>
        /// <param name="sourceType">Optional parameter: If provided, only refunds with the given source type are returned. - `CARD` - List refunds only for payments where card was specified as payment source.  Default: If omitted refunds are returned regardless of source type.</param>
        /// <return>Returns the Models.ListPaymentRefundsResponse response from the API call</return>
        Task<Models.ListPaymentRefundsResponse> ListPaymentRefundsAsync(
                string beginTime = null,
                string endTime = null,
                string sortOrder = null,
                string cursor = null,
                string locationId = null,
                string status = null,
                string sourceType = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Refunds a payment. You can refund the entire payment amount or a 
        /// portion of it. For more information, see 
        /// [Payments and Refunds Overview](https://developer.squareup.com/docs/payments-api/overview).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.RefundPaymentResponse response from the API call</return>
        Models.RefundPaymentResponse RefundPayment(Models.RefundPaymentRequest body);

        /// <summary>
        /// Refunds a payment. You can refund the entire payment amount or a 
        /// portion of it. For more information, see 
        /// [Payments and Refunds Overview](https://developer.squareup.com/docs/payments-api/overview).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.RefundPaymentResponse response from the API call</return>
        Task<Models.RefundPaymentResponse> RefundPaymentAsync(Models.RefundPaymentRequest body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a specific `Refund` using the `refund_id`.
        /// </summary>
        /// <param name="refundId">Required parameter: Unique ID for the desired `PaymentRefund`.</param>
        /// <return>Returns the Models.GetPaymentRefundResponse response from the API call</return>
        Models.GetPaymentRefundResponse GetPaymentRefund(string refundId);

        /// <summary>
        /// Retrieves a specific `Refund` using the `refund_id`.
        /// </summary>
        /// <param name="refundId">Required parameter: Unique ID for the desired `PaymentRefund`.</param>
        /// <return>Returns the Models.GetPaymentRefundResponse response from the API call</return>
        Task<Models.GetPaymentRefundResponse> GetPaymentRefundAsync(string refundId, CancellationToken cancellationToken = default);

    }
}