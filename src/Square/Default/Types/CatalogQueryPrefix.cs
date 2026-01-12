using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// The query filter to return the search result whose named attribute values are prefixed by the specified attribute value.
/// </summary>
[Serializable]
public record CatalogQueryPrefix : IJsonOnDeserialized
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
    /// The desired prefix of the search attribute value.
    /// </summary>
    [JsonPropertyName("attribute_prefix")]
    public required string AttributePrefix { get; set; }

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
