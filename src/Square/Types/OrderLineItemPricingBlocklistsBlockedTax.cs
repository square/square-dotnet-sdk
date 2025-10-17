using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// A tax to block from applying to a line item. The tax must be
/// identified by either `tax_uid` or `tax_catalog_object_id`, but not both.
/// </summary>
[Serializable]
public record OrderLineItemPricingBlocklistsBlockedTax : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// A unique ID of the `BlockedTax` within the order.
    /// </summary>
    [JsonPropertyName("uid")]
    public string? Uid { get; set; }

    /// <summary>
    /// The `uid` of the tax that should be blocked. Use this field to block
    /// ad hoc taxes. For catalog, taxes use the `tax_catalog_object_id` field.
    /// </summary>
    [JsonPropertyName("tax_uid")]
    public string? TaxUid { get; set; }

    /// <summary>
    /// The `catalog_object_id` of the tax that should be blocked.
    /// Use this field to block catalog taxes. For ad hoc taxes, use the
    /// `tax_uid` field.
    /// </summary>
    [JsonPropertyName("tax_catalog_object_id")]
    public string? TaxCatalogObjectId { get; set; }

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
