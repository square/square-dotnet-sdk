using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Customers.Segments;

public record GetSegmentsRequest
{
    /// <summary>
    /// The Square-issued ID of the customer segment.
    /// </summary>
    [JsonIgnore]
    public required string SegmentId { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
