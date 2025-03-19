using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Checkout;

public record UpdateLocationSettingsRequest
{
    /// <summary>
    /// The ID of the location for which to retrieve settings.
    /// </summary>
    [JsonIgnore]
    public required string LocationId { get; set; }

    /// <summary>
    /// Describe your updates using the `location_settings` object. Make sure it contains only the fields that have changed.
    /// </summary>
    [JsonPropertyName("location_settings")]
    public required CheckoutLocationSettings LocationSettings { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
