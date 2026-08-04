using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Inventory;

[Serializable]
public record ListInventoryAdjustmentReasonsRequest
{
    /// <summary>
    /// Indicates whether the response should include deleted custom inventory
    /// adjustment reasons. The default value is `false`.
    /// </summary>
    [JsonIgnore]
    public bool? IncludeDeleted { get; set; }

    /// <summary>
    /// Indicates whether the response should include Square-generated system
    /// inventory adjustment reason codes that cannot be used to write adjustments
    /// from the Connect API, such as `SALE`, `RECOUNT`, `TRANSFER`, `IN_TRANSIT`,
    /// and `CANCELED_SALE`. The default value is `false`.
    /// </summary>
    [JsonIgnore]
    public bool? IncludeSystemCodes { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
