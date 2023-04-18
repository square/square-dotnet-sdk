
# Invoice Filter

Describes query filters to apply.

## Structure

`InvoiceFilter`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `LocationIds` | `IList<string>` | Required | Limits the search to the specified locations. A location is required.<br>In the current implementation, only one location can be specified. |
| `CustomerIds` | `IList<string>` | Optional | Limits the search to the specified customers, within the specified locations.<br>Specifying a customer is optional. In the current implementation,<br>a maximum of one customer can be specified. |

## Example (as JSON)

```json
{
  "location_ids": [
    "location_ids0"
  ],
  "customer_ids": [
    "customer_ids1",
    "customer_ids2"
  ]
}
```

