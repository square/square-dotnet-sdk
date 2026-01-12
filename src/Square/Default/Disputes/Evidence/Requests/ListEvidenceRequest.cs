using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default.Disputes.Evidence;

[Serializable]
public record ListEvidenceRequest
{
    /// <summary>
    /// The ID of the dispute.
    /// </summary>
    [JsonIgnore]
    public required string DisputeId { get; set; }

    /// <summary>
    /// A pagination cursor returned by a previous call to this endpoint.
    /// Provide this cursor to retrieve the next set of results for the original query.
    /// For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
    /// </summary>
    [JsonIgnore]
    public string? Cursor { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
