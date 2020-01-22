## Refund Payment Request

Refunds a payment.

### Structure

`RefundPaymentRequest`

### Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `IdempotencyKey` | `string` |  | A unique string that identifies this RefundPayment request. Key can be any valid string but<br>must be unique for every RefundPayment request.<br>For more information, see [Idempotency keys](https://developer.squareup.com/docs/working-with-apis/idempotency). |
| `AmountMoney` | [`Models.Money`](/doc/models/money.md) |  | Represents an amount of money. `Money` fields can be signed or unsigned.<br>Fields that do not explicitly define whether they are signed or unsigned are<br>considered unsigned and can only hold positive amounts. For signed fields, the<br>sign of the value indicates the purpose of the money transfer. See<br>[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)<br>for more information. |
| `AppFeeMoney` | [`Models.Money`](/doc/models/money.md) | Optional | Represents an amount of money. `Money` fields can be signed or unsigned.<br>Fields that do not explicitly define whether they are signed or unsigned are<br>considered unsigned and can only hold positive amounts. For signed fields, the<br>sign of the value indicates the purpose of the money transfer. See<br>[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)<br>for more information. |
| `PaymentId` | `string` |  | Unique ID of the payment being refunded. |
| `Reason` | `string` | Optional | A description of the reason for the refund. |

### Example (as JSON)

```json
{
  "idempotency_key": "a7e36d40-d24b-11e8-b568-0800200c9a66",
  "payment_id": "UNOE3kv2BZwqHlJ830RCt5YCuaB",
  "amount_money": {
    "amount": 100,
    "currency": "USD"
  }
}
```

