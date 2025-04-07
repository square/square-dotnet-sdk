using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Configuration associated with `SELECTION`-type custom attribute definitions.
/// </summary>
public record CatalogCustomAttributeDefinitionSelectionConfig
{
    /// <summary>
    /// The maximum number of selections that can be set. The maximum value for this
    /// attribute is 100. The default value is 1. The value can be modified, but changing the value will not
    /// affect existing custom attribute values on objects. Clients need to
    /// handle custom attributes with more selected values than allowed by this limit.
    /// </summary>
    [JsonPropertyName("max_allowed_selections")]
    public int? MaxAllowedSelections { get; set; }

    /// <summary>
    /// The set of valid `CatalogCustomAttributeSelections`. Up to a maximum of 100
    /// selections can be defined. Can be modified.
    /// </summary>
    [JsonPropertyName("allowed_selections")]
    public IEnumerable<CatalogCustomAttributeDefinitionSelectionConfigCustomAttributeSelection>? AllowedSelections { get; set; }

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
