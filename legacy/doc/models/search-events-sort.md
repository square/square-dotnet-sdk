
# Search Events Sort

Criteria to sort events by.

## Structure

`SearchEventsSort`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Field` | [`string`](../../doc/models/search-events-sort-field.md) | Optional | Specifies the sort key for events returned from a search. |
| `Order` | [`string`](../../doc/models/sort-order.md) | Optional | The order (e.g., chronological or alphabetical) in which results from a request are returned. |

## Example (as JSON)

```json
{
  "field": "DEFAULT",
  "order": "DESC"
}
```

