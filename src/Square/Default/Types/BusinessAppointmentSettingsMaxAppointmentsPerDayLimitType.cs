using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[JsonConverter(
    typeof(StringEnumSerializer<BusinessAppointmentSettingsMaxAppointmentsPerDayLimitType>)
)]
[Serializable]
public readonly record struct BusinessAppointmentSettingsMaxAppointmentsPerDayLimitType
    : IStringEnum
{
    public static readonly BusinessAppointmentSettingsMaxAppointmentsPerDayLimitType PerTeamMember =
        new(Values.PerTeamMember);

    public static readonly BusinessAppointmentSettingsMaxAppointmentsPerDayLimitType PerLocation =
        new(Values.PerLocation);

    public BusinessAppointmentSettingsMaxAppointmentsPerDayLimitType(string value)
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
    public static BusinessAppointmentSettingsMaxAppointmentsPerDayLimitType FromCustom(string value)
    {
        return new BusinessAppointmentSettingsMaxAppointmentsPerDayLimitType(value);
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
        BusinessAppointmentSettingsMaxAppointmentsPerDayLimitType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        BusinessAppointmentSettingsMaxAppointmentsPerDayLimitType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        BusinessAppointmentSettingsMaxAppointmentsPerDayLimitType value
    ) => value.Value;

    public static explicit operator BusinessAppointmentSettingsMaxAppointmentsPerDayLimitType(
        string value
    ) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string PerTeamMember = "PER_TEAM_MEMBER";

        public const string PerLocation = "PER_LOCATION";
    }
}
