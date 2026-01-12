using System.Text.Json.Serialization;
using Square.Core;
using Square.Default;

namespace Square.Default.Labor;

[Serializable]
public record SearchScheduledShiftsRequest
{
    /// <summary>
    /// Query conditions used to filter and sort the results.
    /// </summary>
    [JsonPropertyName("query")]
    public ScheduledShiftQuery? Query { get; set; }

    /// <summary>
    /// The maximum number of results to return in a single response page. The default value is 50.
    /// </summary>
    [JsonPropertyName("limit")]
    public int? Limit { get; set; }

    /// <summary>
    /// The pagination cursor returned by the previous call to this endpoint. Provide
    /// this cursor to retrieve the next page of results for your original request. For more
    /// information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
    /// </summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
