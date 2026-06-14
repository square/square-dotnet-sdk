using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Custom time format for time dimensions
/// </summary>
[Serializable]
public record CustomTimeFormat : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Type of the format (must be 'custom-time')
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; } = "custom-time";

    /// <summary>
    /// POSIX strftime format string (IEEE Std 1003.1 / POSIX.1) with d3-time-format extensions (e.g., '%Y-%m-%d', '%d/%m/%Y %H:%M:%S'). See https://pubs.opengroup.org/onlinepubs/009695399/functions/strptime.html and https://d3js.org/d3-time-format
    /// </summary>
    [JsonPropertyName("value")]
    public required string Value { get; set; }

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
