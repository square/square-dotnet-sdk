using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[JsonConverter(typeof(StringEnumSerializer<LoyaltyProgramAccrualRuleTaxMode>))]
[Serializable]
public readonly record struct LoyaltyProgramAccrualRuleTaxMode : IStringEnum
{
    public static readonly LoyaltyProgramAccrualRuleTaxMode BeforeTax = new(Values.BeforeTax);

    public static readonly LoyaltyProgramAccrualRuleTaxMode AfterTax = new(Values.AfterTax);

    public LoyaltyProgramAccrualRuleTaxMode(string value)
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
    public static LoyaltyProgramAccrualRuleTaxMode FromCustom(string value)
    {
        return new LoyaltyProgramAccrualRuleTaxMode(value);
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

    public static bool operator ==(LoyaltyProgramAccrualRuleTaxMode value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(LoyaltyProgramAccrualRuleTaxMode value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(LoyaltyProgramAccrualRuleTaxMode value) => value.Value;

    public static explicit operator LoyaltyProgramAccrualRuleTaxMode(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string BeforeTax = "BEFORE_TAX";

        public const string AfterTax = "AFTER_TAX";
    }
}
