using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[Serializable]
public record ListEntriesPayoutsRequest
{
    /// <summary>
    /// The ID of the payout to retrieve the information for.
    /// </summary>
    [JsonIgnore]
    public required string PayoutId { get; set; }

    /// <summary>
    /// The order in which payout entries are listed.
    /// </summary>
    [JsonIgnore]
    public SortOrder? SortOrder { get; set; }

    /// <summary>
    /// A pagination cursor returned by a previous call to this endpoint.
    /// Provide this cursor to retrieve the next set of results for the original query.
    /// For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
    /// If request parameters change between requests, subsequent results may contain duplicates or missing records.
    /// </summary>
    [JsonIgnore]
    public string? Cursor { get; set; }

    /// <summary>
    /// The maximum number of results to be returned in a single page.
    /// It is possible to receive fewer results than the specified limit on a given page.
    /// The default value of 100 is also the maximum allowed value. If the provided value is
    /// greater than 100, it is ignored and the default value is used instead.
    /// Default: `100`
    /// </summary>
    [JsonIgnore]
    public int? Limit { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
