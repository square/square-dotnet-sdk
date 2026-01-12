using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[JsonConverter(typeof(StringEnumSerializer<ScheduledShiftNotificationAudience>))]
[Serializable]
public readonly record struct ScheduledShiftNotificationAudience : IStringEnum
{
    public static readonly ScheduledShiftNotificationAudience All = new(Values.All);

    public static readonly ScheduledShiftNotificationAudience Affected = new(Values.Affected);

    public static readonly ScheduledShiftNotificationAudience None = new(Values.None);

    public ScheduledShiftNotificationAudience(string value)
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
    public static ScheduledShiftNotificationAudience FromCustom(string value)
    {
        return new ScheduledShiftNotificationAudience(value);
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

    public static bool operator ==(ScheduledShiftNotificationAudience value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ScheduledShiftNotificationAudience value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ScheduledShiftNotificationAudience value) => value.Value;

    public static explicit operator ScheduledShiftNotificationAudience(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string All = "ALL";

        public const string Affected = "AFFECTED";

        public const string None = "NONE";
    }
}
