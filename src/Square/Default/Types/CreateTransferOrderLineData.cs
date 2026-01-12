using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Data for creating a new transfer order line item. Each line item specifies a
/// [CatalogItemVariation](entity:CatalogItemVariation) and quantity to transfer.
/// </summary>
[Serializable]
public record CreateTransferOrderLineData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// ID of the [CatalogItemVariation](entity:CatalogItemVariation) to transfer. Must reference a valid
    /// item variation in the [Catalog](api:Catalog). The item variation must be:
    /// - Active and available for sale
    /// - Enabled for inventory tracking
    /// - Available at the source location
    /// </summary>
    [JsonPropertyName("item_variation_id")]
    public required string ItemVariationId { get; set; }

    /// <summary>
    /// Total quantity ordered
    /// </summary>
    [JsonPropertyName("quantity_ordered")]
    public required string QuantityOrdered { get; set; }

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
