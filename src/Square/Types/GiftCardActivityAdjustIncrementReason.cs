using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<GiftCardActivityAdjustIncrementReason>))]
[Serializable]
public readonly record struct GiftCardActivityAdjustIncrementReason : IStringEnum
{
    public static readonly GiftCardActivityAdjustIncrementReason Complimentary = new(
        Values.Complimentary
    );

    public static readonly GiftCardActivityAdjustIncrementReason SupportIssue = new(
        Values.SupportIssue
    );

    public static readonly GiftCardActivityAdjustIncrementReason TransactionVoided = new(
        Values.TransactionVoided
    );

    public GiftCardActivityAdjustIncrementReason(string value)
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
    public static GiftCardActivityAdjustIncrementReason FromCustom(string value)
    {
        return new GiftCardActivityAdjustIncrementReason(value);
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

    public static bool operator ==(GiftCardActivityAdjustIncrementReason value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GiftCardActivityAdjustIncrementReason value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GiftCardActivityAdjustIncrementReason value) =>
        value.Value;

    public static explicit operator GiftCardActivityAdjustIncrementReason(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Complimentary = "COMPLIMENTARY";

        public const string SupportIssue = "SUPPORT_ISSUE";

        public const string TransactionVoided = "TRANSACTION_VOIDED";
    }
}
