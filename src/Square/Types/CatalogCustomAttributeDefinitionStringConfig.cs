using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Configuration associated with Custom Attribute Definitions of type `STRING`.
/// </summary>
public record CatalogCustomAttributeDefinitionStringConfig
{
    /// <summary>
    /// If true, each Custom Attribute instance associated with this Custom Attribute
    /// Definition must have a unique value within the seller's catalog. For
    /// example, this may be used for a value like a SKU that should not be
    /// duplicated within a seller's catalog. May not be modified after the
    /// definition has been created.
    /// </summary>
    [JsonPropertyName("enforce_uniqueness")]
    public bool? EnforceUniqueness { get; set; }

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
