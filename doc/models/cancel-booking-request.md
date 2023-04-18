
# Cancel Booking Request

## Structure

`CancelBookingRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `IdempotencyKey` | `string` | Optional | A unique key to make this request an idempotent operation.<br>**Constraints**: *Maximum Length*: `255` |
| `BookingVersion` | `int?` | Optional | The revision number for the booking used for optimistic concurrency. |

## Example (as JSON)

```json
{
  "idempotency_key": "idempotency_key6",
  "booking_version": 0
}
```

