using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<LoyaltyPromotionIncentiveType>))]
public readonly record struct LoyaltyPromotionIncentiveType : IStringEnum
{
    public static readonly LoyaltyPromotionIncentiveType PointsMultiplier = new(
        Values.PointsMultiplier
    );

    public static readonly LoyaltyPromotionIncentiveType PointsAddition = new(
        Values.PointsAddition
    );

    public LoyaltyPromotionIncentiveType(string value)
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
    public static LoyaltyPromotionIncentiveType FromCustom(string value)
    {
        return new LoyaltyPromotionIncentiveType(value);
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

    public static bool operator ==(LoyaltyPromotionIncentiveType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(LoyaltyPromotionIncentiveType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(LoyaltyPromotionIncentiveType value) => value.Value;

    public static explicit operator LoyaltyPromotionIncentiveType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string PointsMultiplier = "POINTS_MULTIPLIER";

        public const string PointsAddition = "POINTS_ADDITION";
    }
}
