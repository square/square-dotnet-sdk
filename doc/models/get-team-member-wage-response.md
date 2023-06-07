
# Get Team Member Wage Response

A response to a request to get a `TeamMemberWage`. The response contains
the requested `TeamMemberWage` objects and might contain a set of `Error` objects if
the request resulted in errors.

## Structure

`GetTeamMemberWageResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `TeamMemberWage` | [`Models.TeamMemberWage`](../../doc/models/team-member-wage.md) | Optional | The hourly wage rate that a team member earns on a `Shift` for doing the job<br>specified by the `title` property of this object. |
| `Errors` | [`IList<Models.Error>`](../../doc/models/error.md) | Optional | Any errors that occurred during the request. |

## Example (as JSON)

```json
{
  "team_member_wage": {
    "hourly_rate": {
      "amount": 2000,
      "currency": "USD"
    },
    "id": "pXS3qCv7BERPnEGedM4S8mhm",
    "team_member_id": "33fJchumvVdJwxV0H6L9",
    "title": "Manager",
    "job_id": "job_id4"
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

