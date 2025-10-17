using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<BusinessAppointmentSettingsBookingLocationType>))]
[Serializable]
public readonly record struct BusinessAppointmentSettingsBookingLocationType : IStringEnum
{
    public static readonly BusinessAppointmentSettingsBookingLocationType BusinessLocation = new(
        Values.BusinessLocation
    );

    public static readonly BusinessAppointmentSettingsBookingLocationType CustomerLocation = new(
        Values.CustomerLocation
    );

    public static readonly BusinessAppointmentSettingsBookingLocationType Phone = new(Values.Phone);

    public BusinessAppointmentSettingsBookingLocationType(string value)
    {
        Value = value;
    }

    /// <summary>
    /// The string value of the enum.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Create a string enum with the given value.
    /// </summary>
    public static BusinessAppointmentSettingsBookingLocationType FromCustom(string value)
    {
        return new BusinessAppointmentSettingsBookingLocationType(value);
    }

    public bool Equals(string? other)
    {
        return Value.Equals(other);
    }

    /// <summary>
    /// Returns the string value of the enum.
    /// </summary>
    public override string ToString()
    {
        return Value;
    }

    public static bool operator ==(
        BusinessAppointmentSettingsBookingLocationType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        BusinessAppointmentSettingsBookingLocationType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(BusinessAppointmentSettingsBookingLocationType value) =>
        value.Value;

    public static explicit operator BusinessAppointmentSettingsBookingLocationType(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string BusinessLocation = "BUSINESS_LOCATION";

        public const string CustomerLocation = "CUSTOMER_LOCATION";

        public const string Phone = "PHONE";
    }
}
