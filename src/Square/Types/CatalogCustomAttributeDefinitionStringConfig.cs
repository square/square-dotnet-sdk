using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Configuration associated with Custom Attribute Definitions of type `STRING`.
/// </summary>
[Serializable]
public record CatalogCustomAttributeDefinitionStringConfig : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// If true, each Custom Attribute instance associated with this Custom Attribute
    /// Definition must have a unique value within the seller's catalog. For
    /// example, this may be used for a value like a SKU that should not be
    /// duplicated within a seller's catalog. May not be modified after the
    /// definition has been created.
    /// </summary>
    [JsonPropertyName("enforce_uniqueness")]
    public bool? EnforceUniqueness { get; set; }

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
