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
    /// TransactionsApi.
    /// </summary>
    internal class TransactionsApi : BaseApi, ITransactionsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionsApi"/> class.
        /// </summary>
        internal TransactionsApi(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

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
        public Models.ListTransactionsResponse ListTransactions(
                string locationId,
                string beginTime = null,
                string endTime = null,
                string sortOrder = null,
                string cursor = null)
            => CoreHelper.RunTask(ListTransactionsAsync(locationId, beginTime, endTime, sortOrder, cursor));

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
        public async Task<Models.ListTransactionsResponse> ListTransactionsAsync(
                string locationId,
                string beginTime = null,
                string endTime = null,
                string sortOrder = null,
                string cursor = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ListTransactionsResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/locations/{location_id}/transactions")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("location_id", locationId))
                      .Query(_query => _query.Setup("begin_time", beginTime))
                      .Query(_query => _query.Setup("end_time", endTime))
                      .Query(_query => _query.Setup("sort_order", sortOrder))
                      .Query(_query => _query.Setup("cursor", cursor))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Retrieves details for a single transaction.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the transaction's associated location..</param>
        /// <param name="transactionId">Required parameter: The ID of the transaction to retrieve..</param>
        /// <returns>Returns the Models.RetrieveTransactionResponse response from the API call.</returns>
        [Obsolete]
        public Models.RetrieveTransactionResponse RetrieveTransaction(
                string locationId,
                string transactionId)
            => CoreHelper.RunTask(RetrieveTransactionAsync(locationId, transactionId));

        /// <summary>
        /// Retrieves details for a single transaction.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the transaction's associated location..</param>
        /// <param name="transactionId">Required parameter: The ID of the transaction to retrieve..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveTransactionResponse response from the API call.</returns>
        [Obsolete]
        public async Task<Models.RetrieveTransactionResponse> RetrieveTransactionAsync(
                string locationId,
                string transactionId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.RetrieveTransactionResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/locations/{location_id}/transactions/{transaction_id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("location_id", locationId))
                      .Template(_template => _template.Setup("transaction_id", transactionId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

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
        public Models.CaptureTransactionResponse CaptureTransaction(
                string locationId,
                string transactionId)
            => CoreHelper.RunTask(CaptureTransactionAsync(locationId, transactionId));

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
        public async Task<Models.CaptureTransactionResponse> CaptureTransactionAsync(
                string locationId,
                string transactionId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.CaptureTransactionResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/locations/{location_id}/transactions/{transaction_id}/capture")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("location_id", locationId))
                      .Template(_template => _template.Setup("transaction_id", transactionId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

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
        public Models.VoidTransactionResponse VoidTransaction(
                string locationId,
                string transactionId)
            => CoreHelper.RunTask(VoidTransactionAsync(locationId, transactionId));

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
        public async Task<Models.VoidTransactionResponse> VoidTransactionAsync(
                string locationId,
                string transactionId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.VoidTransactionResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/locations/{location_id}/transactions/{transaction_id}/void")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("location_id", locationId))
                      .Template(_template => _template.Setup("transaction_id", transactionId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);
    }
}