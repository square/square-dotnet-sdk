using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[JsonConverter(typeof(StringEnumSerializer<SubscriptionPricingType>))]
[Serializable]
public readonly record struct SubscriptionPricingType : IStringEnum
{
    public static readonly SubscriptionPricingType Static = new(Values.Static);

    public static readonly SubscriptionPricingType Relative = new(Values.Relative);

    public SubscriptionPricingType(string value)
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
    public static SubscriptionPricingType FromCustom(string value)
    {
        return new SubscriptionPricingType(value);
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

    public static bool operator ==(SubscriptionPricingType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SubscriptionPricingType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SubscriptionPricingType value) => value.Value;

    public static explicit operator SubscriptionPricingType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Static = "STATIC";

        public const string Relative = "RELATIVE";
    }
}
