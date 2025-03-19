using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// The response to a request to get a `BreakType`. The response contains
/// the requested `BreakType` objects and might contain a set of `Error` objects if
/// the request resulted in errors.
/// </summary>
public record GetBreakTypeResponse
{
    /// <summary>
    /// The response object.
    /// </summary>
    [JsonPropertyName("break_type")]
    public BreakType? BreakType { get; set; }

    /// <summary>
    /// Any errors that occurred during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
