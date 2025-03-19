using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.TeamMembers;

public record UpdateTeamMembersRequest
{
    /// <summary>
    /// The ID of the team member to update.
    /// </summary>
    [JsonIgnore]
    public required string TeamMemberId { get; set; }

    [JsonIgnore]
    public required UpdateTeamMemberRequest Body { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
