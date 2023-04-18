
# Retrieve Inventory Changes Request

## Structure

`RetrieveInventoryChangesRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `LocationIds` | `string` | Optional | The [Location](entity:Location) IDs to look up as a comma-separated<br>list. An empty list queries all locations. |
| `Cursor` | `string` | Optional | A pagination cursor returned by a previous call to this endpoint.<br>Provide this to retrieve the next set of results for the original query.<br><br>See the [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination) guide for more information. |

## Example (as JSON)

```json
{
  "location_ids": "location_ids0",
  "cursor": "cursor6"
}
```

