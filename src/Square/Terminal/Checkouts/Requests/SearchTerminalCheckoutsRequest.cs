using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Terminal.Checkouts;

[Serializable]
public record SearchTerminalCheckoutsRequest
{
    /// <summary>
    /// Queries Terminal checkouts based on given conditions and the sort order.
    /// Leaving these unset returns all checkouts with the default sort order.
    /// </summary>
    [JsonPropertyName("query")]
    public TerminalCheckoutQuery? Query { get; set; }

    /// <summary>
    /// A pagination cursor returned by a previous call to this endpoint.
    /// Provide this cursor to retrieve the next set of results for the original query.
    /// See [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination) for more information.
    /// </summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }

    /// <summary>
    /// Limits the number of results returned for a single request.
    /// </summary>
    [JsonPropertyName("limit")]
    public int? Limit { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
