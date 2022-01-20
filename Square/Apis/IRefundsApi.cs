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
    /// IRefundsApi.
    /// </summary>
    public interface IRefundsApi
    {
        /// <summary>
        /// Retrieves a list of refunds for the account making the request.
        /// Results are eventually consistent, and new refunds or changes to refunds might take several.
        /// seconds to appear.
        /// The maximum results per page is 100.
        /// </summary>
        /// <param name="beginTime">Optional parameter: The timestamp for the beginning of the requested reporting period, in RFC 3339 format.  Default: The current time minus one year..</param>
        /// <param name="endTime">Optional parameter: The timestamp for the end of the requested reporting period, in RFC 3339 format.  Default: The current time..</param>
        /// <param name="sortOrder">Optional parameter: The order in which results are listed: - `ASC` - Oldest to newest. - `DESC` - Newest to oldest (default)..</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this cursor to retrieve the next set of results for the original query.  For more information, see [Pagination](https://developer.squareup.com/docs/basics/api101/pagination)..</param>
        /// <param name="locationId">Optional parameter: Limit results to the location supplied. By default, results are returned for all locations associated with the seller..</param>
        /// <param name="status">Optional parameter: If provided, only refunds with the given status are returned. For a list of refund status values, see [PaymentRefund]($m/PaymentRefund).  Default: If omitted, refunds are returned regardless of their status..</param>
        /// <param name="sourceType">Optional parameter: If provided, only returns refunds whose payments have the indicated source type. Current values include `CARD`, `BANK_ACCOUNT`, `WALLET`, `CASH`, and `EXTERNAL`. For information about these payment source types, see [Take Payments](https://developer.squareup.com/docs/payments-api/take-payments).  Default: If omitted, refunds are returned regardless of the source type..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to be returned in a single page.  It is possible to receive fewer results than the specified limit on a given page.  If the supplied value is greater than 100, no more than 100 results are returned.  Default: 100.</param>
        /// <returns>Returns the Models.ListPaymentRefundsResponse response from the API call.</returns>
        Models.ListPaymentRefundsResponse ListPaymentRefunds(
                string beginTime = null,
                string endTime = null,
                string sortOrder = null,
                string cursor = null,
                string locationId = null,
                string status = null,
                string sourceType = null,
                int? limit = null);

        /// <summary>
        /// Retrieves a list of refunds for the account making the request.
        /// Results are eventually consistent, and new refunds or changes to refunds might take several.
        /// seconds to appear.
        /// The maximum results per page is 100.
        /// </summary>
        /// <param name="beginTime">Optional parameter: The timestamp for the beginning of the requested reporting period, in RFC 3339 format.  Default: The current time minus one year..</param>
        /// <param name="endTime">Optional parameter: The timestamp for the end of the requested reporting period, in RFC 3339 format.  Default: The current time..</param>
        /// <param name="sortOrder">Optional parameter: The order in which results are listed: - `ASC` - Oldest to newest. - `DESC` - Newest to oldest (default)..</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this cursor to retrieve the next set of results for the original query.  For more information, see [Pagination](https://developer.squareup.com/docs/basics/api101/pagination)..</param>
        /// <param name="locationId">Optional parameter: Limit results to the location supplied. By default, results are returned for all locations associated with the seller..</param>
        /// <param name="status">Optional parameter: If provided, only refunds with the given status are returned. For a list of refund status values, see [PaymentRefund]($m/PaymentRefund).  Default: If omitted, refunds are returned regardless of their status..</param>
        /// <param name="sourceType">Optional parameter: If provided, only returns refunds whose payments have the indicated source type. Current values include `CARD`, `BANK_ACCOUNT`, `WALLET`, `CASH`, and `EXTERNAL`. For information about these payment source types, see [Take Payments](https://developer.squareup.com/docs/payments-api/take-payments).  Default: If omitted, refunds are returned regardless of the source type..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to be returned in a single page.  It is possible to receive fewer results than the specified limit on a given page.  If the supplied value is greater than 100, no more than 100 results are returned.  Default: 100.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListPaymentRefundsResponse response from the API call.</returns>
        Task<Models.ListPaymentRefundsResponse> ListPaymentRefundsAsync(
                string beginTime = null,
                string endTime = null,
                string sortOrder = null,
                string cursor = null,
                string locationId = null,
                string status = null,
                string sourceType = null,
                int? limit = null,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Refunds a payment. You can refund the entire payment amount or a.
        /// portion of it. You can use this endpoint to refund a card payment or record a .
        /// refund of a cash or external payment. For more information, see.
        /// [Refund Payment](https://developer.squareup.com/docs/payments-api/refund-payments).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.RefundPaymentResponse response from the API call.</returns>
        Models.RefundPaymentResponse RefundPayment(
                Models.RefundPaymentRequest body);

        /// <summary>
        /// Refunds a payment. You can refund the entire payment amount or a.
        /// portion of it. You can use this endpoint to refund a card payment or record a .
        /// refund of a cash or external payment. For more information, see.
        /// [Refund Payment](https://developer.squareup.com/docs/payments-api/refund-payments).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RefundPaymentResponse response from the API call.</returns>
        Task<Models.RefundPaymentResponse> RefundPaymentAsync(
                Models.RefundPaymentRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a specific refund using the `refund_id`.
        /// </summary>
        /// <param name="refundId">Required parameter: The unique ID for the desired `PaymentRefund`..</param>
        /// <returns>Returns the Models.GetPaymentRefundResponse response from the API call.</returns>
        Models.GetPaymentRefundResponse GetPaymentRefund(
                string refundId);

        /// <summary>
        /// Retrieves a specific refund using the `refund_id`.
        /// </summary>
        /// <param name="refundId">Required parameter: The unique ID for the desired `PaymentRefund`..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.GetPaymentRefundResponse response from the API call.</returns>
        Task<Models.GetPaymentRefundResponse> GetPaymentRefundAsync(
                string refundId,
                CancellationToken cancellationToken = default);
    }
}