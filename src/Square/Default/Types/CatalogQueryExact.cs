using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// The query filter to return the search result by exact match of the specified attribute name and value.
/// </summary>
[Serializable]
public record CatalogQueryExact : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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
