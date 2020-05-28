## Loyalty Reward

### Structure

`LoyaltyReward`

### Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Optional | The Square-assigned ID of the loyalty reward. |
| `Status` | [`string`](/doc/models/loyalty-reward-status.md) | Optional | The status of the loyalty reward. |
| `LoyaltyAccountId` | `string` |  | The Square-assigned ID of the [loyalty account](#type-LoyaltyAccount) to which the reward belongs. |
| `RewardTierId` | `string` |  | The Square-assigned ID of the [reward tier](#type-LoyaltyProgramRewardTier) used to create the reward. |
| `Points` | `int?` | Optional | The number of loyalty points used for the reward. |
| `OrderId` | `string` | Optional | The Square-assigned ID of the [order](#type-Order) to which the reward is attached. |
| `CreatedAt` | `string` | Optional | The timestamp when the reward was created, in RFC 3339 format. |
| `UpdatedAt` | `string` | Optional | The timestamp when the reward was last updated, in RFC 3339 format. |
| `RedeemedAt` | `string` | Optional | The timestamp when the reward was redeemed, in RFC 3339 format. |

### Example (as JSON)

```json
{
  "id": null,
  "status": null,
  "loyalty_account_id": "loyalty_account_id0",
  "reward_tier_id": "reward_tier_id6",
  "points": null,
  "order_id": null,
  "created_at": null,
  "updated_at": null,
  "redeemed_at": null
}
```

