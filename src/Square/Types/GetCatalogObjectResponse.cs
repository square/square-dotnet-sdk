using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record GetCatalogObjectResponse
{
    /// <summary>
    /// Any errors that occurred during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// The `CatalogObject`s returned.
    /// </summary>
    [JsonPropertyName("object")]
    public CatalogObject? Object { get; set; }

    /// <summary>
    /// A list of `CatalogObject`s referenced by the object in the `object` field.
    /// </summary>
    [JsonPropertyName("related_objects")]
    public IEnumerable<CatalogObject>? RelatedObjects { get; set; }

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
