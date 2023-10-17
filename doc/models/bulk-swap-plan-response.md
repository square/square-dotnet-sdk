
# Bulk Swap Plan Response

Defines output parameters in a response of the
[BulkSwapPlan](../../doc/api/subscriptions.md#bulk-swap-plan) endpoint.

## Structure

`BulkSwapPlanResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Errors` | [`IList<Error>`](../../doc/models/error.md) | Optional | Errors encountered during the request. |
| `AffectedSubscriptions` | `int?` | Optional | The number of affected subscriptions. |

## Example (as JSON)

```json
{
  "affected_subscriptions": 12,
  "errors": [
    {
      "category": "MERCHANT_SUBSCRIPTION_ERROR",
      "code": "MAP_KEY_LENGTH_TOO_LONG",
      "detail": "detail6",
      "field": "field4"
    },
    {
      "category": "MERCHANT_SUBSCRIPTION_ERROR",
      "code": "MAP_KEY_LENGTH_TOO_LONG",
      "detail": "detail6",
      "field": "field4"
    }
  ]
}
```

