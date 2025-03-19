using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<BusinessAppointmentSettingsAlignmentTime>))]
public readonly record struct BusinessAppointmentSettingsAlignmentTime : IStringEnum
{
    public static readonly BusinessAppointmentSettingsAlignmentTime ServiceDuration = new(
        Values.ServiceDuration
    );

    public static readonly BusinessAppointmentSettingsAlignmentTime QuarterHourly = new(
        Values.QuarterHourly
    );

    public static readonly BusinessAppointmentSettingsAlignmentTime HalfHourly = new(
        Values.HalfHourly
    );

    public static readonly BusinessAppointmentSettingsAlignmentTime Hourly = new(Values.Hourly);

    public BusinessAppointmentSettingsAlignmentTime(string value)
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
    public static BusinessAppointmentSettingsAlignmentTime FromCustom(string value)
    {
        return new BusinessAppointmentSettingsAlignmentTime(value);
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
        BusinessAppointmentSettingsAlignmentTime value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        BusinessAppointmentSettingsAlignmentTime value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(BusinessAppointmentSettingsAlignmentTime value) =>
        value.Value;

    public static explicit operator BusinessAppointmentSettingsAlignmentTime(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string ServiceDuration = "SERVICE_DURATION";

        public const string QuarterHourly = "QUARTER_HOURLY";

        public const string HalfHourly = "HALF_HOURLY";

        public const string Hourly = "HOURLY";
    }
}
