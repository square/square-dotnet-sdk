
# Booking Custom Attribute Upsert Response

Represents a response for an individual upsert request in a [BulkUpsertBookingCustomAttributes](../../doc/api/booking-custom-attributes.md#bulk-upsert-booking-custom-attributes) operation.

## Structure

`BookingCustomAttributeUpsertResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `BookingId` | `string` | Optional | The ID of the [booking](../../doc/models/booking.md) associated with the custom attribute. |
| `CustomAttribute` | [`Models.CustomAttribute`](../../doc/models/custom-attribute.md) | Optional | A custom attribute value. Each custom attribute value has a corresponding<br>`CustomAttributeDefinition` object. |
| `Errors` | [`IList<Models.Error>`](../../doc/models/error.md) | Optional | Any errors that occurred while processing the individual request. |

## Example (as JSON)

```json
{
  "booking_id": null,
  "custom_attribute": null,
  "errors": null
}
```

