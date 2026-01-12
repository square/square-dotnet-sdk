using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// A `CatalogItemOptionValue` links an item variation to an item option as
/// an item option value. For example, a t-shirt item may offer a color option and
/// a size option. An item option value would represent each variation of t-shirt:
/// For example, "Color:Red, Size:Small" or "Color:Blue, Size:Medium".
/// </summary>
[Serializable]
public record CatalogItemOptionValueForItemVariation : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The unique id of an item option.
    /// </summary>
    [JsonPropertyName("item_option_id")]
    public string? ItemOptionId { get; set; }

    /// <summary>
    /// The unique id of the selected value for the item option.
    /// </summary>
    [JsonPropertyName("item_option_value_id")]
    public string? ItemOptionValueId { get; set; }

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
