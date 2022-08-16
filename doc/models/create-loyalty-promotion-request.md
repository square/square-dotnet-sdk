
# Create Loyalty Promotion Request

Represents a [CreateLoyaltyPromotion](../../doc/api/loyalty.md#create-loyalty-promotion) request.

## Structure

`CreateLoyaltyPromotionRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `LoyaltyPromotion` | [`Models.LoyaltyPromotion`](../../doc/models/loyalty-promotion.md) | Required | Represents a promotion for a [loyalty program](../../doc/models/loyalty-program.md). Loyalty promotions enable buyers<br>to earn extra points on top of those earned from the base program.<br><br>A loyalty program can have a maximum of 10 loyalty promotions with an `ACTIVE` or `SCHEDULED` status. |
| `IdempotencyKey` | `string` | Required | A unique identifier for this request, which is used to ensure idempotency. For more information,<br>see [Idempotency](https://developer.squareup.com/docs/build-basics/common-api-patterns/idempotency).<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `128` |

## Example (as JSON)

```json
{
  "idempotency_key": "ec78c477-b1c3-4899-a209-a4e71337c996",
  "loyalty_promotion": {
    "available_time": {
      "time_periods": [
        "BEGIN:VEVENT\nDTSTART:20220816T160000\nDURATION:PT2H\nRRULE:FREQ=WEEKLY;BYDAY=TU\nEND:VEVENT"
      ]
    },
    "incentive": {
      "points_multiplier_data": {
        "points_multiplier": 3
      },
      "type": "POINTS_MULTIPLIER"
    },
    "name": "Tuesday Happy Hour Promo",
    "trigger_limit": {
      "interval": "DAY",
      "times": 1
    }
  }
}
```

