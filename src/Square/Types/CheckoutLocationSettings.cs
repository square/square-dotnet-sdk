using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record CheckoutLocationSettings
{
    /// <summary>
    /// The ID of the location that these settings apply to.
    /// </summary>
    [JsonPropertyName("location_id")]
    public string? LocationId { get; set; }

    /// <summary>
    /// Indicates whether customers are allowed to leave notes at checkout.
    /// </summary>
    [JsonPropertyName("customer_notes_enabled")]
    public bool? CustomerNotesEnabled { get; set; }

    /// <summary>
    /// Policy information is displayed at the bottom of the checkout pages.
    /// You can set a maximum of two policies.
    /// </summary>
    [JsonPropertyName("policies")]
    public IEnumerable<CheckoutLocationSettingsPolicy>? Policies { get; set; }

    /// <summary>
    /// The branding settings for this location.
    /// </summary>
    [JsonPropertyName("branding")]
    public CheckoutLocationSettingsBranding? Branding { get; set; }

    /// <summary>
    /// The tip settings for this location.
    /// </summary>
    [JsonPropertyName("tipping")]
    public CheckoutLocationSettingsTipping? Tipping { get; set; }

    /// <summary>
    /// The coupon settings for this location.
    /// </summary>
    [JsonPropertyName("coupons")]
    public CheckoutLocationSettingsCoupons? Coupons { get; set; }

    /// <summary>
    /// The timestamp when the settings were last updated, in RFC 3339 format.
    /// Examples for January 25th, 2020 6:25:34pm Pacific Standard Time:
    /// UTC: 2020-01-26T02:25:34Z
    /// Pacific Standard Time with UTC offset: 2020-01-25T18:25:34-08:00
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    /// <remarks>
    /// [EXPERIMENTAL] This API is experimental and may change in future releases.
    /// </remarks>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
