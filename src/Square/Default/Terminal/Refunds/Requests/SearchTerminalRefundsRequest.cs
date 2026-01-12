using System.Text.Json.Serialization;
using Square.Core;
using Square.Default;

namespace Square.Default.Terminal.Refunds;

[Serializable]
public record SearchTerminalRefundsRequest
{
    /// <summary>
    /// Queries the Terminal refunds based on given conditions and the sort order. Calling
    /// `SearchTerminalRefunds` without an explicit query parameter returns all available
    /// refunds with the default sort order.
    /// </summary>
    [JsonPropertyName("query")]
    public TerminalRefundQuery? Query { get; set; }

    /// <summary>
    /// A pagination cursor returned by a previous call to this endpoint.
    /// Provide this cursor to retrieve the next set of results for the original query.
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
