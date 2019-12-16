## Create Order Request

### Structure

`CreateOrderRequest`

### Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Order` | [`Models.Order`](/doc/models/order.md) | Optional | Contains all information related to a single order to process with Square,<br>including line items that specify the products to purchase. Order objects also<br>include information on any associated tenders, refunds, and returns.<br><br>All Connect V2 Transactions have all been converted to Orders including all associated<br>itemization data. |
| `IdempotencyKey` | `string` | Optional | A value you specify that uniquely identifies this<br>order among orders you've created.<br><br>If you're unsure whether a particular order was created successfully,<br>you can reattempt it with the same idempotency key without<br>worrying about creating duplicate orders.<br><br>See [Idempotency](https://developer.squareup.com/docs/basics/api101/idempotency) for more information. |
| `ReferenceId` | `string` | Optional | __Deprecated__: Please set the reference_id on the nested [order](#type-order) field<br>instead.<br><br>An optional ID you can associate with the order for your own<br>purposes (such as to associate the order with an entity ID in your<br>own database).<br><br>This value cannot exceed 40 characters. |
| `LineItems` | [`IList<Models.CreateOrderRequestLineItem>`](/doc/models/create-order-request-line-item.md) | Optional | __Deprecated__: Please set the line_items on the nested [order](#type-order) field<br>instead.<br><br>The line items to associate with this order.<br><br>Each line item represents a different product to include in a purchase. |
| `Taxes` | [`IList<Models.CreateOrderRequestTax>`](/doc/models/create-order-request-tax.md) | Optional | __Deprecated__: Please set the taxes on the nested [order](#type-order) field instead.<br><br>The taxes to include on the order. |
| `Discounts` | [`IList<Models.CreateOrderRequestDiscount>`](/doc/models/create-order-request-discount.md) | Optional | __Deprecated__: Please set the discounts on the nested [order](#type-order) field instead.<br><br>The discounts to include on the order. |

### Example (as JSON)

```json
{
  "order": null,
  "idempotency_key": null,
  "reference_id": null,
  "line_items": null,
  "taxes": null,
  "discounts": null
}
```

