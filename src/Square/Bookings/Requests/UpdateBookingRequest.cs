using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Bookings;

public record UpdateBookingRequest
{
    /// <summary>
    /// The ID of the [Booking](entity:Booking) object representing the to-be-updated booking.
    /// </summary>
    [JsonIgnore]
    public required string BookingId { get; set; }

    /// <summary>
    /// A unique key to make this request an idempotent operation.
    /// </summary>
    [JsonPropertyName("idempotency_key")]
    public string? IdempotencyKey { get; set; }

    /// <summary>
    /// The booking to be updated. Individual attributes explicitly specified here override the corresponding values of the existing booking.
    /// </summary>
    [JsonPropertyName("booking")]
    public required Booking Booking { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
