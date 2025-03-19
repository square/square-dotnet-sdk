using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<ChangeTiming>))]
public readonly record struct ChangeTiming : IStringEnum
{
    public static readonly ChangeTiming Immediate = new(Values.Immediate);

    public static readonly ChangeTiming EndOfBillingCycle = new(Values.EndOfBillingCycle);

    public ChangeTiming(string value)
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
    public static ChangeTiming FromCustom(string value)
    {
        return new ChangeTiming(value);
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

    public static bool operator ==(ChangeTiming value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ChangeTiming value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ChangeTiming value) => value.Value;

    public static explicit operator ChangeTiming(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string Immediate = "IMMEDIATE";

        public const string EndOfBillingCycle = "END_OF_BILLING_CYCLE";
    }
}
