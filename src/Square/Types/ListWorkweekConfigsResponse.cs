using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// The response to a request for a set of `WorkweekConfig` objects. The response contains
/// the requested `WorkweekConfig` objects and might contain a set of `Error` objects if
/// the request resulted in errors.
/// </summary>
[Serializable]
public record ListWorkweekConfigsResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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
