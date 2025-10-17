using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<InvoicePaymentReminderStatus>))]
[Serializable]
public readonly record struct InvoicePaymentReminderStatus : IStringEnum
{
    public static readonly InvoicePaymentReminderStatus Pending = new(Values.Pending);

    public static readonly InvoicePaymentReminderStatus NotApplicable = new(Values.NotApplicable);

    public static readonly InvoicePaymentReminderStatus Sent = new(Values.Sent);

    public InvoicePaymentReminderStatus(string value)
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
    public static InvoicePaymentReminderStatus FromCustom(string value)
    {
        return new InvoicePaymentReminderStatus(value);
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

    public static bool operator ==(InvoicePaymentReminderStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(InvoicePaymentReminderStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(InvoicePaymentReminderStatus value) => value.Value;

    public static explicit operator InvoicePaymentReminderStatus(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Pending = "PENDING";

        public const string NotApplicable = "NOT_APPLICABLE";

        public const string Sent = "SENT";
    }
}
