## V1 Update Order Request

V1UpdateOrderRequest

### Structure

`V1UpdateOrderRequest`

### Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Action` | [`string`](/doc/models/v1-update-order-request-action.md) |  | - |
| `ShippedTrackingNumber` | `string` | Optional | The tracking number of the shipment associated with the order. Only valid if action is COMPLETE. |
| `CompletedNote` | `string` | Optional | A merchant-specified note about the completion of the order. Only valid if action is COMPLETE. |
| `RefundedNote` | `string` | Optional | A merchant-specified note about the refunding of the order. Only valid if action is REFUND. |
| `CanceledNote` | `string` | Optional | A merchant-specified note about the canceling of the order. Only valid if action is CANCEL. |

### Example (as JSON)

```json
{
  "action": "COMPLETE",
  "shipped_tracking_number": "shipped_tracking_number0",
  "completed_note": "completed_note0",
  "refunded_note": "refunded_note4",
  "canceled_note": "canceled_note0"
}
```

