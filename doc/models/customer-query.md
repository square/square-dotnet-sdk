## Customer Query

Represents a query (filtering and sorting criteria) used to search
for customer profiles.

### Structure

`CustomerQuery`

### Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Filter` | [`Models.CustomerFilter`](/doc/models/customer-filter.md) | Optional | Represents a set of `CustomerQuery` filters used to limit the set of<br>`Customers` returned by SearchCustomers. |
| `Sort` | [`Models.CustomerSort`](/doc/models/customer-sort.md) | Optional | Indicates the field to use for sorting customer profiles. |

### Example (as JSON)

```json
{
  "filter": null,
  "sort": null
}
```

