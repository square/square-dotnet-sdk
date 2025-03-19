using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// The response to the request to create a `BreakType`. The response contains
/// the created `BreakType` object and might contain a set of `Error` objects if
/// the request resulted in errors.
/// </summary>
public record CreateBreakTypeResponse
{
    /// <summary>
    /// The `BreakType` that was created by the request.
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

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
