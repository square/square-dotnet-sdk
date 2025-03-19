using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Bookings;

public record RetrieveLocationBookingProfileRequest
{
    /// <summary>
    /// The ID of the location to retrieve the booking profile.
    /// </summary>
    [JsonIgnore]
    public required string LocationId { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
