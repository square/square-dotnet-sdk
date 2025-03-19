using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<ShiftStatus>))]
public readonly record struct ShiftStatus : IStringEnum
{
    public static readonly ShiftStatus Open = new(Values.Open);

    public static readonly ShiftStatus Closed = new(Values.Closed);

    public ShiftStatus(string value)
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
    public static ShiftStatus FromCustom(string value)
    {
        return new ShiftStatus(value);
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

    public static bool operator ==(ShiftStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ShiftStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ShiftStatus value) => value.Value;

    public static explicit operator ShiftStatus(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string Open = "OPEN";

        public const string Closed = "CLOSED";
    }
}
