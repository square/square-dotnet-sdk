using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Inventory;

[Serializable]
public record ChangesInventoryRequest
{
    /// <summary>
    /// ID of the [CatalogObject](entity:CatalogObject) to retrieve.
    /// </summary>
    [JsonIgnore]
    public required string CatalogObjectId { get; set; }

    /// <summary>
    /// The [Location](entity:Location) IDs to look up as a comma-separated
    /// list. An empty list queries all locations.
    /// </summary>
    [JsonIgnore]
    public string? LocationIds { get; set; }

    /// <summary>
    /// A pagination cursor returned by a previous call to this endpoint.
    /// Provide this to retrieve the next set of results for the original query.
    ///
    /// See the [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination) guide for more information.
    /// </summary>
    [JsonIgnore]
    public string? Cursor { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
