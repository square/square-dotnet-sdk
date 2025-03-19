using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<ListPaymentsRequestSortField>))]
public readonly record struct ListPaymentsRequestSortField : IStringEnum
{
    public static readonly ListPaymentsRequestSortField CreatedAt = new(Values.CreatedAt);

    public static readonly ListPaymentsRequestSortField OfflineCreatedAt = new(
        Values.OfflineCreatedAt
    );

    public static readonly ListPaymentsRequestSortField UpdatedAt = new(Values.UpdatedAt);

    public ListPaymentsRequestSortField(string value)
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
    public static ListPaymentsRequestSortField FromCustom(string value)
    {
        return new ListPaymentsRequestSortField(value);
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

    public static bool operator ==(ListPaymentsRequestSortField value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListPaymentsRequestSortField value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListPaymentsRequestSortField value) => value.Value;

    public static explicit operator ListPaymentsRequestSortField(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string CreatedAt = "CREATED_AT";

        public const string OfflineCreatedAt = "OFFLINE_CREATED_AT";

        public const string UpdatedAt = "UPDATED_AT";
    }
}
