using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[JsonConverter(typeof(StringEnumSerializer<CatalogDiscountType>))]
[Serializable]
public readonly record struct CatalogDiscountType : IStringEnum
{
    public static readonly CatalogDiscountType FixedPercentage = new(Values.FixedPercentage);

    public static readonly CatalogDiscountType FixedAmount = new(Values.FixedAmount);

    public static readonly CatalogDiscountType VariablePercentage = new(Values.VariablePercentage);

    public static readonly CatalogDiscountType VariableAmount = new(Values.VariableAmount);

    public CatalogDiscountType(string value)
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
    public static CatalogDiscountType FromCustom(string value)
    {
        return new CatalogDiscountType(value);
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

    public static bool operator ==(CatalogDiscountType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CatalogDiscountType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CatalogDiscountType value) => value.Value;

    public static explicit operator CatalogDiscountType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string FixedPercentage = "FIXED_PERCENTAGE";

        public const string FixedAmount = "FIXED_AMOUNT";

        public const string VariablePercentage = "VARIABLE_PERCENTAGE";

        public const string VariableAmount = "VARIABLE_AMOUNT";
    }
}
