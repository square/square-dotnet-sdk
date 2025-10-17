using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// An enumerated value that can link a
/// `CatalogItemVariation` to an item option as one of
/// its item option values.
/// </summary>
[Serializable]
public record CatalogItemOptionValue : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Unique ID of the associated item option.
    /// </summary>
    [JsonPropertyName("item_option_id")]
    public string? ItemOptionId { get; set; }

    /// <summary>
    /// Name of this item option value. This is a searchable attribute for use in applicable query filters.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// A human-readable description for the option value. This is a searchable attribute for use in applicable query filters.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The HTML-supported hex color for the item option (e.g., "#ff8d4e85").
    /// Only displayed if `show_colors` is enabled on the parent `ItemOption`. When
    /// left unset, `color` defaults to white ("#ffffff") when `show_colors` is
    /// enabled on the parent `ItemOption`.
    /// </summary>
    [JsonPropertyName("color")]
    public string? Color { get; set; }

    /// <summary>
    /// Determines where this option value appears in a list of option values.
    /// </summary>
    [JsonPropertyName("ordinal")]
    public int? Ordinal { get; set; }

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
