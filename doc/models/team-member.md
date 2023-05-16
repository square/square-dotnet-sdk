
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
| `EmailAddress` | `string` | Optional | The email address associated with the team member. |
| `PhoneNumber` | `string` | Optional | The team member's phone number, in E.164 format. For example:<br>+14155552671 - the country code is 1 for US<br>+551155256325 - the country code is 55 for BR |
| `CreatedAt` | `string` | Optional | The timestamp, in RFC 3339 format, describing when the team member was created.<br>For example, "2018-10-04T04:00:00-07:00" or "2019-02-05T12:00:00Z". |
| `UpdatedAt` | `string` | Optional | The timestamp, in RFC 3339 format, describing when the team member was last updated.<br>For example, "2018-10-04T04:00:00-07:00" or "2019-02-05T12:00:00Z". |
| `AssignedLocations` | [`Models.TeamMemberAssignedLocations`](../../doc/models/team-member-assigned-locations.md) | Optional | An object that represents a team member's assignment to locations. |

## Example (as JSON)

```json
{
  "id": "id0",
  "reference_id": "reference_id2",
  "is_owner": false,
  "status": "ACTIVE",
  "given_name": "given_name2"
}
```

