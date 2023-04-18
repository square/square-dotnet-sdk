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
    /// ITransactionsApi.
    /// </summary>
    public interface ITransactionsApi
    {
        /// <summary>
        /// Lists transactions for a particular location.
        /// Transactions include payment information from sales and exchanges and refund.
        /// information from returns and exchanges.
        /// Max results per [page](https://developer.squareup.com/docs/working-with-apis/pagination): 50.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to list transactions for..</param>
        /// <param name="beginTime">Optional parameter: The beginning of the requested reporting period, in RFC 3339 format.  See [Date ranges](https://developer.squareup.com/docs/build-basics/working-with-dates) for details on date inclusivity/exclusivity.  Default value: The current time minus one year..</param>
        /// <param name="endTime">Optional parameter: The end of the requested reporting period, in RFC 3339 format.  See [Date ranges](https://developer.squareup.com/docs/build-basics/working-with-dates) for details on date inclusivity/exclusivity.  Default value: The current time..</param>
        /// <param name="sortOrder">Optional parameter: The order in which results are listed in the response (`ASC` for oldest first, `DESC` for newest first).  Default value: `DESC`.</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for your original query.  See [Paginating results](https://developer.squareup.com/docs/working-with-apis/pagination) for more information..</param>
        /// <returns>Returns the Models.ListTransactionsResponse response from the API call.</returns>
        [Obsolete]
        Models.ListTransactionsResponse ListTransactions(
                string locationId,
                string beginTime = null,
                string endTime = null,
                string sortOrder = null,
                string cursor = null);

        /// <summary>
        /// Lists transactions for a particular location.
        /// Transactions include payment information from sales and exchanges and refund.
        /// information from returns and exchanges.
        /// Max results per [page](https://developer.squareup.com/docs/working-with-apis/pagination): 50.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to list transactions for..</param>
        /// <param name="beginTime">Optional parameter: The beginning of the requested reporting period, in RFC 3339 format.  See [Date ranges](https://developer.squareup.com/docs/build-basics/working-with-dates) for details on date inclusivity/exclusivity.  Default value: The current time minus one year..</param>
        /// <param name="endTime">Optional parameter: The end of the requested reporting period, in RFC 3339 format.  See [Date ranges](https://developer.squareup.com/docs/build-basics/working-with-dates) for details on date inclusivity/exclusivity.  Default value: The current time..</param>
        /// <param name="sortOrder">Optional parameter: The order in which results are listed in the response (`ASC` for oldest first, `DESC` for newest first).  Default value: `DESC`.</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for your original query.  See [Paginating results](https://developer.squareup.com/docs/working-with-apis/pagination) for more information..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListTransactionsResponse response from the API call.</returns>
        [Obsolete]
        Task<Models.ListTransactionsResponse> ListTransactionsAsync(
                string locationId,
                string beginTime = null,
                string endTime = null,
                string sortOrder = null,
                string cursor = null,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves details for a single transaction.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the transaction's associated location..</param>
        /// <param name="transactionId">Required parameter: The ID of the transaction to retrieve..</param>
        /// <returns>Returns the Models.RetrieveTransactionResponse response from the API call.</returns>
        [Obsolete]
        Models.RetrieveTransactionResponse RetrieveTransaction(
                string locationId,
                string transactionId);

        /// <summary>
        /// Retrieves details for a single transaction.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the transaction's associated location..</param>
        /// <param name="transactionId">Required parameter: The ID of the transaction to retrieve..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveTransactionResponse response from the API call.</returns>
        [Obsolete]
        Task<Models.RetrieveTransactionResponse> RetrieveTransactionAsync(
                string locationId,
                string transactionId,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Captures a transaction that was created with the [Charge](api-endpoint:Transactions-Charge).
        /// endpoint with a `delay_capture` value of `true`.
        /// See [Delayed capture transactions](https://developer.squareup.com/docs/payments/transactions/overview#delayed-capture).
        /// for more information.
        /// </summary>
        /// <param name="locationId">Required parameter: Example: .</param>
        /// <param name="transactionId">Required parameter: Example: .</param>
        /// <returns>Returns the Models.CaptureTransactionResponse response from the API call.</returns>
        [Obsolete]
        Models.CaptureTransactionResponse CaptureTransaction(
                string locationId,
                string transactionId);

        /// <summary>
        /// Captures a transaction that was created with the [Charge](api-endpoint:Transactions-Charge).
        /// endpoint with a `delay_capture` value of `true`.
        /// See [Delayed capture transactions](https://developer.squareup.com/docs/payments/transactions/overview#delayed-capture).
        /// for more information.
        /// </summary>
        /// <param name="locationId">Required parameter: Example: .</param>
        /// <param name="transactionId">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CaptureTransactionResponse response from the API call.</returns>
        [Obsolete]
        Task<Models.CaptureTransactionResponse> CaptureTransactionAsync(
                string locationId,
                string transactionId,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Cancels a transaction that was created with the [Charge](api-endpoint:Transactions-Charge).
        /// endpoint with a `delay_capture` value of `true`.
        /// See [Delayed capture transactions](https://developer.squareup.com/docs/payments/transactions/overview#delayed-capture).
        /// for more information.
        /// </summary>
        /// <param name="locationId">Required parameter: Example: .</param>
        /// <param name="transactionId">Required parameter: Example: .</param>
        /// <returns>Returns the Models.VoidTransactionResponse response from the API call.</returns>
        [Obsolete]
        Models.VoidTransactionResponse VoidTransaction(
                string locationId,
                string transactionId);

        /// <summary>
        /// Cancels a transaction that was created with the [Charge](api-endpoint:Transactions-Charge).
        /// endpoint with a `delay_capture` value of `true`.
        /// See [Delayed capture transactions](https://developer.squareup.com/docs/payments/transactions/overview#delayed-capture).
        /// for more information.
        /// </summary>
        /// <param name="locationId">Required parameter: Example: .</param>
        /// <param name="transactionId">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.VoidTransactionResponse response from the API call.</returns>
        [Obsolete]
        Task<Models.VoidTransactionResponse> VoidTransactionAsync(
                string locationId,
                string transactionId,
                CancellationToken cancellationToken = default);
    }
}