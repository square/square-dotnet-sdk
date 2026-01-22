using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[Serializable]
public record SearchOrdersRequest
{
    /// <summary>
    /// The location IDs for the orders to query. All locations must belong to
    /// the same merchant.
    ///
    /// Max: 10 location IDs.
    /// </summary>
    [JsonPropertyName("location_ids")]
    public IEnumerable<string>? LocationIds { get; set; }

    /// <summary>
    /// A pagination cursor returned by a previous call to this endpoint.
    /// Provide this cursor to retrieve the next set of results for your original query.
    /// For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
    /// </summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }

    /// <summary>
    /// Query conditions used to filter or sort the results. Note that when
    /// retrieving additional pages using a cursor, you must use the original query.
    /// </summary>
    [JsonPropertyName("query")]
    public SearchOrdersQuery? Query { get; set; }

    /// <summary>
    /// The maximum number of results to be returned in a single page.
    ///
    /// Default: `500`
    /// Max: `1000`
    /// </summary>
    [JsonPropertyName("limit")]
    public int? Limit { get; set; }

    /// <summary>
    /// A Boolean that controls the format of the search results. If `true`,
    /// `SearchOrders` returns [OrderEntry](entity:OrderEntry) objects. If `false`, `SearchOrders`
    /// returns complete order objects.
    ///
    /// Default: `false`.
    /// </summary>
    [JsonPropertyName("return_entries")]
    public bool? ReturnEntries { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
