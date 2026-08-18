using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Related resources of the response `CatalogObject`s requested using `IncludeOptions`
/// </summary>
[Serializable]
public record IncludedResources : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Nested `CatalogModifierList`s as requested via `INCLUDE_NESTED_MODIFIERS`.
    /// </summary>
    [JsonPropertyName("nested_modifiers")]
    public IEnumerable<CatalogObject>? NestedModifiers { get; set; }

    /// <summary>
    /// Ancestor `CatalogModifierList`s as requested via INCLUDE_ANCESTOR_MODIFIERS
    /// </summary>
    [JsonPropertyName("ancestor_modifiers")]
    public IEnumerable<CatalogObject>? AncestorModifiers { get; set; }

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
