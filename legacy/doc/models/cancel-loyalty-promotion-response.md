
# Cancel Loyalty Promotion Response

Represents a [CancelLoyaltyPromotion](../../doc/api/loyalty.md#cancel-loyalty-promotion) response.
Either `loyalty_promotion` or `errors` is present in the response.

## Structure

`CancelLoyaltyPromotionResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Errors` | [`IList<Error>`](../../doc/models/error.md) | Optional | Any errors that occurred during the request. |
| `LoyaltyPromotion` | [`LoyaltyPromotion`](../../doc/models/loyalty-promotion.md) | Optional | Represents a promotion for a [loyalty program](../../doc/models/loyalty-program.md). Loyalty promotions enable buyers<br>to earn extra points on top of those earned from the base program.<br><br>A loyalty program can have a maximum of 10 loyalty promotions with an `ACTIVE` or `SCHEDULED` status. |

## Example (as JSON)

```json
{
  "loyalty_promotion": {
    "available_time": {
      "start_date": "2022-08-16",
      "time_periods": [
        "BEGIN:VEVENT\nDTSTART:20220816T160000\nDURATION:PT2H\nRRULE:FREQ=WEEKLY;BYDAY=TU\nEND:VEVENT"
      ],
      "end_date": "end_date8"
    },
    "canceled_at": "2022-08-17T12:42:49Z",
    "created_at": "2022-08-16T08:38:54Z",
    "id": "loypromo_f0f9b849-725e-378d-b810-511237e07b67",
    "incentive": {
      "points_multiplier_data": {
        "multiplier": "3.000",
        "points_multiplier": 3
      },
      "type": "POINTS_MULTIPLIER",
      "points_addition_data": {
        "points_addition": 218
      }
    },
    "loyalty_program_id": "d619f755-2d17-41f3-990d-c04ecedd64dd",
    "minimum_spend_amount_money": {
      "amount": 2000,
      "currency": "USD"
    },
    "name": "Tuesday Happy Hour Promo",
    "qualifying_category_ids": [
      "XTQPYLR3IIU9C44VRCB3XD12"
    ],
    "status": "CANCELED",
    "trigger_limit": {
      "interval": "DAY",
      "times": 1
    },
    "updated_at": "2022-08-17T12:42:49Z"
  },
  "errors": [
    {
      "category": "MERCHANT_SUBSCRIPTION_ERROR",
      "code": "INVALID_EXPIRATION",
      "detail": "detail6",
      "field": "field4"
    },
    {
      "category": "MERCHANT_SUBSCRIPTION_ERROR",
      "code": "INVALID_EXPIRATION",
      "detail": "detail6",
      "field": "field4"
    },
    {
      "category": "MERCHANT_SUBSCRIPTION_ERROR",
      "code": "INVALID_EXPIRATION",
      "detail": "detail6",
      "field": "field4"
    }
  ]
}
```

