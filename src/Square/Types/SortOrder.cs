using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<SortOrder>))]
public readonly record struct SortOrder : IStringEnum
{
    public static readonly SortOrder Desc = new(Values.Desc);

    public static readonly SortOrder Asc = new(Values.Asc);

    public SortOrder(string value)
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
    public static SortOrder FromCustom(string value)
    {
        return new SortOrder(value);
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

    public static bool operator ==(SortOrder value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(SortOrder value1, string value2) => !value1.Value.Equals(value2);

    public static explicit operator string(SortOrder value) => value.Value;

    public static explicit operator SortOrder(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string Desc = "DESC";

        public const string Asc = "ASC";
    }
}
