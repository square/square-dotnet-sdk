
# List Team Member Booking Profiles Response

## Structure

`ListTeamMemberBookingProfilesResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `TeamMemberBookingProfiles` | [`IList<Models.TeamMemberBookingProfile>`](../../doc/models/team-member-booking-profile.md) | Optional | The list of team member booking profiles. The results are returned in the ascending order of the time<br>when the team member booking profiles were last updated. Multiple booking profiles updated at the same time<br>are further sorted in the ascending order of their IDs. |
| `Cursor` | `string` | Optional | The pagination cursor to be used in the subsequent request to get the next page of the results. Stop retrieving the next page of the results when the cursor is not set.<br>**Constraints**: *Maximum Length*: `65536` |
| `Errors` | [`IList<Models.Error>`](../../doc/models/error.md) | Optional | Errors that occurred during the request. |

## Example (as JSON)

```json
{
  "errors": [],
  "team_member_booking_profiles": [
    {
      "display_name": "Sandbox Seller",
      "is_bookable": true,
      "team_member_id": "TMXUrsBWWcHTt79t",
      "description": "description7",
      "profile_image_url": "profile_image_url9"
    },
    {
      "display_name": "Sandbox Staff",
      "is_bookable": true,
      "team_member_id": "TMaJcbiRqPIGZuS9",
      "description": "description6",
      "profile_image_url": "profile_image_url0"
    }
  ],
  "cursor": "cursor6"
}
```

