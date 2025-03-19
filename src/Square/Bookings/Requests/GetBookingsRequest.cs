using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Bookings;

public record GetBookingsRequest
{
    /// <summary>
    /// The ID of the [Booking](entity:Booking) object representing the to-be-retrieved booking.
    /// </summary>
    [JsonIgnore]
    public required string BookingId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
