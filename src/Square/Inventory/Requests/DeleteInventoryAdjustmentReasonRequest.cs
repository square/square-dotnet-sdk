using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[Serializable]
public record DeleteInventoryAdjustmentReasonRequest
{
    /// <summary>
    /// The identifier of the custom inventory adjustment reason to soft delete.
    /// </summary>
    [JsonPropertyName("reason_id")]
    public required InventoryAdjustmentReasonId ReasonId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
