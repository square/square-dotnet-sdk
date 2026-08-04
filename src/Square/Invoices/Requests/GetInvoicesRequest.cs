using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Invoices;

[Serializable]
public record GetInvoicesRequest
{
    /// <summary>
    /// The ID of the invoice to retrieve.
    /// </summary>
    [JsonIgnore]
    public required string InvoiceId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
