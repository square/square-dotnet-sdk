using System.Text.Json.Serialization;
using Square.Core;
using Square.Default;

namespace Square.Default.Bookings;

[Serializable]
public record CreateBookingRequest
{
    /// <summary>
    /// A unique key to make this request an idempotent operation.
    /// </summary>
    [JsonPropertyName("idempotency_key")]
    public string? IdempotencyKey { get; set; }

    /// <summary>
    /// The details of the booking to be created.
    /// </summary>
    [JsonPropertyName("booking")]
    public required Booking Booking { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
