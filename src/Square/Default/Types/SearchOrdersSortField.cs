using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[JsonConverter(typeof(StringEnumSerializer<SearchOrdersSortField>))]
[Serializable]
public readonly record struct SearchOrdersSortField : IStringEnum
{
    public static readonly SearchOrdersSortField CreatedAt = new(Values.CreatedAt);

    public static readonly SearchOrdersSortField UpdatedAt = new(Values.UpdatedAt);

    public static readonly SearchOrdersSortField ClosedAt = new(Values.ClosedAt);

    public SearchOrdersSortField(string value)
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
    public static SearchOrdersSortField FromCustom(string value)
    {
        return new SearchOrdersSortField(value);
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

    public static bool operator ==(SearchOrdersSortField value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SearchOrdersSortField value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SearchOrdersSortField value) => value.Value;

    public static explicit operator SearchOrdersSortField(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string CreatedAt = "CREATED_AT";

        public const string UpdatedAt = "UPDATED_AT";

        public const string ClosedAt = "CLOSED_AT";
    }
}
