using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<LoyaltyProgramAccrualRuleType>))]
[Serializable]
public readonly record struct LoyaltyProgramAccrualRuleType : IStringEnum
{
    public static readonly LoyaltyProgramAccrualRuleType Visit = new(Values.Visit);

    public static readonly LoyaltyProgramAccrualRuleType Spend = new(Values.Spend);

    public static readonly LoyaltyProgramAccrualRuleType ItemVariation = new(Values.ItemVariation);

    public static readonly LoyaltyProgramAccrualRuleType Category = new(Values.Category);

    public LoyaltyProgramAccrualRuleType(string value)
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
    public static LoyaltyProgramAccrualRuleType FromCustom(string value)
    {
        return new LoyaltyProgramAccrualRuleType(value);
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

    public static bool operator ==(LoyaltyProgramAccrualRuleType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(LoyaltyProgramAccrualRuleType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(LoyaltyProgramAccrualRuleType value) => value.Value;

    public static explicit operator LoyaltyProgramAccrualRuleType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Visit = "VISIT";

        public const string Spend = "SPEND";

        public const string ItemVariation = "ITEM_VARIATION";

        public const string Category = "CATEGORY";
    }
}
