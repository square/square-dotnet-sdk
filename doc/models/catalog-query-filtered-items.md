## Catalog Query Filtered Items

### Structure

`CatalogQueryFilteredItems`

### Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `TextFilter` | `string` | Optional | - |
| `SearchVendorCode` | `bool?` | Optional | - |
| `CategoryIds` | `IList<string>` | Optional | - |
| `StockLevels` | [`IList<string>`](/doc/models/catalog-query-filtered-items-stock-level.md) | Optional | See [CatalogQueryFilteredItemsStockLevel](#type-catalogqueryfiltereditemsstocklevel) for possible values |
| `EnabledLocationIds` | `IList<string>` | Optional | - |
| `VendorIds` | `IList<string>` | Optional | - |
| `ProductTypes` | [`IList<string>`](/doc/models/catalog-item-product-type.md) | Optional | See [CatalogItemProductType](#type-catalogitemproducttype) for possible values |
| `CustomAttributeFilters` | [`IList<Models.CatalogQueryFilteredItemsCustomAttributeFilter>`](/doc/models/catalog-query-filtered-items-custom-attribute-filter.md) | Optional | - |
| `DoesNotExist` | [`IList<string>`](/doc/models/catalog-query-filtered-items-nullable-attribute.md) | Optional | See [CatalogQueryFilteredItemsNullableAttribute](#type-catalogqueryfiltereditemsnullableattribute) for possible values |
| `SortOrder` | [`string`](/doc/models/sort-order.md) | Optional | The order (e.g., chronological or alphabetical) in which results from a request are returned. |

### Example (as JSON)

```json
{
  "text_filter": null,
  "search_vendor_code": null,
  "category_ids": null,
  "stock_levels": null,
  "enabled_location_ids": null,
  "vendor_ids": null,
  "product_types": null,
  "custom_attribute_filters": null,
  "does_not_exist": null,
  "sort_order": null
}
```

