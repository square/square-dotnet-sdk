using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default.TeamMembers;

[Serializable]
public record GetTeamMembersRequest
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
