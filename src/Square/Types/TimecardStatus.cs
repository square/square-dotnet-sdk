using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<TimecardStatus>))]
[Serializable]
public readonly record struct TimecardStatus : IStringEnum
{
    public static readonly TimecardStatus Open = new(Values.Open);

    public static readonly TimecardStatus Closed = new(Values.Closed);

    public TimecardStatus(string value)
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
    public static TimecardStatus FromCustom(string value)
    {
        return new TimecardStatus(value);
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

    public static bool operator ==(TimecardStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TimecardStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TimecardStatus value) => value.Value;

    public static explicit operator TimecardStatus(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Open = "OPEN";

        public const string Closed = "CLOSED";
    }
}
