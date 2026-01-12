using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// A query composed of one or more different types of filters to narrow the scope of targeted objects when calling the `SearchCatalogObjects` endpoint.
///
/// Although a query can have multiple filters, only certain query types can be combined per call to [SearchCatalogObjects](api-endpoint:Catalog-SearchCatalogObjects).
/// Any combination of the following types may be used together:
/// - [exact_query](entity:CatalogQueryExact)
/// - [prefix_query](entity:CatalogQueryPrefix)
/// - [range_query](entity:CatalogQueryRange)
/// - [sorted_attribute_query](entity:CatalogQuerySortedAttribute)
/// - [text_query](entity:CatalogQueryText)
///
/// All other query types cannot be combined with any others.
///
/// When a query filter is based on an attribute, the attribute must be searchable.
/// Searchable attributes are listed as follows, along their parent types that can be searched for with applicable query filters.
///
/// Searchable attribute and objects queryable by searchable attributes:
/// - `name`:  `CatalogItem`, `CatalogItemVariation`, `CatalogCategory`, `CatalogTax`, `CatalogDiscount`, `CatalogModifier`, `CatalogModifierList`, `CatalogItemOption`, `CatalogItemOptionValue`
/// - `description`: `CatalogItem`, `CatalogItemOptionValue`
/// - `abbreviation`: `CatalogItem`
/// - `upc`: `CatalogItemVariation`
/// - `sku`: `CatalogItemVariation`
/// - `caption`: `CatalogImage`
/// - `display_name`: `CatalogItemOption`
///
/// For example, to search for [CatalogItem](entity:CatalogItem) objects by searchable attributes, you can use
/// the `"name"`, `"description"`, or `"abbreviation"` attribute in an applicable query filter.
/// </summary>
[Serializable]
public record CatalogQuery : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// A query expression to sort returned query result by the given attribute.
    /// </summary>
    [JsonPropertyName("sorted_attribute_query")]
    public CatalogQuerySortedAttribute? SortedAttributeQuery { get; set; }

    /// <summary>
    /// An exact query expression to return objects with attribute name and value
    /// matching the specified attribute name and value exactly. Value matching is case insensitive.
    /// </summary>
    [JsonPropertyName("exact_query")]
    public CatalogQueryExact? ExactQuery { get; set; }

    /// <summary>
    /// A set query expression to return objects with attribute name and value
    /// matching the specified attribute name and any of the specified attribute values exactly.
    /// Value matching is case insensitive.
    /// </summary>
    [JsonPropertyName("set_query")]
    public CatalogQuerySet? SetQuery { get; set; }

    /// <summary>
    /// A prefix query expression to return objects with attribute values
    /// that have a prefix matching the specified string value. Value matching is case insensitive.
    /// </summary>
    [JsonPropertyName("prefix_query")]
    public CatalogQueryPrefix? PrefixQuery { get; set; }

    /// <summary>
    /// A range query expression to return objects with numeric values
    /// that lie in the specified range.
    /// </summary>
    [JsonPropertyName("range_query")]
    public CatalogQueryRange? RangeQuery { get; set; }

    /// <summary>
    /// A text query expression to return objects whose searchable attributes contain all of the given
    /// keywords, irrespective of their order. For example, if a `CatalogItem` contains custom attribute values of
    /// `{"name": "t-shirt"}` and `{"description": "Small, Purple"}`, the query filter of `{"keywords": ["shirt", "sma", "purp"]}`
    /// returns this item.
    /// </summary>
    [JsonPropertyName("text_query")]
    public CatalogQueryText? TextQuery { get; set; }

    /// <summary>
    /// A query expression to return items that have any of the specified taxes (as identified by the corresponding `CatalogTax` object IDs) enabled.
    /// </summary>
    [JsonPropertyName("items_for_tax_query")]
    public CatalogQueryItemsForTax? ItemsForTaxQuery { get; set; }

    /// <summary>
    /// A query expression to return items that have any of the given modifier list (as identified by the corresponding `CatalogModifierList`s IDs) enabled.
    /// </summary>
    [JsonPropertyName("items_for_modifier_list_query")]
    public CatalogQueryItemsForModifierList? ItemsForModifierListQuery { get; set; }

    /// <summary>
    /// A query expression to return items that contains the specified item options (as identified the corresponding `CatalogItemOption` IDs).
    /// </summary>
    [JsonPropertyName("items_for_item_options_query")]
    public CatalogQueryItemsForItemOptions? ItemsForItemOptionsQuery { get; set; }

    /// <summary>
    /// A query expression to return item variations (of the [CatalogItemVariation](entity:CatalogItemVariation) type) that
    /// contain all of the specified `CatalogItemOption` IDs.
    /// </summary>
    [JsonPropertyName("item_variations_for_item_option_values_query")]
    public CatalogQueryItemVariationsForItemOptionValues? ItemVariationsForItemOptionValuesQuery { get; set; }

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
