using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(
    typeof(StringEnumSerializer<CatalogItemFoodAndBeverageDetailsIngredientStandardIngredient>)
)]
[Serializable]
public readonly record struct CatalogItemFoodAndBeverageDetailsIngredientStandardIngredient
    : IStringEnum
{
    public static readonly CatalogItemFoodAndBeverageDetailsIngredientStandardIngredient Celery =
        new(Values.Celery);

    public static readonly CatalogItemFoodAndBeverageDetailsIngredientStandardIngredient Crustaceans =
        new(Values.Crustaceans);

    public static readonly CatalogItemFoodAndBeverageDetailsIngredientStandardIngredient Eggs = new(
        Values.Eggs
    );

    public static readonly CatalogItemFoodAndBeverageDetailsIngredientStandardIngredient Fish = new(
        Values.Fish
    );

    public static readonly CatalogItemFoodAndBeverageDetailsIngredientStandardIngredient Gluten =
        new(Values.Gluten);

    public static readonly CatalogItemFoodAndBeverageDetailsIngredientStandardIngredient Lupin =
        new(Values.Lupin);

    public static readonly CatalogItemFoodAndBeverageDetailsIngredientStandardIngredient Milk = new(
        Values.Milk
    );

    public static readonly CatalogItemFoodAndBeverageDetailsIngredientStandardIngredient Molluscs =
        new(Values.Molluscs);

    public static readonly CatalogItemFoodAndBeverageDetailsIngredientStandardIngredient Mustard =
        new(Values.Mustard);

    public static readonly CatalogItemFoodAndBeverageDetailsIngredientStandardIngredient Peanuts =
        new(Values.Peanuts);

    public static readonly CatalogItemFoodAndBeverageDetailsIngredientStandardIngredient Sesame =
        new(Values.Sesame);

    public static readonly CatalogItemFoodAndBeverageDetailsIngredientStandardIngredient Soy = new(
        Values.Soy
    );

    public static readonly CatalogItemFoodAndBeverageDetailsIngredientStandardIngredient Sulphites =
        new(Values.Sulphites);

    public static readonly CatalogItemFoodAndBeverageDetailsIngredientStandardIngredient TreeNuts =
        new(Values.TreeNuts);

    public CatalogItemFoodAndBeverageDetailsIngredientStandardIngredient(string value)
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
    public static CatalogItemFoodAndBeverageDetailsIngredientStandardIngredient FromCustom(
        string value
    )
    {
        return new CatalogItemFoodAndBeverageDetailsIngredientStandardIngredient(value);
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
        CatalogItemFoodAndBeverageDetailsIngredientStandardIngredient value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CatalogItemFoodAndBeverageDetailsIngredientStandardIngredient value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CatalogItemFoodAndBeverageDetailsIngredientStandardIngredient value
    ) => value.Value;

    public static explicit operator CatalogItemFoodAndBeverageDetailsIngredientStandardIngredient(
        string value
    ) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Celery = "CELERY";

        public const string Crustaceans = "CRUSTACEANS";

        public const string Eggs = "EGGS";

        public const string Fish = "FISH";

        public const string Gluten = "GLUTEN";

        public const string Lupin = "LUPIN";

        public const string Milk = "MILK";

        public const string Molluscs = "MOLLUSCS";

        public const string Mustard = "MUSTARD";

        public const string Peanuts = "PEANUTS";

        public const string Sesame = "SESAME";

        public const string Soy = "SOY";

        public const string Sulphites = "SULPHITES";

        public const string TreeNuts = "TREE_NUTS";
    }
}
