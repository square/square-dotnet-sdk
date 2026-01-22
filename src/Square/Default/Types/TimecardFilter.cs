using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Defines a filter used in a search for `Timecard` records. `AND` logic is
/// used by Square's servers to apply each filter property specified.
/// </summary>
[Serializable]
public record TimecardFilter : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Fetch timecards for the specified location.
    /// </summary>
    [JsonPropertyName("location_ids")]
    public IEnumerable<string>? LocationIds { get; set; }

    /// <summary>
    /// Fetch a `Timecard` instance by `Timecard.status`.
    /// See [TimecardFilterStatus](#type-timecardfilterstatus) for possible values
    /// </summary>
    [JsonPropertyName("status")]
    public TimecardFilterStatus? Status { get; set; }

    /// <summary>
    /// Fetch `Timecard` instances that start in the time range - Inclusive.
    /// </summary>
    [JsonPropertyName("start")]
    public TimeRange? Start { get; set; }

    /// <summary>
    /// Fetch the `Timecard` instances that end in the time range - Inclusive.
    /// </summary>
    [JsonPropertyName("end")]
    public TimeRange? End { get; set; }

    /// <summary>
    /// Fetch the `Timecard` instances based on the workday date range.
    /// </summary>
    [JsonPropertyName("workday")]
    public TimecardWorkday? Workday { get; set; }

    /// <summary>
    /// Fetch timecards for the specified team members.
    /// </summary>
    [JsonPropertyName("team_member_ids")]
    public IEnumerable<string>? TeamMemberIds { get; set; }

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
