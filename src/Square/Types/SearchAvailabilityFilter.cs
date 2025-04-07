using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// A query filter to search for buyer-accessible availabilities by.
/// </summary>
public record SearchAvailabilityFilter
{
    /// <summary>
    /// The query expression to search for buy-accessible availabilities with their starting times falling within the specified time range.
    /// The time range must be at least 24 hours and at most 32 days long.
    /// For waitlist availabilities, the time range can be 0 or more up to 367 days long.
    /// </summary>
    [JsonPropertyName("start_at_range")]
    public required TimeRange StartAtRange { get; set; }

    /// <summary>
    /// The query expression to search for buyer-accessible availabilities with their location IDs matching the specified location ID.
    /// This query expression cannot be set if `booking_id` is set.
    /// </summary>
    [JsonPropertyName("location_id")]
    public string? LocationId { get; set; }

    /// <summary>
    /// The query expression to search for buyer-accessible availabilities matching the specified list of segment filters.
    /// If the size of the `segment_filters` list is `n`, the search returns availabilities with `n` segments per availability.
    ///
    /// This query expression cannot be set if `booking_id` is set.
    /// </summary>
    [JsonPropertyName("segment_filters")]
    public IEnumerable<SegmentFilter>? SegmentFilters { get; set; }

    /// <summary>
    /// The query expression to search for buyer-accessible availabilities for an existing booking by matching the specified `booking_id` value.
    /// This is commonly used to reschedule an appointment.
    /// If this expression is set, the `location_id` and `segment_filters` expressions cannot be set.
    /// </summary>
    [JsonPropertyName("booking_id")]
    public string? BookingId { get; set; }

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
