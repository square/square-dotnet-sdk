using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Vendors;

public record SearchVendorsRequest
{
    /// <summary>
    /// Specifies a filter used to search for vendors.
    /// </summary>
    [JsonPropertyName("filter")]
    public SearchVendorsRequestFilter? Filter { get; set; }

    /// <summary>
    /// Specifies a sorter used to sort the returned vendors.
    /// </summary>
    [JsonPropertyName("sort")]
    public SearchVendorsRequestSort? Sort { get; set; }

    /// <summary>
    /// A pagination cursor returned by a previous call to this endpoint.
    /// Provide this to retrieve the next set of results for the original query.
    ///
    /// See the [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination) guide for more information.
    /// </summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
