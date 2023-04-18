
# Appointment Segment

Defines an appointment segment of a booking.

## Structure

`AppointmentSegment`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `DurationMinutes` | `int?` | Optional | The time span in minutes of an appointment segment.<br>**Constraints**: `<= 1500` |
| `ServiceVariationId` | `string` | Optional | The ID of the [CatalogItemVariation](entity:CatalogItemVariation) object representing the service booked in this segment.<br>**Constraints**: *Maximum Length*: `36` |
| `TeamMemberId` | `string` | Required | The ID of the [TeamMember](entity:TeamMember) object representing the team member booked in this segment.<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `32` |
| `ServiceVariationVersion` | `long?` | Optional | The current version of the item variation representing the service booked in this segment. |
| `IntermissionMinutes` | `int?` | Optional | Time between the end of this segment and the beginning of the subsequent segment. |
| `AnyTeamMember` | `bool?` | Optional | Whether the customer accepts any team member, instead of a specific one, to serve this segment. |
| `ResourceIds` | `IList<string>` | Optional | The IDs of the seller-accessible resources used for this appointment segment. |

## Example (as JSON)

```json
{
  "duration_minutes": 144,
  "service_variation_id": "service_variation_id6",
  "team_member_id": "team_member_id0",
  "service_variation_version": 56,
  "intermission_minutes": 62,
  "any_team_member": false,
  "resource_ids": [
    "resource_ids0",
    "resource_ids1"
  ]
}
```

