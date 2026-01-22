using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Represents a single physical count, inventory, adjustment, or transfer
/// that is part of the history of inventory changes for a particular
/// [CatalogObject](entity:CatalogObject) instance.
/// </summary>
[Serializable]
public record InventoryChange : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Indicates how the inventory change is applied. See
    /// [InventoryChangeType](entity:InventoryChangeType) for all possible values.
    /// See [InventoryChangeType](#type-inventorychangetype) for possible values
    /// </summary>
    [JsonPropertyName("type")]
    public InventoryChangeType? Type { get; set; }

    /// <summary>
    /// Contains details about the physical count when `type` is
    /// `PHYSICAL_COUNT`, and is unset for all other change types.
    /// </summary>
    [JsonPropertyName("physical_count")]
    public InventoryPhysicalCount? PhysicalCount { get; set; }

    /// <summary>
    /// Contains details about the inventory adjustment when `type` is
    /// `ADJUSTMENT`, and is unset for all other change types.
    /// </summary>
    [JsonPropertyName("adjustment")]
    public InventoryAdjustment? Adjustment { get; set; }

    /// <summary>
    /// Contains details about the inventory transfer when `type` is
    /// `TRANSFER`, and is unset for all other change types.
    ///
    /// _Note:_ An [InventoryTransfer](entity:InventoryTransfer) object can only be set in the input to the
    /// [BatchChangeInventory](api-endpoint:Inventory-BatchChangeInventory) endpoint when the seller has an active Retail Plus subscription.
    /// </summary>
    [JsonPropertyName("transfer")]
    public InventoryTransfer? Transfer { get; set; }

    /// <summary>
    /// The [CatalogMeasurementUnit](entity:CatalogMeasurementUnit) object representing the catalog measurement unit associated with the inventory change.
    /// </summary>
    [JsonPropertyName("measurement_unit")]
    public CatalogMeasurementUnit? MeasurementUnit { get; set; }

    /// <summary>
    /// The ID of the [CatalogMeasurementUnit](entity:CatalogMeasurementUnit) object representing the catalog measurement unit associated with the inventory change.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("measurement_unit_id")]
    public string? MeasurementUnitId { get; set; }

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
