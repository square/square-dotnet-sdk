using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Defines an appointment slot that encapsulates the appointment segments, location and starting time available for booking.
/// </summary>
public record Availability
{
    /// <summary>
    /// The RFC 3339 timestamp specifying the beginning time of the slot available for booking.
    /// </summary>
    [JsonPropertyName("start_at")]
    public string? StartAt { get; set; }

    /// <summary>
    /// The ID of the location available for booking.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("location_id")]
    public string? LocationId { get; set; }

    /// <summary>
    /// The list of appointment segments available for booking
    /// </summary>
    [JsonPropertyName("appointment_segments")]
    public IEnumerable<AppointmentSegment>? AppointmentSegments { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
