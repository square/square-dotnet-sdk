
# Retrieve Wage Setting Response

Represents a response from a retrieve request containing the specified `WageSetting` object or error messages.

## Structure

`RetrieveWageSettingResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `WageSetting` | [`Models.WageSetting`](../../doc/models/wage-setting.md) | Optional | An object representing a team member's wage information. |
| `Errors` | [`IList<Models.Error>`](../../doc/models/error.md) | Optional | The errors that occurred during the request. |

## Example (as JSON)

```json
{
  "wage_setting": {
    "created_at": "2020-06-11T23:01:21+00:00",
    "is_overtime_exempt": false,
    "job_assignments": [
      {
        "annual_rate": {
          "amount": 4500000,
          "currency": "USD"
        },
        "hourly_rate": {
          "amount": 2164,
          "currency": "USD"
        },
        "job_title": "Manager",
        "pay_type": "SALARY",
        "weekly_hours": 40
      }
    ],
    "team_member_id": "1yJlHapkseYnNPETIU1B",
    "updated_at": "2020-06-11T23:01:21+00:00",
    "version": 1
  },
  "errors": [
    {
      "category": "AUTHENTICATION_ERROR",
      "code": "REFUND_ALREADY_PENDING",
      "detail": "detail1",
      "field": "field9"
    },
    {
      "category": "INVALID_REQUEST_ERROR",
      "code": "PAYMENT_NOT_REFUNDABLE",
      "detail": "detail2",
      "field": "field0"
    },
    {
      "category": "RATE_LIMIT_ERROR",
      "code": "REFUND_DECLINED",
      "detail": "detail3",
      "field": "field1"
    }
  ]
}
```

