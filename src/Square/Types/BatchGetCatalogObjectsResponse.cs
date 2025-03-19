using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record BatchGetCatalogObjectsResponse
{
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
