using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Catalog;

public record BatchGetCatalogObjectsRequest
{
    /// <summary>
    /// The IDs of the CatalogObjects to be retrieved.
    /// </summary>
    [JsonPropertyName("object_ids")]
    public IEnumerable<string> ObjectIds { get; set; } = new List<string>();

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
    [JsonPropertyName("include_related_objects")]
    public bool? IncludeRelatedObjects { get; set; }

    /// <summary>
    /// The specific version of the catalog objects to be included in the response.
    /// This allows you to retrieve historical versions of objects. The specified version value is matched against
    /// the [CatalogObject](entity:CatalogObject)s' `version` attribute. If not included, results will
    /// be from the current version of the catalog.
    /// </summary>
    [JsonPropertyName("catalog_version")]
    public long? CatalogVersion { get; set; }

    /// <summary>
    /// Indicates whether to include (`true`) or not (`false`) in the response deleted objects, namely, those with the `is_deleted` attribute set to `true`.
    /// </summary>
    [JsonPropertyName("include_deleted_objects")]
    public bool? IncludeDeletedObjects { get; set; }

    /// <summary>
    /// Specifies whether or not to include the `path_to_root` list for each returned category instance. The `path_to_root` list consists
    /// of `CategoryPathToRootNode` objects and specifies the path that starts with the immediate parent category of the returned category
    /// and ends with its root category. If the returned category is a top-level category, the `path_to_root` list is empty and is not returned
    /// in the response payload.
    /// </summary>
    [JsonPropertyName("include_category_path_to_root")]
    public bool? IncludeCategoryPathToRoot { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
