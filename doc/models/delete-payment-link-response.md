
# Delete Payment Link Response

## Structure

`DeletePaymentLinkResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Errors` | [`IList<Models.Error>`](../../doc/models/error.md) | Optional | - |
| `Id` | `string` | Optional | The ID of the link that is deleted. |
| `CancelledOrderId` | `string` | Optional | The ID of the order that is canceled. When a payment link is deleted, Square updates the<br>the `state` (of the order that the checkout link created) to CANCELED. |

## Example (as JSON)

```json
{
  "cancelled_order_id": "asx8LgZ6MRzD0fObfkJ6obBmSh4F",
  "id": "MQASNYL6QB6DFCJ3"
}
```

