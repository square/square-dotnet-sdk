using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<TimecardFilterStatus>))]
[Serializable]
public readonly record struct TimecardFilterStatus : IStringEnum
{
    public static readonly TimecardFilterStatus Open = new(Values.Open);

    public static readonly TimecardFilterStatus Closed = new(Values.Closed);

    public TimecardFilterStatus(string value)
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
    public static TimecardFilterStatus FromCustom(string value)
    {
        return new TimecardFilterStatus(value);
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

    public static bool operator ==(TimecardFilterStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TimecardFilterStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TimecardFilterStatus value) => value.Value;

    public static explicit operator TimecardFilterStatus(string value) => new(value);

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
