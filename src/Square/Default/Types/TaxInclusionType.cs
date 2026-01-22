using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[JsonConverter(typeof(StringEnumSerializer<TaxInclusionType>))]
[Serializable]
public readonly record struct TaxInclusionType : IStringEnum
{
    public static readonly TaxInclusionType Additive = new(Values.Additive);

    public static readonly TaxInclusionType Inclusive = new(Values.Inclusive);

    public TaxInclusionType(string value)
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
    public static TaxInclusionType FromCustom(string value)
    {
        return new TaxInclusionType(value);
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

    public static bool operator ==(TaxInclusionType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TaxInclusionType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TaxInclusionType value) => value.Value;

    public static explicit operator TaxInclusionType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Additive = "ADDITIVE";

        public const string Inclusive = "INCLUSIVE";
    }
}
