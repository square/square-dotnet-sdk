using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Response payload for bulk retrieval of bookings.
/// </summary>
public record BulkRetrieveBookingsResponse
{
    /// <summary>
    /// Requested bookings returned as a map containing `booking_id` as the key and `RetrieveBookingResponse` as the value.
    /// </summary>
    [JsonPropertyName("bookings")]
    public Dictionary<string, GetBookingResponse>? Bookings { get; set; }

    /// <summary>
    /// Errors that occurred during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

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
