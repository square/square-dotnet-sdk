using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default.TeamMembers.WageSetting;

[Serializable]
public record UpdateWageSettingRequest
{
    /// <summary>
    /// The ID of the team member for which to update the `WageSetting` object.
    /// </summary>
    [JsonIgnore]
    public required string TeamMemberId { get; set; }

    /// <summary>
    /// The complete `WageSetting` object. For all job assignments, specify one of the following:
    /// - `job_id` (recommended) - If needed, call [ListJobs](api-endpoint:Team-ListJobs) to get a list of all jobs.
    /// Requires Square API version 2024-12-18 or later.
    /// - `job_title` - Use the exact, case-sensitive spelling of an existing title unless you want to create a new job.
    /// This value is ignored if `job_id` is also provided.
    /// </summary>
    [JsonPropertyName("wage_setting")]
    public required Square.Default.WageSetting WageSetting { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
