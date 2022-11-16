
# Update Order Request

Defines the fields that are included in requests to the
[UpdateOrder](../../doc/api/orders.md#update-order) endpoint.

## Structure

`UpdateOrderRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Order` | [`Models.Order`](../../doc/models/order.md) | Optional | Contains all information related to a single order to process with Square,<br>including line items that specify the products to purchase. `Order` objects also<br>include information about any associated tenders, refunds, and returns.<br><br>All Connect V2 Transactions have all been converted to Orders including all associated<br>itemization data. |
| `FieldsToClear` | `IList<string>` | Optional | The [dot notation paths](https://developer.squareup.com/docs/orders-api/manage-orders/update-orders#identifying-fields-to-delete)<br>fields to clear. For example, `line_items[uid].note`.<br>For more information, see [Deleting fields](https://developer.squareup.com/docs/orders-api/manage-orders/update-orders#deleting-fields). |
| `IdempotencyKey` | `string` | Optional | A value you specify that uniquely identifies this update request.<br><br>If you are unsure whether a particular update was applied to an order successfully,<br>you can reattempt it with the same idempotency key without<br>worrying about creating duplicate updates to the order.<br>The latest order version is returned.<br><br>For more information, see [Idempotency](https://developer.squareup.com/docs/basics/api101/idempotency).<br>**Constraints**: *Maximum Length*: `192` |

## Example (as JSON)

```json
{
  "order": null,
  "fields_to_clear": null,
  "idempotency_key": null
}
```

