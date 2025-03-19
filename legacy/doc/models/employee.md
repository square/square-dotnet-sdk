
# Employee

An employee object that is used by the external API.

DEPRECATED at version 2020-08-26. Replaced by [TeamMember](entity:TeamMember).

## Structure

`Employee`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Optional | UUID for this object. |
| `FirstName` | `string` | Optional | The employee's first name. |
| `LastName` | `string` | Optional | The employee's last name. |
| `Email` | `string` | Optional | The employee's email address |
| `PhoneNumber` | `string` | Optional | The employee's phone number in E.164 format, i.e. "+12125554250" |
| `LocationIds` | `IList<string>` | Optional | A list of location IDs where this employee has access to. |
| `Status` | [`string`](../../doc/models/employee-status.md) | Optional | The status of the Employee being retrieved.<br><br>DEPRECATED at version 2020-08-26. Replaced by [TeamMemberStatus](entity:TeamMemberStatus). |
| `IsOwner` | `bool?` | Optional | Whether this employee is the owner of the merchant. Each merchant<br>has one owner employee, and that employee has full authority over<br>the account. |
| `CreatedAt` | `string` | Optional | A read-only timestamp in RFC 3339 format. |
| `UpdatedAt` | `string` | Optional | A read-only timestamp in RFC 3339 format. |

## Example (as JSON)

```json
{
  "id": "id6",
  "first_name": "first_name6",
  "last_name": "last_name4",
  "email": "email0",
  "phone_number": "phone_number6"
}
```

