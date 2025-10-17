using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Inventory;

[Serializable]
public record GetPhysicalCountInventoryRequest
{
    /// <summary>
    /// ID of the
    /// [InventoryPhysicalCount](entity:InventoryPhysicalCount) to retrieve.
    /// </summary>
    [JsonIgnore]
    public required string PhysicalCountId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
