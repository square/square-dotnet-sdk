using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[Serializable]
public record BatchUpdateTeamMembersRequest
{
    /// <summary>
    /// The data used to update the `TeamMember` objects. Each key is the `team_member_id` that maps to the `UpdateTeamMemberRequest`.
    /// The maximum number of update objects is 25.
    ///
    /// For each team member, include the fields to add, change, or clear. Fields can be cleared using a null value.
    /// To update `wage_setting.job_assignments`, you must provide the complete list of job assignments. If needed,
    /// call [ListJobs](api-endpoint:Team-ListJobs) to get the required `job_id` values.
    /// </summary>
    [JsonPropertyName("team_members")]
    public Dictionary<string, UpdateTeamMemberRequest> TeamMembers { get; set; } =
        new Dictionary<string, UpdateTeamMemberRequest>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
