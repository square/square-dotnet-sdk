
# Retrieve Team Member Booking Profile Response

## Structure

`RetrieveTeamMemberBookingProfileResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `TeamMemberBookingProfile` | [`Models.TeamMemberBookingProfile`](../../doc/models/team-member-booking-profile.md) | Optional | The booking profile of a seller's team member, including the team member's ID, display name, description and whether the team member can be booked as a service provider. |
| `Errors` | [`IList<Models.Error>`](../../doc/models/error.md) | Optional | Errors that occurred during the request. |

## Example (as JSON)

```json
{
  "errors": [],
  "team_member_booking_profile": {
    "display_name": "Sandbox Staff",
    "is_bookable": true,
    "team_member_id": "TMaJcbiRqPIGZuS9"
  }
}
```

