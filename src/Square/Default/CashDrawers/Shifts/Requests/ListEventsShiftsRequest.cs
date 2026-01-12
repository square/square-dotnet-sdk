using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default.CashDrawers.Shifts;

[Serializable]
public record ListEventsShiftsRequest
{
    /// <summary>
    /// The shift ID.
    /// </summary>
    [JsonIgnore]
    public required string ShiftId { get; set; }

    /// <summary>
    /// The ID of the location to list cash drawer shifts for.
    /// </summary>
    [JsonIgnore]
    public required string LocationId { get; set; }

    /// <summary>
    /// Number of resources to be returned in a page of results (200 by
    /// default, 1000 max).
    /// </summary>
    [JsonIgnore]
    public int? Limit { get; set; }

    /// <summary>
    /// Opaque cursor for fetching the next page of results.
    /// </summary>
    [JsonIgnore]
    public string? Cursor { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
