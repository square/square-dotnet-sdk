
# Team Member

A record representing an individual team member for a business.

## Structure

`TeamMember`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Optional | The unique ID for the team member. |
| `ReferenceId` | `string` | Optional | A second ID used to associate the team member with an entity in another system. |
| `IsOwner` | `bool?` | Optional | Whether the team member is the owner of the Square account. |
| `Status` | [`string`](../../doc/models/team-member-status.md) | Optional | Enumerates the possible statuses the team member can have within a business. |
| `GivenName` | `string` | Optional | The given name (that is, the first name) associated with the team member. |
| `FamilyName` | `string` | Optional | The family name (that is, the last name) associated with the team member. |
| `EmailAddress` | `string` | Optional | The email address associated with the team member. After accepting the invitation<br>from Square, only the team member can change this value. |
| `PhoneNumber` | `string` | Optional | The team member's phone number, in E.164 format. For example:<br>+14155552671 - the country code is 1 for US<br>+551155256325 - the country code is 55 for BR |
| `CreatedAt` | `string` | Optional | The timestamp when the team member was created, in RFC 3339 format. |
| `UpdatedAt` | `string` | Optional | The timestamp when the team member was last updated, in RFC 3339 format. |
| `AssignedLocations` | [`TeamMemberAssignedLocations`](../../doc/models/team-member-assigned-locations.md) | Optional | An object that represents a team member's assignment to locations. |
| `WageSetting` | [`WageSetting`](../../doc/models/wage-setting.md) | Optional | Represents information about the overtime exemption status, job assignments, and compensation<br>for a [team member](../../doc/models/team-member.md). |

## Example (as JSON)

```json
{
  "id": "id4",
  "reference_id": "reference_id8",
  "is_owner": false,
  "status": "ACTIVE",
  "given_name": "given_name6"
}
```

