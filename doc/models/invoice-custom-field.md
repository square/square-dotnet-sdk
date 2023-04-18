
# Invoice Custom Field

An additional seller-defined and customer-facing field to include on the invoice. For more information,
see [Custom fields](https://developer.squareup.com/docs/invoices-api/overview#custom-fields).

Adding custom fields to an invoice requires an
[Invoices Plus subscription](https://developer.squareup.com/docs/invoices-api/overview#invoices-plus-subscription).

## Structure

`InvoiceCustomField`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Label` | `string` | Optional | The label or title of the custom field. This field is required for a custom field.<br>**Constraints**: *Maximum Length*: `30` |
| `MValue` | `string` | Optional | The text of the custom field. If omitted, only the label is rendered.<br>**Constraints**: *Maximum Length*: `2000` |
| `Placement` | [`string`](../../doc/models/invoice-custom-field-placement.md) | Optional | Indicates where to render a custom field on the Square-hosted invoice page and in emailed or PDF<br>copies of the invoice. |

## Example (as JSON)

```json
{
  "label": "label0",
  "value": "value2",
  "placement": "ABOVE_LINE_ITEMS"
}
```

