using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// The query filter to return the search result whose named attribute values fall between the specified range.
/// </summary>
public record CatalogQueryRange
{
    /// <summary>
    /// The name of the attribute to be searched.
    /// </summary>
    [JsonPropertyName("attribute_name")]
    public required string AttributeName { get; set; }

    /// <summary>
    /// The desired minimum value for the search attribute (inclusive).
    /// </summary>
    [JsonPropertyName("attribute_min_value")]
    public long? AttributeMinValue { get; set; }

    /// <summary>
    /// The desired maximum value for the search attribute (inclusive).
    /// </summary>
    [JsonPropertyName("attribute_max_value")]
    public long? AttributeMaxValue { get; set; }

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
