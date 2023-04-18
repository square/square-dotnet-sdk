
# List Workweek Configs Request

A request for a set of `WorkweekConfig` objects.

## Structure

`ListWorkweekConfigsRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Limit` | `int?` | Optional | The maximum number of `WorkweekConfigs` results to return per page. |
| `Cursor` | `string` | Optional | A pointer to the next page of `WorkweekConfig` results to fetch. |

## Example (as JSON)

```json
{
  "limit": 172,
  "cursor": "cursor6"
}
```

