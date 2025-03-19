using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<CardType>))]
public readonly record struct CardType : IStringEnum
{
    public static readonly CardType UnknownCardType = new(Values.UnknownCardType);

    public static readonly CardType Credit = new(Values.Credit);

    public static readonly CardType Debit = new(Values.Debit);

    public CardType(string value)
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
    public static CardType FromCustom(string value)
    {
        return new CardType(value);
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

    public static bool operator ==(CardType value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(CardType value1, string value2) => !value1.Value.Equals(value2);

    public static explicit operator string(CardType value) => value.Value;

    public static explicit operator CardType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string UnknownCardType = "UNKNOWN_CARD_TYPE";

        public const string Credit = "CREDIT";

        public const string Debit = "DEBIT";
    }
}
