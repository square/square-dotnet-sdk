using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<CustomAttributeDefinitionVisibility>))]
[Serializable]
public readonly record struct CustomAttributeDefinitionVisibility : IStringEnum
{
    public static readonly CustomAttributeDefinitionVisibility VisibilityHidden = new(
        Values.VisibilityHidden
    );

    public static readonly CustomAttributeDefinitionVisibility VisibilityReadOnly = new(
        Values.VisibilityReadOnly
    );

    public static readonly CustomAttributeDefinitionVisibility VisibilityReadWriteValues = new(
        Values.VisibilityReadWriteValues
    );

    public CustomAttributeDefinitionVisibility(string value)
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
    public static CustomAttributeDefinitionVisibility FromCustom(string value)
    {
        return new CustomAttributeDefinitionVisibility(value);
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

    public static bool operator ==(CustomAttributeDefinitionVisibility value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CustomAttributeDefinitionVisibility value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CustomAttributeDefinitionVisibility value) =>
        value.Value;

    public static explicit operator CustomAttributeDefinitionVisibility(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string VisibilityHidden = "VISIBILITY_HIDDEN";

        public const string VisibilityReadOnly = "VISIBILITY_READ_ONLY";

        public const string VisibilityReadWriteValues = "VISIBILITY_READ_WRITE_VALUES";
    }
}
