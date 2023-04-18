
# Catalog Query Items for Item Options

The query filter to return the items containing the specified item option IDs.

## Structure

`CatalogQueryItemsForItemOptions`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `ItemOptionIds` | `IList<string>` | Optional | A set of `CatalogItemOption` IDs to be used to find associated<br>`CatalogItem`s. All Items that contain all of the given Item Options (in any order)<br>will be returned. |

## Example (as JSON)

```json
{
  "item_option_ids": [
    "item_option_ids9"
  ]
}
```

