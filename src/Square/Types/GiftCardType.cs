using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<GiftCardType>))]
[Serializable]
public readonly record struct GiftCardType : IStringEnum
{
    public static readonly GiftCardType Physical = new(Values.Physical);

    public static readonly GiftCardType Digital = new(Values.Digital);

    public GiftCardType(string value)
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
    public static GiftCardType FromCustom(string value)
    {
        return new GiftCardType(value);
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

    public static bool operator ==(GiftCardType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GiftCardType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GiftCardType value) => value.Value;

    public static explicit operator GiftCardType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Physical = "PHYSICAL";

        public const string Digital = "DIGITAL";
    }
}
