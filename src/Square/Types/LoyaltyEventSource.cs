using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<LoyaltyEventSource>))]
public readonly record struct LoyaltyEventSource : IStringEnum
{
    public static readonly LoyaltyEventSource Square = new(Values.Square);

    public static readonly LoyaltyEventSource LoyaltyApi = new(Values.LoyaltyApi);

    public LoyaltyEventSource(string value)
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
    public static LoyaltyEventSource FromCustom(string value)
    {
        return new LoyaltyEventSource(value);
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

    public static bool operator ==(LoyaltyEventSource value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(LoyaltyEventSource value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(LoyaltyEventSource value) => value.Value;

    public static explicit operator LoyaltyEventSource(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string Square = "SQUARE";

        public const string LoyaltyApi = "LOYALTY_API";
    }
}
