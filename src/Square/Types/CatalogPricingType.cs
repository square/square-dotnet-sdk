using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<CatalogPricingType>))]
public readonly record struct CatalogPricingType : IStringEnum
{
    public static readonly CatalogPricingType FixedPricing = new(Values.FixedPricing);

    public static readonly CatalogPricingType VariablePricing = new(Values.VariablePricing);

    public CatalogPricingType(string value)
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
    public static CatalogPricingType FromCustom(string value)
    {
        return new CatalogPricingType(value);
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

    public static bool operator ==(CatalogPricingType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CatalogPricingType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CatalogPricingType value) => value.Value;

    public static explicit operator CatalogPricingType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string FixedPricing = "FIXED_PRICING";

        public const string VariablePricing = "VARIABLE_PRICING";
    }
}
