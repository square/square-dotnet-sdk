using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Sets the day of the week and hour of the day that a business starts a
/// workweek. This is used to calculate overtime pay.
/// </summary>
public record WorkweekConfig
{
    /// <summary>
    /// The UUID for this object.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The day of the week on which a business week starts for
    /// compensation purposes.
    /// See [Weekday](#type-weekday) for possible values
    /// </summary>
    [JsonPropertyName("start_of_week")]
    public required Weekday StartOfWeek { get; set; }

    /// <summary>
    /// The local time at which a business week starts. Represented as a
    /// string in `HH:MM` format (`HH:MM:SS` is also accepted, but seconds are
    /// truncated).
    /// </summary>
    [JsonPropertyName("start_of_day_local_time")]
    public required string StartOfDayLocalTime { get; set; }

    /// <summary>
    /// Used for resolving concurrency issues. The request fails if the version
    /// provided does not match the server version at the time of the request. If not provided,
    /// Square executes a blind write; potentially overwriting data from another
    /// write.
    /// </summary>
    [JsonPropertyName("version")]
    public int? Version { get; set; }

    /// <summary>
    /// A read-only timestamp in RFC 3339 format; presented in UTC.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    /// <summary>
    /// A read-only timestamp in RFC 3339 format; presented in UTC.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; set; }

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
