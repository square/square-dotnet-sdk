using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Catalog;

public record SearchCatalogItemsRequest
{
    /// <summary>
    /// The text filter expression to return items or item variations containing specified text in
    /// the `name`, `description`, or `abbreviation` attribute value of an item, or in
    /// the `name`, `sku`, or `upc` attribute value of an item variation.
    /// </summary>
    [JsonPropertyName("text_filter")]
    public string? TextFilter { get; set; }

    /// <summary>
    /// The category id query expression to return items containing the specified category IDs.
    /// </summary>
    [JsonPropertyName("category_ids")]
    public IEnumerable<string>? CategoryIds { get; set; }

    /// <summary>
    /// The stock-level query expression to return item variations with the specified stock levels.
    /// See [SearchCatalogItemsRequestStockLevel](#type-searchcatalogitemsrequeststocklevel) for possible values
    /// </summary>
    [JsonPropertyName("stock_levels")]
    public IEnumerable<SearchCatalogItemsRequestStockLevel>? StockLevels { get; set; }

    /// <summary>
    /// The enabled-location query expression to return items and item variations having specified enabled locations.
    /// </summary>
    [JsonPropertyName("enabled_location_ids")]
    public IEnumerable<string>? EnabledLocationIds { get; set; }

    /// <summary>
    /// The pagination token, returned in the previous response, used to fetch the next batch of pending results.
    /// </summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }

    /// <summary>
    /// The maximum number of results to return per page. The default value is 100.
    /// </summary>
    [JsonPropertyName("limit")]
    public int? Limit { get; set; }

    /// <summary>
    /// The order to sort the results by item names. The default sort order is ascending (`ASC`).
    /// See [SortOrder](#type-sortorder) for possible values
    /// </summary>
    [JsonPropertyName("sort_order")]
    public SortOrder? SortOrder { get; set; }

    /// <summary>
    /// The product types query expression to return items or item variations having the specified product types.
    /// </summary>
    [JsonPropertyName("product_types")]
    public IEnumerable<CatalogItemProductType>? ProductTypes { get; set; }

    /// <summary>
    /// The customer-attribute filter to return items or item variations matching the specified
    /// custom attribute expressions. A maximum number of 10 custom attribute expressions are supported in
    /// a single call to the [SearchCatalogItems](api-endpoint:Catalog-SearchCatalogItems) endpoint.
    /// </summary>
    [JsonPropertyName("custom_attribute_filters")]
    public IEnumerable<CustomAttributeFilter>? CustomAttributeFilters { get; set; }

    /// <summary>
    /// The query filter to return not archived (`ARCHIVED_STATE_NOT_ARCHIVED`), archived (`ARCHIVED_STATE_ARCHIVED`), or either type (`ARCHIVED_STATE_ALL`) of items.
    /// </summary>
    [JsonPropertyName("archived_state")]
    public ArchivedState? ArchivedState { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
