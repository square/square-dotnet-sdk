
# Search Shifts Request

A request for a filtered and sorted set of `Shift` objects.

## Structure

`SearchShiftsRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Query` | [`Models.ShiftQuery`](../../doc/models/shift-query.md) | Optional | The parameters of a `Shift` search query, which includes filter and sort options. |
| `Limit` | `int?` | Optional | The number of resources in a page (200 by default).<br>**Constraints**: `>= 1`, `<= 200` |
| `Cursor` | `string` | Optional | An opaque cursor for fetching the next page. |

## Example (as JSON)

```json
{
  "limit": 100,
  "query": {
    "filter": {
      "workday": {
        "date_range": {
          "end_date": "2019-02-03",
          "start_date": "2019-01-20"
        },
        "default_timezone": "America/Los_Angeles",
        "match_shifts_by": "START_AT"
      }
    }
  }
}
```

