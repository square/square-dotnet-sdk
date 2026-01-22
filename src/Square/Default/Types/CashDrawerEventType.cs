using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[JsonConverter(typeof(StringEnumSerializer<CashDrawerEventType>))]
[Serializable]
public readonly record struct CashDrawerEventType : IStringEnum
{
    public static readonly CashDrawerEventType NoSale = new(Values.NoSale);

    public static readonly CashDrawerEventType CashTenderPayment = new(Values.CashTenderPayment);

    public static readonly CashDrawerEventType OtherTenderPayment = new(Values.OtherTenderPayment);

    public static readonly CashDrawerEventType CashTenderCancelledPayment = new(
        Values.CashTenderCancelledPayment
    );

    public static readonly CashDrawerEventType OtherTenderCancelledPayment = new(
        Values.OtherTenderCancelledPayment
    );

    public static readonly CashDrawerEventType CashTenderRefund = new(Values.CashTenderRefund);

    public static readonly CashDrawerEventType OtherTenderRefund = new(Values.OtherTenderRefund);

    public static readonly CashDrawerEventType PaidIn = new(Values.PaidIn);

    public static readonly CashDrawerEventType PaidOut = new(Values.PaidOut);

    public CashDrawerEventType(string value)
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
    public static CashDrawerEventType FromCustom(string value)
    {
        return new CashDrawerEventType(value);
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

    public static bool operator ==(CashDrawerEventType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CashDrawerEventType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CashDrawerEventType value) => value.Value;

    public static explicit operator CashDrawerEventType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string NoSale = "NO_SALE";

        public const string CashTenderPayment = "CASH_TENDER_PAYMENT";

        public const string OtherTenderPayment = "OTHER_TENDER_PAYMENT";

        public const string CashTenderCancelledPayment = "CASH_TENDER_CANCELLED_PAYMENT";

        public const string OtherTenderCancelledPayment = "OTHER_TENDER_CANCELLED_PAYMENT";

        public const string CashTenderRefund = "CASH_TENDER_REFUND";

        public const string OtherTenderRefund = "OTHER_TENDER_REFUND";

        public const string PaidIn = "PAID_IN";

        public const string PaidOut = "PAID_OUT";
    }
}
