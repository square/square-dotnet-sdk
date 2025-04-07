using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// References a text-based modifier or a list of non text-based modifiers applied to a `CatalogItem` instance
/// and specifies supported behaviors of the application.
/// </summary>
public record CatalogItemModifierListInfo
{
    /// <summary>
    /// The ID of the `CatalogModifierList` controlled by this `CatalogModifierListInfo`.
    /// </summary>
    [JsonPropertyName("modifier_list_id")]
    public required string ModifierListId { get; set; }

    /// <summary>
    /// A set of `CatalogModifierOverride` objects that override whether a given `CatalogModifier` is enabled by default.
    /// </summary>
    [JsonPropertyName("modifier_overrides")]
    public IEnumerable<CatalogModifierOverride>? ModifierOverrides { get; set; }

    /// <summary>
    /// If 0 or larger, the smallest number of `CatalogModifier`s that must be selected from this `CatalogModifierList`.
    /// The default value is `-1`.
    ///
    /// When  `CatalogModifierList.selection_type` is `MULTIPLE`, `CatalogModifierListInfo.min_selected_modifiers=-1`
    /// and `CatalogModifierListInfo.max_selected_modifier=-1` means that from zero to the maximum number of modifiers of
    /// the `CatalogModifierList` can be selected from the `CatalogModifierList`.
    ///
    /// When the `CatalogModifierList.selection_type` is `SINGLE`, `CatalogModifierListInfo.min_selected_modifiers=-1`
    /// and `CatalogModifierListInfo.max_selected_modifier=-1` means that exactly one modifier must be present in
    /// and can be selected from the `CatalogModifierList`
    /// </summary>
    [JsonPropertyName("min_selected_modifiers")]
    public int? MinSelectedModifiers { get; set; }

    /// <summary>
    /// If 0 or larger, the largest number of `CatalogModifier`s that can be selected from this `CatalogModifierList`.
    /// The default value is `-1`.
    ///
    /// When  `CatalogModifierList.selection_type` is `MULTIPLE`, `CatalogModifierListInfo.min_selected_modifiers=-1`
    /// and `CatalogModifierListInfo.max_selected_modifier=-1` means that from zero to the maximum number of modifiers of
    /// the `CatalogModifierList` can be selected from the `CatalogModifierList`.
    ///
    /// When the `CatalogModifierList.selection_type` is `SINGLE`, `CatalogModifierListInfo.min_selected_modifiers=-1`
    /// and `CatalogModifierListInfo.max_selected_modifier=-1` means that exactly one modifier must be present in
    /// and can be selected from the `CatalogModifierList`
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
