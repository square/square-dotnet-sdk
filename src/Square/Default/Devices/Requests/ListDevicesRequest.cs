using System.Text.Json.Serialization;
using Square.Core;
using Square.Default;

namespace Square.Default.Devices;

[Serializable]
public record ListDevicesRequest
{
    /// <summary>
    /// A pagination cursor returned by a previous call to this endpoint.
    /// Provide this cursor to retrieve the next set of results for the original query.
    /// See [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination) for more information.
    /// </summary>
    [JsonIgnore]
    public string? Cursor { get; set; }

    /// <summary>
    /// The order in which results are listed.
    /// - `ASC` - Oldest to newest.
    /// - `DESC` - Newest to oldest (default).
    /// </summary>
    [JsonIgnore]
    public SortOrder? SortOrder { get; set; }

    /// <summary>
    /// The number of results to return in a single page.
    /// </summary>
    [JsonIgnore]
    public int? Limit { get; set; }

    /// <summary>
    /// If present, only returns devices at the target location.
    /// </summary>
    [JsonIgnore]
    public string? LocationId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
