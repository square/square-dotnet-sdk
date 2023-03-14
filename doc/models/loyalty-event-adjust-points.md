
# Loyalty Event Adjust Points

Provides metadata when the event `type` is `ADJUST_POINTS`.

## Structure

`LoyaltyEventAdjustPoints`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `LoyaltyProgramId` | `string` | Optional | The Square-assigned ID of the [loyalty program](../../doc/models/loyalty-program.md).<br>**Constraints**: *Maximum Length*: `36` |
| `Points` | `int` | Required | The number of points added or removed. |
| `Reason` | `string` | Optional | The reason for the adjustment of points. |

## Example (as JSON)

```json
{
  "loyalty_program_id": null,
  "points": 236,
  "reason": null
}
```

