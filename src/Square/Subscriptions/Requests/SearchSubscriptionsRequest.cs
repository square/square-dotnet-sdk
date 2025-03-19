using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Subscriptions;

public record SearchSubscriptionsRequest
{
    /// <summary>
    /// When the total number of resulting subscriptions exceeds the limit of a paged response,
    /// specify the cursor returned from a preceding response here to fetch the next set of results.
    /// If the cursor is unset, the response contains the last page of the results.
    ///
    /// For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
    /// </summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }

    /// <summary>
    /// The upper limit on the number of subscriptions to return
    /// in a paged response.
    /// </summary>
    [JsonPropertyName("limit")]
    public int? Limit { get; set; }

    /// <summary>
    /// A subscription query consisting of specified filtering conditions.
    ///
    /// If this `query` field is unspecified, the `SearchSubscriptions` call will return all subscriptions.
    /// </summary>
    [JsonPropertyName("query")]
    public SearchSubscriptionsQuery? Query { get; set; }

    /// <summary>
    /// An option to include related information in the response.
    ///
    /// The supported values are:
    ///
    /// - `actions`: to include scheduled actions on the targeted subscriptions.
    /// </summary>
    [JsonPropertyName("include")]
    public IEnumerable<string>? Include { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
