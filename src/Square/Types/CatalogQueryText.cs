using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// The query filter to return the search result whose searchable attribute values contain all of the specified keywords or tokens, independent of the token order or case.
/// </summary>
[Serializable]
public record CatalogQueryText : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// A list of 1, 2, or 3 search keywords. Keywords with fewer than 3 alphanumeric characters are ignored.
    /// </summary>
    [JsonPropertyName("keywords")]
    public IEnumerable<string> Keywords { get; set; } = new List<string>();

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
