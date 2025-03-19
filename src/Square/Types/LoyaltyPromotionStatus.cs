using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<LoyaltyPromotionStatus>))]
public readonly record struct LoyaltyPromotionStatus : IStringEnum
{
    public static readonly LoyaltyPromotionStatus Active = new(Values.Active);

    public static readonly LoyaltyPromotionStatus Ended = new(Values.Ended);

    public static readonly LoyaltyPromotionStatus Canceled = new(Values.Canceled);

    public static readonly LoyaltyPromotionStatus Scheduled = new(Values.Scheduled);

    public LoyaltyPromotionStatus(string value)
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
    public static LoyaltyPromotionStatus FromCustom(string value)
    {
        return new LoyaltyPromotionStatus(value);
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

    public static bool operator ==(LoyaltyPromotionStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(LoyaltyPromotionStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(LoyaltyPromotionStatus value) => value.Value;

    public static explicit operator LoyaltyPromotionStatus(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string Active = "ACTIVE";

        public const string Ended = "ENDED";

        public const string Canceled = "CANCELED";

        public const string Scheduled = "SCHEDULED";
    }
}
