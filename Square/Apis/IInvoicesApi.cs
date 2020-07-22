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
    public interface IInvoicesApi
    {
        /// <summary>
        /// Returns a list of invoices for a given location. The response 
        /// is paginated. If truncated, the response includes a `cursor` that you    
        /// use in a subsequent request to fetch the next set of invoices.
        /// For more information about retrieving invoices, see [Retrieve invoices](https://developer.squareup.com/docs/docs/invoices-api/overview#retrieve-invoices).
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location for which to list invoices.</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint.  Provide this cursor to retrieve the next set of results for your original query.  For more information, see [Pagination](https://developer.squareup.com/docs/docs/working-with-apis/pagination).</param>
        /// <param name="limit">Optional parameter: The maximum number of invoices to return (200 is the maximum `limit`).  If not provided, the server  uses a default limit of 100 invoices.</param>
        /// <return>Returns the Models.ListInvoicesResponse response from the API call</return>
        Models.ListInvoicesResponse ListInvoices(string locationId, string cursor = null, int? limit = null);

        /// <summary>
        /// Returns a list of invoices for a given location. The response 
        /// is paginated. If truncated, the response includes a `cursor` that you    
        /// use in a subsequent request to fetch the next set of invoices.
        /// For more information about retrieving invoices, see [Retrieve invoices](https://developer.squareup.com/docs/docs/invoices-api/overview#retrieve-invoices).
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location for which to list invoices.</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint.  Provide this cursor to retrieve the next set of results for your original query.  For more information, see [Pagination](https://developer.squareup.com/docs/docs/working-with-apis/pagination).</param>
        /// <param name="limit">Optional parameter: The maximum number of invoices to return (200 is the maximum `limit`).  If not provided, the server  uses a default limit of 100 invoices.</param>
        /// <return>Returns the Models.ListInvoicesResponse response from the API call</return>
        Task<Models.ListInvoicesResponse> ListInvoicesAsync(string locationId, string cursor = null, int? limit = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a draft [invoice](#type-invoice) 
        /// for an order created using the Orders API.
        /// A draft invoice remains in your account and no action is taken. 
        /// You must publish the invoice before Square can process it (send it to the customer's email address or charge the customer’s card on file). 
        /// For more information, see [Manage Invoices Using the Invoices API](https://developer.squareup.com/docs/docs/invoices-api/overview).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreateInvoiceResponse response from the API call</return>
        Models.CreateInvoiceResponse CreateInvoice(Models.CreateInvoiceRequest body);

        /// <summary>
        /// Creates a draft [invoice](#type-invoice) 
        /// for an order created using the Orders API.
        /// A draft invoice remains in your account and no action is taken. 
        /// You must publish the invoice before Square can process it (send it to the customer's email address or charge the customer’s card on file). 
        /// For more information, see [Manage Invoices Using the Invoices API](https://developer.squareup.com/docs/docs/invoices-api/overview).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreateInvoiceResponse response from the API call</return>
        Task<Models.CreateInvoiceResponse> CreateInvoiceAsync(Models.CreateInvoiceRequest body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Searches for invoices from a location specified in 
        /// the filter. You can optionally specify customers in the filter for whom to 
        /// retrieve invoices. In the current implementation, you can only specify one location and 
        /// optionally one customer.
        /// The response is paginated. If truncated, the response includes a `cursor` 
        /// that you use in a subsequent request to fetch the next set of invoices. 
        /// For more information about retrieving invoices, see [Retrieve invoices](https://developer.squareup.com/docs/docs/invoices-api/overview#retrieve-invoices).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.SearchInvoicesResponse response from the API call</return>
        Models.SearchInvoicesResponse SearchInvoices(Models.SearchInvoicesRequest body);

        /// <summary>
        /// Searches for invoices from a location specified in 
        /// the filter. You can optionally specify customers in the filter for whom to 
        /// retrieve invoices. In the current implementation, you can only specify one location and 
        /// optionally one customer.
        /// The response is paginated. If truncated, the response includes a `cursor` 
        /// that you use in a subsequent request to fetch the next set of invoices. 
        /// For more information about retrieving invoices, see [Retrieve invoices](https://developer.squareup.com/docs/docs/invoices-api/overview#retrieve-invoices).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.SearchInvoicesResponse response from the API call</return>
        Task<Models.SearchInvoicesResponse> SearchInvoicesAsync(Models.SearchInvoicesRequest body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes the specified invoice. When an invoice is deleted, the 
        /// associated Order status changes to CANCELED. You can only delete a draft 
        /// invoice (you cannot delete an invoice scheduled for publication, or a 
        /// published invoice).
        /// </summary>
        /// <param name="invoiceId">Required parameter: The ID of the invoice to delete.</param>
        /// <param name="version">Optional parameter: The version of the [invoice](#type-invoice) to delete. If you do not know the version, you can call [GetInvoice](#endpoint-Invoices-GetInvoice) or  [ListInvoices](#endpoint-Invoices-ListInvoices).</param>
        /// <return>Returns the Models.DeleteInvoiceResponse response from the API call</return>
        Models.DeleteInvoiceResponse DeleteInvoice(string invoiceId, int? version = null);

        /// <summary>
        /// Deletes the specified invoice. When an invoice is deleted, the 
        /// associated Order status changes to CANCELED. You can only delete a draft 
        /// invoice (you cannot delete an invoice scheduled for publication, or a 
        /// published invoice).
        /// </summary>
        /// <param name="invoiceId">Required parameter: The ID of the invoice to delete.</param>
        /// <param name="version">Optional parameter: The version of the [invoice](#type-invoice) to delete. If you do not know the version, you can call [GetInvoice](#endpoint-Invoices-GetInvoice) or  [ListInvoices](#endpoint-Invoices-ListInvoices).</param>
        /// <return>Returns the Models.DeleteInvoiceResponse response from the API call</return>
        Task<Models.DeleteInvoiceResponse> DeleteInvoiceAsync(string invoiceId, int? version = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves an invoice by invoice ID.
        /// </summary>
        /// <param name="invoiceId">Required parameter: The id of the invoice to retrieve.</param>
        /// <return>Returns the Models.GetInvoiceResponse response from the API call</return>
        Models.GetInvoiceResponse GetInvoice(string invoiceId);

        /// <summary>
        /// Retrieves an invoice by invoice ID.
        /// </summary>
        /// <param name="invoiceId">Required parameter: The id of the invoice to retrieve.</param>
        /// <return>Returns the Models.GetInvoiceResponse response from the API call</return>
        Task<Models.GetInvoiceResponse> GetInvoiceAsync(string invoiceId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an invoice by modifying field values, clearing field values, or both 
        /// as specified in the request. 
        /// There are no restrictions to updating an invoice in a draft state. 
        /// However, there are guidelines for updating a published invoice. 
        /// For more information, see [Update an invoice](https://developer.squareup.com/docs/docs/invoices-api/overview#update-an-invoice).
        /// </summary>
        /// <param name="invoiceId">Required parameter: The id of the invoice to update.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.UpdateInvoiceResponse response from the API call</return>
        Models.UpdateInvoiceResponse UpdateInvoice(string invoiceId, Models.UpdateInvoiceRequest body);

        /// <summary>
        /// Updates an invoice by modifying field values, clearing field values, or both 
        /// as specified in the request. 
        /// There are no restrictions to updating an invoice in a draft state. 
        /// However, there are guidelines for updating a published invoice. 
        /// For more information, see [Update an invoice](https://developer.squareup.com/docs/docs/invoices-api/overview#update-an-invoice).
        /// </summary>
        /// <param name="invoiceId">Required parameter: The id of the invoice to update.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.UpdateInvoiceResponse response from the API call</return>
        Task<Models.UpdateInvoiceResponse> UpdateInvoiceAsync(string invoiceId, Models.UpdateInvoiceRequest body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Cancels an invoice. The seller cannot collect payments for 
        /// the canceled invoice.
        /// You cannot cancel an invoice in a terminal state: `PAID`, `REFUNDED`, `CANCELED`, or `FAILED`.
        /// </summary>
        /// <param name="invoiceId">Required parameter: The ID of the [invoice](#type-invoice) to cancel.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CancelInvoiceResponse response from the API call</return>
        Models.CancelInvoiceResponse CancelInvoice(string invoiceId, Models.CancelInvoiceRequest body);

        /// <summary>
        /// Cancels an invoice. The seller cannot collect payments for 
        /// the canceled invoice.
        /// You cannot cancel an invoice in a terminal state: `PAID`, `REFUNDED`, `CANCELED`, or `FAILED`.
        /// </summary>
        /// <param name="invoiceId">Required parameter: The ID of the [invoice](#type-invoice) to cancel.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CancelInvoiceResponse response from the API call</return>
        Task<Models.CancelInvoiceResponse> CancelInvoiceAsync(string invoiceId, Models.CancelInvoiceRequest body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Publishes the specified draft invoice. 
        /// After an invoice is published, Square 
        /// follows up based on the invoice configuration. For example, Square 
        /// sends the invoice to the customer's email address, charges the customer's card on file, or does 
        /// nothing. Square also makes the invoice available on a Square-hosted invoice page. 
        /// The invoice `status` also changes from `DRAFT` to a status 
        /// based on the invoice configuration. For example, the status changes to `UNPAID` if 
        /// Square emails the invoice or `PARTIALLY_PAID` if Square charge a card on file for a portion of the 
        /// invoice amount).
        /// For more information, see 
        /// [Create and publish an invoice](https://developer.squareup.com/docs/docs/invoices-api/overview#create-and-publish-an-invoice).
        /// </summary>
        /// <param name="invoiceId">Required parameter: The id of the invoice to publish.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.PublishInvoiceResponse response from the API call</return>
        Models.PublishInvoiceResponse PublishInvoice(string invoiceId, Models.PublishInvoiceRequest body);

        /// <summary>
        /// Publishes the specified draft invoice. 
        /// After an invoice is published, Square 
        /// follows up based on the invoice configuration. For example, Square 
        /// sends the invoice to the customer's email address, charges the customer's card on file, or does 
        /// nothing. Square also makes the invoice available on a Square-hosted invoice page. 
        /// The invoice `status` also changes from `DRAFT` to a status 
        /// based on the invoice configuration. For example, the status changes to `UNPAID` if 
        /// Square emails the invoice or `PARTIALLY_PAID` if Square charge a card on file for a portion of the 
        /// invoice amount).
        /// For more information, see 
        /// [Create and publish an invoice](https://developer.squareup.com/docs/docs/invoices-api/overview#create-and-publish-an-invoice).
        /// </summary>
        /// <param name="invoiceId">Required parameter: The id of the invoice to publish.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.PublishInvoiceResponse response from the API call</return>
        Task<Models.PublishInvoiceResponse> PublishInvoiceAsync(string invoiceId, Models.PublishInvoiceRequest body, CancellationToken cancellationToken = default);

    }
}