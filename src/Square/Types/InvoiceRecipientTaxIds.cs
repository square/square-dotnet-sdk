using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents the tax IDs for an invoice recipient. The country of the seller account determines
/// whether the corresponding `tax_ids` field is available for the customer. For more information,
/// see [Invoice recipient tax IDs](https://developer.squareup.com/docs/invoices-api/overview#recipient-tax-ids).
/// </summary>
public record InvoiceRecipientTaxIds
{
    /// <summary>
    /// The EU VAT identification number for the invoice recipient. For example, `IE3426675K`.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("eu_vat")]
    public string? EuVat { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
