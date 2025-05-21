using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// The hourly wage rate used to compensate a team member for a [timecard](entity:Timecard).
/// </summary>
public record TimecardWage
{
    /// <summary>
    /// The name of the job performed during this timecard.
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
    /// The ID of the [job](entity:Job) performed for this timecard. Square
    /// labor-reporting UIs might group timecards together by ID.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
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
    /// <remarks>
    /// [EXPERIMENTAL] This API is experimental and may change in future releases.
    /// </remarks>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
