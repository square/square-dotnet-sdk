using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[JsonConverter(typeof(StringEnumSerializer<SearchVendorsRequestSortField>))]
[Serializable]
public readonly record struct SearchVendorsRequestSortField : IStringEnum
{
    public static readonly SearchVendorsRequestSortField Name = new(Values.Name);

    public static readonly SearchVendorsRequestSortField CreatedAt = new(Values.CreatedAt);

    public SearchVendorsRequestSortField(string value)
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
    public static SearchVendorsRequestSortField FromCustom(string value)
    {
        return new SearchVendorsRequestSortField(value);
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

    public static bool operator ==(SearchVendorsRequestSortField value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SearchVendorsRequestSortField value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SearchVendorsRequestSortField value) => value.Value;

    public static explicit operator SearchVendorsRequestSortField(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Name = "NAME";

        public const string CreatedAt = "CREATED_AT";
    }
}
