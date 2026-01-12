using System.Text.Json.Serialization;
using Square.Core;
using Square.Default;

namespace Square.Default.Events;

[Serializable]
public record SearchEventsRequest
{
    /// <summary>
    /// A pagination cursor returned by a previous call to this endpoint. Provide this cursor to retrieve the next set of events for your original query.
    ///
    /// For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
    /// </summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }

    /// <summary>
    /// The maximum number of events to return in a single page. The response might contain fewer events. The default value is 100, which is also the maximum allowed value.
    ///
    /// For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
    ///
    /// Default: 100
    /// </summary>
    [JsonPropertyName("limit")]
    public int? Limit { get; set; }

    /// <summary>
    /// The filtering and sorting criteria for the search request. To retrieve additional pages using a cursor, you must use the original query.
    /// </summary>
    [JsonPropertyName("query")]
    public SearchEventsQuery? Query { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
