
# Order Fulfillment Updated Update

Information about fulfillment updates.

## Structure

`OrderFulfillmentUpdatedUpdate`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `FulfillmentUid` | `string` | Optional | A unique ID that identifies the fulfillment only within this order. |
| `OldState` | [`string`](../../doc/models/order-fulfillment-state.md) | Optional | The current state of this fulfillment. |
| `NewState` | [`string`](../../doc/models/order-fulfillment-state.md) | Optional | The current state of this fulfillment. |

## Example (as JSON)

```json
{
  "fulfillment_uid": null,
  "old_state": null,
  "new_state": null
}
```

