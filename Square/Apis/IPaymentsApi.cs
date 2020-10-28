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
    public interface IPaymentsApi
    {
        /// <summary>
        /// Retrieves a list of payments taken by the account making the request.
        /// The maximum results per page is 100.
        /// </summary>
        /// <param name="beginTime">Optional parameter: The timestamp for the beginning of the reporting period, in RFC 3339 format. Inclusive. Default: The current time minus one year.</param>
        /// <param name="endTime">Optional parameter: The timestamp for the end of the reporting period, in RFC 3339 format.  Default: The current time.</param>
        /// <param name="sortOrder">Optional parameter: The order in which results are listed: - `ASC` - Oldest to newest. - `DESC` - Newest to oldest (default).</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this cursor to retrieve the next set of results for the original query.  For more information, see [Pagination](https://developer.squareup.com/docs/basics/api101/pagination).</param>
        /// <param name="locationId">Optional parameter: Limit results to the location supplied. By default, results are returned for the default (main) location associated with the seller.</param>
        /// <param name="total">Optional parameter: The exact amount in the `total_money` for a payment.</param>
        /// <param name="last4">Optional parameter: The last four digits of a payment card.</param>
        /// <param name="cardBrand">Optional parameter: The brand of the payment card (for example, VISA).</param>
        /// <param name="limit">Optional parameter: The maximum number of results to be returned in a single page. It is possible to receive fewer results than the specified limit on a given page.  The default value of 100 is also the maximum allowed value. If the provided value is  greater than 100, it is ignored and the default value is used instead.  Default: `100`</param>
        /// <return>Returns the Models.ListPaymentsResponse response from the API call</return>
        Models.ListPaymentsResponse ListPayments(
                string beginTime = null,
                string endTime = null,
                string sortOrder = null,
                string cursor = null,
                string locationId = null,
                long? total = null,
                string last4 = null,
                string cardBrand = null,
                int? limit = null);

        /// <summary>
        /// Retrieves a list of payments taken by the account making the request.
        /// The maximum results per page is 100.
        /// </summary>
        /// <param name="beginTime">Optional parameter: The timestamp for the beginning of the reporting period, in RFC 3339 format. Inclusive. Default: The current time minus one year.</param>
        /// <param name="endTime">Optional parameter: The timestamp for the end of the reporting period, in RFC 3339 format.  Default: The current time.</param>
        /// <param name="sortOrder">Optional parameter: The order in which results are listed: - `ASC` - Oldest to newest. - `DESC` - Newest to oldest (default).</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this cursor to retrieve the next set of results for the original query.  For more information, see [Pagination](https://developer.squareup.com/docs/basics/api101/pagination).</param>
        /// <param name="locationId">Optional parameter: Limit results to the location supplied. By default, results are returned for the default (main) location associated with the seller.</param>
        /// <param name="total">Optional parameter: The exact amount in the `total_money` for a payment.</param>
        /// <param name="last4">Optional parameter: The last four digits of a payment card.</param>
        /// <param name="cardBrand">Optional parameter: The brand of the payment card (for example, VISA).</param>
        /// <param name="limit">Optional parameter: The maximum number of results to be returned in a single page. It is possible to receive fewer results than the specified limit on a given page.  The default value of 100 is also the maximum allowed value. If the provided value is  greater than 100, it is ignored and the default value is used instead.  Default: `100`</param>
        /// <return>Returns the Models.ListPaymentsResponse response from the API call</return>
        Task<Models.ListPaymentsResponse> ListPaymentsAsync(
                string beginTime = null,
                string endTime = null,
                string sortOrder = null,
                string cursor = null,
                string locationId = null,
                long? total = null,
                string last4 = null,
                string cardBrand = null,
                int? limit = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Charges a payment source (for example, a card 
        /// represented by customer's card on file or a card nonce). In addition 
        /// to the payment source, the request must include the 
        /// amount to accept for the payment.
        /// There are several optional parameters that you can include in the request 
        /// (for example, tip money, whether to autocomplete the payment, or a reference ID 
        /// to correlate this payment with another system). 
        /// The `PAYMENTS_WRITE_ADDITIONAL_RECIPIENTS` OAuth permission is required
        /// to enable application fees.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreatePaymentResponse response from the API call</return>
        Models.CreatePaymentResponse CreatePayment(Models.CreatePaymentRequest body);

        /// <summary>
        /// Charges a payment source (for example, a card 
        /// represented by customer's card on file or a card nonce). In addition 
        /// to the payment source, the request must include the 
        /// amount to accept for the payment.
        /// There are several optional parameters that you can include in the request 
        /// (for example, tip money, whether to autocomplete the payment, or a reference ID 
        /// to correlate this payment with another system). 
        /// The `PAYMENTS_WRITE_ADDITIONAL_RECIPIENTS` OAuth permission is required
        /// to enable application fees.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreatePaymentResponse response from the API call</return>
        Task<Models.CreatePaymentResponse> CreatePaymentAsync(Models.CreatePaymentRequest body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Cancels (voids) a payment identified by the idempotency key that is specified in the
        /// request.
        /// Use this method when the status of a `CreatePayment` request is unknown (for example, after you send a
        /// `CreatePayment` request, a network error occurs and you do not get a response). In this case, you can
        /// direct Square to cancel the payment using this endpoint. In the request, you provide the same
        /// idempotency key that you provided in your `CreatePayment` request that you want to cancel. After
        /// canceling the payment, you can submit your `CreatePayment` request again.
        /// Note that if no payment with the specified idempotency key is found, no action is taken and the endpoint 
        /// returns successfully.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CancelPaymentByIdempotencyKeyResponse response from the API call</return>
        Models.CancelPaymentByIdempotencyKeyResponse CancelPaymentByIdempotencyKey(Models.CancelPaymentByIdempotencyKeyRequest body);

        /// <summary>
        /// Cancels (voids) a payment identified by the idempotency key that is specified in the
        /// request.
        /// Use this method when the status of a `CreatePayment` request is unknown (for example, after you send a
        /// `CreatePayment` request, a network error occurs and you do not get a response). In this case, you can
        /// direct Square to cancel the payment using this endpoint. In the request, you provide the same
        /// idempotency key that you provided in your `CreatePayment` request that you want to cancel. After
        /// canceling the payment, you can submit your `CreatePayment` request again.
        /// Note that if no payment with the specified idempotency key is found, no action is taken and the endpoint 
        /// returns successfully.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CancelPaymentByIdempotencyKeyResponse response from the API call</return>
        Task<Models.CancelPaymentByIdempotencyKeyResponse> CancelPaymentByIdempotencyKeyAsync(Models.CancelPaymentByIdempotencyKeyRequest body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves details for a specific payment.
        /// </summary>
        /// <param name="paymentId">Required parameter: A unique ID for the desired payment.</param>
        /// <return>Returns the Models.GetPaymentResponse response from the API call</return>
        Models.GetPaymentResponse GetPayment(string paymentId);

        /// <summary>
        /// Retrieves details for a specific payment.
        /// </summary>
        /// <param name="paymentId">Required parameter: A unique ID for the desired payment.</param>
        /// <return>Returns the Models.GetPaymentResponse response from the API call</return>
        Task<Models.GetPaymentResponse> GetPaymentAsync(string paymentId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Cancels (voids) a payment. If you set `autocomplete` to `false` when creating a payment, 
        /// you can cancel the payment using this endpoint.
        /// </summary>
        /// <param name="paymentId">Required parameter: The `payment_id` identifying the payment to be canceled.</param>
        /// <return>Returns the Models.CancelPaymentResponse response from the API call</return>
        Models.CancelPaymentResponse CancelPayment(string paymentId);

        /// <summary>
        /// Cancels (voids) a payment. If you set `autocomplete` to `false` when creating a payment, 
        /// you can cancel the payment using this endpoint.
        /// </summary>
        /// <param name="paymentId">Required parameter: The `payment_id` identifying the payment to be canceled.</param>
        /// <return>Returns the Models.CancelPaymentResponse response from the API call</return>
        Task<Models.CancelPaymentResponse> CancelPaymentAsync(string paymentId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Completes (captures) a payment.
        /// By default, payments are set to complete immediately after they are created. 
        /// If you set `autocomplete` to `false` when creating a payment, you can complete (capture) 
        /// the payment using this endpoint.
        /// </summary>
        /// <param name="paymentId">Required parameter: The unique ID identifying the payment to be completed.</param>
        /// <return>Returns the Models.CompletePaymentResponse response from the API call</return>
        Models.CompletePaymentResponse CompletePayment(string paymentId);

        /// <summary>
        /// Completes (captures) a payment.
        /// By default, payments are set to complete immediately after they are created. 
        /// If you set `autocomplete` to `false` when creating a payment, you can complete (capture) 
        /// the payment using this endpoint.
        /// </summary>
        /// <param name="paymentId">Required parameter: The unique ID identifying the payment to be completed.</param>
        /// <return>Returns the Models.CompletePaymentResponse response from the API call</return>
        Task<Models.CompletePaymentResponse> CompletePaymentAsync(string paymentId, CancellationToken cancellationToken = default);

    }
}