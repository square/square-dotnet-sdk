using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// A named selection for this `SELECTION`-type custom attribute definition.
/// </summary>
public record CatalogCustomAttributeDefinitionSelectionConfigCustomAttributeSelection
{
    /// <summary>
    /// Unique ID set by Square.
    /// </summary>
    [JsonPropertyName("uid")]
    public string? Uid { get; set; }

    /// <summary>
    /// Selection name, unique within `allowed_selections`.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

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
