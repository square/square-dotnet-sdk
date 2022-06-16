
# Gift Card Activity Unblock

Represents details about an `UNBLOCK` [gift card activity type](../../doc/models/gift-card-activity-type.md).

## Structure

`GiftCardActivityUnblock`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Reason` | `string` | Required, Constant | Indicates the reason for unblocking a [gift card](../../doc/models/gift-card.md).<br>**Default**: `"CHARGEBACK_UNBLOCK"` |

## Example (as JSON)

```json
{
  "reason": "CHARGEBACK_UNBLOCK"
}
```

