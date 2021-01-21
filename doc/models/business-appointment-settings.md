
# Business Appointment Settings

The service appointment settings, including where and how the service is provided.

## Structure

`BusinessAppointmentSettings`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `LocationTypes` | [`IList<string>`](/doc/models/business-appointment-settings-booking-location-type.md) | Optional | Types of the location allowed for bookings.<br>See [BusinessAppointmentSettingsBookingLocationType](#type-businessappointmentsettingsbookinglocationtype) for possible values |
| `AlignmentTime` | [`string`](/doc/models/business-appointment-settings-alignment-time.md) | Optional | Time units of a service duration for bookings. |
| `MinBookingLeadTimeSeconds` | `int?` | Optional | The minimum lead time in seconds before a service can be booked. Bookings must be created at least this far ahead of the booking's starting time. |
| `MaxBookingLeadTimeSeconds` | `int?` | Optional | The maximum lead time in seconds before a service can be booked. Bookings must be created at most this far ahead of the booking's starting time. |
| `AnyTeamMemberBookingEnabled` | `bool?` | Optional | Indicates whether a customer can choose from all available time slots and have a staff member assigned<br>automatically (`true`) or not (`false`). |
| `MultipleServiceBookingEnabled` | `bool?` | Optional | Indicates whether a customer can book multiple services in a single online booking. |
| `MaxAppointmentsPerDayLimitType` | [`string`](/doc/models/business-appointment-settings-max-appointments-per-day-limit-type.md) | Optional | Types of daily appointment limits. |
| `MaxAppointmentsPerDayLimit` | `int?` | Optional | The maximum number of daily appointments per team member or per location. |
| `CancellationWindowSeconds` | `int?` | Optional | The cut-off time in seconds for allowing clients to cancel or reschedule an appointment. |
| `CancellationFeeMoney` | [`Models.Money`](/doc/models/money.md) | Optional | Represents an amount of money. `Money` fields can be signed or unsigned.<br>Fields that do not explicitly define whether they are signed or unsigned are<br>considered unsigned and can only hold positive amounts. For signed fields, the<br>sign of the value indicates the purpose of the money transfer. See<br>[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)<br>for more information. |
| `CancellationPolicy` | [`string`](/doc/models/business-appointment-settings-cancellation-policy.md) | Optional | The category of the seller’s cancellation policy. |
| `CancellationPolicyText` | `string` | Optional | The free-form text of the seller's cancellation policy. |
| `SkipBookingFlowStaffSelection` | `bool?` | Optional | Indicates whether customers has an assigned staff member (`true`) or can select s staff member of their choice (`false`). |

## Example (as JSON)

```json
{
  "location_types": [
    "BUSINESS_LOCATION",
    "CUSTOMER_LOCATION"
  ],
  "alignment_time": "HALF_HOURLY",
  "min_booking_lead_time_seconds": 38,
  "max_booking_lead_time_seconds": 48,
  "any_team_member_booking_enabled": false
}
```

