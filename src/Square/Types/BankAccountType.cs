using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<BankAccountType>))]
public readonly record struct BankAccountType : IStringEnum
{
    public static readonly BankAccountType Checking = new(Values.Checking);

    public static readonly BankAccountType Savings = new(Values.Savings);

    public static readonly BankAccountType Investment = new(Values.Investment);

    public static readonly BankAccountType Other = new(Values.Other);

    public static readonly BankAccountType BusinessChecking = new(Values.BusinessChecking);

    public BankAccountType(string value)
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
    public static BankAccountType FromCustom(string value)
    {
        return new BankAccountType(value);
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

    public static bool operator ==(BankAccountType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BankAccountType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BankAccountType value) => value.Value;

    public static explicit operator BankAccountType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string Checking = "CHECKING";

        public const string Savings = "SAVINGS";

        public const string Investment = "INVESTMENT";

        public const string Other = "OTHER";

        public const string BusinessChecking = "BUSINESS_CHECKING";
    }
}
