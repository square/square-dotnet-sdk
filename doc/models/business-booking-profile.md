
# Business Booking Profile

## Structure

`BusinessBookingProfile`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `SellerId` | `string` | Optional | The ID of the seller, obtainable using the Merchants API.<br>**Constraints**: *Maximum Length*: `32` |
| `CreatedAt` | `string` | Optional | The RFC 3339 timestamp specifying the booking's creation time. |
| `BookingEnabled` | `bool?` | Optional | Indicates whether the seller is open for booking. |
| `CustomerTimezoneChoice` | [`string`](../../doc/models/business-booking-profile-customer-timezone-choice.md) | Optional | Choices of customer-facing time zone used for bookings. |
| `BookingPolicy` | [`string`](../../doc/models/business-booking-profile-booking-policy.md) | Optional | Policies for accepting bookings. |
| `AllowUserCancel` | `bool?` | Optional | Indicates whether customers can cancel or reschedule their own bookings (`true`) or not (`false`). |
| `BusinessAppointmentSettings` | [`Models.BusinessAppointmentSettings`](../../doc/models/business-appointment-settings.md) | Optional | The service appointment settings, including where and how the service is provided. |
| `SupportSellerLevelWrites` | `bool?` | Optional | Indicates whether the seller's subscription to Square Appointments supports creating, updating or canceling an appointment through the API (`true`) or not (`false`) using seller permission. |

## Example (as JSON)

```json
{
  "seller_id": null,
  "created_at": null,
  "booking_enabled": null,
  "customer_timezone_choice": null,
  "booking_policy": null,
  "allow_user_cancel": null,
  "business_appointment_settings": null,
  "support_seller_level_writes": null
}
```

