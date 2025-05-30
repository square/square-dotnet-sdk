using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<ShiftWorkdayMatcher>))]
public readonly record struct ShiftWorkdayMatcher : IStringEnum
{
    public static readonly ShiftWorkdayMatcher StartAt = new(Values.StartAt);

    public static readonly ShiftWorkdayMatcher EndAt = new(Values.EndAt);

    public static readonly ShiftWorkdayMatcher Intersection = new(Values.Intersection);

    public ShiftWorkdayMatcher(string value)
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
    public static ShiftWorkdayMatcher FromCustom(string value)
    {
        return new ShiftWorkdayMatcher(value);
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

    public static bool operator ==(ShiftWorkdayMatcher value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ShiftWorkdayMatcher value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ShiftWorkdayMatcher value) => value.Value;

    public static explicit operator ShiftWorkdayMatcher(string value) => new(value);

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
