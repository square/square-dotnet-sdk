
# Team Member Booking Profile

The booking profile of a seller's team member, including the team member's ID, display name, description and whether the team member can be booked as a service provider.

## Structure

`TeamMemberBookingProfile`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `TeamMemberId` | `string` | Optional | The ID of the [TeamMember](../../doc/models/team-member.md) object for the team member associated with the booking profile.<br>**Constraints**: *Maximum Length*: `32` |
| `Description` | `string` | Optional | The description of the team member.<br>**Constraints**: *Maximum Length*: `65536` |
| `DisplayName` | `string` | Optional | The display name of the team member.<br>**Constraints**: *Maximum Length*: `512` |
| `IsBookable` | `bool?` | Optional | Indicates whether the team member can be booked through the Bookings API or the seller's online booking channel or site (`true) or not (`false`). |
| `ProfileImageUrl` | `string` | Optional | The URL of the team member's image for the bookings profile.<br>**Constraints**: *Maximum Length*: `2048` |

## Example (as JSON)

```json
{
  "team_member_id": null,
  "description": null,
  "display_name": null,
  "is_bookable": null,
  "profile_image_url": null
}
```

