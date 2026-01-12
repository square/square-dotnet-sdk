using System.Text.Json.Serialization;
using Square.Core;
using Square.Default;

namespace Square.Default.Customers;

[Serializable]
public record SearchCustomersRequest
{
    /// <summary>
    /// Include the pagination cursor in subsequent calls to this endpoint to retrieve
    /// the next set of results associated with the original query.
    ///
    /// For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
    /// </summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }

    /// <summary>
    /// The maximum number of results to return in a single page. This limit is advisory. The response might contain more or fewer results.
    /// If the specified limit is invalid, Square returns a `400 VALUE_TOO_LOW` or `400 VALUE_TOO_HIGH` error. The default value is 100.
    ///
    /// For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
    /// </summary>
    [JsonPropertyName("limit")]
    public long? Limit { get; set; }

    /// <summary>
    /// The filtering and sorting criteria for the search request. If a query is not specified,
    /// Square returns all customer profiles ordered alphabetically by `given_name` and `family_name`.
    /// </summary>
    [JsonPropertyName("query")]
    public CustomerQuery? Query { get; set; }

    /// <summary>
    /// Indicates whether to return the total count of matching customers in the `count` field of the response.
    ///
    /// The default value is `false`.
    /// </summary>
    [JsonPropertyName("count")]
    public bool? Count { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
