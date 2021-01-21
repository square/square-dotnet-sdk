
# Appointment Segment

Defines an appointment segment of a booking.

## Structure

`AppointmentSegment`

## Fields

| Name | Type | Description |
|  --- | --- | --- |
| `DurationMinutes` | `int` | The time span in minutes of an appointment segment.<br>**Constraints**: `<= 1500` |
| `ServiceVariationId` | `string` | The ID of the [CatalogItemVariation](#type-CatalogItemVariation) object representing the service booked in this segment.<br>**Constraints**: *Minimum Length*: `1` |
| `TeamMemberId` | `string` | The ID of the [TeamMember](#type-TeamMember) object representing the team member booked in this segment.<br>**Constraints**: *Minimum Length*: `1` |
| `ServiceVariationVersion` | `long` | The current version of the item variation representing the service booked in this segment. |

## Example (as JSON)

```json
{
  "duration_minutes": 144,
  "service_variation_id": "service_variation_id6",
  "team_member_id": "team_member_id0",
  "service_variation_version": 56
}
```

