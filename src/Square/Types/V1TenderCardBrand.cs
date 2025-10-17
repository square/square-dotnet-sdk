using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<V1TenderCardBrand>))]
[Serializable]
public readonly record struct V1TenderCardBrand : IStringEnum
{
    public static readonly V1TenderCardBrand OtherBrand = new(Values.OtherBrand);

    public static readonly V1TenderCardBrand Visa = new(Values.Visa);

    public static readonly V1TenderCardBrand MasterCard = new(Values.MasterCard);

    public static readonly V1TenderCardBrand AmericanExpress = new(Values.AmericanExpress);

    public static readonly V1TenderCardBrand Discover = new(Values.Discover);

    public static readonly V1TenderCardBrand DiscoverDiners = new(Values.DiscoverDiners);

    public static readonly V1TenderCardBrand Jcb = new(Values.Jcb);

    public static readonly V1TenderCardBrand ChinaUnionpay = new(Values.ChinaUnionpay);

    public static readonly V1TenderCardBrand SquareGiftCard = new(Values.SquareGiftCard);

    public V1TenderCardBrand(string value)
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
    public static V1TenderCardBrand FromCustom(string value)
    {
        return new V1TenderCardBrand(value);
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

    public static bool operator ==(V1TenderCardBrand value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(V1TenderCardBrand value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(V1TenderCardBrand value) => value.Value;

    public static explicit operator V1TenderCardBrand(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string OtherBrand = "OTHER_BRAND";

        public const string Visa = "VISA";

        public const string MasterCard = "MASTER_CARD";

        public const string AmericanExpress = "AMERICAN_EXPRESS";

        public const string Discover = "DISCOVER";

        public const string DiscoverDiners = "DISCOVER_DINERS";

        public const string Jcb = "JCB";

        public const string ChinaUnionpay = "CHINA_UNIONPAY";

        public const string SquareGiftCard = "SQUARE_GIFT_CARD";
    }
}
