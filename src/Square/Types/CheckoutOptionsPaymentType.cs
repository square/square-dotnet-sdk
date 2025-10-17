using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<CheckoutOptionsPaymentType>))]
[Serializable]
public readonly record struct CheckoutOptionsPaymentType : IStringEnum
{
    public static readonly CheckoutOptionsPaymentType CardPresent = new(Values.CardPresent);

    public static readonly CheckoutOptionsPaymentType ManualCardEntry = new(Values.ManualCardEntry);

    public static readonly CheckoutOptionsPaymentType FelicaId = new(Values.FelicaId);

    public static readonly CheckoutOptionsPaymentType FelicaQuicpay = new(Values.FelicaQuicpay);

    public static readonly CheckoutOptionsPaymentType FelicaTransportationGroup = new(
        Values.FelicaTransportationGroup
    );

    public static readonly CheckoutOptionsPaymentType FelicaAll = new(Values.FelicaAll);

    public static readonly CheckoutOptionsPaymentType Paypay = new(Values.Paypay);

    public static readonly CheckoutOptionsPaymentType QrCode = new(Values.QrCode);

    public CheckoutOptionsPaymentType(string value)
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
    public static CheckoutOptionsPaymentType FromCustom(string value)
    {
        return new CheckoutOptionsPaymentType(value);
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

    public static bool operator ==(CheckoutOptionsPaymentType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CheckoutOptionsPaymentType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CheckoutOptionsPaymentType value) => value.Value;

    public static explicit operator CheckoutOptionsPaymentType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string CardPresent = "CARD_PRESENT";

        public const string ManualCardEntry = "MANUAL_CARD_ENTRY";

        public const string FelicaId = "FELICA_ID";

        public const string FelicaQuicpay = "FELICA_QUICPAY";

        public const string FelicaTransportationGroup = "FELICA_TRANSPORTATION_GROUP";

        public const string FelicaAll = "FELICA_ALL";

        public const string Paypay = "PAYPAY";

        public const string QrCode = "QR_CODE";
    }
}
