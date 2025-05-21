using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<ScheduledShiftWorkdayMatcher>))]
public readonly record struct ScheduledShiftWorkdayMatcher : IStringEnum
{
    public static readonly ScheduledShiftWorkdayMatcher StartAt = new(Values.StartAt);

    public static readonly ScheduledShiftWorkdayMatcher EndAt = new(Values.EndAt);

    public static readonly ScheduledShiftWorkdayMatcher Intersection = new(Values.Intersection);

    public ScheduledShiftWorkdayMatcher(string value)
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
    public static ScheduledShiftWorkdayMatcher FromCustom(string value)
    {
        return new ScheduledShiftWorkdayMatcher(value);
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

    public static bool operator ==(ScheduledShiftWorkdayMatcher value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ScheduledShiftWorkdayMatcher value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ScheduledShiftWorkdayMatcher value) => value.Value;

    public static explicit operator ScheduledShiftWorkdayMatcher(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string StartAt = "START_AT";

        public const string EndAt = "END_AT";

        public const string Intersection = "INTERSECTION";
    }
}
