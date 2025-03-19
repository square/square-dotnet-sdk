using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(
    typeof(StringEnumSerializer<CatalogItemFoodAndBeverageDetailsDietaryPreferenceType>)
)]
public readonly record struct CatalogItemFoodAndBeverageDetailsDietaryPreferenceType : IStringEnum
{
    public static readonly CatalogItemFoodAndBeverageDetailsDietaryPreferenceType Standard = new(
        Values.Standard
    );

    public static readonly CatalogItemFoodAndBeverageDetailsDietaryPreferenceType Custom = new(
        Values.Custom
    );

    public CatalogItemFoodAndBeverageDetailsDietaryPreferenceType(string value)
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
    public static CatalogItemFoodAndBeverageDetailsDietaryPreferenceType FromCustom(string value)
    {
        return new CatalogItemFoodAndBeverageDetailsDietaryPreferenceType(value);
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
        CatalogItemFoodAndBeverageDetailsDietaryPreferenceType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CatalogItemFoodAndBeverageDetailsDietaryPreferenceType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CatalogItemFoodAndBeverageDetailsDietaryPreferenceType value
    ) => value.Value;

    public static explicit operator CatalogItemFoodAndBeverageDetailsDietaryPreferenceType(
        string value
    ) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string Standard = "STANDARD";

        public const string Custom = "CUSTOM";
    }
}
