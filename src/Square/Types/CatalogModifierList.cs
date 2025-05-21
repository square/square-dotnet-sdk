using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// A container for a list of modifiers, or a text-based modifier.
/// For text-based modifiers, this represents text configuration for an item. (For example, custom text to print on a t-shirt).
/// For non text-based modifiers, this represents a list of modifiers that can be applied to items at the time of sale.
/// (For example, a list of condiments for a hot dog, or a list of ice cream flavors).
/// Each element of the modifier list is a `CatalogObject` instance of the `MODIFIER` type.
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
    /// __Deprecated__: Indicates whether a single (`SINGLE`) modifier or multiple (`MULTIPLE`) modifiers can be selected. Use
    /// `min_selected_modifiers` and `max_selected_modifiers` instead.
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
    /// When `true`, allows multiple quantities of the same modifier to be selected.
    /// </summary>
    [JsonPropertyName("allow_quantities")]
    public bool? AllowQuantities { get; set; }

    /// <summary>
    /// True if modifiers belonging to this list can be used conversationally.
    /// </summary>
    [JsonPropertyName("is_conversational")]
    public bool? IsConversational { get; set; }

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
    /// The minimum number of modifiers that must be selected from this list. The value can be overridden with `CatalogItemModifierListInfo`.
    ///
    /// Values:
    ///
    /// - 0: No selection is required.
    /// - -1: Default value, the attribute was not set by the client. Treated as no selection required.
    /// - &gt;0: The required minimum modifier selections. This can be larger than the total `CatalogModifiers` when `allow_quantities` is enabled.
    /// - &lt; -1: Invalid. Treated as no selection required.
    /// </summary>
    [JsonPropertyName("min_selected_modifiers")]
    public long? MinSelectedModifiers { get; set; }

    /// <summary>
    /// The maximum number of modifiers that must be selected from this list. The value can be overridden with `CatalogItemModifierListInfo`.
    ///
    /// Values:
    ///
    /// - 0: No maximum limit.
    /// - -1: Default value, the attribute was not set by the client. Treated as no maximum limit.
    /// - &gt;0: The maximum total modifier selections. This can be larger than the total `CatalogModifiers` when `allow_quantities` is enabled.
    /// - &lt; -1: Invalid. Treated as no maximum limit.
    /// </summary>
    [JsonPropertyName("max_selected_modifiers")]
    public long? MaxSelectedModifiers { get; set; }

    /// <summary>
    /// If `true`, modifiers from this list are hidden from customer receipts. The default value is `false`.
    /// This setting can be overridden with `CatalogItemModifierListInfo.hidden_from_customer_override`.
    /// </summary>
    [JsonPropertyName("hidden_from_customer")]
    public bool? HiddenFromCustomer { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    /// <remarks>
    /// [EXPERIMENTAL] This API is experimental and may change in future releases.
    /// </remarks>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
