
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
| `Phases` | [`IList<Phase>`](../../doc/models/phase.md) | Optional | A list of Phases, to pass phase-specific information used in the swap. |
| `NewPlanVariationId` | `string` | Optional | The target subscription plan variation that a subscription switches to, for a `SWAP_PLAN` action. |

## Example (as JSON)

```json
{
  "id": "id2",
  "type": "CANCEL",
  "effective_date": "effective_date2",
  "phases": [
    {
      "uid": "uid0",
      "ordinal": 78,
      "order_template_id": "order_template_id2",
      "plan_phase_uid": "plan_phase_uid6"
    },
    {
      "uid": "uid0",
      "ordinal": 78,
      "order_template_id": "order_template_id2",
      "plan_phase_uid": "plan_phase_uid6"
    }
  ],
  "new_plan_variation_id": "new_plan_variation_id2"
}
```

