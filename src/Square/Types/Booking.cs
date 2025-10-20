using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a booking as a time-bound service contract for a seller's staff member to provide a specified service
/// at a given location to a requesting customer in one or more appointment segments.
/// </summary>
[Serializable]
public record Booking : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// A unique ID of this object representing a booking.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The revision number for the booking used for optimistic concurrency.
    /// </summary>
    [JsonPropertyName("version")]
    public int? Version { get; set; }

    /// <summary>
    /// The status of the booking, describing where the booking stands with respect to the booking state machine.
    /// See [BookingStatus](#type-bookingstatus) for possible values
    /// </summary>
    [JsonPropertyName("status")]
    public BookingStatus? Status { get; set; }

    /// <summary>
    /// The RFC 3339 timestamp specifying the creation time of this booking.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    /// <summary>
    /// The RFC 3339 timestamp specifying the most recent update time of this booking.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; set; }

    /// <summary>
    /// The RFC 3339 timestamp specifying the starting time of this booking.
    /// </summary>
    [JsonPropertyName("start_at")]
    public string? StartAt { get; set; }

    /// <summary>
    /// The ID of the [Location](entity:Location) object representing the location where the booked service is provided. Once set when the booking is created, its value cannot be changed.
    /// </summary>
    [JsonPropertyName("location_id")]
    public string? LocationId { get; set; }

    /// <summary>
    /// The ID of the [Customer](entity:Customer) object representing the customer receiving the booked service.
    /// </summary>
    [JsonPropertyName("customer_id")]
    public string? CustomerId { get; set; }

    /// <summary>
    /// The free-text field for the customer to supply notes about the booking. For example, the note can be preferences that cannot be expressed by supported attributes of a relevant [CatalogObject](entity:CatalogObject) instance.
    /// </summary>
    [JsonPropertyName("customer_note")]
    public string? CustomerNote { get; set; }

    /// <summary>
    /// The free-text field for the seller to supply notes about the booking. For example, the note can be preferences that cannot be expressed by supported attributes of a specific [CatalogObject](entity:CatalogObject) instance.
    /// This field should not be visible to customers.
    /// </summary>
    [JsonPropertyName("seller_note")]
    public string? SellerNote { get; set; }

    /// <summary>
    /// A list of appointment segments for this booking.
    /// </summary>
    [JsonPropertyName("appointment_segments")]
    public IEnumerable<AppointmentSegment>? AppointmentSegments { get; set; }

    /// <summary>
    /// Additional time at the end of a booking.
    /// Applications should not make this field visible to customers of a seller.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("transition_time_minutes")]
    public int? TransitionTimeMinutes { get; set; }

    /// <summary>
    /// Whether the booking is of a full business day.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("all_day")]
    public bool? AllDay { get; set; }

    /// <summary>
    /// The type of location where the booking is held.
    /// See [BusinessAppointmentSettingsBookingLocationType](#type-businessappointmentsettingsbookinglocationtype) for possible values
    /// </summary>
    [JsonPropertyName("location_type")]
    public BusinessAppointmentSettingsBookingLocationType? LocationType { get; set; }

    /// <summary>
    /// Information about the booking creator.
    /// </summary>
    [JsonPropertyName("creator_details")]
    public BookingCreatorDetails? CreatorDetails { get; set; }

    /// <summary>
    /// The source of the booking.
    /// Access to this field requires seller-level permissions.
    /// See [BookingBookingSource](#type-bookingbookingsource) for possible values
    /// </summary>
    [JsonPropertyName("source")]
    public BookingBookingSource? Source { get; set; }

    /// <summary>
    /// Stores a customer address if the location type is `CUSTOMER_LOCATION`.
    /// </summary>
    [JsonPropertyName("address")]
    public Address? Address { get; set; }

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
