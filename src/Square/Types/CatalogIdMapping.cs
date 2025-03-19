using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// A mapping between a temporary client-supplied ID and a permanent server-generated ID.
///
/// When calling [UpsertCatalogObject](api-endpoint:Catalog-UpsertCatalogObject) or
/// [BatchUpsertCatalogObjects](api-endpoint:Catalog-BatchUpsertCatalogObjects) to
/// create a [CatalogObject](entity:CatalogObject) instance, you can supply
/// a temporary ID for the to-be-created object, especially when the object is to be referenced
/// elsewhere in the same request body. This temporary ID can be any string unique within
/// the call, but must be prefixed by "#".
///
/// After the request is submitted and the object created, a permanent server-generated ID is assigned
/// to the new object. The permanent ID is unique across the Square catalog.
/// </summary>
public record CatalogIdMapping
{
    /// <summary>
    /// The client-supplied temporary `#`-prefixed ID for a new `CatalogObject`.
    /// </summary>
    [JsonPropertyName("client_object_id")]
    public string? ClientObjectId { get; set; }

    /// <summary>
    /// The permanent ID for the CatalogObject created by the server.
    /// </summary>
    [JsonPropertyName("object_id")]
    public string? ObjectId { get; set; }

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
