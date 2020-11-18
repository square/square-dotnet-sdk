
# Availability

Describes a slot available for booking, encapsulating appointment segments, the location and starting time.

## Structure

`Availability`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `StartAt` | `string` | Optional | The RFC-3339 timestamp specifying the beginning time of the slot available for booking. |
| `LocationId` | `string` | Optional | The ID of the location available for booking. |
| `AppointmentSegments` | [`IList<Models.AppointmentSegment>`](/doc/models/appointment-segment.md) | Optional | The list of appointment segments available for booking |

## Example (as JSON)

```json
{
  "start_at": "start_at2",
  "location_id": "location_id4",
  "appointment_segments": [
    {
      "duration_minutes": 4,
      "service_variation_id": "service_variation_id4",
      "team_member_id": "team_member_id0",
      "service_variation_version": 172
    }
  ]
}
```

