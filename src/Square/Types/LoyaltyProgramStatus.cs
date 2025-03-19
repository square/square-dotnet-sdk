using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<LoyaltyProgramStatus>))]
public readonly record struct LoyaltyProgramStatus : IStringEnum
{
    public static readonly LoyaltyProgramStatus Inactive = new(Values.Inactive);

    public static readonly LoyaltyProgramStatus Active = new(Values.Active);

    public LoyaltyProgramStatus(string value)
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
    public static LoyaltyProgramStatus FromCustom(string value)
    {
        return new LoyaltyProgramStatus(value);
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

    public static bool operator ==(LoyaltyProgramStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(LoyaltyProgramStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(LoyaltyProgramStatus value) => value.Value;

    public static explicit operator LoyaltyProgramStatus(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string Inactive = "INACTIVE";

        public const string Active = "ACTIVE";
    }
}
