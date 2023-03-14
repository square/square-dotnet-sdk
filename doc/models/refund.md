
# Refund

Represents a refund processed for a Square transaction.

## Structure

`Refund`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Required | The refund's unique ID.<br>**Constraints**: *Maximum Length*: `255` |
| `LocationId` | `string` | Required | The ID of the refund's associated location.<br>**Constraints**: *Maximum Length*: `50` |
| `TransactionId` | `string` | Optional | The ID of the transaction that the refunded tender is part of.<br>**Constraints**: *Maximum Length*: `192` |
| `TenderId` | `string` | Required | The ID of the refunded tender.<br>**Constraints**: *Maximum Length*: `192` |
| `CreatedAt` | `string` | Optional | The timestamp for when the refund was created, in RFC 3339 format.<br>**Constraints**: *Maximum Length*: `32` |
| `Reason` | `string` | Required | The reason for the refund being issued.<br>**Constraints**: *Maximum Length*: `192` |
| `AmountMoney` | [`Models.Money`](../../doc/models/money.md) | Required | Represents an amount of money. `Money` fields can be signed or unsigned.<br>Fields that do not explicitly define whether they are signed or unsigned are<br>considered unsigned and can only hold positive amounts. For signed fields, the<br>sign of the value indicates the purpose of the money transfer. See<br>[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)<br>for more information. |
| `Status` | [`string`](../../doc/models/refund-status.md) | Required | Indicates a refund's current status. |
| `ProcessingFeeMoney` | [`Models.Money`](../../doc/models/money.md) | Optional | Represents an amount of money. `Money` fields can be signed or unsigned.<br>Fields that do not explicitly define whether they are signed or unsigned are<br>considered unsigned and can only hold positive amounts. For signed fields, the<br>sign of the value indicates the purpose of the money transfer. See<br>[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)<br>for more information. |
| `AdditionalRecipients` | [`IList<Models.AdditionalRecipient>`](../../doc/models/additional-recipient.md) | Optional | Additional recipients (other than the merchant) receiving a portion of this refund.<br>For example, fees assessed on a refund of a purchase by a third party integration. |

## Example (as JSON)

```json
{
  "id": "id0",
  "location_id": "location_id4",
  "transaction_id": null,
  "tender_id": "tender_id8",
  "created_at": null,
  "reason": "reason4",
  "amount_money": {
    "amount": null,
    "currency": null
  },
  "status": "PENDING",
  "processing_fee_money": null,
  "additional_recipients": null
}
```

