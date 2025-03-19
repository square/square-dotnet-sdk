using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<CatalogCategoryType>))]
public readonly record struct CatalogCategoryType : IStringEnum
{
    public static readonly CatalogCategoryType RegularCategory = new(Values.RegularCategory);

    public static readonly CatalogCategoryType MenuCategory = new(Values.MenuCategory);

    public static readonly CatalogCategoryType KitchenCategory = new(Values.KitchenCategory);

    public CatalogCategoryType(string value)
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
    public static CatalogCategoryType FromCustom(string value)
    {
        return new CatalogCategoryType(value);
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

    public static bool operator ==(CatalogCategoryType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CatalogCategoryType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CatalogCategoryType value) => value.Value;

    public static explicit operator CatalogCategoryType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string RegularCategory = "REGULAR_CATEGORY";

        public const string MenuCategory = "MENU_CATEGORY";

        public const string KitchenCategory = "KITCHEN_CATEGORY";
    }
}
