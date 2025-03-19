using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record RetrieveLocationBookingProfileResponse
{
    /// <summary>
    /// The requested location booking profile.
    /// </summary>
    [JsonPropertyName("location_booking_profile")]
    public LocationBookingProfile? LocationBookingProfile { get; set; }

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
