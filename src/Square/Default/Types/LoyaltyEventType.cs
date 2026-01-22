using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[JsonConverter(typeof(StringEnumSerializer<LoyaltyEventType>))]
[Serializable]
public readonly record struct LoyaltyEventType : IStringEnum
{
    public static readonly LoyaltyEventType AccumulatePoints = new(Values.AccumulatePoints);

    public static readonly LoyaltyEventType CreateReward = new(Values.CreateReward);

    public static readonly LoyaltyEventType RedeemReward = new(Values.RedeemReward);

    public static readonly LoyaltyEventType DeleteReward = new(Values.DeleteReward);

    public static readonly LoyaltyEventType AdjustPoints = new(Values.AdjustPoints);

    public static readonly LoyaltyEventType ExpirePoints = new(Values.ExpirePoints);

    public static readonly LoyaltyEventType Other = new(Values.Other);

    public static readonly LoyaltyEventType AccumulatePromotionPoints = new(
        Values.AccumulatePromotionPoints
    );

    public LoyaltyEventType(string value)
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
    public static LoyaltyEventType FromCustom(string value)
    {
        return new LoyaltyEventType(value);
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

    public static bool operator ==(LoyaltyEventType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(LoyaltyEventType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(LoyaltyEventType value) => value.Value;

    public static explicit operator LoyaltyEventType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string AccumulatePoints = "ACCUMULATE_POINTS";

        public const string CreateReward = "CREATE_REWARD";

        public const string RedeemReward = "REDEEM_REWARD";

        public const string DeleteReward = "DELETE_REWARD";

        public const string AdjustPoints = "ADJUST_POINTS";

        public const string ExpirePoints = "EXPIRE_POINTS";

        public const string Other = "OTHER";

        public const string AccumulatePromotionPoints = "ACCUMULATE_PROMOTION_POINTS";
    }
}
