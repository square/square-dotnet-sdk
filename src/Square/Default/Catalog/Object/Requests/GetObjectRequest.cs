using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default.Catalog;

[Serializable]
public record GetObjectRequest
{
    /// <summary>
    /// The object ID of any type of catalog objects to be retrieved.
    /// </summary>
    [JsonIgnore]
    public required string ObjectId { get; set; }

    /// <summary>
    /// If `true`, the response will include additional objects that are related to the
    /// requested objects. Related objects are defined as any objects referenced by ID by the results in the `objects` field
    /// of the response. These objects are put in the `related_objects` field. Setting this to `true` is
    /// helpful when the objects are needed for immediate display to a user.
    /// This process only goes one level deep. Objects referenced by the related objects will not be included. For example,
    ///
    /// if the `objects` field of the response contains a CatalogItem, its associated
    /// CatalogCategory objects, CatalogTax objects, CatalogImage objects and
    /// CatalogModifierLists will be returned in the `related_objects` field of the
    /// response. If the `objects` field of the response contains a CatalogItemVariation,
    /// its parent CatalogItem will be returned in the `related_objects` field of
    /// the response.
    ///
    /// Default value: `false`
    /// </summary>
    [JsonIgnore]
    public bool? IncludeRelatedObjects { get; set; }

    /// <summary>
    /// Requests objects as of a specific version of the catalog. This allows you to retrieve historical
    /// versions of objects. The value to retrieve a specific version of an object can be found
    /// in the version field of [CatalogObject](entity:CatalogObject)s. If not included, results will
    /// be from the current version of the catalog.
    /// </summary>
    [JsonIgnore]
    public long? CatalogVersion { get; set; }

    /// <summary>
    /// Specifies whether or not to include the `path_to_root` list for each returned category instance. The `path_to_root` list consists
    /// of `CategoryPathToRootNode` objects and specifies the path that starts with the immediate parent category of the returned category
    /// and ends with its root category. If the returned category is a top-level category, the `path_to_root` list is empty and is not returned
    /// in the response payload.
    /// </summary>
    [JsonIgnore]
    public bool? IncludeCategoryPathToRoot { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
