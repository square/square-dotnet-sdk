using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// The query filter to return the item variations containing the specified item option value IDs.
/// </summary>
[Serializable]
public record CatalogQueryItemVariationsForItemOptionValues : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// A set of `CatalogItemOptionValue` IDs to be used to find associated
    /// `CatalogItemVariation`s. All ItemVariations that contain all of the given
    /// Item Option Values (in any order) will be returned.
    /// </summary>
    [JsonPropertyName("item_option_value_ids")]
    public IEnumerable<string>? ItemOptionValueIds { get; set; }

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
