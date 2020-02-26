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
        /// Max results per page: 100
        /// </summary>
        /// <param name="beginTime">Optional parameter: Timestamp for the beginning of the reporting period, in RFC 3339 format. Inclusive. Default: The current time minus one year.</param>
        /// <param name="endTime">Optional parameter: Timestamp for the end of the requested reporting period, in RFC 3339 format.  Default: The current time.</param>
        /// <param name="sortOrder">Optional parameter: The order in which results are listed. - `ASC` - oldest to newest - `DESC` - newest to oldest (default).</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for the original query.  See [Pagination](https://developer.squareup.com/docs/basics/api101/pagination) for more information.</param>
        /// <param name="locationId">Optional parameter: Limit results to the location supplied. By default, results are returned for all locations associated with the merchant.</param>
        /// <param name="total">Optional parameter: The exact amount in the total_money for a `Payment`.</param>
        /// <param name="last4">Optional parameter: The last 4 digits of `Payment` card.</param>
        /// <param name="cardBrand">Optional parameter: The brand of `Payment` card. For example, `VISA`</param>
        /// <return>Returns the Models.ListPaymentsResponse response from the API call</return>
        Models.ListPaymentsResponse ListPayments(
                string beginTime = null,
                string endTime = null,
                string sortOrder = null,
                string cursor = null,
                string locationId = null,
                long? total = null,
                string last4 = null,
                string cardBrand = null);

        /// <summary>
        /// Retrieves a list of payments taken by the account making the request.
        /// Max results per page: 100
        /// </summary>
        /// <param name="beginTime">Optional parameter: Timestamp for the beginning of the reporting period, in RFC 3339 format. Inclusive. Default: The current time minus one year.</param>
        /// <param name="endTime">Optional parameter: Timestamp for the end of the requested reporting period, in RFC 3339 format.  Default: The current time.</param>
        /// <param name="sortOrder">Optional parameter: The order in which results are listed. - `ASC` - oldest to newest - `DESC` - newest to oldest (default).</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for the original query.  See [Pagination](https://developer.squareup.com/docs/basics/api101/pagination) for more information.</param>
        /// <param name="locationId">Optional parameter: Limit results to the location supplied. By default, results are returned for all locations associated with the merchant.</param>
        /// <param name="total">Optional parameter: The exact amount in the total_money for a `Payment`.</param>
        /// <param name="last4">Optional parameter: The last 4 digits of `Payment` card.</param>
        /// <param name="cardBrand">Optional parameter: The brand of `Payment` card. For example, `VISA`</param>
        /// <return>Returns the Models.ListPaymentsResponse response from the API call</return>
        Task<Models.ListPaymentsResponse> ListPaymentsAsync(
                string beginTime = null,
                string endTime = null,
                string sortOrder = null,
                string cursor = null,
                string locationId = null,
                long? total = null,
                string last4 = null,
                string cardBrand = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Charges a payment source, for example, a card 
        /// represented by customer's card on file or a card nonce. In addition 
        /// to the payment source, the request must also include the 
        /// amount to accept for the payment.
        /// There are several optional parameters that you can include in the request. 
        /// For example, tip money, whether to autocomplete the payment, or a reference ID
        /// to correlate this payment with another system. 
        /// For more information about these 
        /// payment options, see [Take Payments](https://developer.squareup.com/docs/payments-api/take-payments).
        /// The `PAYMENTS_WRITE_ADDITIONAL_RECIPIENTS` OAuth permission is required
        /// to enable application fees.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreatePaymentResponse response from the API call</return>
        Models.CreatePaymentResponse CreatePayment(Models.CreatePaymentRequest body);

        /// <summary>
        /// Charges a payment source, for example, a card 
        /// represented by customer's card on file or a card nonce. In addition 
        /// to the payment source, the request must also include the 
        /// amount to accept for the payment.
        /// There are several optional parameters that you can include in the request. 
        /// For example, tip money, whether to autocomplete the payment, or a reference ID
        /// to correlate this payment with another system. 
        /// For more information about these 
        /// payment options, see [Take Payments](https://developer.squareup.com/docs/payments-api/take-payments).
        /// The `PAYMENTS_WRITE_ADDITIONAL_RECIPIENTS` OAuth permission is required
        /// to enable application fees.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreatePaymentResponse response from the API call</return>
        Task<Models.CreatePaymentResponse> CreatePaymentAsync(Models.CreatePaymentRequest body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Cancels (voids) a payment identified by the idempotency key that is specified in the
        /// request.
        /// Use this method when status of a CreatePayment request is unknown. For example, after you send a
        /// CreatePayment request a network error occurs and you don't get a response. In this case, you can
        /// direct Square to cancel the payment using this endpoint. In the request, you provide the same
        /// idempotency key that you provided in your CreatePayment request you want  to cancel. After
        /// cancelling the payment, you can submit your CreatePayment request again.
        /// Note that if no payment with the specified idempotency key is found, no action is taken, the end
        /// point returns successfully.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CancelPaymentByIdempotencyKeyResponse response from the API call</return>
        Models.CancelPaymentByIdempotencyKeyResponse CancelPaymentByIdempotencyKey(Models.CancelPaymentByIdempotencyKeyRequest body);

        /// <summary>
        /// Cancels (voids) a payment identified by the idempotency key that is specified in the
        /// request.
        /// Use this method when status of a CreatePayment request is unknown. For example, after you send a
        /// CreatePayment request a network error occurs and you don't get a response. In this case, you can
        /// direct Square to cancel the payment using this endpoint. In the request, you provide the same
        /// idempotency key that you provided in your CreatePayment request you want  to cancel. After
        /// cancelling the payment, you can submit your CreatePayment request again.
        /// Note that if no payment with the specified idempotency key is found, no action is taken, the end
        /// point returns successfully.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CancelPaymentByIdempotencyKeyResponse response from the API call</return>
        Task<Models.CancelPaymentByIdempotencyKeyResponse> CancelPaymentByIdempotencyKeyAsync(Models.CancelPaymentByIdempotencyKeyRequest body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves details for a specific Payment.
        /// </summary>
        /// <param name="paymentId">Required parameter: Unique ID for the desired `Payment`.</param>
        /// <return>Returns the Models.GetPaymentResponse response from the API call</return>
        Models.GetPaymentResponse GetPayment(string paymentId);

        /// <summary>
        /// Retrieves details for a specific Payment.
        /// </summary>
        /// <param name="paymentId">Required parameter: Unique ID for the desired `Payment`.</param>
        /// <return>Returns the Models.GetPaymentResponse response from the API call</return>
        Task<Models.GetPaymentResponse> GetPaymentAsync(string paymentId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Cancels (voids) a payment. If you set `autocomplete` to false when creating a payment, 
        /// you can cancel the payment using this endpoint. For more information, see 
        /// [Delayed Payments](https://developer.squareup.com/docs/payments-api/take-payments#delayed-payments).
        /// </summary>
        /// <param name="paymentId">Required parameter: `payment_id` identifying the payment to be canceled.</param>
        /// <return>Returns the Models.CancelPaymentResponse response from the API call</return>
        Models.CancelPaymentResponse CancelPayment(string paymentId);

        /// <summary>
        /// Cancels (voids) a payment. If you set `autocomplete` to false when creating a payment, 
        /// you can cancel the payment using this endpoint. For more information, see 
        /// [Delayed Payments](https://developer.squareup.com/docs/payments-api/take-payments#delayed-payments).
        /// </summary>
        /// <param name="paymentId">Required parameter: `payment_id` identifying the payment to be canceled.</param>
        /// <return>Returns the Models.CancelPaymentResponse response from the API call</return>
        Task<Models.CancelPaymentResponse> CancelPaymentAsync(string paymentId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Completes (captures) a payment.
        /// By default, payments are set to complete immediately after they are created. 
        /// If you set autocomplete to false when creating a payment, you can complete (capture) 
        /// the payment using this endpoint. For more information, see
        /// [Delayed Payments](https://developer.squareup.com/docs/payments-api/take-payments#delayed-payments).
        /// </summary>
        /// <param name="paymentId">Required parameter: Unique ID identifying the payment to be completed.</param>
        /// <return>Returns the Models.CompletePaymentResponse response from the API call</return>
        Models.CompletePaymentResponse CompletePayment(string paymentId);

        /// <summary>
        /// Completes (captures) a payment.
        /// By default, payments are set to complete immediately after they are created. 
        /// If you set autocomplete to false when creating a payment, you can complete (capture) 
        /// the payment using this endpoint. For more information, see
        /// [Delayed Payments](https://developer.squareup.com/docs/payments-api/take-payments#delayed-payments).
        /// </summary>
        /// <param name="paymentId">Required parameter: Unique ID identifying the payment to be completed.</param>
        /// <return>Returns the Models.CompletePaymentResponse response from the API call</return>
        Task<Models.CompletePaymentResponse> CompletePaymentAsync(string paymentId, CancellationToken cancellationToken = default);

    }
}