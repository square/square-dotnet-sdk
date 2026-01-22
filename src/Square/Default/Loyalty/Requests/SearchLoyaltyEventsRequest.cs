using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[Serializable]
public record SearchLoyaltyEventsRequest
{
    /// <summary>
    /// A set of one or more predefined query filters to apply when
    /// searching for loyalty events. The endpoint performs a logical AND to
    /// evaluate multiple filters and performs a logical OR on arrays
    /// that specifies multiple field values.
    /// </summary>
    [JsonPropertyName("query")]
    public LoyaltyEventQuery? Query { get; set; }

    /// <summary>
    /// The maximum number of results to include in the response.
    /// The last page might contain fewer events.
    /// The default is 30 events.
    /// </summary>
    [JsonPropertyName("limit")]
    public int? Limit { get; set; }

    /// <summary>
    /// A pagination cursor returned by a previous call to this endpoint.
    /// Provide this to retrieve the next set of results for your original query.
    /// For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
    /// </summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
