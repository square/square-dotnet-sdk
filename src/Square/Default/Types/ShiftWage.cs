using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// The hourly wage rate used to compensate an employee for this shift.
///
/// Deprecated at Square API version 2025-05-21. See the [migration notes](https://developer.squareup.com/docs/labor-api/what-it-does#migration-notes).
/// </summary>
[Serializable]
public record ShiftWage : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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
    /// labor-reporting UIs might group shifts together by id.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("job_id")]
    public string? JobId { get; set; }

    /// <summary>
    /// Whether team members are eligible for tips when working this job.
    /// </summary>
    [JsonPropertyName("tip_eligible")]
    public bool? TipEligible { get; set; }

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
