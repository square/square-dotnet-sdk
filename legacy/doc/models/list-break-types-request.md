
# List Break Types Request

A request for a filtered set of `BreakType` objects.

## Structure

`ListBreakTypesRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `LocationId` | `string` | Optional | Filter the returned `BreakType` results to only those that are associated with the<br>specified location. |
| `Limit` | `int?` | Optional | The maximum number of `BreakType` results to return per page. The number can range between 1<br>and 200. The default is 200.<br>**Constraints**: `>= 1`, `<= 200` |
| `Cursor` | `string` | Optional | A pointer to the next page of `BreakType` results to fetch. |

## Example (as JSON)

```json
{
  "location_id": "location_id6",
  "limit": 244,
  "cursor": "cursor4"
}
```

