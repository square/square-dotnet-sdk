
# Loyalty Account

Describes a loyalty account in a [loyalty program](../../doc/models/loyalty-program.md). For more information, see
[Create and Retrieve Loyalty Accounts](https://developer.squareup.com/docs/loyalty-api/loyalty-accounts).

## Structure

`LoyaltyAccount`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Optional | The Square-assigned ID of the loyalty account.<br>**Constraints**: *Maximum Length*: `36` |
| `ProgramId` | `string` | Required | The Square-assigned ID of the [loyalty program](../../doc/models/loyalty-program.md) to which the account belongs.<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `36` |
| `Balance` | `int?` | Optional | The available point balance in the loyalty account. If points are scheduled to expire, they are listed in the `expiring_point_deadlines` field.<br><br>Your application should be able to handle loyalty accounts that have a negative point balance (`balance` is less than 0). This might occur if a seller makes a manual adjustment or as a result of a refund or exchange. |
| `LifetimePoints` | `int?` | Optional | The total points accrued during the lifetime of the account. |
| `CustomerId` | `string` | Optional | The Square-assigned ID of the [customer](../../doc/models/customer.md) that is associated with the account. |
| `EnrolledAt` | `string` | Optional | The timestamp when the buyer joined the loyalty program, in RFC 3339 format. This field is used to display the **Enrolled On** or **Member Since** date in first-party Square products.<br><br>If this field is not set in a `CreateLoyaltyAccount` request, Square populates it after the buyer's first action on their account<br>(when `AccumulateLoyaltyPoints` or `CreateLoyaltyReward` is called). In first-party flows, Square populates the field when the buyer agrees to the terms of service in Square Point of Sale.<br><br>This field is typically specified in a `CreateLoyaltyAccount` request when creating a loyalty account for a buyer who already interacted with their account.<br>For example, you would set this field when migrating accounts from an external system. The timestamp in the request can represent a current or previous date and time, but it cannot be set for the future. |
| `CreatedAt` | `string` | Optional | The timestamp when the loyalty account was created, in RFC 3339 format. |
| `UpdatedAt` | `string` | Optional | The timestamp when the loyalty account was last updated, in RFC 3339 format. |
| `Mapping` | [`Models.LoyaltyAccountMapping`](../../doc/models/loyalty-account-mapping.md) | Optional | Represents the mapping that associates a loyalty account with a buyer.<br><br>Currently, a loyalty account can only be mapped to a buyer by phone number. For more information, see<br>[Loyalty Overview](https://developer.squareup.com/docs/loyalty/overview). |
| `ExpiringPointDeadlines` | [`IList<Models.LoyaltyAccountExpiringPointDeadline>`](../../doc/models/loyalty-account-expiring-point-deadline.md) | Optional | The schedule for when points expire in the loyalty account balance. This field is present only if the account has points that are scheduled to expire.<br><br>The total number of points in this field equals the number of points in the `balance` field. |

## Example (as JSON)

```json
{
  "id": null,
  "program_id": "program_id0",
  "balance": null,
  "lifetime_points": null,
  "customer_id": null,
  "enrolled_at": null,
  "created_at": null,
  "updated_at": null,
  "mapping": null,
  "expiring_point_deadlines": null
}
```

