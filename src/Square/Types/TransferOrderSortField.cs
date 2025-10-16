using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<TransferOrderSortField>))]
public readonly record struct TransferOrderSortField : IStringEnum
{
    public static readonly TransferOrderSortField CreatedAt = new(Values.CreatedAt);

    public static readonly TransferOrderSortField UpdatedAt = new(Values.UpdatedAt);

    public TransferOrderSortField(string value)
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
    public static TransferOrderSortField FromCustom(string value)
    {
        return new TransferOrderSortField(value);
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

    public static bool operator ==(TransferOrderSortField value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TransferOrderSortField value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TransferOrderSortField value) => value.Value;

    public static explicit operator TransferOrderSortField(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string CreatedAt = "CREATED_AT";

        public const string UpdatedAt = "UPDATED_AT";
    }
}
