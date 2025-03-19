using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Catalog;

public record BatchDeleteCatalogObjectsRequest
{
    /// <summary>
    /// The IDs of the CatalogObjects to be deleted. When an object is deleted, other objects
    /// in the graph that depend on that object will be deleted as well (for example, deleting a
    /// CatalogItem will delete its CatalogItemVariation.
    /// </summary>
    [JsonPropertyName("object_ids")]
    public IEnumerable<string>? ObjectIds { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
