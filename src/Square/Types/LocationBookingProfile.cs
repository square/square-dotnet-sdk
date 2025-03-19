using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// The booking profile of a seller's location, including the location's ID and whether the location is enabled for online booking.
/// </summary>
public record LocationBookingProfile
{
    /// <summary>
    /// The ID of the [location](entity:Location).
    /// </summary>
    [JsonPropertyName("location_id")]
    public string? LocationId { get; set; }

    /// <summary>
    /// Url for the online booking site for this location.
    /// </summary>
    [JsonPropertyName("booking_site_url")]
    public string? BookingSiteUrl { get; set; }

    /// <summary>
    /// Indicates whether the location is enabled for online booking.
    /// </summary>
    [JsonPropertyName("online_booking_enabled")]
    public bool? OnlineBookingEnabled { get; set; }

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
