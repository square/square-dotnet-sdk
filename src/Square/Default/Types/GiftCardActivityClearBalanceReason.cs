using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[JsonConverter(typeof(StringEnumSerializer<GiftCardActivityClearBalanceReason>))]
[Serializable]
public readonly record struct GiftCardActivityClearBalanceReason : IStringEnum
{
    public static readonly GiftCardActivityClearBalanceReason SuspiciousActivity = new(
        Values.SuspiciousActivity
    );

    public static readonly GiftCardActivityClearBalanceReason ReuseGiftcard = new(
        Values.ReuseGiftcard
    );

    public static readonly GiftCardActivityClearBalanceReason UnknownReason = new(
        Values.UnknownReason
    );

    public GiftCardActivityClearBalanceReason(string value)
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
    public static GiftCardActivityClearBalanceReason FromCustom(string value)
    {
        return new GiftCardActivityClearBalanceReason(value);
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

    public static bool operator ==(GiftCardActivityClearBalanceReason value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GiftCardActivityClearBalanceReason value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GiftCardActivityClearBalanceReason value) => value.Value;

    public static explicit operator GiftCardActivityClearBalanceReason(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string SuspiciousActivity = "SUSPICIOUS_ACTIVITY";

        public const string ReuseGiftcard = "REUSE_GIFTCARD";

        public const string UnknownReason = "UNKNOWN_REASON";
    }
}
