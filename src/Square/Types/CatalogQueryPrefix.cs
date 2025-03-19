using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// The query filter to return the search result whose named attribute values are prefixed by the specified attribute value.
/// </summary>
public record CatalogQueryPrefix
{
    /// <summary>
    /// The name of the attribute to be searched.
    /// </summary>
    [JsonPropertyName("attribute_name")]
    public required string AttributeName { get; set; }

    /// <summary>
    /// The desired prefix of the search attribute value.
    /// </summary>
    [JsonPropertyName("attribute_prefix")]
    public required string AttributePrefix { get; set; }

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
