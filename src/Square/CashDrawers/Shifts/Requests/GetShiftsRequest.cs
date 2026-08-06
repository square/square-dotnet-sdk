using System.Text.Json.Serialization;
using Square.Core;

namespace Square.CashDrawers.Shifts;

[Serializable]
public record GetShiftsRequest
{
    /// <summary>
    /// The shift ID.
    /// </summary>
    [JsonIgnore]
    public required string ShiftId { get; set; }

    /// <summary>
    /// The ID of the location to retrieve cash drawer shifts from.
    /// </summary>
    [JsonIgnore]
    public required string LocationId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
