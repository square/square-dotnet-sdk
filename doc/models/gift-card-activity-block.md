
# Gift Card Activity Block

Represents details about a `BLOCK` [gift card activity type](../../doc/models/gift-card-activity-type.md).

## Structure

`GiftCardActivityBlock`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Reason` | `string` | Required, Constant | Indicates the reason for blocking a [gift card](../../doc/models/gift-card.md).<br>**Default**: `"CHARGEBACK_BLOCK"` |

## Example (as JSON)

```json
{
  "reason": "CHARGEBACK_BLOCK"
}
```

