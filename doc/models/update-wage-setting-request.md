
# Update Wage Setting Request

Represents an update request for the `WageSetting` object describing a `TeamMember`.

## Structure

`UpdateWageSettingRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `WageSetting` | [`Models.WageSetting`](../../doc/models/wage-setting.md) | Required | An object representing a team member's wage information. |

## Example (as JSON)

```json
{
  "wage_setting": {
    "is_overtime_exempt": true,
    "job_assignments": [
      {
        "annual_rate": {
          "amount": 3000000,
          "currency": "USD"
        },
        "job_title": "Manager",
        "pay_type": "SALARY",
        "weekly_hours": 40,
        "hourly_rate": {
          "amount": 125,
          "currency": "ETB"
        }
      },
      {
        "hourly_rate": {
          "amount": 1200,
          "currency": "USD"
        },
        "job_title": "Cashier",
        "pay_type": "HOURLY",
        "annual_rate": {
          "amount": 66,
          "currency": "EGP"
        },
        "weekly_hours": 234
      }
    ],
    "team_member_id": "team_member_id8",
    "version": 130,
    "created_at": "created_at6"
  }
}
```

