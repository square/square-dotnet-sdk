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
    /// IInvoicesApi.
    /// </summary>
    public interface IInvoicesApi
    {
        /// <summary>
        /// Returns a list of invoices for a given location. The response .
        /// is paginated. If truncated, the response includes a `cursor` that you    .
        /// use in a subsequent request to retrieve the next set of invoices.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location for which to list invoices..</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint.  Provide this cursor to retrieve the next set of results for your original query.  For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="limit">Optional parameter: The maximum number of invoices to return (200 is the maximum `limit`).  If not provided, the server uses a default limit of 100 invoices..</param>
        /// <returns>Returns the Models.ListInvoicesResponse response from the API call.</returns>
        Models.ListInvoicesResponse ListInvoices(
                string locationId,
                string cursor = null,
                int? limit = null);

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
        Task<Models.ListInvoicesResponse> ListInvoicesAsync(
                string locationId,
                string cursor = null,
                int? limit = null,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a draft [invoice]($m/Invoice) .
        /// for an order created using the Orders API.
        /// A draft invoice remains in your account and no action is taken. .
        /// You must publish the invoice before Square can process it (send it to the customer's email address or charge the customer’s card on file).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateInvoiceResponse response from the API call.</returns>
        Models.CreateInvoiceResponse CreateInvoice(
                Models.CreateInvoiceRequest body);

        /// <summary>
        /// Creates a draft [invoice]($m/Invoice) .
        /// for an order created using the Orders API.
        /// A draft invoice remains in your account and no action is taken. .
        /// You must publish the invoice before Square can process it (send it to the customer's email address or charge the customer’s card on file).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateInvoiceResponse response from the API call.</returns>
        Task<Models.CreateInvoiceResponse> CreateInvoiceAsync(
                Models.CreateInvoiceRequest body,
                CancellationToken cancellationToken = default);

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
        Models.SearchInvoicesResponse SearchInvoices(
                Models.SearchInvoicesRequest body);

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
        Task<Models.SearchInvoicesResponse> SearchInvoicesAsync(
                Models.SearchInvoicesRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes the specified invoice. When an invoice is deleted, the .
        /// associated order status changes to CANCELED. You can only delete a draft .
        /// invoice (you cannot delete a published invoice, including one that is scheduled for processing).
        /// </summary>
        /// <param name="invoiceId">Required parameter: The ID of the invoice to delete..</param>
        /// <param name="version">Optional parameter: The version of the [invoice](entity:Invoice) to delete. If you do not know the version, you can call [GetInvoice](api-endpoint:Invoices-GetInvoice) or  [ListInvoices](api-endpoint:Invoices-ListInvoices)..</param>
        /// <returns>Returns the Models.DeleteInvoiceResponse response from the API call.</returns>
        Models.DeleteInvoiceResponse DeleteInvoice(
                string invoiceId,
                int? version = null);

        /// <summary>
        /// Deletes the specified invoice. When an invoice is deleted, the .
        /// associated order status changes to CANCELED. You can only delete a draft .
        /// invoice (you cannot delete a published invoice, including one that is scheduled for processing).
        /// </summary>
        /// <param name="invoiceId">Required parameter: The ID of the invoice to delete..</param>
        /// <param name="version">Optional parameter: The version of the [invoice](entity:Invoice) to delete. If you do not know the version, you can call [GetInvoice](api-endpoint:Invoices-GetInvoice) or  [ListInvoices](api-endpoint:Invoices-ListInvoices)..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.DeleteInvoiceResponse response from the API call.</returns>
        Task<Models.DeleteInvoiceResponse> DeleteInvoiceAsync(
                string invoiceId,
                int? version = null,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves an invoice by invoice ID.
        /// </summary>
        /// <param name="invoiceId">Required parameter: The ID of the invoice to retrieve..</param>
        /// <returns>Returns the Models.GetInvoiceResponse response from the API call.</returns>
        Models.GetInvoiceResponse GetInvoice(
                string invoiceId);

        /// <summary>
        /// Retrieves an invoice by invoice ID.
        /// </summary>
        /// <param name="invoiceId">Required parameter: The ID of the invoice to retrieve..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.GetInvoiceResponse response from the API call.</returns>
        Task<Models.GetInvoiceResponse> GetInvoiceAsync(
                string invoiceId,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an invoice by modifying fields, clearing fields, or both. For most updates, you can use a sparse .
        /// `Invoice` object to add fields or change values and use the `fields_to_clear` field to specify fields to clear. .
        /// However, some restrictions apply. For example, you cannot change the `order_id` or `location_id` field and you .
        /// must provide the complete `custom_fields` list to update a custom field. Published invoices have additional restrictions.
        /// </summary>
        /// <param name="invoiceId">Required parameter: The ID of the invoice to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpdateInvoiceResponse response from the API call.</returns>
        Models.UpdateInvoiceResponse UpdateInvoice(
                string invoiceId,
                Models.UpdateInvoiceRequest body);

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
        Task<Models.UpdateInvoiceResponse> UpdateInvoiceAsync(
                string invoiceId,
                Models.UpdateInvoiceRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Cancels an invoice. The seller cannot collect payments for .
        /// the canceled invoice.
        /// You cannot cancel an invoice in the `DRAFT` state or in a terminal state: `PAID`, `REFUNDED`, `CANCELED`, or `FAILED`.
        /// </summary>
        /// <param name="invoiceId">Required parameter: The ID of the [invoice](entity:Invoice) to cancel..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CancelInvoiceResponse response from the API call.</returns>
        Models.CancelInvoiceResponse CancelInvoice(
                string invoiceId,
                Models.CancelInvoiceRequest body);

        /// <summary>
        /// Cancels an invoice. The seller cannot collect payments for .
        /// the canceled invoice.
        /// You cannot cancel an invoice in the `DRAFT` state or in a terminal state: `PAID`, `REFUNDED`, `CANCELED`, or `FAILED`.
        /// </summary>
        /// <param name="invoiceId">Required parameter: The ID of the [invoice](entity:Invoice) to cancel..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CancelInvoiceResponse response from the API call.</returns>
        Task<Models.CancelInvoiceResponse> CancelInvoiceAsync(
                string invoiceId,
                Models.CancelInvoiceRequest body,
                CancellationToken cancellationToken = default);

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
        Models.PublishInvoiceResponse PublishInvoice(
                string invoiceId,
                Models.PublishInvoiceRequest body);

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
        Task<Models.PublishInvoiceResponse> PublishInvoiceAsync(
                string invoiceId,
                Models.PublishInvoiceRequest body,
                CancellationToken cancellationToken = default);
    }
}