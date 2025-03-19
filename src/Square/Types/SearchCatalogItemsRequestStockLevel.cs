using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<SearchCatalogItemsRequestStockLevel>))]
public readonly record struct SearchCatalogItemsRequestStockLevel : IStringEnum
{
    public static readonly SearchCatalogItemsRequestStockLevel Out = new(Values.Out);

    public static readonly SearchCatalogItemsRequestStockLevel Low = new(Values.Low);

    public SearchCatalogItemsRequestStockLevel(string value)
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
    public static SearchCatalogItemsRequestStockLevel FromCustom(string value)
    {
        return new SearchCatalogItemsRequestStockLevel(value);
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

    public static bool operator ==(SearchCatalogItemsRequestStockLevel value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SearchCatalogItemsRequestStockLevel value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SearchCatalogItemsRequestStockLevel value) =>
        value.Value;

    public static explicit operator SearchCatalogItemsRequestStockLevel(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string Out = "OUT";

        public const string Low = "LOW";
    }
}
