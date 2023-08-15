
# Customer Query

Represents filtering and sorting criteria for a [SearchCustomers](../../doc/api/customers.md#search-customers) request.

## Structure

`CustomerQuery`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Filter` | [`CustomerFilter`](../../doc/models/customer-filter.md) | Optional | Represents the filtering criteria in a [search query](../../doc/models/customer-query.md) that defines how to filter<br>customer profiles returned in [SearchCustomers](../../doc/api/customers.md#search-customers) results. |
| `Sort` | [`CustomerSort`](../../doc/models/customer-sort.md) | Optional | Represents the sorting criteria in a [search query](../../doc/models/customer-query.md) that defines how to sort<br>customer profiles returned in [SearchCustomers](../../doc/api/customers.md#search-customers) results. |

## Example (as JSON)

```json
{
  "filter": {
    "creation_source": {
      "values": [
        "INVOICES",
        "LOYALTY",
        "MARKETING"
      ],
      "rule": "INCLUDE"
    },
    "created_at": {
      "start_at": "start_at4",
      "end_at": "end_at8"
    },
    "updated_at": {
      "start_at": "start_at2",
      "end_at": "end_at0"
    },
    "email_address": {
      "exact": "exact2",
      "fuzzy": "fuzzy2"
    },
    "phone_number": {
      "exact": "exact8",
      "fuzzy": "fuzzy6"
    }
  },
  "sort": {
    "field": "DEFAULT",
    "order": "DESC"
  }
}
```

