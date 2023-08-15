
# Terminal Action Query

## Structure

`TerminalActionQuery`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Filter` | [`TerminalActionQueryFilter`](../../doc/models/terminal-action-query-filter.md) | Optional | - |
| `Sort` | [`TerminalActionQuerySort`](../../doc/models/terminal-action-query-sort.md) | Optional | - |

## Example (as JSON)

```json
{
  "include": [
    "CUSTOMER"
  ],
  "limit": 2,
  "query": {
    "filter": {
      "status": "COMPLETED"
    }
  },
  "filter": {
    "device_id": "device_id0",
    "created_at": {
      "start_at": "start_at4",
      "end_at": "end_at8"
    },
    "status": "status6",
    "type": "SAVE_CARD"
  },
  "sort": {
    "sort_order": "DESC"
  }
}
```

