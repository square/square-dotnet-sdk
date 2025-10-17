using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// A `ScheduledShift` search query filter parameter that sets a range of days that
/// a `Shift` must start or end in before passing the filter condition.
/// </summary>
[Serializable]
public record ScheduledShiftWorkday : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Dates for fetching the scheduled shifts.
    /// </summary>
    [JsonPropertyName("date_range")]
    public DateRange? DateRange { get; set; }

    /// <summary>
    /// The strategy on which the dates are applied.
    /// See [ScheduledShiftWorkdayMatcher](#type-scheduledshiftworkdaymatcher) for possible values
    /// </summary>
    [JsonPropertyName("match_scheduled_shifts_by")]
    public ScheduledShiftWorkdayMatcher? MatchScheduledShiftsBy { get; set; }

    /// <summary>
    /// Location-specific timezones convert workdays to datetime filters.
    /// Every location included in the query must have a timezone or this field
    /// must be provided as a fallback. Format: the IANA timezone database
    /// identifier for the relevant timezone.
    /// </summary>
    [JsonPropertyName("default_timezone")]
    public string? DefaultTimezone { get; set; }

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
