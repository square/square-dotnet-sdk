using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

[Serializable]
public record BatchGetCatalogObjectsResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Any errors that occurred during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// A list of [CatalogObject](entity:CatalogObject)s returned.
    /// </summary>
    [JsonPropertyName("objects")]
    public IEnumerable<CatalogObject>? Objects { get; set; }

    /// <summary>
    /// A list of [CatalogObject](entity:CatalogObject)s referenced by the object in the `objects` field.
    /// </summary>
    [JsonPropertyName("related_objects")]
    public IEnumerable<CatalogObject>? RelatedObjects { get; set; }

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
