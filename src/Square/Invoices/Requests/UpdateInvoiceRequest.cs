using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Invoices;

[Serializable]
public record UpdateInvoiceRequest
{
    /// <summary>
    /// The ID of the invoice to update.
    /// </summary>
    [JsonIgnore]
    public required string InvoiceId { get; set; }

    /// <summary>
    /// The invoice fields to add, change, or clear. Fields can be cleared using
    /// null values or the `remove` field (for individual payment requests or reminders).
    /// The current invoice `version` is also required. For more information, including requirements,
    /// limitations, and more examples, see [Update an Invoice](https://developer.squareup.com/docs/invoices-api/update-invoices).
    /// </summary>
    [JsonPropertyName("invoice")]
    public required Invoice Invoice { get; set; }

    /// <summary>
    /// A unique string that identifies the `UpdateInvoice` request. If you do not
    /// provide `idempotency_key` (or provide an empty string as the value), the endpoint
    /// treats each request as independent.
    ///
    /// For more information, see [Idempotency](https://developer.squareup.com/docs/build-basics/common-api-patterns/idempotency).
    /// </summary>
    [JsonPropertyName("idempotency_key")]
    public string? IdempotencyKey { get; set; }

    /// <summary>
    /// The list of fields to clear. Although this field is currently supported, we
    /// recommend using null values or the `remove` field when possible. For examples, see
    /// [Update an Invoice](https://developer.squareup.com/docs/invoices-api/update-invoices).
    /// </summary>
    [JsonPropertyName("fields_to_clear")]
    public IEnumerable<string>? FieldsToClear { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
