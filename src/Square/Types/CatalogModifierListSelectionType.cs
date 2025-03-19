using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<CatalogModifierListSelectionType>))]
public readonly record struct CatalogModifierListSelectionType : IStringEnum
{
    public static readonly CatalogModifierListSelectionType Single = new(Values.Single);

    public static readonly CatalogModifierListSelectionType Multiple = new(Values.Multiple);

    public CatalogModifierListSelectionType(string value)
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
    public static CatalogModifierListSelectionType FromCustom(string value)
    {
        return new CatalogModifierListSelectionType(value);
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

    public static bool operator ==(CatalogModifierListSelectionType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CatalogModifierListSelectionType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CatalogModifierListSelectionType value) => value.Value;

    public static explicit operator CatalogModifierListSelectionType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string Single = "SINGLE";

        public const string Multiple = "MULTIPLE";
    }
}
