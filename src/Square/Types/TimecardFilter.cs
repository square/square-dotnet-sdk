using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Defines a filter used in a search for `Timecard` records. `AND` logic is
/// used by Square's servers to apply each filter property specified.
/// </summary>
public record TimecardFilter
{
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
