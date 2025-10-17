using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a job assigned to a [team member](entity:TeamMember), including the compensation the team
/// member earns for the job. Job assignments are listed in the team member's [wage setting](entity:WageSetting).
/// </summary>
[Serializable]
public record JobAssignment : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The title of the job.
    /// </summary>
    [JsonPropertyName("job_title")]
    public string? JobTitle { get; set; }

    /// <summary>
    /// The current pay type for the job assignment used to
    /// calculate the pay amount in a pay period.
    /// See [JobAssignmentPayType](#type-jobassignmentpaytype) for possible values
    /// </summary>
    [JsonPropertyName("pay_type")]
    public required JobAssignmentPayType PayType { get; set; }

    /// <summary>
    /// The hourly pay rate of the job. For `SALARY` pay types, Square calculates the hourly rate based on
    /// `annual_rate` and `weekly_hours`.
    /// </summary>
    [JsonPropertyName("hourly_rate")]
    public Money? HourlyRate { get; set; }

    /// <summary>
    /// The total pay amount for a 12-month period on the job. Set if the job `PayType` is `SALARY`.
    /// </summary>
    [JsonPropertyName("annual_rate")]
    public Money? AnnualRate { get; set; }

    /// <summary>
    /// The planned hours per week for the job. Set if the job `PayType` is `SALARY`.
    /// </summary>
    [JsonPropertyName("weekly_hours")]
    public int? WeeklyHours { get; set; }

    /// <summary>
    /// The ID of the [job](entity:Job).
    /// </summary>
    [JsonPropertyName("job_id")]
    public string? JobId { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
