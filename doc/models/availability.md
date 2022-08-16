
# Availability

Defines an appointment slot that encapsulates the appointment segments, location and starting time available for booking.

## Structure

`Availability`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `StartAt` | `string` | Optional | The RFC 3339 timestamp specifying the beginning time of the slot available for booking. |
| `LocationId` | `string` | Optional | The ID of the location available for booking.<br>**Constraints**: *Maximum Length*: `32` |
| `AppointmentSegments` | [`IList<Models.AppointmentSegment>`](../../doc/models/appointment-segment.md) | Optional | The list of appointment segments available for booking |

## Example (as JSON)

```json
{
  "start_at": null,
  "appointment_segments": null
}
```

