using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<GiftCardActivityAdjustDecrementReason>))]
[Serializable]
public readonly record struct GiftCardActivityAdjustDecrementReason : IStringEnum
{
    public static readonly GiftCardActivityAdjustDecrementReason SuspiciousActivity = new(
        Values.SuspiciousActivity
    );

    public static readonly GiftCardActivityAdjustDecrementReason BalanceAccidentallyIncreased = new(
        Values.BalanceAccidentallyIncreased
    );

    public static readonly GiftCardActivityAdjustDecrementReason SupportIssue = new(
        Values.SupportIssue
    );

    public static readonly GiftCardActivityAdjustDecrementReason PurchaseWasRefunded = new(
        Values.PurchaseWasRefunded
    );

    public GiftCardActivityAdjustDecrementReason(string value)
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
    public static GiftCardActivityAdjustDecrementReason FromCustom(string value)
    {
        return new GiftCardActivityAdjustDecrementReason(value);
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

    public static bool operator ==(GiftCardActivityAdjustDecrementReason value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GiftCardActivityAdjustDecrementReason value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GiftCardActivityAdjustDecrementReason value) =>
        value.Value;

    public static explicit operator GiftCardActivityAdjustDecrementReason(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string SuspiciousActivity = "SUSPICIOUS_ACTIVITY";

        public const string BalanceAccidentallyIncreased = "BALANCE_ACCIDENTALLY_INCREASED";

        public const string SupportIssue = "SUPPORT_ISSUE";

        public const string PurchaseWasRefunded = "PURCHASE_WAS_REFUNDED";
    }
}
