using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default.Bookings.TeamMemberProfiles;

[Serializable]
public record GetTeamMemberProfilesRequest
{
    /// <summary>
    /// The ID of the team member to retrieve.
    /// </summary>
    [JsonIgnore]
    public required string TeamMemberId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
