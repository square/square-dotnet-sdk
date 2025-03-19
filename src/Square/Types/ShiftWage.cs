using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// The hourly wage rate used to compensate an employee for this shift.
/// </summary>
public record ShiftWage
{
    /// <summary>
    /// The name of the job performed during this shift.
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
    /// The id of the job performed during this shift. Square
    /// labor-reporting UIs might group shifts together by id. This cannot be used to retrieve the job.
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
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
