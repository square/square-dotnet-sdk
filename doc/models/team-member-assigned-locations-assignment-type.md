## Team Member Assigned Locations Assignment Type

Enumerates the possible assignment types the team member can have

### Enumeration

`TeamMemberAssignedLocationsAssignmentType`

### Fields

| Name | Description |
|  --- | --- |
| `ALLCURRENTANDFUTURELOCATIONS` | The team member is assigned to all curent and future locations - the location_ids field<br>is empty if the team member has this assignment type. |
| `EXPLICITLOCATIONS` | The team member is assigned to an explicit subset of locations - the location_ids field<br>is the list of locations that the team member is assigned to. |

