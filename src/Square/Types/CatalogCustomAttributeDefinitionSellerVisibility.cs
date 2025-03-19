using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<CatalogCustomAttributeDefinitionSellerVisibility>))]
public readonly record struct CatalogCustomAttributeDefinitionSellerVisibility : IStringEnum
{
    public static readonly CatalogCustomAttributeDefinitionSellerVisibility SellerVisibilityHidden =
        new(Values.SellerVisibilityHidden);

    public static readonly CatalogCustomAttributeDefinitionSellerVisibility SellerVisibilityReadWriteValues =
        new(Values.SellerVisibilityReadWriteValues);

    public CatalogCustomAttributeDefinitionSellerVisibility(string value)
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
    public static CatalogCustomAttributeDefinitionSellerVisibility FromCustom(string value)
    {
        return new CatalogCustomAttributeDefinitionSellerVisibility(value);
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

    public static bool operator ==(
        CatalogCustomAttributeDefinitionSellerVisibility value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CatalogCustomAttributeDefinitionSellerVisibility value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CatalogCustomAttributeDefinitionSellerVisibility value
    ) => value.Value;

    public static explicit operator CatalogCustomAttributeDefinitionSellerVisibility(
        string value
    ) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string SellerVisibilityHidden = "SELLER_VISIBILITY_HIDDEN";

        public const string SellerVisibilityReadWriteValues = "SELLER_VISIBILITY_READ_WRITE_VALUES";
    }
}
