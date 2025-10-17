using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Inventory;

[Serializable]
public record DeprecatedGetAdjustmentInventoryRequest
{
    /// <summary>
    /// ID of the [InventoryAdjustment](entity:InventoryAdjustment) to retrieve.
    /// </summary>
    [JsonIgnore]
    public required string AdjustmentId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
