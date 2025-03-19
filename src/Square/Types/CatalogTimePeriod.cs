using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a time period - either a single period or a repeating period.
/// </summary>
public record CatalogTimePeriod
{
    /// <summary>
    /// An iCalendar (RFC 5545) [event](https://tools.ietf.org/html/rfc5545#section-3.6.1), which
    /// specifies the name, timing, duration and recurrence of this time period.
    ///
    /// Example:
    ///
    /// ```
    /// DTSTART:20190707T180000
    /// DURATION:P2H
    /// RRULE:FREQ=WEEKLY;BYDAY=MO,WE,FR
    /// ```
    ///
    /// Only `SUMMARY`, `DTSTART`, `DURATION` and `RRULE` fields are supported.
    /// `DTSTART` must be in local (unzoned) time format. Note that while `BEGIN:VEVENT`
    /// and `END:VEVENT` is not required in the request. The response will always
    /// include them.
    /// </summary>
    [JsonPropertyName("event")]
    public string? Event { get; set; }

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
