
# Loyalty Program

Represents a Square loyalty program. Loyalty programs define how buyers can earn points and redeem points for rewards.
Square sellers can have only one loyalty program, which is created and managed from the Seller Dashboard.
For more information, see [Loyalty Program Overview](https://developer.squareup.com/docs/loyalty/overview).

## Structure

`LoyaltyProgram`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Optional | The Square-assigned ID of the loyalty program. Updates to<br>the loyalty program do not modify the identifier.<br>**Constraints**: *Maximum Length*: `36` |
| `Status` | [`string`](../../doc/models/loyalty-program-status.md) | Optional | Indicates whether the program is currently active. |
| `RewardTiers` | [`IList<Models.LoyaltyProgramRewardTier>`](../../doc/models/loyalty-program-reward-tier.md) | Required | The list of rewards for buyers, sorted by ascending points. |
| `ExpirationPolicy` | [`Models.LoyaltyProgramExpirationPolicy`](../../doc/models/loyalty-program-expiration-policy.md) | Optional | Describes when the loyalty program expires. |
| `Terminology` | [`Models.LoyaltyProgramTerminology`](../../doc/models/loyalty-program-terminology.md) | Required | Represents the naming used for loyalty points. |
| `LocationIds` | `IList<string>` | Optional | The [locations](../../doc/models/location.md) at which the program is active. |
| `CreatedAt` | `string` | Optional | The timestamp when the program was created, in RFC 3339 format. |
| `UpdatedAt` | `string` | Optional | The timestamp when the reward was last updated, in RFC 3339 format. |
| `AccrualRules` | [`IList<Models.LoyaltyProgramAccrualRule>`](../../doc/models/loyalty-program-accrual-rule.md) | Required | Defines how buyers can earn loyalty points from the base loyalty program.<br>To check for associated [loyalty promotions](../../doc/models/loyalty-promotion.md) that enable<br>buyers to earn extra points, call [ListLoyaltyPromotions](../../doc/api/loyalty.md#list-loyalty-promotions). |

## Example (as JSON)

```json
{
  "status": null,
  "reward_tiers": [
    {
      "points": 249,
      "definition": null,
      "pricing_rule_reference": null
    },
    {
      "points": 248,
      "definition": null,
      "pricing_rule_reference": null
    }
  ],
  "expiration_policy": null,
  "terminology": {
    "one": "one0",
    "other": "other6"
  },
  "location_ids": null,
  "accrual_rules": [
    {
      "accrual_type": "ITEM_VARIATION",
      "points": null,
      "visit_data": null,
      "spend_data": null,
      "item_variation_data": null,
      "category_data": null
    },
    {
      "accrual_type": "SPEND",
      "points": null,
      "visit_data": null,
      "spend_data": null,
      "item_variation_data": null,
      "category_data": null
    }
  ]
}
```

