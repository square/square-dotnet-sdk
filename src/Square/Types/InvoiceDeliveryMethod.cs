using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<InvoiceDeliveryMethod>))]
[Serializable]
public readonly record struct InvoiceDeliveryMethod : IStringEnum
{
    public static readonly InvoiceDeliveryMethod Email = new(Values.Email);

    public static readonly InvoiceDeliveryMethod ShareManually = new(Values.ShareManually);

    public static readonly InvoiceDeliveryMethod Sms = new(Values.Sms);

    public InvoiceDeliveryMethod(string value)
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
    public static InvoiceDeliveryMethod FromCustom(string value)
    {
        return new InvoiceDeliveryMethod(value);
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

    public static bool operator ==(InvoiceDeliveryMethod value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(InvoiceDeliveryMethod value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(InvoiceDeliveryMethod value) => value.Value;

    public static explicit operator InvoiceDeliveryMethod(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Email = "EMAIL";

        public const string ShareManually = "SHARE_MANUALLY";

        public const string Sms = "SMS";
    }
}
