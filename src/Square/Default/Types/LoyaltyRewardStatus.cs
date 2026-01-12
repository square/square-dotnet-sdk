using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[JsonConverter(typeof(StringEnumSerializer<LoyaltyRewardStatus>))]
[Serializable]
public readonly record struct LoyaltyRewardStatus : IStringEnum
{
    public static readonly LoyaltyRewardStatus Issued = new(Values.Issued);

    public static readonly LoyaltyRewardStatus Redeemed = new(Values.Redeemed);

    public static readonly LoyaltyRewardStatus Deleted = new(Values.Deleted);

    public LoyaltyRewardStatus(string value)
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
    public static LoyaltyRewardStatus FromCustom(string value)
    {
        return new LoyaltyRewardStatus(value);
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

    public static bool operator ==(LoyaltyRewardStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(LoyaltyRewardStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(LoyaltyRewardStatus value) => value.Value;

    public static explicit operator LoyaltyRewardStatus(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Issued = "ISSUED";

        public const string Redeemed = "REDEEMED";

        public const string Deleted = "DELETED";
    }
}
