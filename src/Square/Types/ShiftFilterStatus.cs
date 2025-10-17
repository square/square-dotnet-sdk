using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<ShiftFilterStatus>))]
[Serializable]
public readonly record struct ShiftFilterStatus : IStringEnum
{
    public static readonly ShiftFilterStatus Open = new(Values.Open);

    public static readonly ShiftFilterStatus Closed = new(Values.Closed);

    public ShiftFilterStatus(string value)
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
    public static ShiftFilterStatus FromCustom(string value)
    {
        return new ShiftFilterStatus(value);
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

    public static bool operator ==(ShiftFilterStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ShiftFilterStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ShiftFilterStatus value) => value.Value;

    public static explicit operator ShiftFilterStatus(string value) => new(value);

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
