
# Shift Query

The parameters of a `Shift` search query, which includes filter and sort options.

## Structure

`ShiftQuery`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Filter` | [`Models.ShiftFilter`](../../doc/models/shift-filter.md) | Optional | Defines a filter used in a search for `Shift` records. `AND` logic is<br>used by Square's servers to apply each filter property specified. |
| `Sort` | [`Models.ShiftSort`](../../doc/models/shift-sort.md) | Optional | Sets the sort order of search results. |

## Example (as JSON)

```json
{
  "filter": {
    "location_ids": [
      "location_ids4"
    ],
    "employee_ids": [
      "employee_ids9"
    ],
    "status": "OPEN",
    "start": {
      "start_at": "start_at0",
      "end_at": "end_at2"
    },
    "end": {
      "start_at": "start_at4",
      "end_at": "end_at8"
    }
  },
  "sort": {
    "field": "START_AT",
    "order": "DESC"
  }
}
```

