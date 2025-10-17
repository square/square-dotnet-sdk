using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<CardPrepaidType>))]
[Serializable]
public readonly record struct CardPrepaidType : IStringEnum
{
    public static readonly CardPrepaidType UnknownPrepaidType = new(Values.UnknownPrepaidType);

    public static readonly CardPrepaidType NotPrepaid = new(Values.NotPrepaid);

    public static readonly CardPrepaidType Prepaid = new(Values.Prepaid);

    public CardPrepaidType(string value)
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
    public static CardPrepaidType FromCustom(string value)
    {
        return new CardPrepaidType(value);
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

    public static bool operator ==(CardPrepaidType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CardPrepaidType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CardPrepaidType value) => value.Value;

    public static explicit operator CardPrepaidType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string UnknownPrepaidType = "UNKNOWN_PREPAID_TYPE";

        public const string NotPrepaid = "NOT_PREPAID";

        public const string Prepaid = "PREPAID";
    }
}
