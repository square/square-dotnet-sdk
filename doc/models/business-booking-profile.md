
# Business Booking Profile

## Structure

`BusinessBookingProfile`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `SellerId` | `string` | Optional | The ID of the seller, obtainable using the Merchants API. |
| `CreatedAt` | `string` | Optional | The RFC-3339 timestamp specifying the booking's creation time. |
| `BookingEnabled` | `bool?` | Optional | Indicates whether the seller is open for booking. |
| `CustomerTimezoneChoice` | [`string`](/doc/models/business-booking-profile-customer-timezone-choice.md) | Optional | Choices of customer-facing time zone used for bookings. |
| `BookingPolicy` | [`string`](/doc/models/business-booking-profile-booking-policy.md) | Optional | Policies for accepting bookings. |
| `AllowUserCancel` | `bool?` | Optional | Indicates whether customers can cancel or reschedule their own bookings (`true`) or not (`false`). |
| `BusinessAppointmentSettings` | [`Models.BusinessAppointmentSettings`](/doc/models/business-appointment-settings.md) | Optional | The service appointment settings, including where and how the service is provided. |

## Example (as JSON)

```json
{
  "seller_id": "seller_id8",
  "created_at": "created_at2",
  "booking_enabled": false,
  "customer_timezone_choice": "BUSINESS_LOCATION_TIMEZONE",
  "booking_policy": "ACCEPT_ALL"
}
```

