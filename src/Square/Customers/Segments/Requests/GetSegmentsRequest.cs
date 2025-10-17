using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Customers.Segments;

[Serializable]
public record GetSegmentsRequest
{
    /// <summary>
    /// The Square-issued ID of the customer segment.
    /// </summary>
    [JsonIgnore]
    public required string SegmentId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
