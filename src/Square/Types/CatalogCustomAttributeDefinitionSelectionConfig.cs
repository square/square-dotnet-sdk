using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Configuration associated with `SELECTION`-type custom attribute definitions.
/// </summary>
[Serializable]
public record CatalogCustomAttributeDefinitionSelectionConfig : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The maximum number of selections that can be set. The maximum value for this
    /// attribute is 100. The default value is 1. The value can be modified, but changing the value will not
    /// affect existing custom attribute values on objects. Clients need to
    /// handle custom attributes with more selected values than allowed by this limit.
    /// </summary>
    [JsonPropertyName("max_allowed_selections")]
    public int? MaxAllowedSelections { get; set; }

    /// <summary>
    /// The set of valid `CatalogCustomAttributeSelections`. Up to a maximum of 100
    /// selections can be defined. Can be modified.
    /// </summary>
    [JsonPropertyName("allowed_selections")]
    public IEnumerable<CatalogCustomAttributeDefinitionSelectionConfigCustomAttributeSelection>? AllowedSelections { get; set; }

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
