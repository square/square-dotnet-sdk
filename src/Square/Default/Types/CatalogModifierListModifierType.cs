using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[JsonConverter(typeof(StringEnumSerializer<CatalogModifierListModifierType>))]
[Serializable]
public readonly record struct CatalogModifierListModifierType : IStringEnum
{
    public static readonly CatalogModifierListModifierType List = new(Values.List);

    public static readonly CatalogModifierListModifierType Text = new(Values.Text);

    public CatalogModifierListModifierType(string value)
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
    public static CatalogModifierListModifierType FromCustom(string value)
    {
        return new CatalogModifierListModifierType(value);
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

    public static bool operator ==(CatalogModifierListModifierType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CatalogModifierListModifierType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CatalogModifierListModifierType value) => value.Value;

    public static explicit operator CatalogModifierListModifierType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string List = "LIST";

        public const string Text = "TEXT";
    }
}
