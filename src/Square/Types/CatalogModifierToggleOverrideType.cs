using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<CatalogModifierToggleOverrideType>))]
[Serializable]
public readonly record struct CatalogModifierToggleOverrideType : IStringEnum
{
    public static readonly CatalogModifierToggleOverrideType No = new(Values.No);

    public static readonly CatalogModifierToggleOverrideType Yes = new(Values.Yes);

    public static readonly CatalogModifierToggleOverrideType NotSet = new(Values.NotSet);

    public CatalogModifierToggleOverrideType(string value)
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
    public static CatalogModifierToggleOverrideType FromCustom(string value)
    {
        return new CatalogModifierToggleOverrideType(value);
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

    public static bool operator ==(CatalogModifierToggleOverrideType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CatalogModifierToggleOverrideType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CatalogModifierToggleOverrideType value) => value.Value;

    public static explicit operator CatalogModifierToggleOverrideType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string No = "NO";

        public const string Yes = "YES";

        public const string NotSet = "NOT_SET";
    }
}
