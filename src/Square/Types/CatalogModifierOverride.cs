using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Options to control how to override the default behavior of the specified modifier.
/// </summary>
[Serializable]
public record CatalogModifierOverride : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The ID of the `CatalogModifier` whose default behavior is being overridden.
    /// </summary>
    [JsonPropertyName("modifier_id")]
    public required string ModifierId { get; set; }

    /// <summary>
    /// __Deprecated__: Use `on_by_default_override` instead.
    /// </summary>
    [JsonPropertyName("on_by_default")]
    public bool? OnByDefault { get; set; }

    /// <summary>
    /// If `YES`, this setting overrides the `hidden_online` setting on the `CatalogModifier` object,
    /// and the modifier is always hidden from online sales channels.
    /// If `NO`, the modifier is not hidden. It is always visible in online sales channels for this catalog item.
    /// `NOT_SET` means the `hidden_online` setting on the `CatalogModifier` object is obeyed.
    /// See [CatalogModifierToggleOverrideType](#type-catalogmodifiertoggleoverridetype) for possible values
    /// </summary>
    [JsonPropertyName("hidden_online_override")]
    public CatalogModifierToggleOverrideType? HiddenOnlineOverride { get; set; }

    /// <summary>
    /// If `YES`, this setting overrides the `on_by_default` setting on the `CatalogModifier` object,
    /// and the modifier is always selected by default for the catalog item.
    ///
    /// If `NO`, the modifier is not selected by default for this catalog item.
    /// `NOT_SET` means the `on_by_default` setting on the `CatalogModifier` object is obeyed.
    /// See [CatalogModifierToggleOverrideType](#type-catalogmodifiertoggleoverridetype) for possible values
    /// </summary>
    [JsonPropertyName("on_by_default_override")]
    public CatalogModifierToggleOverrideType? OnByDefaultOverride { get; set; }

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
