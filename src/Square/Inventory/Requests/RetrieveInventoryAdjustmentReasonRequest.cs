using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Inventory;

[Serializable]
public record RetrieveInventoryAdjustmentReasonRequest
{
    /// <summary>
    /// The identifier of the inventory adjustment reason to retrieve.
    /// </summary>
    [JsonPropertyName("reason_id")]
    public required InventoryAdjustmentReasonId ReasonId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
