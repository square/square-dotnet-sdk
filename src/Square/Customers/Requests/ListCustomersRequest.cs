using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Customers;

public record ListCustomersRequest
{
    /// <summary>
    /// A pagination cursor returned by a previous call to this endpoint.
    /// Provide this cursor to retrieve the next set of results for your original query.
    ///
    /// For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
    /// </summary>
    [JsonIgnore]
    public string? Cursor { get; set; }

    /// <summary>
    /// The maximum number of results to return in a single page. This limit is advisory. The response might contain more or fewer results.
    /// If the specified limit is less than 1 or greater than 100, Square returns a `400 VALUE_TOO_LOW` or `400 VALUE_TOO_HIGH` error. The default value is 100.
    ///
    /// For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
    /// </summary>
    [JsonIgnore]
    public int? Limit { get; set; }

    /// <summary>
    /// Indicates how customers should be sorted.
    ///
    /// The default value is `DEFAULT`.
    /// </summary>
    [JsonIgnore]
    public CustomerSortField? SortField { get; set; }

    /// <summary>
    /// Indicates whether customers should be sorted in ascending (`ASC`) or
    /// descending (`DESC`) order.
    ///
    /// The default value is `ASC`.
    /// </summary>
    [JsonIgnore]
    public SortOrder? SortOrder { get; set; }

    /// <summary>
    /// Indicates whether to return the total count of customers in the `count` field of the response.
    ///
    /// The default value is `false`.
    /// </summary>
    [JsonIgnore]
    public bool? Count { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
