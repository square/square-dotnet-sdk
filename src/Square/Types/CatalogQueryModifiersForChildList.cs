using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Query to find `CatalogModifier` objects that reference a given `CatalogModifierList` in their `child_modifier_list_ids` field.
/// </summary>
[Serializable]
public record CatalogQueryModifiersForChildList : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The `CatalogModifierList` IDs to find parent `CatalogModifier`s for.
    /// Returns `CatalogModifier` objects where `child_modifier_list_ids` contains any of these IDs.
    /// </summary>
    [JsonPropertyName("child_modifier_list_ids")]
    public IEnumerable<string> ChildModifierListIds { get; set; } = new List<string>();

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
