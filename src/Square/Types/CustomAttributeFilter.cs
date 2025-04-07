using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Supported custom attribute query expressions for calling the
/// [SearchCatalogItems](api-endpoint:Catalog-SearchCatalogItems)
/// endpoint to search for items or item variations.
/// </summary>
public record CustomAttributeFilter
{
    /// <summary>
    /// A query expression to filter items or item variations by matching their custom attributes'
    /// `custom_attribute_definition_id` property value against the the specified id.
    /// Exactly one of `custom_attribute_definition_id` or `key` must be specified.
    /// </summary>
    [JsonPropertyName("custom_attribute_definition_id")]
    public string? CustomAttributeDefinitionId { get; set; }

    /// <summary>
    /// A query expression to filter items or item variations by matching their custom attributes'
    /// `key` property value against the specified key.
    /// Exactly one of `custom_attribute_definition_id` or `key` must be specified.
    /// </summary>
    [JsonPropertyName("key")]
    public string? Key { get; set; }

    /// <summary>
    /// A query expression to filter items or item variations by matching their custom attributes'
    /// `string_value`  property value against the specified text.
    /// Exactly one of `string_filter`, `number_filter`, `selection_uids_filter`, or `bool_filter` must be specified.
    /// </summary>
    [JsonPropertyName("string_filter")]
    public string? StringFilter { get; set; }

    /// <summary>
    /// A query expression to filter items or item variations with their custom attributes
    /// containing a number value within the specified range.
    /// Exactly one of `string_filter`, `number_filter`, `selection_uids_filter`, or `bool_filter` must be specified.
    /// </summary>
    [JsonPropertyName("number_filter")]
    public Range? NumberFilter { get; set; }

    /// <summary>
    /// A query expression to filter items or item variations by matching  their custom attributes'
    /// `selection_uid_values` values against the specified selection uids.
    /// Exactly one of `string_filter`, `number_filter`, `selection_uids_filter`, or `bool_filter` must be specified.
    /// </summary>
    [JsonPropertyName("selection_uids_filter")]
    public IEnumerable<string>? SelectionUidsFilter { get; set; }

    /// <summary>
    /// A query expression to filter items or item variations by matching their custom attributes'
    /// `boolean_value` property values against the specified Boolean expression.
    /// Exactly one of `string_filter`, `number_filter`, `selection_uids_filter`, or `bool_filter` must be specified.
    /// </summary>
    [JsonPropertyName("bool_filter")]
    public bool? BoolFilter { get; set; }

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
