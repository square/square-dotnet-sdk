using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Options to control how to override the default behavior of the specified modifier.
/// </summary>
public record CatalogModifierOverride
{
    /// <summary>
    /// The ID of the `CatalogModifier` whose default behavior is being overridden.
    /// </summary>
    [JsonPropertyName("modifier_id")]
    public required string ModifierId { get; set; }

    /// <summary>
    /// If `true`, this `CatalogModifier` should be selected by default for this `CatalogItem`.
    /// </summary>
    [JsonPropertyName("on_by_default")]
    public bool? OnByDefault { get; set; }

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
