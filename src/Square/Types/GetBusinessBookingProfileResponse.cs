using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record GetBusinessBookingProfileResponse
{
    /// <summary>
    /// The seller's booking profile.
    /// </summary>
    [JsonPropertyName("business_booking_profile")]
    public BusinessBookingProfile? BusinessBookingProfile { get; set; }

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
