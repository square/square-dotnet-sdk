
# Appointment Segment

Defines an appointment segment of a booking.

## Structure

`AppointmentSegment`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `DurationMinutes` | `int?` | Optional | The time span in minutes of an appointment segment.<br>**Constraints**: `<= 1500` |
| `ServiceVariationId` | `string` | Optional | The ID of the [CatalogItemVariation](../../doc/models/catalog-item-variation.md) object representing the service booked in this segment.<br>**Constraints**: *Maximum Length*: `36` |
| `TeamMemberId` | `string` | Required | The ID of the [TeamMember](../../doc/models/team-member.md) object representing the team member booked in this segment.<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `32` |
| `ServiceVariationVersion` | `long?` | Optional | The current version of the item variation representing the service booked in this segment. |
| `IntermissionMinutes` | `int?` | Optional | Time between the end of this segment and the beginning of the subsequent segment. |
| `AnyTeamMember` | `bool?` | Optional | Whether the customer accepts any team member, instead of a specific one, to serve this segment. |
| `ResourceIds` | `IList<string>` | Optional | The IDs of the seller-accessible resources used for this appointment segment. |

## Example (as JSON)

```json
{
  "duration_minutes": null,
  "service_variation_id": null,
  "team_member_id": "team_member_id0",
  "service_variation_version": null
}
```

