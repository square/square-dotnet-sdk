
# Create Refund Request

Defines the body parameters that can be included in
a request to the [CreateRefund](api-endpoint:Transactions-CreateRefund) endpoint.

Deprecated - recommend using [RefundPayment](api-endpoint:Refunds-RefundPayment)

## Structure

`CreateRefundRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `IdempotencyKey` | `string` | Required | A value you specify that uniquely identifies this<br>refund among refunds you've created for the tender.<br><br>If you're unsure whether a particular refund succeeded,<br>you can reattempt it with the same idempotency key without<br>worrying about duplicating the refund.<br><br>See [Idempotency keys](https://developer.squareup.com/docs/working-with-apis/idempotency) for more information.<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `192` |
| `TenderId` | `string` | Required | The ID of the tender to refund.<br><br>A [`Transaction`](entity:Transaction) has one or more `tenders` (i.e., methods<br>of payment) associated with it, and you refund each tender separately with<br>the Connect API.<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `192` |
| `Reason` | `string` | Optional | A description of the reason for the refund.<br><br>Default value: `Refund via API`<br>**Constraints**: *Maximum Length*: `192` |
| `AmountMoney` | [`Models.Money`](../../doc/models/money.md) | Required | Represents an amount of money. `Money` fields can be signed or unsigned.<br>Fields that do not explicitly define whether they are signed or unsigned are<br>considered unsigned and can only hold positive amounts. For signed fields, the<br>sign of the value indicates the purpose of the money transfer. See<br>[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)<br>for more information. |

## Example (as JSON)

```json
{
  "amount_money": {
    "amount": 100,
    "currency": "USD"
  },
  "idempotency_key": "86ae1696-b1e3-4328-af6d-f1e04d947ad2",
  "reason": "a reason",
  "tender_id": "MtZRYYdDrYNQbOvV7nbuBvMF"
}
```

