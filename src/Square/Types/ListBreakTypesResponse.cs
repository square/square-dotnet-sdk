using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// The response to a request for a set of `BreakType` objects. The response contains
/// the requested `BreakType` objects and might contain a set of `Error` objects if
/// the request resulted in errors.
/// </summary>
public record ListBreakTypesResponse
{
    /// <summary>
    /// A page of `BreakType` results.
    /// </summary>
    [JsonPropertyName("break_types")]
    public IEnumerable<BreakType>? BreakTypes { get; set; }

    /// <summary>
    /// The value supplied in the subsequent request to fetch the next page
    /// of `BreakType` results.
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
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
