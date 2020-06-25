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
    public interface ITransactionsApi
    {
        /// <summary>
        /// Lists refunds for one of a business's locations.
        /// In addition to full or partial tender refunds processed through Square APIs,
        /// refunds may result from itemized returns or exchanges through Square's
        /// Point of Sale applications.
        /// Refunds with a `status` of `PENDING` are not currently included in this
        /// endpoint's response.
        /// Max results per [page](#paginatingresults): 50
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to list refunds for.</param>
        /// <param name="beginTime">Optional parameter: The beginning of the requested reporting period, in RFC 3339 format.  See [Date ranges](#dateranges) for details on date inclusivity/exclusivity.  Default value: The current time minus one year.</param>
        /// <param name="endTime">Optional parameter: The end of the requested reporting period, in RFC 3339 format.  See [Date ranges](#dateranges) for details on date inclusivity/exclusivity.  Default value: The current time.</param>
        /// <param name="sortOrder">Optional parameter: The order in which results are listed in the response (`ASC` for oldest first, `DESC` for newest first).  Default value: `DESC`</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for your original query.  See [Paginating results](#paginatingresults) for more information.</param>
        /// <return>Returns the Models.ListRefundsResponse response from the API call</return>
        [Obsolete]
        Models.ListRefundsResponse ListRefunds(
                string locationId,
                string beginTime = null,
                string endTime = null,
                string sortOrder = null,
                string cursor = null);

        /// <summary>
        /// Lists refunds for one of a business's locations.
        /// In addition to full or partial tender refunds processed through Square APIs,
        /// refunds may result from itemized returns or exchanges through Square's
        /// Point of Sale applications.
        /// Refunds with a `status` of `PENDING` are not currently included in this
        /// endpoint's response.
        /// Max results per [page](#paginatingresults): 50
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to list refunds for.</param>
        /// <param name="beginTime">Optional parameter: The beginning of the requested reporting period, in RFC 3339 format.  See [Date ranges](#dateranges) for details on date inclusivity/exclusivity.  Default value: The current time minus one year.</param>
        /// <param name="endTime">Optional parameter: The end of the requested reporting period, in RFC 3339 format.  See [Date ranges](#dateranges) for details on date inclusivity/exclusivity.  Default value: The current time.</param>
        /// <param name="sortOrder">Optional parameter: The order in which results are listed in the response (`ASC` for oldest first, `DESC` for newest first).  Default value: `DESC`</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for your original query.  See [Paginating results](#paginatingresults) for more information.</param>
        /// <return>Returns the Models.ListRefundsResponse response from the API call</return>
        [Obsolete]
        Task<Models.ListRefundsResponse> ListRefundsAsync(
                string locationId,
                string beginTime = null,
                string endTime = null,
                string sortOrder = null,
                string cursor = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Lists transactions for a particular location.
        /// Transactions include payment information from sales and exchanges and refund
        /// information from returns and exchanges.
        /// Max results per [page](#paginatingresults): 50
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to list transactions for.</param>
        /// <param name="beginTime">Optional parameter: The beginning of the requested reporting period, in RFC 3339 format.  See [Date ranges](#dateranges) for details on date inclusivity/exclusivity.  Default value: The current time minus one year.</param>
        /// <param name="endTime">Optional parameter: The end of the requested reporting period, in RFC 3339 format.  See [Date ranges](#dateranges) for details on date inclusivity/exclusivity.  Default value: The current time.</param>
        /// <param name="sortOrder">Optional parameter: The order in which results are listed in the response (`ASC` for oldest first, `DESC` for newest first).  Default value: `DESC`</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for your original query.  See [Paginating results](#paginatingresults) for more information.</param>
        /// <return>Returns the Models.ListTransactionsResponse response from the API call</return>
        [Obsolete]
        Models.ListTransactionsResponse ListTransactions(
                string locationId,
                string beginTime = null,
                string endTime = null,
                string sortOrder = null,
                string cursor = null);

        /// <summary>
        /// Lists transactions for a particular location.
        /// Transactions include payment information from sales and exchanges and refund
        /// information from returns and exchanges.
        /// Max results per [page](#paginatingresults): 50
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to list transactions for.</param>
        /// <param name="beginTime">Optional parameter: The beginning of the requested reporting period, in RFC 3339 format.  See [Date ranges](#dateranges) for details on date inclusivity/exclusivity.  Default value: The current time minus one year.</param>
        /// <param name="endTime">Optional parameter: The end of the requested reporting period, in RFC 3339 format.  See [Date ranges](#dateranges) for details on date inclusivity/exclusivity.  Default value: The current time.</param>
        /// <param name="sortOrder">Optional parameter: The order in which results are listed in the response (`ASC` for oldest first, `DESC` for newest first).  Default value: `DESC`</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for your original query.  See [Paginating results](#paginatingresults) for more information.</param>
        /// <return>Returns the Models.ListTransactionsResponse response from the API call</return>
        [Obsolete]
        Task<Models.ListTransactionsResponse> ListTransactionsAsync(
                string locationId,
                string beginTime = null,
                string endTime = null,
                string sortOrder = null,
                string cursor = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Charges a card represented by a card nonce or a customer's card on file.
        /// Your request to this endpoint must include _either_:
        /// - A value for the `card_nonce` parameter (to charge a card nonce generated
        /// with the `SqPaymentForm`)
        /// - Values for the `customer_card_id` and `customer_id` parameters (to charge
        /// a customer's card on file)
        /// In order for an eCommerce payment to potentially qualify for
        /// [Square chargeback protection](https://squareup.com/help/article/5394), you
        /// _must_ provide values for the following parameters in your request:
        /// - `buyer_email_address`
        /// - At least one of `billing_address` or `shipping_address`
        /// When this response is returned, the amount of Square's processing fee might not yet be
        /// calculated. To obtain the processing fee, wait about ten seconds and call
        /// [RetrieveTransaction](#endpoint-retrievetransaction). See the `processing_fee_money`
        /// field of each [Tender included](#type-tender) in the transaction.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to associate the created transaction with.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.ChargeResponse response from the API call</return>
        [Obsolete]
        Models.ChargeResponse Charge(string locationId, Models.ChargeRequest body);

        /// <summary>
        /// Charges a card represented by a card nonce or a customer's card on file.
        /// Your request to this endpoint must include _either_:
        /// - A value for the `card_nonce` parameter (to charge a card nonce generated
        /// with the `SqPaymentForm`)
        /// - Values for the `customer_card_id` and `customer_id` parameters (to charge
        /// a customer's card on file)
        /// In order for an eCommerce payment to potentially qualify for
        /// [Square chargeback protection](https://squareup.com/help/article/5394), you
        /// _must_ provide values for the following parameters in your request:
        /// - `buyer_email_address`
        /// - At least one of `billing_address` or `shipping_address`
        /// When this response is returned, the amount of Square's processing fee might not yet be
        /// calculated. To obtain the processing fee, wait about ten seconds and call
        /// [RetrieveTransaction](#endpoint-retrievetransaction). See the `processing_fee_money`
        /// field of each [Tender included](#type-tender) in the transaction.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to associate the created transaction with.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.ChargeResponse response from the API call</return>
        [Obsolete]
        Task<Models.ChargeResponse> ChargeAsync(string locationId, Models.ChargeRequest body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves details for a single transaction.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the transaction's associated location.</param>
        /// <param name="transactionId">Required parameter: The ID of the transaction to retrieve.</param>
        /// <return>Returns the Models.RetrieveTransactionResponse response from the API call</return>
        [Obsolete]
        Models.RetrieveTransactionResponse RetrieveTransaction(string locationId, string transactionId);

        /// <summary>
        /// Retrieves details for a single transaction.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the transaction's associated location.</param>
        /// <param name="transactionId">Required parameter: The ID of the transaction to retrieve.</param>
        /// <return>Returns the Models.RetrieveTransactionResponse response from the API call</return>
        [Obsolete]
        Task<Models.RetrieveTransactionResponse> RetrieveTransactionAsync(string locationId, string transactionId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Captures a transaction that was created with the [Charge](#endpoint-charge)
        /// endpoint with a `delay_capture` value of `true`.
        /// See [Delayed capture transactions](https://developer.squareup.com/docs/payments/transactions/overview#delayed-capture)
        /// for more information.
        /// </summary>
        /// <param name="locationId">Required parameter: Example: </param>
        /// <param name="transactionId">Required parameter: Example: </param>
        /// <return>Returns the Models.CaptureTransactionResponse response from the API call</return>
        [Obsolete]
        Models.CaptureTransactionResponse CaptureTransaction(string locationId, string transactionId);

        /// <summary>
        /// Captures a transaction that was created with the [Charge](#endpoint-charge)
        /// endpoint with a `delay_capture` value of `true`.
        /// See [Delayed capture transactions](https://developer.squareup.com/docs/payments/transactions/overview#delayed-capture)
        /// for more information.
        /// </summary>
        /// <param name="locationId">Required parameter: Example: </param>
        /// <param name="transactionId">Required parameter: Example: </param>
        /// <return>Returns the Models.CaptureTransactionResponse response from the API call</return>
        [Obsolete]
        Task<Models.CaptureTransactionResponse> CaptureTransactionAsync(string locationId, string transactionId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Initiates a refund for a previously charged tender.
        /// You must issue a refund within 120 days of the associated payment. See
        /// [this article](https://squareup.com/help/us/en/article/5060) for more information
        /// on refund behavior.
        /// NOTE: Card-present transactions with Interac credit cards **cannot be
        /// refunded using the Connect API**. Interac transactions must refunded
        /// in-person (e.g., dipping the card using POS app).
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the original transaction's associated location.</param>
        /// <param name="transactionId">Required parameter: The ID of the original transaction that includes the tender to refund.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreateRefundResponse response from the API call</return>
        [Obsolete]
        Models.CreateRefundResponse CreateRefund(string locationId, string transactionId, Models.CreateRefundRequest body);

        /// <summary>
        /// Initiates a refund for a previously charged tender.
        /// You must issue a refund within 120 days of the associated payment. See
        /// [this article](https://squareup.com/help/us/en/article/5060) for more information
        /// on refund behavior.
        /// NOTE: Card-present transactions with Interac credit cards **cannot be
        /// refunded using the Connect API**. Interac transactions must refunded
        /// in-person (e.g., dipping the card using POS app).
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the original transaction's associated location.</param>
        /// <param name="transactionId">Required parameter: The ID of the original transaction that includes the tender to refund.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreateRefundResponse response from the API call</return>
        [Obsolete]
        Task<Models.CreateRefundResponse> CreateRefundAsync(string locationId, string transactionId, Models.CreateRefundRequest body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Cancels a transaction that was created with the [Charge](#endpoint-charge)
        /// endpoint with a `delay_capture` value of `true`.
        /// See [Delayed capture transactions](https://developer.squareup.com/docs/payments/transactions/overview#delayed-capture)
        /// for more information.
        /// </summary>
        /// <param name="locationId">Required parameter: Example: </param>
        /// <param name="transactionId">Required parameter: Example: </param>
        /// <return>Returns the Models.VoidTransactionResponse response from the API call</return>
        [Obsolete]
        Models.VoidTransactionResponse VoidTransaction(string locationId, string transactionId);

        /// <summary>
        /// Cancels a transaction that was created with the [Charge](#endpoint-charge)
        /// endpoint with a `delay_capture` value of `true`.
        /// See [Delayed capture transactions](https://developer.squareup.com/docs/payments/transactions/overview#delayed-capture)
        /// for more information.
        /// </summary>
        /// <param name="locationId">Required parameter: Example: </param>
        /// <param name="transactionId">Required parameter: Example: </param>
        /// <return>Returns the Models.VoidTransactionResponse response from the API call</return>
        [Obsolete]
        Task<Models.VoidTransactionResponse> VoidTransactionAsync(string locationId, string transactionId, CancellationToken cancellationToken = default);

    }
}