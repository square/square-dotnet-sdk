using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// The response to a request to update a `WorkweekConfig` object. The response contains
/// the updated `WorkweekConfig` object and might contain a set of `Error` objects if
/// the request resulted in errors.
/// </summary>
public record UpdateWorkweekConfigResponse
{
    /// <summary>
    /// The response object.
    /// </summary>
    [JsonPropertyName("workweek_config")]
    public WorkweekConfig? WorkweekConfig { get; set; }

    /// <summary>
    /// Any errors that occurred during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

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
