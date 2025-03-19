using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents an update request for a `TeamMember` object.
/// </summary>
public record UpdateTeamMemberRequest
{
    /// <summary>
    /// The team member fields to add, change, or clear. Fields can be cleared using a null value. To update
    /// `wage_setting.job_assignments`, you must provide the complete list of job assignments. If needed, call
    /// [ListJobs](api-endpoint:Team-ListJobs) to get the required `job_id` values.
    /// </summary>
    [JsonPropertyName("team_member")]
    public TeamMember? TeamMember { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
