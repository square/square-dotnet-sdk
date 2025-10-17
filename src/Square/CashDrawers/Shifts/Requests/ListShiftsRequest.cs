using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.CashDrawers.Shifts;

[Serializable]
public record ListShiftsRequest
{
    /// <summary>
    /// The ID of the location to query for a list of cash drawer shifts.
    /// </summary>
    [JsonIgnore]
    public required string LocationId { get; set; }

    /// <summary>
    /// The order in which cash drawer shifts are listed in the response,
    /// based on their opened_at field. Default value: ASC
    /// </summary>
    [JsonIgnore]
    public SortOrder? SortOrder { get; set; }

    /// <summary>
    /// The inclusive start time of the query on opened_at, in ISO 8601 format.
    /// </summary>
    [JsonIgnore]
    public string? BeginTime { get; set; }

    /// <summary>
    /// The exclusive end date of the query on opened_at, in ISO 8601 format.
    /// </summary>
    [JsonIgnore]
    public string? EndTime { get; set; }

    /// <summary>
    /// Number of cash drawer shift events in a page of results (200 by
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
