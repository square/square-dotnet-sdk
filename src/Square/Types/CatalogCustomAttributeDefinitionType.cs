using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<CatalogCustomAttributeDefinitionType>))]
[Serializable]
public readonly record struct CatalogCustomAttributeDefinitionType : IStringEnum
{
    public static readonly CatalogCustomAttributeDefinitionType String = new(Values.String);

    public static readonly CatalogCustomAttributeDefinitionType Boolean = new(Values.Boolean);

    public static readonly CatalogCustomAttributeDefinitionType Number = new(Values.Number);

    public static readonly CatalogCustomAttributeDefinitionType Selection = new(Values.Selection);

    public CatalogCustomAttributeDefinitionType(string value)
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
    public static CatalogCustomAttributeDefinitionType FromCustom(string value)
    {
        return new CatalogCustomAttributeDefinitionType(value);
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

    public static bool operator ==(CatalogCustomAttributeDefinitionType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CatalogCustomAttributeDefinitionType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CatalogCustomAttributeDefinitionType value) =>
        value.Value;

    public static explicit operator CatalogCustomAttributeDefinitionType(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string String = "STRING";

        public const string Boolean = "BOOLEAN";

        public const string Number = "NUMBER";

        public const string Selection = "SELECTION";
    }
}
