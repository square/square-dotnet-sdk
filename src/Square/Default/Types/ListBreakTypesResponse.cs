using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// The response to a request for a set of `BreakType` objects. The response contains
/// the requested `BreakType` objects and might contain a set of `Error` objects if
/// the request resulted in errors.
/// </summary>
[Serializable]
public record ListBreakTypesResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
