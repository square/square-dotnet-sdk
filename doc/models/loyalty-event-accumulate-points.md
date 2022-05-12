
# Loyalty Event Accumulate Points

Provides metadata when the event `type` is `ACCUMULATE_POINTS`.

## Structure

`LoyaltyEventAccumulatePoints`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `LoyaltyProgramId` | `string` | Optional | The ID of the [loyalty program](../../doc/models/loyalty-program.md).<br>**Constraints**: *Maximum Length*: `36` |
| `Points` | `int?` | Optional | The number of points accumulated by the event.<br>**Constraints**: `>= 1` |
| `OrderId` | `string` | Optional | The ID of the [order](../../doc/models/order.md) for which the buyer accumulated the points.<br>This field is returned only if the Orders API is used to process orders. |

## Example (as JSON)

```json
{
  "loyalty_program_id": null,
  "points": null,
  "order_id": null
}
```

