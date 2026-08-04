using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Invoices;

[Serializable]
public record CancelInvoiceRequest
{
    /// <summary>
    /// The ID of the [invoice](entity:Invoice) to cancel.
    /// </summary>
    [JsonIgnore]
    public required string InvoiceId { get; set; }

    /// <summary>
    /// The version of the [invoice](entity:Invoice) to cancel.
    /// If you do not know the version, you can call
    /// [GetInvoice](api-endpoint:Invoices-GetInvoice) or [ListInvoices](api-endpoint:Invoices-ListInvoices).
    /// </summary>
    [JsonPropertyName("version")]
    public required int Version { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
