
# Search Subscriptions Filter

Represents a set of query expressions (filters) to narrow the scope of targeted subscriptions returned by
the [SearchSubscriptions](../../doc/api/subscriptions.md#search-subscriptions) endpoint.

## Structure

`SearchSubscriptionsFilter`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `CustomerIds` | `IList<string>` | Optional | A filter to select subscriptions based on the subscribing customer IDs. |
| `LocationIds` | `IList<string>` | Optional | A filter to select subscriptions based on the location. |
| `SourceNames` | `IList<string>` | Optional | A filter to select subscriptions based on the source application. |

## Example (as JSON)

```json
{
  "customer_ids": [
    "customer_ids1",
    "customer_ids2"
  ],
  "location_ids": [
    "location_ids0"
  ],
  "source_names": [
    "source_names8"
  ]
}
```

