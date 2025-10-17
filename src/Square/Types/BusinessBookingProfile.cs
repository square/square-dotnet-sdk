using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// A seller's business booking profile, including booking policy, appointment settings, etc.
/// </summary>
[Serializable]
public record BusinessBookingProfile : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The ID of the seller, obtainable using the Merchants API.
    /// </summary>
    [JsonPropertyName("seller_id")]
    public string? SellerId { get; set; }

    /// <summary>
    /// The RFC 3339 timestamp specifying the booking's creation time.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    /// <summary>
    /// Indicates whether the seller is open for booking.
    /// </summary>
    [JsonPropertyName("booking_enabled")]
    public bool? BookingEnabled { get; set; }

    /// <summary>
    /// The choice of customer's time zone information of a booking.
    /// The Square online booking site and all notifications to customers uses either the seller location’s time zone
    /// or the time zone the customer chooses at booking.
    /// See [BusinessBookingProfileCustomerTimezoneChoice](#type-businessbookingprofilecustomertimezonechoice) for possible values
    /// </summary>
    [JsonPropertyName("customer_timezone_choice")]
    public BusinessBookingProfileCustomerTimezoneChoice? CustomerTimezoneChoice { get; set; }

    /// <summary>
    /// The policy for the seller to automatically accept booking requests (`ACCEPT_ALL`) or not (`REQUIRES_ACCEPTANCE`).
    /// See [BusinessBookingProfileBookingPolicy](#type-businessbookingprofilebookingpolicy) for possible values
    /// </summary>
    [JsonPropertyName("booking_policy")]
    public BusinessBookingProfileBookingPolicy? BookingPolicy { get; set; }

    /// <summary>
    /// Indicates whether customers can cancel or reschedule their own bookings (`true`) or not (`false`).
    /// </summary>
    [JsonPropertyName("allow_user_cancel")]
    public bool? AllowUserCancel { get; set; }

    /// <summary>
    /// Settings for appointment-type bookings.
    /// </summary>
    [JsonPropertyName("business_appointment_settings")]
    public BusinessAppointmentSettings? BusinessAppointmentSettings { get; set; }

    /// <summary>
    /// Indicates whether the seller's subscription to Square Appointments supports creating, updating or canceling an appointment through the API (`true`) or not (`false`) using seller permission.
    /// </summary>
    [JsonPropertyName("support_seller_level_writes")]
    public bool? SupportSellerLevelWrites { get; set; }

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
