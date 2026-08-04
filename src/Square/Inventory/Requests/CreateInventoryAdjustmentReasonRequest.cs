using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Inventory;

[Serializable]
public record CreateInventoryAdjustmentReasonRequest
{
    /// <summary>
    /// A client-supplied, universally unique identifier to make this
    /// [CreateInventoryAdjustmentReason](api-endpoint:Inventory-CreateInventoryAdjustmentReason)
    /// request idempotent.
    /// </summary>
    [JsonPropertyName("idempotency_key")]
    public required string IdempotencyKey { get; set; }

    /// <summary>
    /// The custom inventory adjustment reason to create. Only custom
    /// adjustment reasons can be created.
    /// </summary>
    [JsonPropertyName("adjustment_reason")]
    public required InventoryAdjustmentReason AdjustmentReason { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
