using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Group of standard measurement units.
/// </summary>
public record StandardUnitDescriptionGroup
{
    /// <summary>
    /// List of standard (non-custom) measurement units in this description group.
    /// </summary>
    [JsonPropertyName("standard_unit_descriptions")]
    public IEnumerable<StandardUnitDescription>? StandardUnitDescriptions { get; set; }

    /// <summary>
    /// IETF language tag.
    /// </summary>
    [JsonPropertyName("language_code")]
    public string? LanguageCode { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
