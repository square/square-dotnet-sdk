
# Catalog Info Response Limits

## Structure

`CatalogInfoResponseLimits`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `BatchUpsertMaxObjectsPerBatch` | `int?` | Optional | The maximum number of objects that may appear within a single batch in a<br>`/v2/catalog/batch-upsert` request. |
| `BatchUpsertMaxTotalObjects` | `int?` | Optional | The maximum number of objects that may appear across all batches in a<br>`/v2/catalog/batch-upsert` request. |
| `BatchRetrieveMaxObjectIds` | `int?` | Optional | The maximum number of object IDs that may appear in a `/v2/catalog/batch-retrieve`<br>request. |
| `SearchMaxPageLimit` | `int?` | Optional | The maximum number of results that may be returned in a page of a<br>`/v2/catalog/search` response. |
| `BatchDeleteMaxObjectIds` | `int?` | Optional | The maximum number of object IDs that may be included in a single<br>`/v2/catalog/batch-delete` request. |
| `UpdateItemTaxesMaxItemIds` | `int?` | Optional | The maximum number of item IDs that may be included in a single<br>`/v2/catalog/update-item-taxes` request. |
| `UpdateItemTaxesMaxTaxesToEnable` | `int?` | Optional | The maximum number of tax IDs to be enabled that may be included in a single<br>`/v2/catalog/update-item-taxes` request. |
| `UpdateItemTaxesMaxTaxesToDisable` | `int?` | Optional | The maximum number of tax IDs to be disabled that may be included in a single<br>`/v2/catalog/update-item-taxes` request. |
| `UpdateItemModifierListsMaxItemIds` | `int?` | Optional | The maximum number of item IDs that may be included in a single<br>`/v2/catalog/update-item-modifier-lists` request. |
| `UpdateItemModifierListsMaxModifierListsToEnable` | `int?` | Optional | The maximum number of modifier list IDs to be enabled that may be included in<br>a single `/v2/catalog/update-item-modifier-lists` request. |
| `UpdateItemModifierListsMaxModifierListsToDisable` | `int?` | Optional | The maximum number of modifier list IDs to be disabled that may be included in<br>a single `/v2/catalog/update-item-modifier-lists` request. |

## Example (as JSON)

```json
{
  "batch_upsert_max_objects_per_batch": 126,
  "batch_upsert_max_total_objects": 214,
  "batch_retrieve_max_object_ids": 230,
  "search_max_page_limit": 192,
  "batch_delete_max_object_ids": 216
}
```

