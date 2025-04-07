using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// The query filter to return the search result by exact match of the specified attribute name and value.
/// </summary>
public record CatalogQueryExact
{
    /// <summary>
    /// The name of the attribute to be searched. Matching of the attribute name is exact.
    /// </summary>
    [JsonPropertyName("attribute_name")]
    public required string AttributeName { get; set; }

    /// <summary>
    /// The desired value of the search attribute. Matching of the attribute value is case insensitive and can be partial.
    /// For example, if a specified value of "sma", objects with the named attribute value of "Small", "small" are both matched.
    /// </summary>
    [JsonPropertyName("attribute_value")]
    public required string AttributeValue { get; set; }

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
