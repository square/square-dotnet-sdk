using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<InvoiceAutomaticPaymentSource>))]
public readonly record struct InvoiceAutomaticPaymentSource : IStringEnum
{
    public static readonly InvoiceAutomaticPaymentSource None = new(Values.None);

    public static readonly InvoiceAutomaticPaymentSource CardOnFile = new(Values.CardOnFile);

    public static readonly InvoiceAutomaticPaymentSource BankOnFile = new(Values.BankOnFile);

    public InvoiceAutomaticPaymentSource(string value)
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
    public static InvoiceAutomaticPaymentSource FromCustom(string value)
    {
        return new InvoiceAutomaticPaymentSource(value);
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

    public static bool operator ==(InvoiceAutomaticPaymentSource value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(InvoiceAutomaticPaymentSource value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(InvoiceAutomaticPaymentSource value) => value.Value;

    public static explicit operator InvoiceAutomaticPaymentSource(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string None = "NONE";

        public const string CardOnFile = "CARD_ON_FILE";

        public const string BankOnFile = "BANK_ON_FILE";
    }
}
