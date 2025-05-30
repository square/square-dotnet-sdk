using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a time period of availability.
/// </summary>
public record CatalogAvailabilityPeriod
{
    /// <summary>
    /// The start time of an availability period, specified in local time using partial-time
    /// RFC 3339 format. For example, `8:30:00` for a period starting at 8:30 in the morning.
    /// Note that the seconds value is always :00, but it is appended for conformance to the RFC.
    /// </summary>
    [JsonPropertyName("start_local_time")]
    public string? StartLocalTime { get; set; }

    /// <summary>
    /// The end time of an availability period, specified in local time using partial-time
    /// RFC 3339 format. For example, `21:00:00` for a period ending at 9:00 in the evening.
    /// Note that the seconds value is always :00, but it is appended for conformance to the RFC.
    /// </summary>
    [JsonPropertyName("end_local_time")]
    public string? EndLocalTime { get; set; }

    /// <summary>
    /// The day of the week for this availability period.
    /// See [DayOfWeek](#type-dayofweek) for possible values
    /// </summary>
    [JsonPropertyName("day_of_week")]
    public DayOfWeek? DayOfWeek { get; set; }

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
