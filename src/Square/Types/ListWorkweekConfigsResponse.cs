using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// The response to a request for a set of `WorkweekConfig` objects. The response contains
/// the requested `WorkweekConfig` objects and might contain a set of `Error` objects if
/// the request resulted in errors.
/// </summary>
public record ListWorkweekConfigsResponse
{
    /// <summary>
    /// A page of `WorkweekConfig` results.
    /// </summary>
    [JsonPropertyName("workweek_configs")]
    public IEnumerable<WorkweekConfig>? WorkweekConfigs { get; set; }

    /// <summary>
    /// The value supplied in the subsequent request to fetch the next page of
    /// `WorkweekConfig` results.
    /// </summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }

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
