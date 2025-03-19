using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Bookings;

public record SearchAvailabilityRequest
{
    /// <summary>
    /// Query conditions used to filter buyer-accessible booking availabilities.
    /// </summary>
    [JsonPropertyName("query")]
    public required SearchAvailabilityQuery Query { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
