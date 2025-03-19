using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// For a text-based modifier, this encapsulates the modifier's text when its `modifier_type` is `TEXT`.
/// For example, to sell T-shirts with custom prints, a text-based modifier can be used to capture the buyer-supplied
/// text string to be selected for the T-shirt at the time of sale.
///
/// For non text-based modifiers, this encapsulates a non-empty list of modifiers applicable to items
/// at the time of sale. Each element of the modifier list is a `CatalogObject` instance of the `MODIFIER` type.
/// For example, a "Condiments" modifier list applicable to a "Hot Dog" item
/// may contain "Ketchup", "Mustard", and "Relish" modifiers.
///
/// A non text-based modifier can be applied to the modified item once or multiple times, if the `selection_type` field
/// is set to `SINGLE` or `MULTIPLE`, respectively. On the other hand, a text-based modifier can be applied to the item
/// only once and the `selection_type` field is always set to `SINGLE`.
/// </summary>
public record CatalogModifierList
{
    /// <summary>
    /// The name of the `CatalogModifierList` instance. This is a searchable attribute for use in applicable query filters, and its value length is of
    /// Unicode code points.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The position of this `CatalogModifierList` within a list of `CatalogModifierList` instances.
    /// </summary>
    [JsonPropertyName("ordinal")]
    public int? Ordinal { get; set; }

    /// <summary>
    /// Indicates whether a single (`SINGLE`) or multiple (`MULTIPLE`) modifiers from the list
    /// can be applied to a single `CatalogItem`.
    ///
    /// For text-based modifiers, the `selection_type` attribute is always `SINGLE`. The other value is ignored.
    /// See [CatalogModifierListSelectionType](#type-catalogmodifierlistselectiontype) for possible values
    /// </summary>
    [JsonPropertyName("selection_type")]
    public CatalogModifierListSelectionType? SelectionType { get; set; }

    /// <summary>
    /// A non-empty list of `CatalogModifier` objects to be included in the `CatalogModifierList`,
    /// for non text-based modifiers when the `modifier_type` attribute is `LIST`. Each element of this list
    /// is a `CatalogObject` instance of the `MODIFIER` type, containing the following attributes:
    /// ```
    /// {
    /// "id": "{{catalog_modifier_id}}",
    /// "type": "MODIFIER",
    /// "modifier_data": {{a CatalogModifier instance&gt;}}
    /// }
    /// ```
    /// </summary>
    [JsonPropertyName("modifiers")]
    public IEnumerable<CatalogObject>? Modifiers { get; set; }

    /// <summary>
    /// The IDs of images associated with this `CatalogModifierList` instance.
    /// Currently these images are not displayed on Square products, but may be displayed in 3rd-party applications.
    /// </summary>
    [JsonPropertyName("image_ids")]
    public IEnumerable<string>? ImageIds { get; set; }

    /// <summary>
    /// The type of the modifier.
    ///
    /// When this `modifier_type` value is `TEXT`,  the `CatalogModifierList` represents a text-based modifier.
    /// When this `modifier_type` value is `LIST`, the `CatalogModifierList` contains a list of `CatalogModifier` objects.
    /// See [CatalogModifierListModifierType](#type-catalogmodifierlistmodifiertype) for possible values
    /// </summary>
    [JsonPropertyName("modifier_type")]
    public CatalogModifierListModifierType? ModifierType { get; set; }

    /// <summary>
    /// The maximum length, in Unicode points, of the text string of the text-based modifier as represented by
    /// this `CatalogModifierList` object with the `modifier_type` set to `TEXT`.
    /// </summary>
    [JsonPropertyName("max_length")]
    public int? MaxLength { get; set; }

    /// <summary>
    /// Whether the text string must be a non-empty string (`true`) or not (`false`) for a text-based modifier
    /// as represented by this `CatalogModifierList` object with the `modifier_type` set to `TEXT`.
    /// </summary>
    [JsonPropertyName("text_required")]
    public bool? TextRequired { get; set; }

    /// <summary>
    /// A note for internal use by the business.
    ///
    /// For example, for a text-based modifier applied to a T-shirt item, if the buyer-supplied text of "Hello, Kitty!"
    /// is to be printed on the T-shirt, this `internal_name` attribute can be "Use italic face" as
    /// an instruction for the business to follow.
    ///
    /// For non text-based modifiers, this `internal_name` attribute can be
    /// used to include SKUs, internal codes, or supplemental descriptions for internal use.
    /// </summary>
    [JsonPropertyName("internal_name")]
    public string? InternalName { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
