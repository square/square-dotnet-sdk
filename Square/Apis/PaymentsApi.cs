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
    /// PaymentsApi.
    /// </summary>
    internal class PaymentsApi : BaseApi, IPaymentsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentsApi"/> class.
        /// </summary>
        internal PaymentsApi(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// Retrieves a list of payments taken by the account making the request.
        /// Results are eventually consistent, and new payments or changes to payments might take several.
        /// seconds to appear.
        /// The maximum results per page is 100.
        /// </summary>
        /// <param name="beginTime">Optional parameter: Indicates the start of the time range to retrieve payments for, in RFC 3339 format.   The range is determined using the `created_at` field for each Payment. Inclusive. Default: The current time minus one year..</param>
        /// <param name="endTime">Optional parameter: Indicates the end of the time range to retrieve payments for, in RFC 3339 format.  The  range is determined using the `created_at` field for each Payment.  Default: The current time..</param>
        /// <param name="sortOrder">Optional parameter: The order in which results are listed by `Payment.created_at`: - `ASC` - Oldest to newest. - `DESC` - Newest to oldest (default)..</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this cursor to retrieve the next set of results for the original query.  For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="locationId">Optional parameter: Limit results to the location supplied. By default, results are returned for the default (main) location associated with the seller..</param>
        /// <param name="total">Optional parameter: The exact amount in the `total_money` for a payment..</param>
        /// <param name="last4">Optional parameter: The last four digits of a payment card..</param>
        /// <param name="cardBrand">Optional parameter: The brand of the payment card (for example, VISA)..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to be returned in a single page. It is possible to receive fewer results than the specified limit on a given page.  The default value of 100 is also the maximum allowed value. If the provided value is  greater than 100, it is ignored and the default value is used instead.  Default: `100`.</param>
        /// <returns>Returns the Models.ListPaymentsResponse response from the API call.</returns>
        public Models.ListPaymentsResponse ListPayments(
                string beginTime = null,
                string endTime = null,
                string sortOrder = null,
                string cursor = null,
                string locationId = null,
                long? total = null,
                string last4 = null,
                string cardBrand = null,
                int? limit = null)
            => CoreHelper.RunTask(ListPaymentsAsync(beginTime, endTime, sortOrder, cursor, locationId, total, last4, cardBrand, limit));

        /// <summary>
        /// Retrieves a list of payments taken by the account making the request.
        /// Results are eventually consistent, and new payments or changes to payments might take several.
        /// seconds to appear.
        /// The maximum results per page is 100.
        /// </summary>
        /// <param name="beginTime">Optional parameter: Indicates the start of the time range to retrieve payments for, in RFC 3339 format.   The range is determined using the `created_at` field for each Payment. Inclusive. Default: The current time minus one year..</param>
        /// <param name="endTime">Optional parameter: Indicates the end of the time range to retrieve payments for, in RFC 3339 format.  The  range is determined using the `created_at` field for each Payment.  Default: The current time..</param>
        /// <param name="sortOrder">Optional parameter: The order in which results are listed by `Payment.created_at`: - `ASC` - Oldest to newest. - `DESC` - Newest to oldest (default)..</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this cursor to retrieve the next set of results for the original query.  For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="locationId">Optional parameter: Limit results to the location supplied. By default, results are returned for the default (main) location associated with the seller..</param>
        /// <param name="total">Optional parameter: The exact amount in the `total_money` for a payment..</param>
        /// <param name="last4">Optional parameter: The last four digits of a payment card..</param>
        /// <param name="cardBrand">Optional parameter: The brand of the payment card (for example, VISA)..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to be returned in a single page. It is possible to receive fewer results than the specified limit on a given page.  The default value of 100 is also the maximum allowed value. If the provided value is  greater than 100, it is ignored and the default value is used instead.  Default: `100`.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListPaymentsResponse response from the API call.</returns>
        public async Task<Models.ListPaymentsResponse> ListPaymentsAsync(
                string beginTime = null,
                string endTime = null,
                string sortOrder = null,
                string cursor = null,
                string locationId = null,
                long? total = null,
                string last4 = null,
                string cardBrand = null,
                int? limit = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ListPaymentsResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/payments")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("begin_time", beginTime))
                      .Query(_query => _query.Setup("end_time", endTime))
                      .Query(_query => _query.Setup("sort_order", sortOrder))
                      .Query(_query => _query.Setup("cursor", cursor))
                      .Query(_query => _query.Setup("location_id", locationId))
                      .Query(_query => _query.Setup("total", total))
                      .Query(_query => _query.Setup("last_4", last4))
                      .Query(_query => _query.Setup("card_brand", cardBrand))
                      .Query(_query => _query.Setup("limit", limit))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Creates a payment using the provided source. You can use this endpoint .
        /// to charge a card (credit/debit card or    .
        /// Square gift card) or record a payment that the seller received outside of Square .
        /// (cash payment from a buyer or a payment that an external entity .
        /// processed on behalf of the seller).
        /// The endpoint creates a .
        /// `Payment` object and returns it in the response.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreatePaymentResponse response from the API call.</returns>
        public Models.CreatePaymentResponse CreatePayment(
                Models.CreatePaymentRequest body)
            => CoreHelper.RunTask(CreatePaymentAsync(body));

        /// <summary>
        /// Creates a payment using the provided source. You can use this endpoint .
        /// to charge a card (credit/debit card or    .
        /// Square gift card) or record a payment that the seller received outside of Square .
        /// (cash payment from a buyer or a payment that an external entity .
        /// processed on behalf of the seller).
        /// The endpoint creates a .
        /// `Payment` object and returns it in the response.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreatePaymentResponse response from the API call.</returns>
        public async Task<Models.CreatePaymentResponse> CreatePaymentAsync(
                Models.CreatePaymentRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.CreatePaymentResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/payments")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Cancels (voids) a payment identified by the idempotency key that is specified in the.
        /// request.
        /// Use this method when the status of a `CreatePayment` request is unknown (for example, after you send a.
        /// `CreatePayment` request, a network error occurs and you do not get a response). In this case, you can.
        /// direct Square to cancel the payment using this endpoint. In the request, you provide the same.
        /// idempotency key that you provided in your `CreatePayment` request that you want to cancel. After.
        /// canceling the payment, you can submit your `CreatePayment` request again.
        /// Note that if no payment with the specified idempotency key is found, no action is taken and the endpoint.
        /// returns successfully.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CancelPaymentByIdempotencyKeyResponse response from the API call.</returns>
        public Models.CancelPaymentByIdempotencyKeyResponse CancelPaymentByIdempotencyKey(
                Models.CancelPaymentByIdempotencyKeyRequest body)
            => CoreHelper.RunTask(CancelPaymentByIdempotencyKeyAsync(body));

        /// <summary>
        /// Cancels (voids) a payment identified by the idempotency key that is specified in the.
        /// request.
        /// Use this method when the status of a `CreatePayment` request is unknown (for example, after you send a.
        /// `CreatePayment` request, a network error occurs and you do not get a response). In this case, you can.
        /// direct Square to cancel the payment using this endpoint. In the request, you provide the same.
        /// idempotency key that you provided in your `CreatePayment` request that you want to cancel. After.
        /// canceling the payment, you can submit your `CreatePayment` request again.
        /// Note that if no payment with the specified idempotency key is found, no action is taken and the endpoint.
        /// returns successfully.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CancelPaymentByIdempotencyKeyResponse response from the API call.</returns>
        public async Task<Models.CancelPaymentByIdempotencyKeyResponse> CancelPaymentByIdempotencyKeyAsync(
                Models.CancelPaymentByIdempotencyKeyRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.CancelPaymentByIdempotencyKeyResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/payments/cancel")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Retrieves details for a specific payment.
        /// </summary>
        /// <param name="paymentId">Required parameter: A unique ID for the desired payment..</param>
        /// <returns>Returns the Models.GetPaymentResponse response from the API call.</returns>
        public Models.GetPaymentResponse GetPayment(
                string paymentId)
            => CoreHelper.RunTask(GetPaymentAsync(paymentId));

        /// <summary>
        /// Retrieves details for a specific payment.
        /// </summary>
        /// <param name="paymentId">Required parameter: A unique ID for the desired payment..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.GetPaymentResponse response from the API call.</returns>
        public async Task<Models.GetPaymentResponse> GetPaymentAsync(
                string paymentId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.GetPaymentResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/payments/{payment_id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("payment_id", paymentId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Updates a payment with the APPROVED status.
        /// You can update the `amount_money` and `tip_money` using this endpoint.
        /// </summary>
        /// <param name="paymentId">Required parameter: The ID of the payment to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpdatePaymentResponse response from the API call.</returns>
        public Models.UpdatePaymentResponse UpdatePayment(
                string paymentId,
                Models.UpdatePaymentRequest body)
            => CoreHelper.RunTask(UpdatePaymentAsync(paymentId, body));

        /// <summary>
        /// Updates a payment with the APPROVED status.
        /// You can update the `amount_money` and `tip_money` using this endpoint.
        /// </summary>
        /// <param name="paymentId">Required parameter: The ID of the payment to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpdatePaymentResponse response from the API call.</returns>
        public async Task<Models.UpdatePaymentResponse> UpdatePaymentAsync(
                string paymentId,
                Models.UpdatePaymentRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.UpdatePaymentResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Put, "/v2/payments/{payment_id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Template(_template => _template.Setup("payment_id", paymentId))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Cancels (voids) a payment. You can use this endpoint to cancel a payment with .
        /// the APPROVED `status`.
        /// </summary>
        /// <param name="paymentId">Required parameter: The ID of the payment to cancel..</param>
        /// <returns>Returns the Models.CancelPaymentResponse response from the API call.</returns>
        public Models.CancelPaymentResponse CancelPayment(
                string paymentId)
            => CoreHelper.RunTask(CancelPaymentAsync(paymentId));

        /// <summary>
        /// Cancels (voids) a payment. You can use this endpoint to cancel a payment with .
        /// the APPROVED `status`.
        /// </summary>
        /// <param name="paymentId">Required parameter: The ID of the payment to cancel..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CancelPaymentResponse response from the API call.</returns>
        public async Task<Models.CancelPaymentResponse> CancelPaymentAsync(
                string paymentId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.CancelPaymentResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/payments/{payment_id}/cancel")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("payment_id", paymentId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Completes (captures) a payment.
        /// By default, payments are set to complete immediately after they are created.
        /// You can use this endpoint to complete a payment with the APPROVED `status`.
        /// </summary>
        /// <param name="paymentId">Required parameter: The unique ID identifying the payment to be completed..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CompletePaymentResponse response from the API call.</returns>
        public Models.CompletePaymentResponse CompletePayment(
                string paymentId,
                Models.CompletePaymentRequest body)
            => CoreHelper.RunTask(CompletePaymentAsync(paymentId, body));

        /// <summary>
        /// Completes (captures) a payment.
        /// By default, payments are set to complete immediately after they are created.
        /// You can use this endpoint to complete a payment with the APPROVED `status`.
        /// </summary>
        /// <param name="paymentId">Required parameter: The unique ID identifying the payment to be completed..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CompletePaymentResponse response from the API call.</returns>
        public async Task<Models.CompletePaymentResponse> CompletePaymentAsync(
                string paymentId,
                Models.CompletePaymentRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.CompletePaymentResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/payments/{payment_id}/complete")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Template(_template => _template.Setup("payment_id", paymentId))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken);
    }
}