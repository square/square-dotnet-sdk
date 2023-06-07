
# Pause Subscription Response

Defines output parameters in a response from the
[PauseSubscription](../../doc/api/subscriptions.md#pause-subscription) endpoint.

## Structure

`PauseSubscriptionResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Errors` | [`IList<Models.Error>`](../../doc/models/error.md) | Optional | Errors encountered during the request. |
| `Subscription` | [`Models.Subscription`](../../doc/models/subscription.md) | Optional | Represents a subscription purchased by a customer.<br><br>For more information, see<br>[Manage Subscriptions](https://developer.squareup.com/docs/subscriptions-api/manage-subscriptions). |
| `Actions` | [`IList<Models.SubscriptionAction>`](../../doc/models/subscription-action.md) | Optional | The list of a `PAUSE` action and a possible `RESUME` action created by the request. |

## Example (as JSON)

```json
{
  "actions": [
    {
      "effective_date": "2021-11-17",
      "id": "99b2439e-63f7-3ad5-95f7-ab2447a80673",
      "type": "PAUSE",
      "phases": [
        {
          "uid": "uid6",
          "ordinal": 186,
          "order_template_id": "order_template_id8",
          "plan_phase_uid": "plan_phase_uid2"
        }
      ],
      "new_plan_variation_id": "new_plan_variation_id9"
    }
  ],
  "subscription": {
    "created_at": "2021-10-20T21:53:10Z",
    "customer_id": "CHFGVKYY8RSV93M5KCYTG4PN0G",
    "id": "9ba40961-995a-4a3d-8c53-048c40cafc13",
    "location_id": "S8GWD5R9QB376",
    "plan_id": "6JHXF3B2CW3YKHDV4XEM674H",
    "price_override_money": {
      "amount": 2000,
      "currency": "USD"
    },
    "source": {
      "name": "My App"
    },
    "status": "ACTIVE",
    "timezone": "America/Los_Angeles",
    "version": 1594311617331,
    "plan_variation_id": "plan_variation_id8",
    "start_date": "start_date8"
  },
  "errors": [
    {
      "category": "AUTHENTICATION_ERROR",
      "code": "REFUND_ALREADY_PENDING",
      "detail": "detail1",
      "field": "field9"
    },
    {
      "category": "INVALID_REQUEST_ERROR",
      "code": "PAYMENT_NOT_REFUNDABLE",
      "detail": "detail2",
      "field": "field0"
    },
    {
      "category": "RATE_LIMIT_ERROR",
      "code": "REFUND_DECLINED",
      "detail": "detail3",
      "field": "field1"
    }
  ]
}
```

