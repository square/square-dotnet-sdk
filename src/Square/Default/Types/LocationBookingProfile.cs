using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// The booking profile of a seller's location, including the location's ID and whether the location is enabled for online booking.
/// </summary>
[Serializable]
public record LocationBookingProfile : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
