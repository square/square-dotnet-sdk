using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Contains the name and abbreviation for standard measurement unit.
/// </summary>
[Serializable]
public record StandardUnitDescription : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Identifies the measurement unit being described.
    /// </summary>
    [JsonPropertyName("unit")]
    public MeasurementUnit? Unit { get; set; }

    /// <summary>
    /// UI display name of the measurement unit. For example, 'Pound'.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// UI display abbreviation for the measurement unit. For example, 'lb'.
    /// </summary>
    [JsonPropertyName("abbreviation")]
    public string? Abbreviation { get; set; }

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
