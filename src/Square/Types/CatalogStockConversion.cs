using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents the rule of conversion between a stockable [CatalogItemVariation](entity:CatalogItemVariation)
/// and a non-stockable sell-by or receive-by `CatalogItemVariation` that
/// share the same underlying stock.
/// </summary>
public record CatalogStockConversion
{
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

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
