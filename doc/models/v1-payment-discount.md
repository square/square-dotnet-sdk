
# V1 Payment Discount

V1PaymentDiscount

## Structure

`V1PaymentDiscount`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Name` | `string` | Optional | The discount's name. |
| `AppliedMoney` | [`Models.V1Money`](../../doc/models/v1-money.md) | Optional | - |
| `DiscountId` | `string` | Optional | The ID of the applied discount, if available. Discounts applied in older versions of Square Register might not have an ID. |

## Example (as JSON)

```json
{
  "name": "name0",
  "applied_money": {
    "amount": 196,
    "currency_code": "LYD"
  },
  "discount_id": "discount_id8"
}
```

