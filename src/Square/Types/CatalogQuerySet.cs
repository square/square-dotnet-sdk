using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// The query filter to return the search result(s) by exact match of the specified `attribute_name` and any of
/// the `attribute_values`.
/// </summary>
public record CatalogQuerySet
{
    /// <summary>
    /// The name of the attribute to be searched. Matching of the attribute name is exact.
    /// </summary>
    [JsonPropertyName("attribute_name")]
    public required string AttributeName { get; set; }

    /// <summary>
    /// The desired values of the search attribute. Matching of the attribute values is exact and case insensitive.
    /// A maximum of 250 values may be searched in a request.
    /// </summary>
    [JsonPropertyName("attribute_values")]
    public IEnumerable<string> AttributeValues { get; set; } = new List<string>();

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
