using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents the tax ID associated with a [customer profile](entity:Customer). The corresponding `tax_ids` field is available only for customers of sellers in EU countries or the United Kingdom.
/// For more information, see [Customer tax IDs](https://developer.squareup.com/docs/customers-api/what-it-does#customer-tax-ids).
/// </summary>
public record CustomerTaxIds
{
    /// <summary>
    /// The EU VAT identification number for the customer. For example, `IE3426675K`. The ID can contain alphanumeric characters only.
    /// </summary>
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
