using System.Text.Json.Serialization;
using Square.Core;
using Square.Default;

namespace Square.Default.Bookings;

[Serializable]
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
