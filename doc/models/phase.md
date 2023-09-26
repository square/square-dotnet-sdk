
# Phase

Represents a phase, which can override subscription phases as defined by plan_id

## Structure

`Phase`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Uid` | `string` | Optional | id of subscription phase |
| `Ordinal` | `int?` | Optional | index of phase in total subscription plan |
| `OrderTemplateId` | `string` | Optional | id of order to be used in billing |
| `PlanPhaseUid` | `string` | Optional | the uid from the plan's phase in catalog |

## Example (as JSON)

```json
{
  "uid": "uid4",
  "ordinal": 12,
  "order_template_id": "order_template_id6",
  "plan_phase_uid": "plan_phase_uid0"
}
```

