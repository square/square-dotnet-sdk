using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[Serializable]
public record GetAdjustmentInventoryRequest
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
