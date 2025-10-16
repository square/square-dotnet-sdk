using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Data for creating a new transfer order line item. Each line item specifies a
/// [CatalogItemVariation](entity:CatalogItemVariation) and quantity to transfer.
/// </summary>
public record CreateTransferOrderLineData
{
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

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    /// <remarks>
    /// [EXPERIMENTAL] This API is experimental and may change in future releases.
    /// </remarks>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
