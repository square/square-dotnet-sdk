using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<ExcludeStrategy>))]
public readonly record struct ExcludeStrategy : IStringEnum
{
    public static readonly ExcludeStrategy LeastExpensive = new(Values.LeastExpensive);

    public static readonly ExcludeStrategy MostExpensive = new(Values.MostExpensive);

    public ExcludeStrategy(string value)
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
    public static ExcludeStrategy FromCustom(string value)
    {
        return new ExcludeStrategy(value);
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

    public static bool operator ==(ExcludeStrategy value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ExcludeStrategy value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ExcludeStrategy value) => value.Value;

    public static explicit operator ExcludeStrategy(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string LeastExpensive = "LEAST_EXPENSIVE";

        public const string MostExpensive = "MOST_EXPENSIVE";
    }
}
