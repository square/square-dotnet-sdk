
# Gift Card Activity

Represents an action performed on a gift card that affects its state or balance.

## Structure

`GiftCardActivity`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Optional | The unique ID of the gift card activity. |
| `Type` | [`string`](/doc/models/gift-card-activity-type.md) | Required | - |
| `LocationId` | `string` | Required | The ID of the location at which the activity occurred. |
| `CreatedAt` | `string` | Optional | The timestamp when the gift card activity was created, in RFC 3339 format. |
| `GiftCardId` | `string` | Optional | The gift card ID. The ID is not required if a GAN is present. |
| `GiftCardGan` | `string` | Optional | The gift card GAN. The GAN is not required if `gift_card_id` is present. |
| `GiftCardBalanceMoney` | [`Models.Money`](/doc/models/money.md) | Optional | Represents an amount of money. `Money` fields can be signed or unsigned.<br>Fields that do not explicitly define whether they are signed or unsigned are<br>considered unsigned and can only hold positive amounts. For signed fields, the<br>sign of the value indicates the purpose of the money transfer. See<br>[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)<br>for more information. |
| `LoadActivityDetails` | [`Models.GiftCardActivityLoad`](/doc/models/gift-card-activity-load.md) | Optional | Present only when `GiftCardActivityType` is LOAD. |
| `ActivateActivityDetails` | [`Models.GiftCardActivityActivate`](/doc/models/gift-card-activity-activate.md) | Optional | Describes a gift card activity of the ACTIVATE type. |
| `RedeemActivityDetails` | [`Models.GiftCardActivityRedeem`](/doc/models/gift-card-activity-redeem.md) | Optional | Present only when `GiftCardActivityType` is REDEEM. |
| `ClearBalanceActivityDetails` | [`Models.GiftCardActivityClearBalance`](/doc/models/gift-card-activity-clear-balance.md) | Optional | Describes a gift card activity of the CLEAR_BALANCE type. |
| `DeactivateActivityDetails` | [`Models.GiftCardActivityDeactivate`](/doc/models/gift-card-activity-deactivate.md) | Optional | Describes a gift card activity of the DEACTIVATE type. |
| `AdjustIncrementActivityDetails` | [`Models.GiftCardActivityAdjustIncrement`](/doc/models/gift-card-activity-adjust-increment.md) | Optional | Describes a gift card activity of the ADJUST_INCREMENT type. |
| `AdjustDecrementActivityDetails` | [`Models.GiftCardActivityAdjustDecrement`](/doc/models/gift-card-activity-adjust-decrement.md) | Optional | Describes a gift card activity of the ADJUST_DECREMENT type. |
| `RefundActivityDetails` | [`Models.GiftCardActivityRefund`](/doc/models/gift-card-activity-refund.md) | Optional | Present only when `GiftCardActivityType` is REFUND. |
| `UnlinkedActivityRefundActivityDetails` | [`Models.GiftCardActivityUnlinkedActivityRefund`](/doc/models/gift-card-activity-unlinked-activity-refund.md) | Optional | Present only when `GiftCardActivityType` is UNLINKED_ACTIVITY_REFUND. |
| `ImportActivityDetails` | [`Models.GiftCardActivityImport`](/doc/models/gift-card-activity-import.md) | Optional | Describes a gift card activity of the IMPORT type and the `GiftCardGANSource` is OTHER<br>(a third-party gift card). |
| `BlockActivityDetails` | [`Models.GiftCardActivityBlock`](/doc/models/gift-card-activity-block.md) | Optional | Describes a gift card activity of the BLOCK type. |
| `UnblockActivityDetails` | [`Models.GiftCardActivityUnblock`](/doc/models/gift-card-activity-unblock.md) | Optional | Present only when `GiftCardActivityType` is UNBLOCK. |
| `ImportReversalActivityDetails` | [`Models.GiftCardActivityImportReversal`](/doc/models/gift-card-activity-import-reversal.md) | Optional | Present only when GiftCardActivityType is IMPORT_REVERSAL and GiftCardGANSource is OTHER |

## Example (as JSON)

```json
{
  "id": "id0",
  "type": "ADJUST_INCREMENT",
  "location_id": "location_id4",
  "created_at": "created_at2",
  "gift_card_id": "gift_card_id8",
  "gift_card_gan": "gift_card_gan6",
  "gift_card_balance_money": {
    "amount": 82,
    "currency": "LSL"
  }
}
```

