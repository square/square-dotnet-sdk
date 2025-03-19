using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<CatalogDiscountModifyTaxBasis>))]
public readonly record struct CatalogDiscountModifyTaxBasis : IStringEnum
{
    public static readonly CatalogDiscountModifyTaxBasis ModifyTaxBasis = new(
        Values.ModifyTaxBasis
    );

    public static readonly CatalogDiscountModifyTaxBasis DoNotModifyTaxBasis = new(
        Values.DoNotModifyTaxBasis
    );

    public CatalogDiscountModifyTaxBasis(string value)
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
    public static CatalogDiscountModifyTaxBasis FromCustom(string value)
    {
        return new CatalogDiscountModifyTaxBasis(value);
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

    public static bool operator ==(CatalogDiscountModifyTaxBasis value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CatalogDiscountModifyTaxBasis value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CatalogDiscountModifyTaxBasis value) => value.Value;

    public static explicit operator CatalogDiscountModifyTaxBasis(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string ModifyTaxBasis = "MODIFY_TAX_BASIS";

        public const string DoNotModifyTaxBasis = "DO_NOT_MODIFY_TAX_BASIS";
    }
}
