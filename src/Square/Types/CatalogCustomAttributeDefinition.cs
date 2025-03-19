using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Contains information defining a custom attribute. Custom attributes are
/// intended to store additional information about a catalog object or to associate a
/// catalog object with an entity in another system. Do not use custom attributes
/// to store any sensitive information (personally identifiable information, card details, etc.).
/// [Read more about custom attributes](https://developer.squareup.com/docs/catalog-api/add-custom-attributes)
/// </summary>
public record CatalogCustomAttributeDefinition
{
    /// <summary>
    /// The type of this custom attribute. Cannot be modified after creation.
    /// Required.
    /// See [CatalogCustomAttributeDefinitionType](#type-catalogcustomattributedefinitiontype) for possible values
    /// </summary>
    [JsonPropertyName("type")]
    public required CatalogCustomAttributeDefinitionType Type { get; set; }

    /// <summary>
    /// The name of this definition for API and seller-facing UI purposes.
    /// The name must be unique within the (merchant, application) pair. Required.
    /// May not be empty and may not exceed 255 characters. Can be modified after creation.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Seller-oriented description of the meaning of this Custom Attribute,
    /// any constraints that the seller should observe, etc. May be displayed as a tooltip in Square UIs.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// __Read only.__ Contains information about the application that
    /// created this custom attribute definition.
    /// </summary>
    [JsonPropertyName("source_application")]
    public SourceApplication? SourceApplication { get; set; }

    /// <summary>
    /// The set of `CatalogObject` types that this custom atttribute may be applied to.
    /// Currently, only `ITEM`, `ITEM_VARIATION`, `MODIFIER`, `MODIFIER_LIST`, and `CATEGORY` are allowed. At least one type must be included.
    /// See [CatalogObjectType](#type-catalogobjecttype) for possible values
    /// </summary>
    [JsonPropertyName("allowed_object_types")]
    public IEnumerable<CatalogObjectType> AllowedObjectTypes { get; set; } =
        new List<CatalogObjectType>();

    /// <summary>
    /// The visibility of a custom attribute in seller-facing UIs (including Square Point
    /// of Sale applications and Square Dashboard). May be modified.
    /// See [CatalogCustomAttributeDefinitionSellerVisibility](#type-catalogcustomattributedefinitionsellervisibility) for possible values
    /// </summary>
    [JsonPropertyName("seller_visibility")]
    public CatalogCustomAttributeDefinitionSellerVisibility? SellerVisibility { get; set; }

    /// <summary>
    /// The visibility of a custom attribute to applications other than the application
    /// that created the attribute.
    /// See [CatalogCustomAttributeDefinitionAppVisibility](#type-catalogcustomattributedefinitionappvisibility) for possible values
    /// </summary>
    [JsonPropertyName("app_visibility")]
    public CatalogCustomAttributeDefinitionAppVisibility? AppVisibility { get; set; }

    /// <summary>
    /// Optionally, populated when `type` = `STRING`, unset otherwise.
    /// </summary>
    [JsonPropertyName("string_config")]
    public CatalogCustomAttributeDefinitionStringConfig? StringConfig { get; set; }

    /// <summary>
    /// Optionally, populated when `type` = `NUMBER`, unset otherwise.
    /// </summary>
    [JsonPropertyName("number_config")]
    public CatalogCustomAttributeDefinitionNumberConfig? NumberConfig { get; set; }

    /// <summary>
    /// Populated when `type` is set to `SELECTION`, unset otherwise.
    /// </summary>
    [JsonPropertyName("selection_config")]
    public CatalogCustomAttributeDefinitionSelectionConfig? SelectionConfig { get; set; }

    /// <summary>
    /// The number of custom attributes that reference this
    /// custom attribute definition. Set by the server in response to a ListCatalog
    /// request with `include_counts` set to `true`.  If the actual count is greater
    /// than 100, `custom_attribute_usage_count` will be set to `100`.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("custom_attribute_usage_count")]
    public int? CustomAttributeUsageCount { get; set; }

    /// <summary>
    /// The name of the desired custom attribute key that can be used to access
    /// the custom attribute value on catalog objects. Cannot be modified after the
    /// custom attribute definition has been created.
    /// Must be between 1 and 60 characters, and may only contain the characters `[a-zA-Z0-9_-]`.
    /// </summary>
    [JsonPropertyName("key")]
    public string? Key { get; set; }

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
