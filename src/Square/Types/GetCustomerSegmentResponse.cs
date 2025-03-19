using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Defines the fields that are included in the response body for requests to the `RetrieveCustomerSegment` endpoint.
///
/// Either `errors` or `segment` is present in a given response (never both).
/// </summary>
public record GetCustomerSegmentResponse
{
    /// <summary>
    /// Any errors that occurred during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// The retrieved customer segment.
    /// </summary>
    [JsonPropertyName("segment")]
    public CustomerSegment? Segment { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
