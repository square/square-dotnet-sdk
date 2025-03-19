using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Bookings;

public record BulkRetrieveBookingsRequest
{
    /// <summary>
    /// A non-empty list of [Booking](entity:Booking) IDs specifying bookings to retrieve.
    /// </summary>
    [JsonPropertyName("booking_ids")]
    public IEnumerable<string> BookingIds { get; set; } = new List<string>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
