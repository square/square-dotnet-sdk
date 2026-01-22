using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[Serializable]
public record DeprecatedGetPhysicalCountInventoryRequest
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
