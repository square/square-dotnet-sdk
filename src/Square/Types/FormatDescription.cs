using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Resolved format description with the predefined name and d3-format specifier
/// </summary>
[Serializable]
public record FormatDescription : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Predefined format name (e.g., 'percent_2', 'currency_1') or a base name like 'number', or 'custom' for ad-hoc specifiers
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// d3-format specifier string (e.g., '.2f', ',.0f', '$,.2f'). See https://d3js.org/d3-format
    /// </summary>
    [JsonPropertyName("specifier")]
    public required string Specifier { get; set; }

    /// <summary>
    /// ISO 4217 currency code in uppercase (e.g. USD, EUR). Present when a currency format is used.
    /// </summary>
    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

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
