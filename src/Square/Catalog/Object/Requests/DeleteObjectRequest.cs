using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Catalog.Object;

public record DeleteObjectRequest
{
    /// <summary>
    /// The ID of the catalog object to be deleted. When an object is deleted, other
    /// objects in the graph that depend on that object will be deleted as well (for example, deleting a
    /// catalog item will delete its catalog item variations).
    /// </summary>
    [JsonIgnore]
    public required string ObjectId { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
