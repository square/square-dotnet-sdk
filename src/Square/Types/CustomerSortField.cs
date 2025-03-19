using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<CustomerSortField>))]
public readonly record struct CustomerSortField : IStringEnum
{
    public static readonly CustomerSortField Default = new(Values.Default);

    public static readonly CustomerSortField CreatedAt = new(Values.CreatedAt);

    public CustomerSortField(string value)
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
    public static CustomerSortField FromCustom(string value)
    {
        return new CustomerSortField(value);
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

    public static bool operator ==(CustomerSortField value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CustomerSortField value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CustomerSortField value) => value.Value;

    public static explicit operator CustomerSortField(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string Default = "DEFAULT";

        public const string CreatedAt = "CREATED_AT";
    }
}
