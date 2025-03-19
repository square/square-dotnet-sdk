using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<CardCoBrand>))]
public readonly record struct CardCoBrand : IStringEnum
{
    public static readonly CardCoBrand Unknown = new(Values.Unknown);

    public static readonly CardCoBrand Afterpay = new(Values.Afterpay);

    public static readonly CardCoBrand Clearpay = new(Values.Clearpay);

    public CardCoBrand(string value)
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
    public static CardCoBrand FromCustom(string value)
    {
        return new CardCoBrand(value);
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

    public static bool operator ==(CardCoBrand value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CardCoBrand value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CardCoBrand value) => value.Value;

    public static explicit operator CardCoBrand(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string Unknown = "UNKNOWN";

        public const string Afterpay = "AFTERPAY";

        public const string Clearpay = "CLEARPAY";
    }
}
