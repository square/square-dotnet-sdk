using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Represents the rule of conversion between a stockable [CatalogItemVariation](entity:CatalogItemVariation)
/// and a non-stockable sell-by or receive-by `CatalogItemVariation` that
/// share the same underlying stock.
/// </summary>
[Serializable]
public record CatalogStockConversion : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// References to the stockable [CatalogItemVariation](entity:CatalogItemVariation)
    /// for this stock conversion. Selling, receiving or recounting the non-stockable `CatalogItemVariation`
    /// defined with a stock conversion results in adjustments of this stockable `CatalogItemVariation`.
    /// This immutable field must reference a stockable `CatalogItemVariation`
    /// that shares the parent [CatalogItem](entity:CatalogItem) of the converted `CatalogItemVariation.`
    /// </summary>
    [JsonPropertyName("stockable_item_variation_id")]
    public required string StockableItemVariationId { get; set; }

    /// <summary>
    /// The quantity of the stockable item variation (as identified by `stockable_item_variation_id`)
    /// equivalent to the non-stockable item variation quantity (as specified in `nonstockable_quantity`)
    /// as defined by this stock conversion.  It accepts a decimal number in a string format that can take
    /// up to 10 digits before the decimal point and up to 5 digits after the decimal point.
    /// </summary>
    [JsonPropertyName("stockable_quantity")]
    public required string StockableQuantity { get; set; }

    /// <summary>
    /// The converted equivalent quantity of the non-stockable [CatalogItemVariation](entity:CatalogItemVariation)
    /// in its measurement unit. The `stockable_quantity` value and this `nonstockable_quantity` value together
    /// define the conversion ratio between stockable item variation and the non-stockable item variation.
    /// It accepts a decimal number in a string format that can take up to 10 digits before the decimal point
    /// and up to 5 digits after the decimal point.
    /// </summary>
    [JsonPropertyName("nonstockable_quantity")]
    public required string NonstockableQuantity { get; set; }

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
