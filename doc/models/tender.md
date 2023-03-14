
# Tender

Represents a tender (i.e., a method of payment) used in a Square transaction.

## Structure

`Tender`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Optional | The tender's unique ID. It is the associated payment ID.<br>**Constraints**: *Maximum Length*: `192` |
| `LocationId` | `string` | Optional | The ID of the transaction's associated location.<br>**Constraints**: *Maximum Length*: `50` |
| `TransactionId` | `string` | Optional | The ID of the tender's associated transaction.<br>**Constraints**: *Maximum Length*: `192` |
| `CreatedAt` | `string` | Optional | The timestamp for when the tender was created, in RFC 3339 format.<br>**Constraints**: *Maximum Length*: `32` |
| `Note` | `string` | Optional | An optional note associated with the tender at the time of payment.<br>**Constraints**: *Maximum Length*: `500` |
| `AmountMoney` | [`Models.Money`](../../doc/models/money.md) | Optional | Represents an amount of money. `Money` fields can be signed or unsigned.<br>Fields that do not explicitly define whether they are signed or unsigned are<br>considered unsigned and can only hold positive amounts. For signed fields, the<br>sign of the value indicates the purpose of the money transfer. See<br>[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)<br>for more information. |
| `TipMoney` | [`Models.Money`](../../doc/models/money.md) | Optional | Represents an amount of money. `Money` fields can be signed or unsigned.<br>Fields that do not explicitly define whether they are signed or unsigned are<br>considered unsigned and can only hold positive amounts. For signed fields, the<br>sign of the value indicates the purpose of the money transfer. See<br>[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)<br>for more information. |
| `ProcessingFeeMoney` | [`Models.Money`](../../doc/models/money.md) | Optional | Represents an amount of money. `Money` fields can be signed or unsigned.<br>Fields that do not explicitly define whether they are signed or unsigned are<br>considered unsigned and can only hold positive amounts. For signed fields, the<br>sign of the value indicates the purpose of the money transfer. See<br>[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)<br>for more information. |
| `CustomerId` | `string` | Optional | If the tender is associated with a customer or represents a customer's card on file,<br>this is the ID of the associated customer.<br>**Constraints**: *Maximum Length*: `191` |
| `Type` | [`string`](../../doc/models/tender-type.md) | Required | Indicates a tender's type. |
| `CardDetails` | [`Models.TenderCardDetails`](../../doc/models/tender-card-details.md) | Optional | Represents additional details of a tender with `type` `CARD` or `SQUARE_GIFT_CARD` |
| `CashDetails` | [`Models.TenderCashDetails`](../../doc/models/tender-cash-details.md) | Optional | Represents the details of a tender with `type` `CASH`. |
| `AdditionalRecipients` | [`IList<Models.AdditionalRecipient>`](../../doc/models/additional-recipient.md) | Optional | Additional recipients (other than the merchant) receiving a portion of this tender.<br>For example, fees assessed on the purchase by a third party integration. |
| `PaymentId` | `string` | Optional | The ID of the [Payment](../../doc/models/payment.md) that corresponds to this tender.<br>This value is only present for payments created with the v2 Payments API.<br>**Constraints**: *Maximum Length*: `192` |

## Example (as JSON)

```json
{
  "id": null,
  "location_id": null,
  "transaction_id": null,
  "created_at": null,
  "note": null,
  "amount_money": null,
  "tip_money": null,
  "processing_fee_money": null,
  "customer_id": null,
  "type": "WALLET",
  "card_details": null,
  "cash_details": null,
  "additional_recipients": null,
  "payment_id": null
}
```

