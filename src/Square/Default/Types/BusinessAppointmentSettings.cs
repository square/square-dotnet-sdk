using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// The service appointment settings, including where and how the service is provided.
/// </summary>
[Serializable]
public record BusinessAppointmentSettings : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Types of the location allowed for bookings.
    /// See [BusinessAppointmentSettingsBookingLocationType](#type-businessappointmentsettingsbookinglocationtype) for possible values
    /// </summary>
    [JsonPropertyName("location_types")]
    public IEnumerable<BusinessAppointmentSettingsBookingLocationType>? LocationTypes { get; set; }

    /// <summary>
    /// The time unit of the service duration for bookings.
    /// See [BusinessAppointmentSettingsAlignmentTime](#type-businessappointmentsettingsalignmenttime) for possible values
    /// </summary>
    [JsonPropertyName("alignment_time")]
    public BusinessAppointmentSettingsAlignmentTime? AlignmentTime { get; set; }

    /// <summary>
    /// The minimum lead time in seconds before a service can be booked. A booking must be created at least this amount of time before its starting time.
    /// </summary>
    [JsonPropertyName("min_booking_lead_time_seconds")]
    public int? MinBookingLeadTimeSeconds { get; set; }

    /// <summary>
    /// The maximum lead time in seconds before a service can be booked. A booking must be created at most this amount of time before its starting time.
    /// </summary>
    [JsonPropertyName("max_booking_lead_time_seconds")]
    public int? MaxBookingLeadTimeSeconds { get; set; }

    /// <summary>
    /// Indicates whether a customer can choose from all available time slots and have a staff member assigned
    /// automatically (`true`) or not (`false`).
    /// </summary>
    [JsonPropertyName("any_team_member_booking_enabled")]
    public bool? AnyTeamMemberBookingEnabled { get; set; }

    /// <summary>
    /// Indicates whether a customer can book multiple services in a single online booking.
    /// </summary>
    [JsonPropertyName("multiple_service_booking_enabled")]
    public bool? MultipleServiceBookingEnabled { get; set; }

    /// <summary>
    /// Indicates whether the daily appointment limit applies to team members or to
    /// business locations.
    /// See [BusinessAppointmentSettingsMaxAppointmentsPerDayLimitType](#type-businessappointmentsettingsmaxappointmentsperdaylimittype) for possible values
    /// </summary>
    [JsonPropertyName("max_appointments_per_day_limit_type")]
    public BusinessAppointmentSettingsMaxAppointmentsPerDayLimitType? MaxAppointmentsPerDayLimitType { get; set; }

    /// <summary>
    /// The maximum number of daily appointments per team member or per location.
    /// </summary>
    [JsonPropertyName("max_appointments_per_day_limit")]
    public int? MaxAppointmentsPerDayLimit { get; set; }

    /// <summary>
    /// The cut-off time in seconds for allowing clients to cancel or reschedule an appointment.
    /// </summary>
    [JsonPropertyName("cancellation_window_seconds")]
    public int? CancellationWindowSeconds { get; set; }

    /// <summary>
    /// The flat-fee amount charged for a no-show booking.
    /// </summary>
    [JsonPropertyName("cancellation_fee_money")]
    public Money? CancellationFeeMoney { get; set; }

    /// <summary>
    /// The cancellation policy adopted by the seller.
    /// See [BusinessAppointmentSettingsCancellationPolicy](#type-businessappointmentsettingscancellationpolicy) for possible values
    /// </summary>
    [JsonPropertyName("cancellation_policy")]
    public BusinessAppointmentSettingsCancellationPolicy? CancellationPolicy { get; set; }

    /// <summary>
    /// The free-form text of the seller's cancellation policy.
    /// </summary>
    [JsonPropertyName("cancellation_policy_text")]
    public string? CancellationPolicyText { get; set; }

    /// <summary>
    /// Indicates whether customers has an assigned staff member (`true`) or can select s staff member of their choice (`false`).
    /// </summary>
    [JsonPropertyName("skip_booking_flow_staff_selection")]
    public bool? SkipBookingFlowStaffSelection { get; set; }

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
