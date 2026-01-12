using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[JsonConverter(typeof(StringEnumSerializer<InvoiceRequestType>))]
[Serializable]
public readonly record struct InvoiceRequestType : IStringEnum
{
    public static readonly InvoiceRequestType Balance = new(Values.Balance);

    public static readonly InvoiceRequestType Deposit = new(Values.Deposit);

    public static readonly InvoiceRequestType Installment = new(Values.Installment);

    public InvoiceRequestType(string value)
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
    public static InvoiceRequestType FromCustom(string value)
    {
        return new InvoiceRequestType(value);
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

    public static bool operator ==(InvoiceRequestType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(InvoiceRequestType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(InvoiceRequestType value) => value.Value;

    public static explicit operator InvoiceRequestType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Balance = "BALANCE";

        public const string Deposit = "DEPOSIT";

        public const string Installment = "INSTALLMENT";
    }
}
