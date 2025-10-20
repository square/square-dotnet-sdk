using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a line item in a transfer order. Each line item tracks a specific
/// [CatalogItemVariation](entity:CatalogItemVariation) being transferred, including ordered quantities
/// and receipt status.
/// </summary>
[Serializable]
public record TransferOrderLine : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Unique system-generated identifier for the line item. Provide when updating/removing a line via [UpdateTransferOrder](api-endpoint:TransferOrders-UpdateTransferOrder).
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("uid")]
    public string? Uid { get; set; }

    /// <summary>
    /// The required identifier of the [CatalogItemVariation](entity:CatalogItemVariation) being transferred. Must reference
    /// a valid catalog item variation that exists in the [Catalog](api:Catalog).
    /// </summary>
    [JsonPropertyName("item_variation_id")]
    public required string ItemVariationId { get; set; }

    /// <summary>
    /// Total quantity ordered, formatted as a decimal string (e.g. "10 or 10.0000"). Required to be a positive number.
    ///
    /// To remove a line item, set `remove` to `true` in [UpdateTransferOrder](api-endpoint:TransferOrders-UpdateTransferOrder).
    /// </summary>
    [JsonPropertyName("quantity_ordered")]
    public required string QuantityOrdered { get; set; }

    /// <summary>
    /// Calculated quantity of this line item's yet to be received stock. This is the difference between the total quantity ordered and the sum of quantities received, canceled, and damaged.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("quantity_pending")]
    public string? QuantityPending { get; set; }

    /// <summary>
    /// Quantity received at destination. These items are added to the destination
    /// [Location](entity:Location)'s inventory with [InventoryState](entity:InventoryState) of IN_STOCK.
    ///
    /// This field cannot be updated directly in Create/Update operations, instead use [ReceiveTransferOrder](api-endpoint:TransferOrders-ReceiveTransferOrder).
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("quantity_received")]
    public string? QuantityReceived { get; set; }

    /// <summary>
    /// Quantity received in damaged condition. These items are added to the destination
    /// [Location](entity:Location)'s inventory with [InventoryState](entity:InventoryState) of WASTE.
    ///
    /// This field cannot be updated directly in Create/Update operations, instead use [ReceiveTransferOrder](api-endpoint:TransferOrders-ReceiveTransferOrder).
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("quantity_damaged")]
    public string? QuantityDamaged { get; set; }

    /// <summary>
    /// Quantity that was canceled. These items will be immediately added to inventory in the source location.
    ///
    /// This field cannot be updated directly in Create/Update operations, instead use [ReceiveTransferOrder](api-endpoint:TransferOrders-ReceiveTransferOrder) or [CancelTransferOrder](api-endpoint:TransferOrders-CancelTransferOrder).
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("quantity_canceled")]
    public string? QuantityCanceled { get; set; }

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
