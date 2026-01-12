using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Represents a generic time range. The start and end values are
/// represented in RFC 3339 format. Time ranges are customized to be
/// inclusive or exclusive based on the needs of a particular endpoint.
/// Refer to the relevant endpoint-specific documentation to determine
/// how time ranges are handled.
/// </summary>
[Serializable]
public record TimeRange : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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
