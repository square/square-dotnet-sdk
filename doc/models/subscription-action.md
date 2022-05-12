
# Subscription Action

Represents an action as a pending change to a subscription.

## Structure

`SubscriptionAction`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Optional | The ID of an action scoped to a subscription. |
| `Type` | [`string`](../../doc/models/subscription-action-type.md) | Optional | Supported types of an action as a pending change to a subscription. |
| `EffectiveDate` | `string` | Optional | The `YYYY-MM-DD`-formatted date when the action occurs on the subscription. |
| `NewPlanId` | `string` | Optional | The target subscription plan a subscription switches to, for a `SWAP_PLAN` action. |

## Example (as JSON)

```json
{
  "id": null,
  "type": null,
  "effective_date": null,
  "new_plan_id": null
}
```

