using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[JsonConverter(typeof(StringEnumSerializer<GiftCardGanSource>))]
[Serializable]
public readonly record struct GiftCardGanSource : IStringEnum
{
    public static readonly GiftCardGanSource Square = new(Values.Square);

    public static readonly GiftCardGanSource Other = new(Values.Other);

    public GiftCardGanSource(string value)
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
    public static GiftCardGanSource FromCustom(string value)
    {
        return new GiftCardGanSource(value);
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

    public static bool operator ==(GiftCardGanSource value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GiftCardGanSource value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GiftCardGanSource value) => value.Value;

    public static explicit operator GiftCardGanSource(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Square = "SQUARE";

        public const string Other = "OTHER";
    }
}
