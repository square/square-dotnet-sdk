
# Update Team Member Request

Represents an update request for a `TeamMember` object.

## Structure

`UpdateTeamMemberRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `TeamMember` | [`Models.TeamMember`](../../doc/models/team-member.md) | Optional | A record representing an individual team member for a business. |

## Example (as JSON)

```json
{
  "team_member": {
    "assigned_locations": {
      "assignment_type": "EXPLICIT_LOCATIONS",
      "location_ids": [
        "YSGH2WBKG94QZ",
        "GA2Y9HSJ8KRYT"
      ]
    },
    "email_address": "joe_doe@gmail.com",
    "family_name": "Doe",
    "given_name": "Joe",
    "phone_number": "+14159283333",
    "reference_id": "reference_id_1",
    "status": "ACTIVE",
    "id": "id6",
    "is_owner": false
  }
}
```

