using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Contains the name and abbreviation for standard measurement unit.
/// </summary>
public record StandardUnitDescription
{
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
