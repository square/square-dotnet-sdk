using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default.Bookings;

[Serializable]
public record CancelBookingRequest
{
    /// <summary>
    /// The ID of the [Booking](entity:Booking) object representing the to-be-cancelled booking.
    /// </summary>
    [JsonIgnore]
    public required string BookingId { get; set; }

    /// <summary>
    /// A unique key to make this request an idempotent operation.
    /// </summary>
    [JsonPropertyName("idempotency_key")]
    public string? IdempotencyKey { get; set; }

    /// <summary>
    /// The revision number for the booking used for optimistic concurrency.
    /// </summary>
    [JsonPropertyName("booking_version")]
    public int? BookingVersion { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
