using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[JsonConverter(
    typeof(StringEnumSerializer<CatalogItemFoodAndBeverageDetailsDietaryPreferenceStandardDietaryPreference>)
)]
[Serializable]
public readonly record struct CatalogItemFoodAndBeverageDetailsDietaryPreferenceStandardDietaryPreference
    : IStringEnum
{
    public static readonly CatalogItemFoodAndBeverageDetailsDietaryPreferenceStandardDietaryPreference DairyFree =
        new(Values.DairyFree);

    public static readonly CatalogItemFoodAndBeverageDetailsDietaryPreferenceStandardDietaryPreference GlutenFree =
        new(Values.GlutenFree);

    public static readonly CatalogItemFoodAndBeverageDetailsDietaryPreferenceStandardDietaryPreference Halal =
        new(Values.Halal);

    public static readonly CatalogItemFoodAndBeverageDetailsDietaryPreferenceStandardDietaryPreference Kosher =
        new(Values.Kosher);

    public static readonly CatalogItemFoodAndBeverageDetailsDietaryPreferenceStandardDietaryPreference NutFree =
        new(Values.NutFree);

    public static readonly CatalogItemFoodAndBeverageDetailsDietaryPreferenceStandardDietaryPreference Vegan =
        new(Values.Vegan);

    public static readonly CatalogItemFoodAndBeverageDetailsDietaryPreferenceStandardDietaryPreference Vegetarian =
        new(Values.Vegetarian);

    public CatalogItemFoodAndBeverageDetailsDietaryPreferenceStandardDietaryPreference(string value)
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
    public static CatalogItemFoodAndBeverageDetailsDietaryPreferenceStandardDietaryPreference FromCustom(
        string value
    )
    {
        return new CatalogItemFoodAndBeverageDetailsDietaryPreferenceStandardDietaryPreference(
            value
        );
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
        CatalogItemFoodAndBeverageDetailsDietaryPreferenceStandardDietaryPreference value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CatalogItemFoodAndBeverageDetailsDietaryPreferenceStandardDietaryPreference value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CatalogItemFoodAndBeverageDetailsDietaryPreferenceStandardDietaryPreference value
    ) => value.Value;

    public static explicit operator CatalogItemFoodAndBeverageDetailsDietaryPreferenceStandardDietaryPreference(
        string value
    ) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string DairyFree = "DAIRY_FREE";

        public const string GlutenFree = "GLUTEN_FREE";

        public const string Halal = "HALAL";

        public const string Kosher = "KOSHER";

        public const string NutFree = "NUT_FREE";

        public const string Vegan = "VEGAN";

        public const string Vegetarian = "VEGETARIAN";
    }
}
