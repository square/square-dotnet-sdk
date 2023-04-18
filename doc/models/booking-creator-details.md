
# Booking Creator Details

Information about a booking creator.

## Structure

`BookingCreatorDetails`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `CreatorType` | [`string`](../../doc/models/booking-creator-details-creator-type.md) | Optional | Supported types of a booking creator. |
| `TeamMemberId` | `string` | Optional | The ID of the team member who created the booking, when the booking creator is of the `TEAM_MEMBER` type.<br>Access to this field requires seller-level permissions.<br>**Constraints**: *Maximum Length*: `32` |
| `CustomerId` | `string` | Optional | The ID of the customer who created the booking, when the booking creator is of the `CUSTOMER` type.<br>Access to this field requires seller-level permissions.<br>**Constraints**: *Maximum Length*: `192` |

## Example (as JSON)

```json
{
  "creator_type": "TEAM_MEMBER",
  "team_member_id": "team_member_id0",
  "customer_id": "customer_id8"
}
```

