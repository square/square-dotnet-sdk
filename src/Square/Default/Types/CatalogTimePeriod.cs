using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Represents a time period - either a single period or a repeating period.
/// </summary>
[Serializable]
public record CatalogTimePeriod : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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
