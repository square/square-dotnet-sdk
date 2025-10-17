using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<ListPaymentRefundsRequestSortField>))]
[Serializable]
public readonly record struct ListPaymentRefundsRequestSortField : IStringEnum
{
    public static readonly ListPaymentRefundsRequestSortField CreatedAt = new(Values.CreatedAt);

    public static readonly ListPaymentRefundsRequestSortField UpdatedAt = new(Values.UpdatedAt);

    public ListPaymentRefundsRequestSortField(string value)
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
    public static ListPaymentRefundsRequestSortField FromCustom(string value)
    {
        return new ListPaymentRefundsRequestSortField(value);
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

    public static bool operator ==(ListPaymentRefundsRequestSortField value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListPaymentRefundsRequestSortField value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListPaymentRefundsRequestSortField value) => value.Value;

    public static explicit operator ListPaymentRefundsRequestSortField(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string CreatedAt = "CREATED_AT";

        public const string UpdatedAt = "UPDATED_AT";
    }
}
