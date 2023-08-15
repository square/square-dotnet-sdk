
# Bulk Retrieve Bookings Request

Request payload for bulk retrieval of bookings.

## Structure

`BulkRetrieveBookingsRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `BookingIds` | `IList<string>` | Required | A non-empty list of [Booking](entity:Booking) IDs specifying bookings to retrieve. |

## Example (as JSON)

```json
{
  "booking_ids": [
    "booking_ids4"
  ]
}
```

