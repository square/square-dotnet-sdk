
# Loyalty Event Delete Reward

Provides metadata when the event `type` is `DELETE_REWARD`.

## Structure

`LoyaltyEventDeleteReward`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `LoyaltyProgramId` | `string` | Required | The ID of the [loyalty program](entity:LoyaltyProgram).<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `36` |
| `RewardId` | `string` | Optional | The ID of the deleted [loyalty reward](entity:LoyaltyReward).<br>This field is returned only if the event source is `LOYALTY_API`.<br>**Constraints**: *Maximum Length*: `36` |
| `Points` | `int` | Required | The number of points returned to the loyalty account. |

## Example (as JSON)

```json
{
  "loyalty_program_id": "loyalty_program_id0",
  "reward_id": "reward_id4",
  "points": 236
}
```

