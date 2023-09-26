
# List Team Member Wages Response

The response to a request for a set of `TeamMemberWage` objects. The response contains
a set of `TeamMemberWage` objects.

## Structure

`ListTeamMemberWagesResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `TeamMemberWages` | [`IList<TeamMemberWage>`](../../doc/models/team-member-wage.md) | Optional | A page of `TeamMemberWage` results. |
| `Cursor` | `string` | Optional | The value supplied in the subsequent request to fetch the next page<br>of `TeamMemberWage` results. |
| `Errors` | [`IList<Error>`](../../doc/models/error.md) | Optional | Any errors that occurred during the request. |

## Example (as JSON)

```json
{
  "cursor": "2fofTniCgT0yIPAq26kmk0YyFQJZfbWkh73OOnlTHmTAx13NgED",
  "team_member_wages": [
    {
      "hourly_rate": {
        "amount": 3250,
        "currency": "USD"
      },
      "id": "pXS3qCv7BERPnEGedM4S8mhm",
      "job_id": "jxJNN6eCJsLrhg5UFJrDWDGE",
      "team_member_id": "33fJchumvVdJwxV0H6L9",
      "title": "Manager"
    },
    {
      "hourly_rate": {
        "amount": 2600,
        "currency": "USD"
      },
      "id": "rZduCkzYDUVL3ovh1sQgbue6",
      "job_id": "gcbz15vKGnMKmaWJJ152kjim",
      "team_member_id": "33fJchumvVdJwxV0H6L9",
      "title": "Cook"
    },
    {
      "hourly_rate": {
        "amount": 1600,
        "currency": "USD"
      },
      "id": "FxLbs5KpPUHa8wyt5ctjubDX",
      "job_id": "FzbJAtt9qEWncK1BWgVCxQ6M",
      "team_member_id": "33fJchumvVdJwxV0H6L9",
      "title": "Barista"
    },
    {
      "hourly_rate": {
        "amount": 1700,
        "currency": "USD"
      },
      "id": "vD1wCgijMDR3cX5TPnu7VXto",
      "job_id": "N4YKVLzFj3oGtNocqoYHYpW3",
      "team_member_id": "33fJchumvVdJwxV0H6L9",
      "title": "Cashier"
    }
  ],
  "errors": [
    {
      "category": "MERCHANT_SUBSCRIPTION_ERROR",
      "code": "MAP_KEY_LENGTH_TOO_LONG",
      "detail": "detail6",
      "field": "field4"
    },
    {
      "category": "MERCHANT_SUBSCRIPTION_ERROR",
      "code": "MAP_KEY_LENGTH_TOO_LONG",
      "detail": "detail6",
      "field": "field4"
    }
  ]
}
```

