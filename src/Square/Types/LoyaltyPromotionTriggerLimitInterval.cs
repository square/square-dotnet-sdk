using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<LoyaltyPromotionTriggerLimitInterval>))]
public readonly record struct LoyaltyPromotionTriggerLimitInterval : IStringEnum
{
    public static readonly LoyaltyPromotionTriggerLimitInterval AllTime = new(Values.AllTime);

    public static readonly LoyaltyPromotionTriggerLimitInterval Day = new(Values.Day);

    public LoyaltyPromotionTriggerLimitInterval(string value)
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
    public static LoyaltyPromotionTriggerLimitInterval FromCustom(string value)
    {
        return new LoyaltyPromotionTriggerLimitInterval(value);
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

    public static bool operator ==(LoyaltyPromotionTriggerLimitInterval value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(LoyaltyPromotionTriggerLimitInterval value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(LoyaltyPromotionTriggerLimitInterval value) =>
        value.Value;

    public static explicit operator LoyaltyPromotionTriggerLimitInterval(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string AllTime = "ALL_TIME";

        public const string Day = "DAY";
    }
}
