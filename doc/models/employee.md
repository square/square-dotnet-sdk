## Employee

An employee object that is used by the external API.

### Structure

`Employee`

### Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Optional | UUID for this object. |
| `FirstName` | `string` | Optional | The employee's first name. |
| `LastName` | `string` | Optional | The employee's last name. |
| `Email` | `string` | Optional | The employee's email address |
| `PhoneNumber` | `string` | Optional | The employee's phone number in E.164 format, i.e. "+12125554250" |
| `LocationIds` | `IList<string>` | Optional | A list of location IDs where this employee has access to. |
| `Status` | [`string`](/doc/models/employee-status.md) | Optional | The status of the Employee being retrieved. |
| `IsOwner` | `bool?` | Optional | Whether this employee is the owner of the merchant. Each merchant<br>has one owner employee, and that employee has full authority over<br>the account. |
| `CreatedAt` | `string` | Optional | A read-only timestamp in RFC 3339 format. |
| `UpdatedAt` | `string` | Optional | A read-only timestamp in RFC 3339 format. |

### Example (as JSON)

```json
{
  "id": null,
  "first_name": null,
  "last_name": null,
  "email": null,
  "phone_number": null,
  "location_ids": null,
  "status": null,
  "is_owner": null,
  "created_at": null,
  "updated_at": null
}
```

