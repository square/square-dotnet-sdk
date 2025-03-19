using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<PayoutFeeType>))]
public readonly record struct PayoutFeeType : IStringEnum
{
    public static readonly PayoutFeeType TransferFee = new(Values.TransferFee);

    public static readonly PayoutFeeType TaxOnTransferFee = new(Values.TaxOnTransferFee);

    public PayoutFeeType(string value)
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
    public static PayoutFeeType FromCustom(string value)
    {
        return new PayoutFeeType(value);
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

    public static bool operator ==(PayoutFeeType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PayoutFeeType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PayoutFeeType value) => value.Value;

    public static explicit operator PayoutFeeType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string TransferFee = "TRANSFER_FEE";

        public const string TaxOnTransferFee = "TAX_ON_TRANSFER_FEE";
    }
}
