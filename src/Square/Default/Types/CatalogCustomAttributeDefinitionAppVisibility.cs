using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[JsonConverter(typeof(StringEnumSerializer<CatalogCustomAttributeDefinitionAppVisibility>))]
[Serializable]
public readonly record struct CatalogCustomAttributeDefinitionAppVisibility : IStringEnum
{
    public static readonly CatalogCustomAttributeDefinitionAppVisibility AppVisibilityHidden = new(
        Values.AppVisibilityHidden
    );

    public static readonly CatalogCustomAttributeDefinitionAppVisibility AppVisibilityReadOnly =
        new(Values.AppVisibilityReadOnly);

    public static readonly CatalogCustomAttributeDefinitionAppVisibility AppVisibilityReadWriteValues =
        new(Values.AppVisibilityReadWriteValues);

    public CatalogCustomAttributeDefinitionAppVisibility(string value)
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
    public static CatalogCustomAttributeDefinitionAppVisibility FromCustom(string value)
    {
        return new CatalogCustomAttributeDefinitionAppVisibility(value);
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
        CatalogCustomAttributeDefinitionAppVisibility value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CatalogCustomAttributeDefinitionAppVisibility value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(CatalogCustomAttributeDefinitionAppVisibility value) =>
        value.Value;

    public static explicit operator CatalogCustomAttributeDefinitionAppVisibility(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string AppVisibilityHidden = "APP_VISIBILITY_HIDDEN";

        public const string AppVisibilityReadOnly = "APP_VISIBILITY_READ_ONLY";

        public const string AppVisibilityReadWriteValues = "APP_VISIBILITY_READ_WRITE_VALUES";
    }
}
