using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents information about the overtime exemption status, job assignments, and compensation
/// for a [team member](entity:TeamMember).
/// </summary>
public record WageSetting
{
    /// <summary>
    /// The ID of the team member associated with the wage setting.
    /// </summary>
    [JsonPropertyName("team_member_id")]
    public string? TeamMemberId { get; set; }

    /// <summary>
    /// **Required** The ordered list of jobs that the team member is assigned to.
    /// The first job assignment is considered the team member's primary job.
    /// </summary>
    [JsonPropertyName("job_assignments")]
    public IEnumerable<JobAssignment>? JobAssignments { get; set; }

    /// <summary>
    /// Whether the team member is exempt from the overtime rules of the seller's country.
    /// </summary>
    [JsonPropertyName("is_overtime_exempt")]
    public bool? IsOvertimeExempt { get; set; }

    /// <summary>
    /// **Read only** Used for resolving concurrency issues. The request fails if the version
    /// provided does not match the server version at the time of the request. If not provided,
    /// Square executes a blind write, potentially overwriting data from another write. For more information,
    /// see [optimistic concurrency](https://developer.squareup.com/docs/working-with-apis/optimistic-concurrency).
    /// </summary>
    [JsonPropertyName("version")]
    public int? Version { get; set; }

    /// <summary>
    /// The timestamp when the wage setting was created, in RFC 3339 format.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    /// <summary>
    /// The timestamp when the wage setting was last updated, in RFC 3339 format.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; set; }

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
