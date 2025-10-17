using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<TransactionType>))]
[Serializable]
public readonly record struct TransactionType : IStringEnum
{
    public static readonly TransactionType Debit = new(Values.Debit);

    public static readonly TransactionType Credit = new(Values.Credit);

    public TransactionType(string value)
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
    public static TransactionType FromCustom(string value)
    {
        return new TransactionType(value);
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

    public static bool operator ==(TransactionType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TransactionType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TransactionType value) => value.Value;

    public static explicit operator TransactionType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Debit = "DEBIT";

        public const string Credit = "CREDIT";
    }
}
