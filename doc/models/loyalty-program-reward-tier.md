
# Loyalty Program Reward Tier

Represents a reward tier in a loyalty program. A reward tier defines how buyers can redeem points for a reward, such as the number of points required and the value and scope of the discount. A loyalty program can offer multiple reward tiers.

## Structure

`LoyaltyProgramRewardTier`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Required | The Square-assigned ID of the reward tier.<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `36` |
| `Points` | `int` | Required | The points exchanged for the reward tier.<br>**Constraints**: `>= 1` |
| `Name` | `string` | Required | The name of the reward tier.<br>**Constraints**: *Minimum Length*: `1` |
| `Definition` | [`Models.LoyaltyProgramRewardDefinition`](../../doc/models/loyalty-program-reward-definition.md) | Required | Provides details about the reward tier discount. DEPRECATED at version 2020-12-16. Discount details<br>are now defined using a catalog pricing rule and other catalog objects. For more information, see<br>[Getting discount details for a reward tier](https://developer.squareup.com/docs/loyalty-api/loyalty-rewards#get-discount-details). |
| `CreatedAt` | `string` | Required | The timestamp when the reward tier was created, in RFC 3339 format. |
| `PricingRuleReference` | [`Models.CatalogObjectReference`](../../doc/models/catalog-object-reference.md) | Optional | A reference to a Catalog object at a specific version. In general this is<br>used as an entry point into a graph of catalog objects, where the objects exist<br>at a specific version. |

## Example (as JSON)

```json
{
  "definition": {
    "scope": "ORDER",
    "discount_type": "FIXED_AMOUNT",
    "fixed_discount_money": null,
    "max_discount_money": null
  },
  "pricing_rule_reference": null
}
```

