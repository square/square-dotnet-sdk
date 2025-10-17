using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<GiftCardActivityRedeemStatus>))]
[Serializable]
public readonly record struct GiftCardActivityRedeemStatus : IStringEnum
{
    public static readonly GiftCardActivityRedeemStatus Pending = new(Values.Pending);

    public static readonly GiftCardActivityRedeemStatus Completed = new(Values.Completed);

    public static readonly GiftCardActivityRedeemStatus Canceled = new(Values.Canceled);

    public GiftCardActivityRedeemStatus(string value)
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
    public static GiftCardActivityRedeemStatus FromCustom(string value)
    {
        return new GiftCardActivityRedeemStatus(value);
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

    public static bool operator ==(GiftCardActivityRedeemStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GiftCardActivityRedeemStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GiftCardActivityRedeemStatus value) => value.Value;

    public static explicit operator GiftCardActivityRedeemStatus(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Pending = "PENDING";

        public const string Completed = "COMPLETED";

        public const string Canceled = "CANCELED";
    }
}
