using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<TenderType>))]
public readonly record struct TenderType : IStringEnum
{
    public static readonly TenderType Card = new(Values.Card);

    public static readonly TenderType Cash = new(Values.Cash);

    public static readonly TenderType ThirdPartyCard = new(Values.ThirdPartyCard);

    public static readonly TenderType SquareGiftCard = new(Values.SquareGiftCard);

    public static readonly TenderType NoSale = new(Values.NoSale);

    public static readonly TenderType BankAccount = new(Values.BankAccount);

    public static readonly TenderType Wallet = new(Values.Wallet);

    public static readonly TenderType BuyNowPayLater = new(Values.BuyNowPayLater);

    public static readonly TenderType SquareAccount = new(Values.SquareAccount);

    public static readonly TenderType Other = new(Values.Other);

    public TenderType(string value)
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
    public static TenderType FromCustom(string value)
    {
        return new TenderType(value);
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

    public static bool operator ==(TenderType value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(TenderType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TenderType value) => value.Value;

    public static explicit operator TenderType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string Card = "CARD";

        public const string Cash = "CASH";

        public const string ThirdPartyCard = "THIRD_PARTY_CARD";

        public const string SquareGiftCard = "SQUARE_GIFT_CARD";

        public const string NoSale = "NO_SALE";

        public const string BankAccount = "BANK_ACCOUNT";

        public const string Wallet = "WALLET";

        public const string BuyNowPayLater = "BUY_NOW_PAY_LATER";

        public const string SquareAccount = "SQUARE_ACCOUNT";

        public const string Other = "OTHER";
    }
}
