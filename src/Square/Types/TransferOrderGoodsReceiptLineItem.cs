using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// A simplified line item for goods receipts in transfer orders
/// </summary>
[Serializable]
public record TransferOrderGoodsReceiptLineItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The unique identifier of the Transfer Order line being received
    /// </summary>
    [JsonPropertyName("transfer_order_line_uid")]
    public required string TransferOrderLineUid { get; set; }

    /// <summary>
    /// The quantity received for this line item as a decimal string (e.g. "10.5").
    /// These items will be added to the destination [Location](entity:Location)'s inventory with [InventoryState](entity:InventoryState) of IN_STOCK.
    /// </summary>
    [JsonPropertyName("quantity_received")]
    public string? QuantityReceived { get; set; }

    /// <summary>
    /// The quantity that was damaged during shipping/handling as a decimal string (e.g. "1.5").
    /// These items will be added to the destination [Location](entity:Location)'s inventory with [InventoryState](entity:InventoryState) of WASTE.
    /// </summary>
    [JsonPropertyName("quantity_damaged")]
    public string? QuantityDamaged { get; set; }

    /// <summary>
    /// The quantity that was canceled during shipping/handling as a decimal string (e.g. "1.5"). These will be immediately added to inventory in the source location.
    /// </summary>
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
