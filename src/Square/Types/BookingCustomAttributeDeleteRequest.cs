using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents an individual delete request in a [BulkDeleteBookingCustomAttributes](api-endpoint:BookingCustomAttributes-BulkDeleteBookingCustomAttributes)
/// request. An individual request contains a booking ID, the custom attribute to delete, and an optional idempotency key.
/// </summary>
public record BookingCustomAttributeDeleteRequest
{
    /// <summary>
    /// The ID of the target [booking](entity:Booking).
    /// </summary>
    [JsonPropertyName("booking_id")]
    public required string BookingId { get; set; }

    /// <summary>
    /// The key of the custom attribute to delete. This key must match the `key` of a
    /// custom attribute definition in the Square seller account. If the requesting application is not
    /// the definition owner, you must use the qualified key.
    /// </summary>
    [JsonPropertyName("key")]
    public required string Key { get; set; }

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
