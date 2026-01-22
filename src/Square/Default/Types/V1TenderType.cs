using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[JsonConverter(typeof(StringEnumSerializer<V1TenderType>))]
[Serializable]
public readonly record struct V1TenderType : IStringEnum
{
    public static readonly V1TenderType CreditCard = new(Values.CreditCard);

    public static readonly V1TenderType Cash = new(Values.Cash);

    public static readonly V1TenderType ThirdPartyCard = new(Values.ThirdPartyCard);

    public static readonly V1TenderType NoSale = new(Values.NoSale);

    public static readonly V1TenderType SquareWallet = new(Values.SquareWallet);

    public static readonly V1TenderType SquareGiftCard = new(Values.SquareGiftCard);

    public static readonly V1TenderType Unknown = new(Values.Unknown);

    public static readonly V1TenderType Other = new(Values.Other);

    public V1TenderType(string value)
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
    public static V1TenderType FromCustom(string value)
    {
        return new V1TenderType(value);
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

    public static bool operator ==(V1TenderType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(V1TenderType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(V1TenderType value) => value.Value;

    public static explicit operator V1TenderType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string CreditCard = "CREDIT_CARD";

        public const string Cash = "CASH";

        public const string ThirdPartyCard = "THIRD_PARTY_CARD";

        public const string NoSale = "NO_SALE";

        public const string SquareWallet = "SQUARE_WALLET";

        public const string SquareGiftCard = "SQUARE_GIFT_CARD";

        public const string Unknown = "UNKNOWN";

        public const string Other = "OTHER";
    }
}
