using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Controls how a modifier list is applied to a specific item. This object allows for item-specific customization of modifier list behavior
/// and provides the ability to override global modifier list settings.
/// </summary>
[Serializable]
public record CatalogItemModifierListInfo : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The ID of the `CatalogModifierList` controlled by this `CatalogModifierListInfo`.
    /// </summary>
    [JsonPropertyName("modifier_list_id")]
    public required string ModifierListId { get; set; }

    /// <summary>
    /// A set of `CatalogModifierOverride` objects that override default modifier settings for this item.
    /// </summary>
    [JsonPropertyName("modifier_overrides")]
    public IEnumerable<CatalogModifierOverride>? ModifierOverrides { get; set; }

    /// <summary>
    /// The minimum number of modifiers that must be selected from this modifier list.
    /// Values:
    ///
    /// - 0: No selection is required.
    /// - -1: Default value, the attribute was not set by the client. When `max_selected_modifiers` is
    /// also -1, use the minimum and maximum selection values set on the `CatalogItemModifierList`.
    /// - &gt;0: The required minimum modifier selections. This can be larger than the total `CatalogModifiers` when `allow_quantities` is enabled.
    /// - &lt; -1: Invalid. Treated as no selection required.
    /// </summary>
    [JsonPropertyName("min_selected_modifiers")]
    public int? MinSelectedModifiers { get; set; }

    /// <summary>
    /// The maximum number of modifiers that can be selected.
    /// Values:
    ///
    /// - 0: No maximum limit.
    /// - -1: Default value, the attribute was not set by the client. When `min_selected_modifiers` is
    /// also -1, use the minimum and maximum selection values set on the `CatalogItemModifierList`.
    /// - &gt;0: The maximum total modifier selections. This can be larger than the total `CatalogModifiers` when `allow_quantities` is enabled.
    /// - &lt; -1: Invalid. Treated as no maximum limit.
    /// </summary>
    [JsonPropertyName("max_selected_modifiers")]
    public int? MaxSelectedModifiers { get; set; }

    /// <summary>
    /// If `true`, enable this `CatalogModifierList`. The default value is `true`.
    /// </summary>
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    /// <summary>
    /// The position of this `CatalogItemModifierListInfo` object within the `modifier_list_info` list applied
    /// to a `CatalogItem` instance.
    /// </summary>
    [JsonPropertyName("ordinal")]
    public int? Ordinal { get; set; }

    /// <summary>
    /// Controls whether multiple quantities of the same modifier can be selected for this item.
    /// - `YES` means that every modifier in the `CatalogModifierList` can have multiple quantities
    /// selected for this item.
    /// - `NO` means that each modifier in the `CatalogModifierList` can be selected only once for this item.
    /// - `NOT_SET` means that the `allow_quantities` setting on the `CatalogModifierList` is obeyed.
    /// See [CatalogModifierToggleOverrideType](#type-catalogmodifiertoggleoverridetype) for possible values
    /// </summary>
    [JsonPropertyName("allow_quantities")]
    public CatalogModifierToggleOverrideType? AllowQuantities { get; set; }

    /// <summary>
    /// Controls whether conversational mode is enabled for modifiers on this item.
    ///
    /// - `YES` means conversational mode is enabled for every modifier in the `CatalogModifierList`.
    /// - `NO` means that conversational mode is not enabled for any modifier in the `CatalogModifierList`.
    /// - `NOT_SET` means that conversational mode is not enabled for any modifier in the `CatalogModifierList`.
    /// See [CatalogModifierToggleOverrideType](#type-catalogmodifiertoggleoverridetype) for possible values
    /// </summary>
    [JsonPropertyName("is_conversational")]
    public CatalogModifierToggleOverrideType? IsConversational { get; set; }

    /// <summary>
    /// Controls whether all modifiers for this item are hidden from customer receipts.
    /// - `YES` means that all modifiers in the `CatalogModifierList` are hidden from customer
    /// receipts for this item.
    /// - `NO` means that all modifiers in the `CatalogModifierList` are visible on customer receipts for this item.
    /// - `NOT_SET` means that the `hidden_from_customer` setting on the `CatalogModifierList` is obeyed.
    /// See [CatalogModifierToggleOverrideType](#type-catalogmodifiertoggleoverridetype) for possible values
    /// </summary>
    [JsonPropertyName("hidden_from_customer_override")]
    public CatalogModifierToggleOverrideType? HiddenFromCustomerOverride { get; set; }

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
