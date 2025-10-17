using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// The query filter to return the search result whose named attribute values fall between the specified range.
/// </summary>
[Serializable]
public record CatalogQueryRange : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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
