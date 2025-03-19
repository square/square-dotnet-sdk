using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<TenderBuyNowPayLaterDetailsBrand>))]
public readonly record struct TenderBuyNowPayLaterDetailsBrand : IStringEnum
{
    public static readonly TenderBuyNowPayLaterDetailsBrand OtherBrand = new(Values.OtherBrand);

    public static readonly TenderBuyNowPayLaterDetailsBrand Afterpay = new(Values.Afterpay);

    public TenderBuyNowPayLaterDetailsBrand(string value)
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
    public static TenderBuyNowPayLaterDetailsBrand FromCustom(string value)
    {
        return new TenderBuyNowPayLaterDetailsBrand(value);
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

    public static bool operator ==(TenderBuyNowPayLaterDetailsBrand value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TenderBuyNowPayLaterDetailsBrand value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TenderBuyNowPayLaterDetailsBrand value) => value.Value;

    public static explicit operator TenderBuyNowPayLaterDetailsBrand(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string OtherBrand = "OTHER_BRAND";

        public const string Afterpay = "AFTERPAY";
    }
}
