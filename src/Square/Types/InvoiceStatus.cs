using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<InvoiceStatus>))]
public readonly record struct InvoiceStatus : IStringEnum
{
    public static readonly InvoiceStatus Draft = new(Values.Draft);

    public static readonly InvoiceStatus Unpaid = new(Values.Unpaid);

    public static readonly InvoiceStatus Scheduled = new(Values.Scheduled);

    public static readonly InvoiceStatus PartiallyPaid = new(Values.PartiallyPaid);

    public static readonly InvoiceStatus Paid = new(Values.Paid);

    public static readonly InvoiceStatus PartiallyRefunded = new(Values.PartiallyRefunded);

    public static readonly InvoiceStatus Refunded = new(Values.Refunded);

    public static readonly InvoiceStatus Canceled = new(Values.Canceled);

    public static readonly InvoiceStatus Failed = new(Values.Failed);

    public static readonly InvoiceStatus PaymentPending = new(Values.PaymentPending);

    public InvoiceStatus(string value)
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
    public static InvoiceStatus FromCustom(string value)
    {
        return new InvoiceStatus(value);
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

    public static bool operator ==(InvoiceStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(InvoiceStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(InvoiceStatus value) => value.Value;

    public static explicit operator InvoiceStatus(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string Draft = "DRAFT";

        public const string Unpaid = "UNPAID";

        public const string Scheduled = "SCHEDULED";

        public const string PartiallyPaid = "PARTIALLY_PAID";

        public const string Paid = "PAID";

        public const string PartiallyRefunded = "PARTIALLY_REFUNDED";

        public const string Refunded = "REFUNDED";

        public const string Canceled = "CANCELED";

        public const string Failed = "FAILED";

        public const string PaymentPending = "PAYMENT_PENDING";
    }
}
