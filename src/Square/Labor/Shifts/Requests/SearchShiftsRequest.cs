using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Labor.Shifts;

public record SearchShiftsRequest
{
    /// <summary>
    /// Query filters.
    /// </summary>
    [JsonPropertyName("query")]
    public ShiftQuery? Query { get; set; }

    /// <summary>
    /// The number of resources in a page (200 by default).
    /// </summary>
    [JsonPropertyName("limit")]
    public int? Limit { get; set; }

    /// <summary>
    /// An opaque cursor for fetching the next page.
    /// </summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
