using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Disputes;

public record ListDisputesRequest
{
    /// <summary>
    /// A pagination cursor returned by a previous call to this endpoint.
    /// Provide this cursor to retrieve the next set of results for the original query.
    /// For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
    /// </summary>
    [JsonIgnore]
    public string? Cursor { get; set; }

    /// <summary>
    /// The dispute states used to filter the result. If not specified, the endpoint returns all disputes.
    /// </summary>
    [JsonIgnore]
    public DisputeState? States { get; set; }

    /// <summary>
    /// The ID of the location for which to return a list of disputes.
    /// If not specified, the endpoint returns disputes associated with all locations.
    /// </summary>
    [JsonIgnore]
    public string? LocationId { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
