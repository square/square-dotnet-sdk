using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<InvoiceRequestMethod>))]
[Serializable]
public readonly record struct InvoiceRequestMethod : IStringEnum
{
    public static readonly InvoiceRequestMethod Email = new(Values.Email);

    public static readonly InvoiceRequestMethod ChargeCardOnFile = new(Values.ChargeCardOnFile);

    public static readonly InvoiceRequestMethod ShareManually = new(Values.ShareManually);

    public static readonly InvoiceRequestMethod ChargeBankOnFile = new(Values.ChargeBankOnFile);

    public static readonly InvoiceRequestMethod Sms = new(Values.Sms);

    public static readonly InvoiceRequestMethod SmsChargeCardOnFile = new(
        Values.SmsChargeCardOnFile
    );

    public static readonly InvoiceRequestMethod SmsChargeBankOnFile = new(
        Values.SmsChargeBankOnFile
    );

    public InvoiceRequestMethod(string value)
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
    public static InvoiceRequestMethod FromCustom(string value)
    {
        return new InvoiceRequestMethod(value);
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

    public static bool operator ==(InvoiceRequestMethod value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(InvoiceRequestMethod value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(InvoiceRequestMethod value) => value.Value;

    public static explicit operator InvoiceRequestMethod(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Email = "EMAIL";

        public const string ChargeCardOnFile = "CHARGE_CARD_ON_FILE";

        public const string ShareManually = "SHARE_MANUALLY";

        public const string ChargeBankOnFile = "CHARGE_BANK_ON_FILE";

        public const string Sms = "SMS";

        public const string SmsChargeCardOnFile = "SMS_CHARGE_CARD_ON_FILE";

        public const string SmsChargeBankOnFile = "SMS_CHARGE_BANK_ON_FILE";
    }
}
