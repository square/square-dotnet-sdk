using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<LoyaltyProgramRewardDefinitionType>))]
public readonly record struct LoyaltyProgramRewardDefinitionType : IStringEnum
{
    public static readonly LoyaltyProgramRewardDefinitionType FixedAmount = new(Values.FixedAmount);

    public static readonly LoyaltyProgramRewardDefinitionType FixedPercentage = new(
        Values.FixedPercentage
    );

    public LoyaltyProgramRewardDefinitionType(string value)
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
    public static LoyaltyProgramRewardDefinitionType FromCustom(string value)
    {
        return new LoyaltyProgramRewardDefinitionType(value);
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

    public static bool operator ==(LoyaltyProgramRewardDefinitionType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(LoyaltyProgramRewardDefinitionType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(LoyaltyProgramRewardDefinitionType value) => value.Value;

    public static explicit operator LoyaltyProgramRewardDefinitionType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string FixedAmount = "FIXED_AMOUNT";

        public const string FixedPercentage = "FIXED_PERCENTAGE";
    }
}
