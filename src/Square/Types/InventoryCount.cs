using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents Square-estimated quantity of items in a particular state at a
/// particular seller location based on the known history of physical counts and
/// inventory adjustments.
/// </summary>
public record InventoryCount
{
    /// <summary>
    /// The Square-generated ID of the
    /// [CatalogObject](entity:CatalogObject) being tracked.
    /// </summary>
    [JsonPropertyName("catalog_object_id")]
    public string? CatalogObjectId { get; set; }

    /// <summary>
    /// The [type](entity:CatalogObjectType) of the [CatalogObject](entity:CatalogObject) being tracked.
    ///
    /// The Inventory API supports setting and reading the `"catalog_object_type": "ITEM_VARIATION"` field value.
    /// In addition, it can also read the `"catalog_object_type": "ITEM"` field value that is set by the Square Restaurants app.
    /// </summary>
    [JsonPropertyName("catalog_object_type")]
    public string? CatalogObjectType { get; set; }

    /// <summary>
    /// The current [inventory state](entity:InventoryState) for the related
    /// quantity of items.
    /// See [InventoryState](#type-inventorystate) for possible values
    /// </summary>
    [JsonPropertyName("state")]
    public InventoryState? State { get; set; }

    /// <summary>
    /// The Square-generated ID of the [Location](entity:Location) where the related
    /// quantity of items is being tracked.
    /// </summary>
    [JsonPropertyName("location_id")]
    public string? LocationId { get; set; }

    /// <summary>
    /// The number of items affected by the estimated count as a decimal string.
    /// Can support up to 5 digits after the decimal point.
    /// </summary>
    [JsonPropertyName("quantity")]
    public string? Quantity { get; set; }

    /// <summary>
    /// An RFC 3339-formatted timestamp that indicates when the most recent physical count or adjustment affecting
    /// the estimated count is received.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("calculated_at")]
    public string? CalculatedAt { get; set; }

    /// <summary>
    /// Whether the inventory count is for composed variation (TRUE) or not (FALSE). If true, the inventory count will not be present in the response of
    /// any of these endpoints: [BatchChangeInventory](api-endpoint:Inventory-BatchChangeInventory),
    /// [BatchRetrieveInventoryChanges](api-endpoint:Inventory-BatchRetrieveInventoryChanges),
    /// [BatchRetrieveInventoryCounts](api-endpoint:Inventory-BatchRetrieveInventoryCounts), and
    /// [RetrieveInventoryChanges](api-endpoint:Inventory-RetrieveInventoryChanges).
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("is_estimated")]
    public bool? IsEstimated { get; set; }

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
