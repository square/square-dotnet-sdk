using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[JsonConverter(typeof(StringEnumSerializer<CashDrawerShiftState>))]
[Serializable]
public readonly record struct CashDrawerShiftState : IStringEnum
{
    public static readonly CashDrawerShiftState Open = new(Values.Open);

    public static readonly CashDrawerShiftState Ended = new(Values.Ended);

    public static readonly CashDrawerShiftState Closed = new(Values.Closed);

    public CashDrawerShiftState(string value)
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
    public static CashDrawerShiftState FromCustom(string value)
    {
        return new CashDrawerShiftState(value);
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

    public static bool operator ==(CashDrawerShiftState value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CashDrawerShiftState value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CashDrawerShiftState value) => value.Value;

    public static explicit operator CashDrawerShiftState(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Open = "OPEN";

        public const string Ended = "ENDED";

        public const string Closed = "CLOSED";
    }
}
