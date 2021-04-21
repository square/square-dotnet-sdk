
# Loyalty Event Other

Provides metadata when the event `type` is `OTHER`.

## Structure

`LoyaltyEventOther`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `LoyaltyProgramId` | `string` | Required | The Square-assigned ID of the [loyalty program](/doc/models/loyalty-program.md).<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `36` |
| `Points` | `int` | Required | The number of points added or removed. |

## Example (as JSON)

```json
{
  "loyalty_program_id": "loyalty_program_id0",
  "points": 236
}
```

