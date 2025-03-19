using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<VisibilityFilter>))]
public readonly record struct VisibilityFilter : IStringEnum
{
    public static readonly VisibilityFilter All = new(Values.All);

    public static readonly VisibilityFilter Read = new(Values.Read);

    public static readonly VisibilityFilter ReadWrite = new(Values.ReadWrite);

    public VisibilityFilter(string value)
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
    public static VisibilityFilter FromCustom(string value)
    {
        return new VisibilityFilter(value);
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

    public static bool operator ==(VisibilityFilter value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(VisibilityFilter value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(VisibilityFilter value) => value.Value;

    public static explicit operator VisibilityFilter(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string All = "ALL";

        public const string Read = "READ";

        public const string ReadWrite = "READ_WRITE";
    }
}
