using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<GiftCardStatus>))]
public readonly record struct GiftCardStatus : IStringEnum
{
    public static readonly GiftCardStatus Active = new(Values.Active);

    public static readonly GiftCardStatus Deactivated = new(Values.Deactivated);

    public static readonly GiftCardStatus Blocked = new(Values.Blocked);

    public static readonly GiftCardStatus Pending = new(Values.Pending);

    public GiftCardStatus(string value)
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
    public static GiftCardStatus FromCustom(string value)
    {
        return new GiftCardStatus(value);
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

    public static bool operator ==(GiftCardStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GiftCardStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GiftCardStatus value) => value.Value;

    public static explicit operator GiftCardStatus(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string Active = "ACTIVE";

        public const string Deactivated = "DEACTIVATED";

        public const string Blocked = "BLOCKED";

        public const string Pending = "PENDING";
    }
}
