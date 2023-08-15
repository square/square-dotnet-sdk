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
    /// InvoicesApi.
    /// </summary>
    internal class InvoicesApi : BaseApi, IInvoicesApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvoicesApi"/> class.
        /// </summary>
        internal InvoicesApi(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// Returns a list of invoices for a given location. The response .
        /// is paginated. If truncated, the response includes a `cursor` that you    .
        /// use in a subsequent request to retrieve the next set of invoices.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location for which to list invoices..</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint.  Provide this cursor to retrieve the next set of results for your original query.  For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="limit">Optional parameter: The maximum number of invoices to return (200 is the maximum `limit`).  If not provided, the server uses a default limit of 100 invoices..</param>
        /// <returns>Returns the Models.ListInvoicesResponse response from the API call.</returns>
        public Models.ListInvoicesResponse ListInvoices(
                string locationId,
                string cursor = null,
                int? limit = null)
            => CoreHelper.RunTask(ListInvoicesAsync(locationId, cursor, limit));

        /// <summary>
        /// Returns a list of invoices for a given location. The response .
        /// is paginated. If truncated, the response includes a `cursor` that you    .
        /// use in a subsequent request to retrieve the next set of invoices.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location for which to list invoices..</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint.  Provide this cursor to retrieve the next set of results for your original query.  For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="limit">Optional parameter: The maximum number of invoices to return (200 is the maximum `limit`).  If not provided, the server uses a default limit of 100 invoices..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListInvoicesResponse response from the API call.</returns>
        public async Task<Models.ListInvoicesResponse> ListInvoicesAsync(
                string locationId,
                string cursor = null,
                int? limit = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ListInvoicesResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/invoices")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("location_id", locationId))
                      .Query(_query => _query.Setup("cursor", cursor))
                      .Query(_query => _query.Setup("limit", limit))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Creates a draft [invoice]($m/Invoice) .
        /// for an order created using the Orders API.
        /// A draft invoice remains in your account and no action is taken. .
        /// You must publish the invoice before Square can process it (send it to the customer's email address or charge the customer’s card on file).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateInvoiceResponse response from the API call.</returns>
        public Models.CreateInvoiceResponse CreateInvoice(
                Models.CreateInvoiceRequest body)
            => CoreHelper.RunTask(CreateInvoiceAsync(body));

        /// <summary>
        /// Creates a draft [invoice]($m/Invoice) .
        /// for an order created using the Orders API.
        /// A draft invoice remains in your account and no action is taken. .
        /// You must publish the invoice before Square can process it (send it to the customer's email address or charge the customer’s card on file).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateInvoiceResponse response from the API call.</returns>
        public async Task<Models.CreateInvoiceResponse> CreateInvoiceAsync(
                Models.CreateInvoiceRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.CreateInvoiceResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/invoices")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Searches for invoices from a location specified in .
        /// the filter. You can optionally specify customers in the filter for whom to .
        /// retrieve invoices. In the current implementation, you can only specify one location and .
        /// optionally one customer.
        /// The response is paginated. If truncated, the response includes a `cursor` .
        /// that you use in a subsequent request to retrieve the next set of invoices.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.SearchInvoicesResponse response from the API call.</returns>
        public Models.SearchInvoicesResponse SearchInvoices(
                Models.SearchInvoicesRequest body)
            => CoreHelper.RunTask(SearchInvoicesAsync(body));

        /// <summary>
        /// Searches for invoices from a location specified in .
        /// the filter. You can optionally specify customers in the filter for whom to .
        /// retrieve invoices. In the current implementation, you can only specify one location and .
        /// optionally one customer.
        /// The response is paginated. If truncated, the response includes a `cursor` .
        /// that you use in a subsequent request to retrieve the next set of invoices.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.SearchInvoicesResponse response from the API call.</returns>
        public async Task<Models.SearchInvoicesResponse> SearchInvoicesAsync(
                Models.SearchInvoicesRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.SearchInvoicesResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/invoices/search")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Deletes the specified invoice. When an invoice is deleted, the .
        /// associated order status changes to CANCELED. You can only delete a draft .
        /// invoice (you cannot delete a published invoice, including one that is scheduled for processing).
        /// </summary>
        /// <param name="invoiceId">Required parameter: The ID of the invoice to delete..</param>
        /// <param name="version">Optional parameter: The version of the [invoice](entity:Invoice) to delete. If you do not know the version, you can call [GetInvoice](api-endpoint:Invoices-GetInvoice) or  [ListInvoices](api-endpoint:Invoices-ListInvoices)..</param>
        /// <returns>Returns the Models.DeleteInvoiceResponse response from the API call.</returns>
        public Models.DeleteInvoiceResponse DeleteInvoice(
                string invoiceId,
                int? version = null)
            => CoreHelper.RunTask(DeleteInvoiceAsync(invoiceId, version));

        /// <summary>
        /// Deletes the specified invoice. When an invoice is deleted, the .
        /// associated order status changes to CANCELED. You can only delete a draft .
        /// invoice (you cannot delete a published invoice, including one that is scheduled for processing).
        /// </summary>
        /// <param name="invoiceId">Required parameter: The ID of the invoice to delete..</param>
        /// <param name="version">Optional parameter: The version of the [invoice](entity:Invoice) to delete. If you do not know the version, you can call [GetInvoice](api-endpoint:Invoices-GetInvoice) or  [ListInvoices](api-endpoint:Invoices-ListInvoices)..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.DeleteInvoiceResponse response from the API call.</returns>
        public async Task<Models.DeleteInvoiceResponse> DeleteInvoiceAsync(
                string invoiceId,
                int? version = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.DeleteInvoiceResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Delete, "/v2/invoices/{invoice_id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("invoice_id", invoiceId))
                      .Query(_query => _query.Setup("version", version))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Retrieves an invoice by invoice ID.
        /// </summary>
        /// <param name="invoiceId">Required parameter: The ID of the invoice to retrieve..</param>
        /// <returns>Returns the Models.GetInvoiceResponse response from the API call.</returns>
        public Models.GetInvoiceResponse GetInvoice(
                string invoiceId)
            => CoreHelper.RunTask(GetInvoiceAsync(invoiceId));

        /// <summary>
        /// Retrieves an invoice by invoice ID.
        /// </summary>
        /// <param name="invoiceId">Required parameter: The ID of the invoice to retrieve..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.GetInvoiceResponse response from the API call.</returns>
        public async Task<Models.GetInvoiceResponse> GetInvoiceAsync(
                string invoiceId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.GetInvoiceResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/invoices/{invoice_id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("invoice_id", invoiceId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Updates an invoice by modifying fields, clearing fields, or both. For most updates, you can use a sparse .
        /// `Invoice` object to add fields or change values and use the `fields_to_clear` field to specify fields to clear. .
        /// However, some restrictions apply. For example, you cannot change the `order_id` or `location_id` field and you .
        /// must provide the complete `custom_fields` list to update a custom field. Published invoices have additional restrictions.
        /// </summary>
        /// <param name="invoiceId">Required parameter: The ID of the invoice to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpdateInvoiceResponse response from the API call.</returns>
        public Models.UpdateInvoiceResponse UpdateInvoice(
                string invoiceId,
                Models.UpdateInvoiceRequest body)
            => CoreHelper.RunTask(UpdateInvoiceAsync(invoiceId, body));

        /// <summary>
        /// Updates an invoice by modifying fields, clearing fields, or both. For most updates, you can use a sparse .
        /// `Invoice` object to add fields or change values and use the `fields_to_clear` field to specify fields to clear. .
        /// However, some restrictions apply. For example, you cannot change the `order_id` or `location_id` field and you .
        /// must provide the complete `custom_fields` list to update a custom field. Published invoices have additional restrictions.
        /// </summary>
        /// <param name="invoiceId">Required parameter: The ID of the invoice to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpdateInvoiceResponse response from the API call.</returns>
        public async Task<Models.UpdateInvoiceResponse> UpdateInvoiceAsync(
                string invoiceId,
                Models.UpdateInvoiceRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.UpdateInvoiceResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Put, "/v2/invoices/{invoice_id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Template(_template => _template.Setup("invoice_id", invoiceId))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Cancels an invoice. The seller cannot collect payments for .
        /// the canceled invoice.
        /// You cannot cancel an invoice in the `DRAFT` state or in a terminal state: `PAID`, `REFUNDED`, `CANCELED`, or `FAILED`.
        /// </summary>
        /// <param name="invoiceId">Required parameter: The ID of the [invoice](entity:Invoice) to cancel..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CancelInvoiceResponse response from the API call.</returns>
        public Models.CancelInvoiceResponse CancelInvoice(
                string invoiceId,
                Models.CancelInvoiceRequest body)
            => CoreHelper.RunTask(CancelInvoiceAsync(invoiceId, body));

        /// <summary>
        /// Cancels an invoice. The seller cannot collect payments for .
        /// the canceled invoice.
        /// You cannot cancel an invoice in the `DRAFT` state or in a terminal state: `PAID`, `REFUNDED`, `CANCELED`, or `FAILED`.
        /// </summary>
        /// <param name="invoiceId">Required parameter: The ID of the [invoice](entity:Invoice) to cancel..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CancelInvoiceResponse response from the API call.</returns>
        public async Task<Models.CancelInvoiceResponse> CancelInvoiceAsync(
                string invoiceId,
                Models.CancelInvoiceRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.CancelInvoiceResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/invoices/{invoice_id}/cancel")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Template(_template => _template.Setup("invoice_id", invoiceId))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Publishes the specified draft invoice. .
        /// After an invoice is published, Square .
        /// follows up based on the invoice configuration. For example, Square .
        /// sends the invoice to the customer's email address, charges the customer's card on file, or does .
        /// nothing. Square also makes the invoice available on a Square-hosted invoice page. .
        /// The invoice `status` also changes from `DRAFT` to a status .
        /// based on the invoice configuration. For example, the status changes to `UNPAID` if .
        /// Square emails the invoice or `PARTIALLY_PAID` if Square charge a card on file for a portion of the .
        /// invoice amount.
        /// </summary>
        /// <param name="invoiceId">Required parameter: The ID of the invoice to publish..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.PublishInvoiceResponse response from the API call.</returns>
        public Models.PublishInvoiceResponse PublishInvoice(
                string invoiceId,
                Models.PublishInvoiceRequest body)
            => CoreHelper.RunTask(PublishInvoiceAsync(invoiceId, body));

        /// <summary>
        /// Publishes the specified draft invoice. .
        /// After an invoice is published, Square .
        /// follows up based on the invoice configuration. For example, Square .
        /// sends the invoice to the customer's email address, charges the customer's card on file, or does .
        /// nothing. Square also makes the invoice available on a Square-hosted invoice page. .
        /// The invoice `status` also changes from `DRAFT` to a status .
        /// based on the invoice configuration. For example, the status changes to `UNPAID` if .
        /// Square emails the invoice or `PARTIALLY_PAID` if Square charge a card on file for a portion of the .
        /// invoice amount.
        /// </summary>
        /// <param name="invoiceId">Required parameter: The ID of the invoice to publish..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.PublishInvoiceResponse response from the API call.</returns>
        public async Task<Models.PublishInvoiceResponse> PublishInvoiceAsync(
                string invoiceId,
                Models.PublishInvoiceRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.PublishInvoiceResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/invoices/{invoice_id}/publish")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Template(_template => _template.Setup("invoice_id", invoiceId))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken);
    }
}