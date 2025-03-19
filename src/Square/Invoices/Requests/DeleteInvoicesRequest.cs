using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Invoices;

public record DeleteInvoicesRequest
{
    /// <summary>
    /// The ID of the invoice to delete.
    /// </summary>
    [JsonIgnore]
    public required string InvoiceId { get; set; }

    /// <summary>
    /// The version of the [invoice](entity:Invoice) to delete.
    /// If you do not know the version, you can call [GetInvoice](api-endpoint:Invoices-GetInvoice) or
    /// [ListInvoices](api-endpoint:Invoices-ListInvoices).
    /// </summary>
    [JsonIgnore]
    public int? Version { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
