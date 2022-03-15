
# Invoice Query

Describes query criteria for searching invoices.

## Structure

`InvoiceQuery`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Filter` | [`Models.InvoiceFilter`](../../doc/models/invoice-filter.md) | Required | Describes query filters to apply. |
| `Sort` | [`Models.InvoiceSort`](../../doc/models/invoice-sort.md) | Optional | Identifies the sort field and sort order. |

## Example (as JSON)

```json
{
  "filter": null,
  "sort": {
    "field": "INVOICE_SORT_DATE"
  }
}
```

