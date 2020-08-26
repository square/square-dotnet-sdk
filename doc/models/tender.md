## Tender

Represents a tender (i.e., a method of payment) used in a Square transaction.

### Structure

`Tender`

### Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Optional | The tender's unique ID. |
| `LocationId` | `string` | Optional | The ID of the transaction's associated location. |
| `TransactionId` | `string` | Optional | The ID of the tender's associated transaction. |
| `CreatedAt` | `string` | Optional | The timestamp for when the tender was created, in RFC 3339 format. |
| `Note` | `string` | Optional | An optional note associated with the tender at the time of payment. |
| `AmountMoney` | [`Models.Money`](/doc/models/money.md) | Optional | Represents an amount of money. `Money` fields can be signed or unsigned.<br>Fields that do not explicitly define whether they are signed or unsigned are<br>considered unsigned and can only hold positive amounts. For signed fields, the<br>sign of the value indicates the purpose of the money transfer. See<br>[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)<br>for more information. |
| `TipMoney` | [`Models.Money`](/doc/models/money.md) | Optional | Represents an amount of money. `Money` fields can be signed or unsigned.<br>Fields that do not explicitly define whether they are signed or unsigned are<br>considered unsigned and can only hold positive amounts. For signed fields, the<br>sign of the value indicates the purpose of the money transfer. See<br>[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)<br>for more information. |
| `ProcessingFeeMoney` | [`Models.Money`](/doc/models/money.md) | Optional | Represents an amount of money. `Money` fields can be signed or unsigned.<br>Fields that do not explicitly define whether they are signed or unsigned are<br>considered unsigned and can only hold positive amounts. For signed fields, the<br>sign of the value indicates the purpose of the money transfer. See<br>[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)<br>for more information. |
| `CustomerId` | `string` | Optional | If the tender is associated with a customer or represents a customer's card on file,<br>this is the ID of the associated customer. |
| `Type` | [`string`](/doc/models/tender-type.md) |  | Indicates a tender's type. |
| `CardDetails` | [`Models.TenderCardDetails`](/doc/models/tender-card-details.md) | Optional | Represents additional details of a tender with `type` `CARD` or `SQUARE_GIFT_CARD` |
| `CashDetails` | [`Models.TenderCashDetails`](/doc/models/tender-cash-details.md) | Optional | Represents the details of a tender with `type` `CASH`. |
| `BankTransferDetails` | [`Models.TenderBankTransferDetails`](/doc/models/tender-bank-transfer-details.md) | Optional | Represents the details of a tender with `type` `BANK_TRANSFER`.<br><br>See [PaymentBankTransferDetails](#type-paymentbanktransferdetails) for more exposed details of a bank transfer payment. |
| `AdditionalRecipients` | [`IList<Models.AdditionalRecipient>`](/doc/models/additional-recipient.md) | Optional | Additional recipients (other than the merchant) receiving a portion of this tender.<br>For example, fees assessed on the purchase by a third party integration. |
| `PaymentId` | `string` | Optional | The ID of the [Payment](#type-payment) that corresponds to this tender.<br>This value is only present for payments created with the v2 Payments API. |

### Example (as JSON)

```json
{
  "id": "id0",
  "location_id": "location_id4",
  "transaction_id": "transaction_id8",
  "created_at": "created_at2",
  "note": "note4",
  "type": "BANK_TRANSFER"
}
```

