using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Inventory;

[Serializable]
public record RestoreInventoryAdjustmentReasonRequest
{
    /// <summary>
    /// The identifier of the soft-deleted custom inventory adjustment reason
    /// to restore.
    /// </summary>
    [JsonPropertyName("reason_id")]
    public required InventoryAdjustmentReasonId ReasonId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
