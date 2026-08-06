using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Inventory;

[Serializable]
public record UpdateInventoryAdjustmentReasonRequest
{
    /// <summary>
    /// The identifier of the custom inventory adjustment reason to update.
    /// </summary>
    [JsonPropertyName("reason_id")]
    public required InventoryAdjustmentReasonId ReasonId { get; set; }

    /// <summary>
    /// The requested custom inventory adjustment reason update. Only the
    /// `name` field can be updated. Deleted custom reasons cannot be updated. To
    /// restore a deleted custom reason, call
    /// [RestoreInventoryAdjustmentReason](api-endpoint:Inventory-RestoreInventoryAdjustmentReason).
    /// </summary>
    [JsonPropertyName("adjustment_reason")]
    public required InventoryAdjustmentReason AdjustmentReason { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
