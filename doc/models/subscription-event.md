
# Subscription Event

Describes changes to a subscription and the subscription status.

## Structure

`SubscriptionEvent`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Required | The ID of the subscription event. |
| `SubscriptionEventType` | [`string`](/doc/models/subscription-event-subscription-event-type.md) | Required | Supported types of an event occurred to a subscription. |
| `EffectiveDate` | `string` | Required | The `YYYY-MM-DD`-formatted date (for example, 2013-01-15) when the subscription event occurred. |
| `PlanId` | `string` | Required | The ID of the subscription plan associated with the subscription. |
| `Info` | [`Models.SubscriptionEventInfo`](/doc/models/subscription-event-info.md) | Optional | Provides information about the subscription event. |

## Example (as JSON)

```json
{
  "id": "id0",
  "subscription_event_type": "RESUME_SUBSCRIPTION",
  "effective_date": "effective_date0",
  "plan_id": "plan_id8",
  "info": {
    "detail": "detail6",
    "code": "CUSTOMER_DELETED"
  }
}
```

