using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Represents the tax ID associated with a [customer profile](entity:Customer). The corresponding `tax_ids` field is available only for customers of sellers in EU countries or the United Kingdom.
/// For more information, see [Customer tax IDs](https://developer.squareup.com/docs/customers-api/what-it-does#customer-tax-ids).
/// </summary>
[Serializable]
public record CustomerTaxIds : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The EU VAT identification number for the customer. For example, `IE3426675K`. The ID can contain alphanumeric characters only.
    /// </summary>
    [JsonPropertyName("eu_vat")]
    public string? EuVat { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
