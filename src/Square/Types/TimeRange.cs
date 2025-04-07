using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a generic time range. The start and end values are
/// represented in RFC 3339 format. Time ranges are customized to be
/// inclusive or exclusive based on the needs of a particular endpoint.
/// Refer to the relevant endpoint-specific documentation to determine
/// how time ranges are handled.
/// </summary>
public record TimeRange
{
    /// <summary>
    /// A datetime value in RFC 3339 format indicating when the time range
    /// starts.
    /// </summary>
    [JsonPropertyName("start_at")]
    public string? StartAt { get; set; }

    /// <summary>
    /// A datetime value in RFC 3339 format indicating when the time range
    /// ends.
    /// </summary>
    [JsonPropertyName("end_at")]
    public string? EndAt { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    /// <remarks>
    /// [EXPERIMENTAL] This API is experimental and may change in future releases.
    /// </remarks>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
