
# Booking

Represents a booking as a time-bound service contract for a seller's staff member to provide a specified service
at a given location to a requesting customer in one or more appointment segments.

## Structure

`Booking`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Optional | A unique ID of this object representing a booking.<br>**Constraints**: *Maximum Length*: `36` |
| `Version` | `int?` | Optional | The revision number for the booking used for optimistic concurrency. |
| `Status` | [`string`](../../doc/models/booking-status.md) | Optional | Supported booking statuses. |
| `CreatedAt` | `string` | Optional | The RFC 3339 timestamp specifying the creation time of this booking. |
| `UpdatedAt` | `string` | Optional | The RFC 3339 timestamp specifying the most recent update time of this booking. |
| `StartAt` | `string` | Optional | The RFC 3339 timestamp specifying the starting time of this booking. |
| `LocationId` | `string` | Optional | The ID of the [Location](entity:Location) object representing the location where the booked service is provided. Once set when the booking is created, its value cannot be changed.<br>**Constraints**: *Maximum Length*: `32` |
| `CustomerId` | `string` | Optional | The ID of the [Customer](entity:Customer) object representing the customer receiving the booked service.<br>**Constraints**: *Maximum Length*: `192` |
| `CustomerNote` | `string` | Optional | The free-text field for the customer to supply notes about the booking. For example, the note can be preferences that cannot be expressed by supported attributes of a relevant [CatalogObject](entity:CatalogObject) instance.<br>**Constraints**: *Maximum Length*: `4096` |
| `SellerNote` | `string` | Optional | The free-text field for the seller to supply notes about the booking. For example, the note can be preferences that cannot be expressed by supported attributes of a specific [CatalogObject](entity:CatalogObject) instance.<br>This field should not be visible to customers.<br>**Constraints**: *Maximum Length*: `4096` |
| `AppointmentSegments` | [`IList<AppointmentSegment>`](../../doc/models/appointment-segment.md) | Optional | A list of appointment segments for this booking. |
| `TransitionTimeMinutes` | `int?` | Optional | Additional time at the end of a booking.<br>Applications should not make this field visible to customers of a seller. |
| `AllDay` | `bool?` | Optional | Whether the booking is of a full business day. |
| `LocationType` | [`string`](../../doc/models/business-appointment-settings-booking-location-type.md) | Optional | Supported types of location where service is provided. |
| `CreatorDetails` | [`BookingCreatorDetails`](../../doc/models/booking-creator-details.md) | Optional | Information about a booking creator. |
| `Source` | [`string`](../../doc/models/booking-booking-source.md) | Optional | Supported sources a booking was created from. |

## Example (as JSON)

```json
{
  "id": "id0",
  "version": 172,
  "status": "CANCELLED_BY_SELLER",
  "created_at": "created_at2",
  "updated_at": "updated_at4"
}
```

