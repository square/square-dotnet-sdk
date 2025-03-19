using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Bookings;

public record BulkRetrieveTeamMemberBookingProfilesRequest
{
    /// <summary>
    /// A non-empty list of IDs of team members whose booking profiles you want to retrieve.
    /// </summary>
    [JsonPropertyName("team_member_ids")]
    public IEnumerable<string> TeamMemberIds { get; set; } = new List<string>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
