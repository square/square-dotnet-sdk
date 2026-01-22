using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[JsonConverter(typeof(StringEnumSerializer<GiftCardActivityDeactivateReason>))]
[Serializable]
public readonly record struct GiftCardActivityDeactivateReason : IStringEnum
{
    public static readonly GiftCardActivityDeactivateReason SuspiciousActivity = new(
        Values.SuspiciousActivity
    );

    public static readonly GiftCardActivityDeactivateReason UnknownReason = new(
        Values.UnknownReason
    );

    public static readonly GiftCardActivityDeactivateReason ChargebackDeactivate = new(
        Values.ChargebackDeactivate
    );

    public GiftCardActivityDeactivateReason(string value)
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
    public static GiftCardActivityDeactivateReason FromCustom(string value)
    {
        return new GiftCardActivityDeactivateReason(value);
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

    public static bool operator ==(GiftCardActivityDeactivateReason value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GiftCardActivityDeactivateReason value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GiftCardActivityDeactivateReason value) => value.Value;

    public static explicit operator GiftCardActivityDeactivateReason(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string SuspiciousActivity = "SUSPICIOUS_ACTIVITY";

        public const string UnknownReason = "UNKNOWN_REASON";

        public const string ChargebackDeactivate = "CHARGEBACK_DEACTIVATE";
    }
}
