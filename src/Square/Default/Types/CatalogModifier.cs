using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// A modifier that can be applied to items at the time of sale. For example, a cheese modifier for a burger, or a flavor modifier for a serving of ice cream.
/// </summary>
[Serializable]
public record CatalogModifier : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The modifier name.  This is a searchable attribute for use in applicable query filters, and its value length is of Unicode code points.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The modifier price.
    /// </summary>
    [JsonPropertyName("price_money")]
    public Money? PriceMoney { get; set; }

    /// <summary>
    /// When `true`, this modifier is selected by default when displaying the modifier list.
    /// This setting can be overridden at the item level using `CatalogModifierListInfo.modifier_overrides`.
    /// </summary>
    [JsonPropertyName("on_by_default")]
    public bool? OnByDefault { get; set; }

    /// <summary>
    /// Determines where this `CatalogModifier` appears in the `CatalogModifierList`.
    /// </summary>
    [JsonPropertyName("ordinal")]
    public int? Ordinal { get; set; }

    /// <summary>
    /// The ID of the `CatalogModifierList` associated with this modifier.
    /// </summary>
    [JsonPropertyName("modifier_list_id")]
    public string? ModifierListId { get; set; }

    /// <summary>
    /// Location-specific price overrides.
    /// </summary>
    [JsonPropertyName("location_overrides")]
    public IEnumerable<ModifierLocationOverrides>? LocationOverrides { get; set; }

    /// <summary>
    /// The ID of the image associated with this `CatalogModifier` instance.
    /// Currently this image is not displayed by Square, but is free to be displayed in 3rd party applications.
    /// </summary>
    [JsonPropertyName("image_id")]
    public string? ImageId { get; set; }

    /// <summary>
    /// When `true`, this modifier is hidden from online ordering channels. This setting can be overridden at the item level using `CatalogModifierListInfo.modifier_overrides`.
    /// </summary>
    [JsonPropertyName("hidden_online")]
    public bool? HiddenOnline { get; set; }

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
