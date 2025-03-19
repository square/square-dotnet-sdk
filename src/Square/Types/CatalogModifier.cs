using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// A modifier applicable to items at the time of sale. An example of a modifier is a Cheese add-on to a Burger item.
/// </summary>
public record CatalogModifier
{
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
