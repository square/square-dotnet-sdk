
# Order Fulfillment Updated

## Structure

`OrderFulfillmentUpdated`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `OrderId` | `string` | Optional | The order's unique ID. |
| `Version` | `int?` | Optional | The version number, which is incremented each time an update is committed to the order.<br>Orders that were not created through the API do not include a version number and<br>therefore cannot be updated.<br><br>[Read more about working with versions.](https://developer.squareup.com/docs/orders-api/manage-orders#update-orders) |
| `LocationId` | `string` | Optional | The ID of the seller location that this order is associated with. |
| `State` | [`string`](../../doc/models/order-state.md) | Optional | The state of the order. |
| `CreatedAt` | `string` | Optional | The timestamp for when the order was created, in RFC 3339 format. |
| `UpdatedAt` | `string` | Optional | The timestamp for when the order was last updated, in RFC 3339 format. |
| `FulfillmentUpdate` | [`IList<Models.OrderFulfillmentUpdatedUpdate>`](../../doc/models/order-fulfillment-updated-update.md) | Optional | The fulfillments that were updated with this version change. |

## Example (as JSON)

```json
{
  "order_id": null,
  "version": null,
  "location_id": null,
  "state": null,
  "created_at": null,
  "updated_at": null,
  "fulfillment_update": null
}
```

