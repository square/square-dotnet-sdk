using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Custom numeric format for numeric measures and dimensions
/// </summary>
[Serializable]
public record CustomNumericFormat : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Type of the format (must be 'custom-numeric')
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; } = "custom-numeric";

    /// <summary>
    /// d3-format specifier string (e.g., '.2f', ',.0f', '$,.2f', '.0%', '.2s'). See https://d3js.org/d3-format
    /// </summary>
    [JsonPropertyName("value")]
    public required string Value { get; set; }

    /// <summary>
    /// Name of the predefined format (e.g., 'percent_2', 'currency_1'). Present only when a named format was used.
    /// </summary>
    [JsonPropertyName("alias")]
    public string? Alias { get; set; }

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
