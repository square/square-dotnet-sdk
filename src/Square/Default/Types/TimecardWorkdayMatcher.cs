using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[JsonConverter(typeof(StringEnumSerializer<TimecardWorkdayMatcher>))]
[Serializable]
public readonly record struct TimecardWorkdayMatcher : IStringEnum
{
    public static readonly TimecardWorkdayMatcher StartAt = new(Values.StartAt);

    public static readonly TimecardWorkdayMatcher EndAt = new(Values.EndAt);

    public static readonly TimecardWorkdayMatcher Intersection = new(Values.Intersection);

    public TimecardWorkdayMatcher(string value)
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
    public static TimecardWorkdayMatcher FromCustom(string value)
    {
        return new TimecardWorkdayMatcher(value);
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

    public static bool operator ==(TimecardWorkdayMatcher value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TimecardWorkdayMatcher value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TimecardWorkdayMatcher value) => value.Value;

    public static explicit operator TimecardWorkdayMatcher(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string StartAt = "START_AT";

        public const string EndAt = "END_AT";

        public const string Intersection = "INTERSECTION";
    }
}
