using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Supported custom attribute query expressions for calling the
/// [SearchCatalogItems](api-endpoint:Catalog-SearchCatalogItems)
/// endpoint to search for items or item variations.
/// </summary>
[Serializable]
public record CustomAttributeFilter : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
