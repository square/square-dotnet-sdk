
# Subscription Pricing

Describes the pricing for the subscription.

## Structure

`SubscriptionPricing`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Type` | [`string`](../../doc/models/subscription-pricing-type.md) | Optional | Determines the pricing of a [Subscription](../../doc/models/subscription.md) |
| `DiscountIds` | `IList<string>` | Optional | The ids of the discount catalog objects |
| `PriceMoney` | [`Models.Money`](../../doc/models/money.md) | Optional | Represents an amount of money. `Money` fields can be signed or unsigned.<br>Fields that do not explicitly define whether they are signed or unsigned are<br>considered unsigned and can only hold positive amounts. For signed fields, the<br>sign of the value indicates the purpose of the money transfer. See<br>[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)<br>for more information. |

## Example (as JSON)

```json
{
  "type": "STATIC",
  "discount_ids": [
    "discount_ids1",
    "discount_ids2"
  ],
  "price_money": {
    "amount": 202,
    "currency": "BBD"
  }
}
```

