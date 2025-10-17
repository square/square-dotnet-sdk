using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.TeamMembers;

[Serializable]
public record BatchCreateTeamMembersRequest
{
    /// <summary>
    /// The data used to create the `TeamMember` objects. Each key is the `idempotency_key` that maps to the `CreateTeamMemberRequest`.
    /// The maximum number of create objects is 25.
    ///
    /// If you include a team member's `wage_setting`, you must provide `job_id` for each job assignment. To get job IDs,
    /// call [ListJobs](api-endpoint:Team-ListJobs).
    /// </summary>
    [JsonPropertyName("team_members")]
    public Dictionary<string, CreateTeamMemberRequest> TeamMembers { get; set; } =
        new Dictionary<string, CreateTeamMemberRequest>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
