using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// A `Shift` search query filter parameter that sets a range of days that
/// a `Shift` must start or end in before passing the filter condition.
/// </summary>
public record ShiftWorkday
{
    /// <summary>
    /// Dates for fetching the shifts.
    /// </summary>
    [JsonPropertyName("date_range")]
    public DateRange? DateRange { get; set; }

    /// <summary>
    /// The strategy on which the dates are applied.
    /// See [ShiftWorkdayMatcher](#type-shiftworkdaymatcher) for possible values
    /// </summary>
    [JsonPropertyName("match_shifts_by")]
    public ShiftWorkdayMatcher? MatchShiftsBy { get; set; }

    /// <summary>
    /// Location-specific timezones convert workdays to datetime filters.
    /// Every location included in the query must have a timezone or this field
    /// must be provided as a fallback. Format: the IANA timezone database
    /// identifier for the relevant timezone.
    /// </summary>
    [JsonPropertyName("default_timezone")]
    public string? DefaultTimezone { get; set; }

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
