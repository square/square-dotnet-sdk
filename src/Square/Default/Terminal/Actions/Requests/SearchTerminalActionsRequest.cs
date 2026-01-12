using System.Text.Json.Serialization;
using Square.Core;
using Square.Default;

namespace Square.Default.Terminal.Actions;

[Serializable]
public record SearchTerminalActionsRequest
{
    /// <summary>
    /// Queries terminal actions based on given conditions and sort order.
    /// Leaving this unset will return all actions with the default sort order.
    /// </summary>
    [JsonPropertyName("query")]
    public TerminalActionQuery? Query { get; set; }

    /// <summary>
    /// A pagination cursor returned by a previous call to this endpoint.
    /// Provide this to retrieve the next set of results for the original query.
    /// See [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination) for more
    /// information.
    /// </summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }

    /// <summary>
    /// Limit the number of results returned for a single request.
    /// </summary>
    [JsonPropertyName("limit")]
    public int? Limit { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
