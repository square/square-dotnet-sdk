using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<IncludeType>))]
[Serializable]
public readonly record struct IncludeType : IStringEnum
{
    public static readonly IncludeType IncludeNestedModifiers = new(Values.IncludeNestedModifiers);

    public static readonly IncludeType IncludeAncestorModifiers = new(
        Values.IncludeAncestorModifiers
    );

    public IncludeType(string value)
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
    public static IncludeType FromCustom(string value)
    {
        return new IncludeType(value);
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

    public static bool operator ==(IncludeType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(IncludeType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(IncludeType value) => value.Value;

    public static explicit operator IncludeType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string IncludeNestedModifiers = "INCLUDE_NESTED_MODIFIERS";

        public const string IncludeAncestorModifiers = "INCLUDE_ANCESTOR_MODIFIERS";
    }
}
