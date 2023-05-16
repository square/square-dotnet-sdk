
# Gift Card Activity

Represents an action performed on a [gift card](../../doc/models/gift-card.md) that affects its state or balance.
A gift card activity contains information about a specific activity type. For example, a `REDEEM` activity
includes a `redeem_activity_details` field that contains information about the redemption.

## Structure

`GiftCardActivity`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Optional | The Square-assigned ID of the gift card activity. |
| `Type` | [`string`](../../doc/models/gift-card-activity-type.md) | Required | Indicates the type of [gift card activity](../../doc/models/gift-card-activity.md). |
| `LocationId` | `string` | Required | The ID of the [business location](entity:Location) where the activity occurred. |
| `CreatedAt` | `string` | Optional | The timestamp when the gift card activity was created, in RFC 3339 format. |
| `GiftCardId` | `string` | Optional | The gift card ID. When creating a gift card activity, `gift_card_id` is not required if<br>`gift_card_gan` is specified. |
| `GiftCardGan` | `string` | Optional | The gift card account number (GAN). When creating a gift card activity, `gift_card_gan`<br>is not required if `gift_card_id` is specified. |
| `GiftCardBalanceMoney` | [`Models.Money`](../../doc/models/money.md) | Optional | Represents an amount of money. `Money` fields can be signed or unsigned.<br>Fields that do not explicitly define whether they are signed or unsigned are<br>considered unsigned and can only hold positive amounts. For signed fields, the<br>sign of the value indicates the purpose of the money transfer. See<br>[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)<br>for more information. |
| `LoadActivityDetails` | [`Models.GiftCardActivityLoad`](../../doc/models/gift-card-activity-load.md) | Optional | Represents details about a `LOAD` [gift card activity type](../../doc/models/gift-card-activity-type.md). |
| `ActivateActivityDetails` | [`Models.GiftCardActivityActivate`](../../doc/models/gift-card-activity-activate.md) | Optional | Represents details about an `ACTIVATE` [gift card activity type](../../doc/models/gift-card-activity-type.md). |
| `RedeemActivityDetails` | [`Models.GiftCardActivityRedeem`](../../doc/models/gift-card-activity-redeem.md) | Optional | Represents details about a `REDEEM` [gift card activity type](../../doc/models/gift-card-activity-type.md). |
| `ClearBalanceActivityDetails` | [`Models.GiftCardActivityClearBalance`](../../doc/models/gift-card-activity-clear-balance.md) | Optional | Represents details about a `CLEAR_BALANCE` [gift card activity type](../../doc/models/gift-card-activity-type.md). |
| `DeactivateActivityDetails` | [`Models.GiftCardActivityDeactivate`](../../doc/models/gift-card-activity-deactivate.md) | Optional | Represents details about a `DEACTIVATE` [gift card activity type](../../doc/models/gift-card-activity-type.md). |
| `AdjustIncrementActivityDetails` | [`Models.GiftCardActivityAdjustIncrement`](../../doc/models/gift-card-activity-adjust-increment.md) | Optional | Represents details about an `ADJUST_INCREMENT` [gift card activity type](../../doc/models/gift-card-activity-type.md). |
| `AdjustDecrementActivityDetails` | [`Models.GiftCardActivityAdjustDecrement`](../../doc/models/gift-card-activity-adjust-decrement.md) | Optional | Represents details about an `ADJUST_DECREMENT` [gift card activity type](../../doc/models/gift-card-activity-type.md). |
| `RefundActivityDetails` | [`Models.GiftCardActivityRefund`](../../doc/models/gift-card-activity-refund.md) | Optional | Represents details about a `REFUND` [gift card activity type](../../doc/models/gift-card-activity-type.md). |
| `UnlinkedActivityRefundActivityDetails` | [`Models.GiftCardActivityUnlinkedActivityRefund`](../../doc/models/gift-card-activity-unlinked-activity-refund.md) | Optional | Represents details about an `UNLINKED_ACTIVITY_REFUND` [gift card activity type](../../doc/models/gift-card-activity-type.md). |
| `ImportActivityDetails` | [`Models.GiftCardActivityImport`](../../doc/models/gift-card-activity-import.md) | Optional | Represents details about an `IMPORT` [gift card activity type](../../doc/models/gift-card-activity-type.md).<br>This activity type is used when Square imports a third-party gift card, in which case the<br>`gan_source` of the gift card is set to `OTHER`. |
| `BlockActivityDetails` | [`Models.GiftCardActivityBlock`](../../doc/models/gift-card-activity-block.md) | Optional | Represents details about a `BLOCK` [gift card activity type](../../doc/models/gift-card-activity-type.md). |
| `UnblockActivityDetails` | [`Models.GiftCardActivityUnblock`](../../doc/models/gift-card-activity-unblock.md) | Optional | Represents details about an `UNBLOCK` [gift card activity type](../../doc/models/gift-card-activity-type.md). |
| `ImportReversalActivityDetails` | [`Models.GiftCardActivityImportReversal`](../../doc/models/gift-card-activity-import-reversal.md) | Optional | Represents details about an `IMPORT_REVERSAL` [gift card activity type](../../doc/models/gift-card-activity-type.md). |
| `TransferBalanceToActivityDetails` | [`Models.GiftCardActivityTransferBalanceTo`](../../doc/models/gift-card-activity-transfer-balance-to.md) | Optional | Represents details about a `TRANSFER_BALANCE_TO` [gift card activity type](../../doc/models/gift-card-activity-type.md). |
| `TransferBalanceFromActivityDetails` | [`Models.GiftCardActivityTransferBalanceFrom`](../../doc/models/gift-card-activity-transfer-balance-from.md) | Optional | Represents details about a `TRANSFER_BALANCE_FROM` [gift card activity type](../../doc/models/gift-card-activity-type.md). |

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

