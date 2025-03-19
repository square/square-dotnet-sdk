using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// The hourly wage rate that a team member earns on a `Shift` for doing the job
/// specified by the `title` property of this object.
/// </summary>
public record TeamMemberWage
{
    /// <summary>
    /// The UUID for this object.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The `TeamMember` that this wage is assigned to.
    /// </summary>
    [JsonPropertyName("team_member_id")]
    public string? TeamMemberId { get; set; }

    /// <summary>
    /// The job title that this wage relates to.
    /// </summary>
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    /// <summary>
    /// Can be a custom-set hourly wage or the calculated effective hourly
    /// wage based on the annual wage and hours worked per week.
    /// </summary>
    [JsonPropertyName("hourly_rate")]
    public Money? HourlyRate { get; set; }

    /// <summary>
    /// An identifier for the job that this wage relates to. This cannot be
    /// used to retrieve the job.
    /// </summary>
    [JsonPropertyName("job_id")]
    public string? JobId { get; set; }

    /// <summary>
    /// Whether team members are eligible for tips when working this job.
    /// </summary>
    [JsonPropertyName("tip_eligible")]
    public bool? TipEligible { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
