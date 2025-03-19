using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<BusinessAppointmentSettingsCancellationPolicy>))]
public readonly record struct BusinessAppointmentSettingsCancellationPolicy : IStringEnum
{
    public static readonly BusinessAppointmentSettingsCancellationPolicy CancellationTreatedAsNoShow =
        new(Values.CancellationTreatedAsNoShow);

    public static readonly BusinessAppointmentSettingsCancellationPolicy CustomPolicy = new(
        Values.CustomPolicy
    );

    public BusinessAppointmentSettingsCancellationPolicy(string value)
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
    public static BusinessAppointmentSettingsCancellationPolicy FromCustom(string value)
    {
        return new BusinessAppointmentSettingsCancellationPolicy(value);
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
        BusinessAppointmentSettingsCancellationPolicy value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        BusinessAppointmentSettingsCancellationPolicy value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(BusinessAppointmentSettingsCancellationPolicy value) =>
        value.Value;

    public static explicit operator BusinessAppointmentSettingsCancellationPolicy(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string CancellationTreatedAsNoShow = "CANCELLATION_TREATED_AS_NO_SHOW";

        public const string CustomPolicy = "CUSTOM_POLICY";
    }
}
