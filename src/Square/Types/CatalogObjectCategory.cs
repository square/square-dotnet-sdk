using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// A category that can be assigned to an item or a parent category that can be assigned
/// to another category. For example, a clothing category can be assigned to a t-shirt item or
/// be made as the parent category to the pants category.
/// </summary>
public record CatalogObjectCategory
{
    /// <summary>
    /// The ID of the object's category.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The order of the object within the context of the category.
    /// </summary>
    [JsonPropertyName("ordinal")]
    public long? Ordinal { get; set; }

    /// <summary>
    /// Structured data for a `CatalogCategory`, set for CatalogObjects of type `CATEGORY`.
    /// </summary>
    [JsonPropertyName("category_data")]
    public CatalogCategory? CategoryData { get; set; }

    /// <summary>
    /// Last modification [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates) in RFC 3339 format, e.g., `"2016-08-15T23:59:33.123Z"`
    /// would indicate the UTC time (denoted by `Z`) of August 15, 2016 at 23:59:33 and 123 milliseconds.
    /// </summary>
    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; set; }

    /// <summary>
    /// The version of the object. When updating an object, the version supplied
    /// must match the version in the database, otherwise the write will be rejected as conflicting.
    /// </summary>
    [JsonPropertyName("version")]
    public long? Version { get; set; }

    /// <summary>
    /// If `true`, the object has been deleted from the database. Must be `false` for new objects
    /// being inserted. When deleted, the `updated_at` field will equal the deletion time.
    /// </summary>
    [JsonPropertyName("is_deleted")]
    public bool? IsDeleted { get; set; }

    /// <summary>
    /// A map (key-value pairs) of application-defined custom attribute values. The value of a key-value pair
    /// is a [CatalogCustomAttributeValue](entity:CatalogCustomAttributeValue) object. The key is the `key` attribute
    /// value defined in the associated [CatalogCustomAttributeDefinition](entity:CatalogCustomAttributeDefinition)
    /// object defined by the application making the request.
    ///
    /// If the `CatalogCustomAttributeDefinition` object is
    /// defined by another application, the `CatalogCustomAttributeDefinition`'s key attribute value is prefixed by
    /// the defining application ID. For example, if the `CatalogCustomAttributeDefinition` has a `key` attribute of
    /// `"cocoa_brand"` and the defining application ID is `"abcd1234"`, the key in the map is `"abcd1234:cocoa_brand"`
    /// if the application making the request is different from the application defining the custom attribute definition.
    /// Otherwise, the key used in the map is simply `"cocoa_brand"`.
    ///
    /// Application-defined custom attributes are set at a global (location-independent) level.
    /// Custom attribute values are intended to store additional information about a catalog object
    /// or associations with an entity in another system. Do not use custom attributes
    /// to store any sensitive information (personally identifiable information, card details, etc.).
    /// </summary>
    [JsonPropertyName("custom_attribute_values")]
    public Dictionary<string, CatalogCustomAttributeValue>? CustomAttributeValues { get; set; }

    /// <summary>
    /// The Connect v1 IDs for this object at each location where it is present, where they
    /// differ from the object's Connect V2 ID. The field will only be present for objects that
    /// have been created or modified by legacy APIs.
    /// </summary>
    [JsonPropertyName("catalog_v1_ids")]
    public IEnumerable<CatalogV1Id>? CatalogV1Ids { get; set; }

    /// <summary>
    /// If `true`, this object is present at all locations (including future locations), except where specified in
    /// the `absent_at_location_ids` field. If `false`, this object is not present at any locations (including future locations),
    /// except where specified in the `present_at_location_ids` field. If not specified, defaults to `true`.
    /// </summary>
    [JsonPropertyName("present_at_all_locations")]
    public bool? PresentAtAllLocations { get; set; }

    /// <summary>
    /// A list of locations where the object is present, even if `present_at_all_locations` is `false`.
    /// This can include locations that are deactivated.
    /// </summary>
    [JsonPropertyName("present_at_location_ids")]
    public IEnumerable<string>? PresentAtLocationIds { get; set; }

    /// <summary>
    /// A list of locations where the object is not present, even if `present_at_all_locations` is `true`.
    /// This can include locations that are deactivated.
    /// </summary>
    [JsonPropertyName("absent_at_location_ids")]
    public IEnumerable<string>? AbsentAtLocationIds { get; set; }

    /// <summary>
    /// Identifies the `CatalogImage` attached to this `CatalogObject`.
    /// </summary>
    [JsonPropertyName("image_id")]
    public string? ImageId { get; set; }

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
