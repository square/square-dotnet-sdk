using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a job that can be assigned to [team members](entity:TeamMember). This object defines the
/// job's title and tip eligibility. Compensation is defined in a [job assignment](entity:JobAssignment)
/// in a team member's wage setting.
/// </summary>
public record Job
{
    /// <summary>
    /// **Read only** The unique Square-assigned ID of the job. If you need a job ID for an API request,
    /// call [ListJobs](api-endpoint:Team-ListJobs) or use the ID returned when you created the job.
    /// You can also get job IDs from a team member's wage setting.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The title of the job.
    /// </summary>
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    /// <summary>
    /// Indicates whether team members can earn tips for the job.
    /// </summary>
    [JsonPropertyName("is_tip_eligible")]
    public bool? IsTipEligible { get; set; }

    /// <summary>
    /// The timestamp when the job was created, in RFC 3339 format.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    /// <summary>
    /// The timestamp when the job was last updated, in RFC 3339 format.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; set; }

    /// <summary>
    /// **Read only** The current version of the job. Include this field in `UpdateJob` requests to enable
    /// [optimistic concurrency](https://developer.squareup.com/docs/working-with-apis/optimistic-concurrency)
    /// control and avoid overwrites from concurrent requests. Requests fail if the provided version doesn't
    /// match the server version at the time of the request.
    /// </summary>
    [JsonPropertyName("version")]
    public int? Version { get; set; }

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
