using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<CustomerInclusionExclusion>))]
[Serializable]
public readonly record struct CustomerInclusionExclusion : IStringEnum
{
    public static readonly CustomerInclusionExclusion Include = new(Values.Include);

    public static readonly CustomerInclusionExclusion Exclude = new(Values.Exclude);

    public CustomerInclusionExclusion(string value)
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
    public static CustomerInclusionExclusion FromCustom(string value)
    {
        return new CustomerInclusionExclusion(value);
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

    public static bool operator ==(CustomerInclusionExclusion value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CustomerInclusionExclusion value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CustomerInclusionExclusion value) => value.Value;

    public static explicit operator CustomerInclusionExclusion(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Include = "INCLUDE";

        public const string Exclude = "EXCLUDE";
    }
}
