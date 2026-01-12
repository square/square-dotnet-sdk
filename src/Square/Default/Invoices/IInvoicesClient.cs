using Square;
using Square.Core;
using Square.Default;

namespace Square.Default.Invoices;

public partial interface IInvoicesClient
{
    /// <summary>
    /// Returns a list of invoices for a given location. The response
    /// is paginated. If truncated, the response includes a `cursor` that you
    /// use in a subsequent request to retrieve the next set of invoices.
    /// </summary>
    Task<Pager<Invoice>> ListAsync(
        ListInvoicesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a draft [invoice](entity:Invoice)
    /// for an order created using the Orders API.
    ///
    /// A draft invoice remains in your account and no action is taken.
    /// You must publish the invoice before Square can process it (send it to the customer's email address or charge the customer’s card on file).
    /// </summary>
    Task<CreateInvoiceResponse> CreateAsync(
        CreateInvoiceRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Searches for invoices from a location specified in
    /// the filter. You can optionally specify customers in the filter for whom to
    /// retrieve invoices. In the current implementation, you can only specify one location and
    /// optionally one customer.
    ///
    /// The response is paginated. If truncated, the response includes a `cursor`
    /// that you use in a subsequent request to retrieve the next set of invoices.
    /// </summary>
    Task<SearchInvoicesResponse> SearchAsync(
        SearchInvoicesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves an invoice by invoice ID.
    /// </summary>
    Task<GetInvoiceResponse> GetAsync(
        GetInvoicesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates an invoice. This endpoint supports sparse updates, so you only need
    /// to specify the fields you want to change along with the required `version` field.
    /// Some restrictions apply to updating invoices. For example, you cannot change the
    /// `order_id` or `location_id` field.
    /// </summary>
    Task<UpdateInvoiceResponse> UpdateAsync(
        UpdateInvoiceRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes the specified invoice. When an invoice is deleted, the
    /// associated order status changes to CANCELED. You can only delete a draft
    /// invoice (you cannot delete a published invoice, including one that is scheduled for processing).
    /// </summary>
    Task<DeleteInvoiceResponse> DeleteAsync(
        DeleteInvoicesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Uploads a file and attaches it to an invoice. This endpoint accepts HTTP multipart/form-data file uploads
    /// with a JSON `request` part and a `file` part. The `file` part must be a `readable stream` that contains a file
    /// in a supported format: GIF, JPEG, PNG, TIFF, BMP, or PDF.
    ///
    /// Invoices can have up to 10 attachments with a total file size of 25 MB. Attachments can be added only to invoices
    /// in the `DRAFT`, `SCHEDULED`, `UNPAID`, or `PARTIALLY_PAID` state.
    ///
    /// __NOTE:__ When testing in the Sandbox environment, the total file size is limited to 1 KB.
    /// </summary>
    Task<CreateInvoiceAttachmentResponse> CreateInvoiceAttachmentAsync(
        CreateInvoiceAttachmentRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Removes an attachment from an invoice and permanently deletes the file. Attachments can be removed only
    /// from invoices in the `DRAFT`, `SCHEDULED`, `UNPAID`, or `PARTIALLY_PAID` state.
    /// </summary>
    Task<DeleteInvoiceAttachmentResponse> DeleteInvoiceAttachmentAsync(
        DeleteInvoiceAttachmentRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Cancels an invoice. The seller cannot collect payments for
    /// the canceled invoice.
    ///
    /// You cannot cancel an invoice in the `DRAFT` state or in a terminal state: `PAID`, `REFUNDED`, `CANCELED`, or `FAILED`.
    /// </summary>
    Task<CancelInvoiceResponse> CancelAsync(
        CancelInvoiceRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Publishes the specified draft invoice.
    ///
    /// After an invoice is published, Square
    /// follows up based on the invoice configuration. For example, Square
    /// sends the invoice to the customer's email address, charges the customer's card on file, or does
    /// nothing. Square also makes the invoice available on a Square-hosted invoice page.
    ///
    /// The invoice `status` also changes from `DRAFT` to a status
    /// based on the invoice configuration. For example, the status changes to `UNPAID` if
    /// Square emails the invoice or `PARTIALLY_PAID` if Square charges a card on file for a portion of the
    /// invoice amount.
    ///
    /// In addition to the required `ORDERS_WRITE` and `INVOICES_WRITE` permissions, `CUSTOMERS_READ`
    /// and `PAYMENTS_WRITE` are required when publishing invoices configured for card-on-file payments.
    /// </summary>
    Task<PublishInvoiceResponse> PublishAsync(
        PublishInvoiceRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
