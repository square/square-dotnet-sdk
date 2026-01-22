using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[JsonConverter(typeof(StringEnumSerializer<CardBrand>))]
[Serializable]
public readonly record struct CardBrand : IStringEnum
{
    public static readonly CardBrand OtherBrand = new(Values.OtherBrand);

    public static readonly CardBrand Visa = new(Values.Visa);

    public static readonly CardBrand Mastercard = new(Values.Mastercard);

    public static readonly CardBrand AmericanExpress = new(Values.AmericanExpress);

    public static readonly CardBrand Discover = new(Values.Discover);

    public static readonly CardBrand DiscoverDiners = new(Values.DiscoverDiners);

    public static readonly CardBrand Jcb = new(Values.Jcb);

    public static readonly CardBrand ChinaUnionpay = new(Values.ChinaUnionpay);

    public static readonly CardBrand SquareGiftCard = new(Values.SquareGiftCard);

    public static readonly CardBrand SquareCapitalCard = new(Values.SquareCapitalCard);

    public static readonly CardBrand Interac = new(Values.Interac);

    public static readonly CardBrand Eftpos = new(Values.Eftpos);

    public static readonly CardBrand Felica = new(Values.Felica);

    public static readonly CardBrand Ebt = new(Values.Ebt);

    public CardBrand(string value)
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
    public static CardBrand FromCustom(string value)
    {
        return new CardBrand(value);
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

    public static bool operator ==(CardBrand value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(CardBrand value1, string value2) => !value1.Value.Equals(value2);

    public static explicit operator string(CardBrand value) => value.Value;

    public static explicit operator CardBrand(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string OtherBrand = "OTHER_BRAND";

        public const string Visa = "VISA";

        public const string Mastercard = "MASTERCARD";

        public const string AmericanExpress = "AMERICAN_EXPRESS";

        public const string Discover = "DISCOVER";

        public const string DiscoverDiners = "DISCOVER_DINERS";

        public const string Jcb = "JCB";

        public const string ChinaUnionpay = "CHINA_UNIONPAY";

        public const string SquareGiftCard = "SQUARE_GIFT_CARD";

        public const string SquareCapitalCard = "SQUARE_CAPITAL_CARD";

        public const string Interac = "INTERAC";

        public const string Eftpos = "EFTPOS";

        public const string Felica = "FELICA";

        public const string Ebt = "EBT";
    }
}
