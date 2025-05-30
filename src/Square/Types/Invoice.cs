using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Stores information about an invoice. You use the Invoices API to create and manage
/// invoices. For more information, see [Invoices API Overview](https://developer.squareup.com/docs/invoices-api/overview).
/// </summary>
public record Invoice
{
    /// <summary>
    /// The Square-assigned ID of the invoice.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The Square-assigned version number, which is incremented each time an update is committed to the invoice.
    /// </summary>
    [JsonPropertyName("version")]
    public int? Version { get; set; }

    /// <summary>
    /// The ID of the location that this invoice is associated with.
    ///
    /// If specified in a `CreateInvoice` request, the value must match the `location_id` of the associated order.
    /// </summary>
    [JsonPropertyName("location_id")]
    public string? LocationId { get; set; }

    /// <summary>
    /// The ID of the [order](entity:Order) for which the invoice is created.
    /// This field is required when creating an invoice, and the order must be in the `OPEN` state.
    ///
    /// To view the line items and other information for the associated order, call the
    /// [RetrieveOrder](api-endpoint:Orders-RetrieveOrder) endpoint using the order ID.
    /// </summary>
    [JsonPropertyName("order_id")]
    public string? OrderId { get; set; }

    /// <summary>
    /// The customer who receives the invoice. This customer data is displayed on the invoice and used by Square to deliver the invoice.
    ///
    /// This field is required to publish an invoice, and it must specify the `customer_id`.
    /// </summary>
    [JsonPropertyName("primary_recipient")]
    public InvoiceRecipient? PrimaryRecipient { get; set; }

    /// <summary>
    /// The payment schedule for the invoice, represented by one or more payment requests that
    /// define payment settings, such as amount due and due date. An invoice supports the following payment request combinations:
    /// - One balance
    /// - One deposit with one balance
    /// - 2–12 installments
    /// - One deposit with 2–12 installments
    ///
    /// This field is required when creating an invoice. It must contain at least one payment request.
    /// All payment requests for the invoice must equal the total order amount. For more information, see
    /// [Configuring payment requests](https://developer.squareup.com/docs/invoices-api/create-publish-invoices#payment-requests).
    ///
    /// Adding `INSTALLMENT` payment requests to an invoice requires an
    /// [Invoices Plus subscription](https://developer.squareup.com/docs/invoices-api/overview#invoices-plus-subscription).
    /// </summary>
    [JsonPropertyName("payment_requests")]
    public IEnumerable<InvoicePaymentRequest>? PaymentRequests { get; set; }

    /// <summary>
    /// The delivery method that Square uses to send the invoice, reminders, and receipts to
    /// the customer. After the invoice is published, Square processes the invoice based on the delivery
    /// method and payment request settings, either immediately or on the `scheduled_at` date, if specified.
    /// For example, Square might send the invoice or receipt for an automatic payment. For invoices with
    /// automatic payments, this field must be set to `EMAIL`.
    ///
    /// One of the following is required when creating an invoice:
    /// - (Recommended) This `delivery_method` field. To configure an automatic payment, the
    /// `automatic_payment_source` field of the payment request is also required.
    /// - The deprecated `request_method` field of the payment request. Note that `invoice`
    /// objects returned in responses do not include `request_method`.
    /// See [InvoiceDeliveryMethod](#type-invoicedeliverymethod) for possible values
    /// </summary>
    [JsonPropertyName("delivery_method")]
    public InvoiceDeliveryMethod? DeliveryMethod { get; set; }

    /// <summary>
    /// A user-friendly invoice number that is displayed on the invoice. The value is unique within a location.
    /// If not provided when creating an invoice, Square assigns a value.
    /// It increments from 1 and is padded with zeros making it 7 characters long
    /// (for example, 0000001 and 0000002).
    /// </summary>
    [JsonPropertyName("invoice_number")]
    public string? InvoiceNumber { get; set; }

    /// <summary>
    /// The title of the invoice, which is displayed on the invoice.
    /// </summary>
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    /// <summary>
    /// The description of the invoice, which is displayed on the invoice.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The timestamp when the invoice is scheduled for processing, in RFC 3339 format.
    /// After the invoice is published, Square processes the invoice on the specified date,
    /// according to the delivery method and payment request settings.
    ///
    /// If the field is not set, Square processes the invoice immediately after it is published.
    /// </summary>
    [JsonPropertyName("scheduled_at")]
    public string? ScheduledAt { get; set; }

    /// <summary>
    /// A temporary link to the Square-hosted payment page where the customer can pay the
    /// invoice. If the link expires, customers can provide the email address or phone number
    /// associated with the invoice and request a new link directly from the expired payment page.
    ///
    /// This field is added after the invoice is published and reaches the scheduled date
    /// (if one is defined).
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("public_url")]
    public string? PublicUrl { get; set; }

    /// <summary>
    /// The current amount due for the invoice. In addition to the
    /// amount due on the next payment request, this includes any overdue payment amounts.
    /// </summary>
    [JsonPropertyName("next_payment_amount_money")]
    public Money? NextPaymentAmountMoney { get; set; }

    /// <summary>
    /// The status of the invoice.
    /// See [InvoiceStatus](#type-invoicestatus) for possible values
    /// </summary>
    [JsonPropertyName("status")]
    public InvoiceStatus? Status { get; set; }

    /// <summary>
    /// The time zone used to interpret calendar dates on the invoice, such as `due_date`.
    /// When an invoice is created, this field is set to the `timezone` specified for the seller
    /// location. The value cannot be changed.
    ///
    /// For example, a payment `due_date` of 2021-03-09 with a `timezone` of America/Los\_Angeles
    /// becomes overdue at midnight on March 9 in America/Los\_Angeles (which equals a UTC timestamp
    /// of 2021-03-10T08:00:00Z).
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("timezone")]
    public string? Timezone { get; set; }

    /// <summary>
    /// The timestamp when the invoice was created, in RFC 3339 format.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    /// <summary>
    /// The timestamp when the invoice was last updated, in RFC 3339 format.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; set; }

    /// <summary>
    /// The payment methods that customers can use to pay the invoice on the Square-hosted
    /// invoice page. This setting is independent of any automatic payment requests for the invoice.
    ///
    /// This field is required when creating an invoice and must set at least one payment method to `true`.
    /// </summary>
    [JsonPropertyName("accepted_payment_methods")]
    public InvoiceAcceptedPaymentMethods? AcceptedPaymentMethods { get; set; }

    /// <summary>
    /// Additional seller-defined fields that are displayed on the invoice. For more information, see
    /// [Custom fields](https://developer.squareup.com/docs/invoices-api/overview#custom-fields).
    ///
    /// Adding custom fields to an invoice requires an
    /// [Invoices Plus subscription](https://developer.squareup.com/docs/invoices-api/overview#invoices-plus-subscription).
    ///
    /// Max: 2 custom fields
    /// </summary>
    [JsonPropertyName("custom_fields")]
    public IEnumerable<InvoiceCustomField>? CustomFields { get; set; }

    /// <summary>
    /// The ID of the [subscription](entity:Subscription) associated with the invoice.
    /// This field is present only on subscription billing invoices.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("subscription_id")]
    public string? SubscriptionId { get; set; }

    /// <summary>
    /// The date of the sale or the date that the service is rendered, in `YYYY-MM-DD` format.
    /// This field can be used to specify a past or future date which is displayed on the invoice.
    /// </summary>
    [JsonPropertyName("sale_or_service_date")]
    public string? SaleOrServiceDate { get; set; }

    /// <summary>
    /// **France only.** The payment terms and conditions that are displayed on the invoice. For more information,
    /// see [Payment conditions](https://developer.squareup.com/docs/invoices-api/overview#payment-conditions).
    ///
    /// For countries other than France, Square returns an `INVALID_REQUEST_ERROR` with a `BAD_REQUEST` code and
    /// "Payment conditions are not supported for this location's country" detail if this field is included in `CreateInvoice` or `UpdateInvoice` requests.
    /// </summary>
    [JsonPropertyName("payment_conditions")]
    public string? PaymentConditions { get; set; }

    /// <summary>
    /// Indicates whether to allow a customer to save a credit or debit card as a card on file or a bank transfer as a
    /// bank account on file. If `true`, Square displays a __Save my card on file__ or __Save my bank on file__ checkbox on the
    /// invoice payment page. Stored payment information can be used for future automatic payments. The default value is `false`.
    /// </summary>
    [JsonPropertyName("store_payment_method_enabled")]
    public bool? StorePaymentMethodEnabled { get; set; }

    /// <summary>
    /// Metadata about the attachments on the invoice. Invoice attachments are managed using the
    /// [CreateInvoiceAttachment](api-endpoint:Invoices-CreateInvoiceAttachment) and [DeleteInvoiceAttachment](api-endpoint:Invoices-DeleteInvoiceAttachment) endpoints.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("attachments")]
    public IEnumerable<InvoiceAttachment>? Attachments { get; set; }

    /// <summary>
    /// The ID of the [team member](entity:TeamMember) who created the invoice.
    /// This field is present only on invoices created in the Square Dashboard or Square Invoices app by a logged-in team member.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("creator_team_member_id")]
    public string? CreatorTeamMemberId { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    /// <remarks>
    /// [EXPERIMENTAL] This API is experimental and may change in future releases.
    /// </remarks>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
