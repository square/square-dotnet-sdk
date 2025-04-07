using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// An instance of a custom attribute. Custom attributes can be defined and
/// added to `ITEM` and `ITEM_VARIATION` type catalog objects.
/// [Read more about custom attributes](https://developer.squareup.com/docs/catalog-api/add-custom-attributes).
/// </summary>
public record CatalogCustomAttributeValue
{
    /// <summary>
    /// The name of the custom attribute.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The string value of the custom attribute.  Populated if `type` = `STRING`.
    /// </summary>
    [JsonPropertyName("string_value")]
    public string? StringValue { get; set; }

    /// <summary>
    /// The id of the [CatalogCustomAttributeDefinition](entity:CatalogCustomAttributeDefinition) this value belongs to.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("custom_attribute_definition_id")]
    public string? CustomAttributeDefinitionId { get; set; }

    /// <summary>
    /// A copy of type from the associated `CatalogCustomAttributeDefinition`.
    /// See [CatalogCustomAttributeDefinitionType](#type-catalogcustomattributedefinitiontype) for possible values
    /// </summary>
    [JsonPropertyName("type")]
    public CatalogCustomAttributeDefinitionType? Type { get; set; }

    /// <summary>
    /// Populated if `type` = `NUMBER`. Contains a string
    /// representation of a decimal number, using a `.` as the decimal separator.
    /// </summary>
    [JsonPropertyName("number_value")]
    public string? NumberValue { get; set; }

    /// <summary>
    /// A `true` or `false` value. Populated if `type` = `BOOLEAN`.
    /// </summary>
    [JsonPropertyName("boolean_value")]
    public bool? BooleanValue { get; set; }

    /// <summary>
    /// One or more choices from `allowed_selections`. Populated if `type` = `SELECTION`.
    /// </summary>
    [JsonPropertyName("selection_uid_values")]
    public IEnumerable<string>? SelectionUidValues { get; set; }

    /// <summary>
    /// If the associated `CatalogCustomAttributeDefinition` object is defined by another application, this key is prefixed by the defining application ID.
    /// For example, if the CatalogCustomAttributeDefinition has a key attribute of "cocoa_brand" and the defining application ID is "abcd1234", this key is "abcd1234:cocoa_brand"
    /// when the application making the request is different from the application defining the custom attribute definition. Otherwise, the key is simply "cocoa_brand".
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("key")]
    public string? Key { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    /// <remarks>
    /// [EXPERIMENTAL] This API is experimental and may change in future releases.
    /// </remarks>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
