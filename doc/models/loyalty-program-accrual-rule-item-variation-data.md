
# Loyalty Program Accrual Rule Item Variation Data

Represents additional data for rules with the `ITEM_VARIATION` accrual type.

## Structure

`LoyaltyProgramAccrualRuleItemVariationData`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `ItemVariationId` | `string` | Required | The ID of the `ITEM_VARIATION` [catalog object](../../doc/models/catalog-object.md) that buyers can purchase to earn<br>points.<br>**Constraints**: *Minimum Length*: `1` |

## Example (as JSON)

```json
{
  "item_variation_id": "item_variation_id4"
}
```

