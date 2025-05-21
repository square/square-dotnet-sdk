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
    /// __Deprecated__: Use `on_by_default_override` instead.
    /// </summary>
    [JsonPropertyName("on_by_default")]
    public bool? OnByDefault { get; set; }

    [JsonPropertyName("hidden_online_override")]
    public object? HiddenOnlineOverride { get; set; }

    [JsonPropertyName("on_by_default_override")]
    public object? OnByDefaultOverride { get; set; }

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
