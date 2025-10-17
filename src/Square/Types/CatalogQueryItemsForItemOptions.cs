using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// The query filter to return the items containing the specified item option IDs.
/// </summary>
[Serializable]
public record CatalogQueryItemsForItemOptions : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// A set of `CatalogItemOption` IDs to be used to find associated
    /// `CatalogItem`s. All Items that contain all of the given Item Options (in any order)
    /// will be returned.
    /// </summary>
    [JsonPropertyName("item_option_ids")]
    public IEnumerable<string>? ItemOptionIds { get; set; }

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
