using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Inventory;

public record GetPhysicalCountInventoryRequest
{
    /// <summary>
    /// ID of the
    /// [InventoryPhysicalCount](entity:InventoryPhysicalCount) to retrieve.
    /// </summary>
    [JsonIgnore]
    public required string PhysicalCountId { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
