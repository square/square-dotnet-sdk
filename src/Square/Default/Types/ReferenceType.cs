using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[JsonConverter(typeof(StringEnumSerializer<ReferenceType>))]
[Serializable]
public readonly record struct ReferenceType : IStringEnum
{
    public static readonly ReferenceType UnknownType = new(Values.UnknownType);

    public static readonly ReferenceType Location = new(Values.Location);

    public static readonly ReferenceType FirstPartyIntegration = new(Values.FirstPartyIntegration);

    public static readonly ReferenceType OauthApplication = new(Values.OauthApplication);

    public static readonly ReferenceType OnlineSite = new(Values.OnlineSite);

    public static readonly ReferenceType OnlineCheckout = new(Values.OnlineCheckout);

    public static readonly ReferenceType Invoice = new(Values.Invoice);

    public static readonly ReferenceType GiftCard = new(Values.GiftCard);

    public static readonly ReferenceType GiftCardMarketplace = new(Values.GiftCardMarketplace);

    public static readonly ReferenceType RecurringSubscription = new(Values.RecurringSubscription);

    public static readonly ReferenceType OnlineBookingFlow = new(Values.OnlineBookingFlow);

    public static readonly ReferenceType SquareAssistant = new(Values.SquareAssistant);

    public static readonly ReferenceType CashLocal = new(Values.CashLocal);

    public static readonly ReferenceType PointOfSale = new(Values.PointOfSale);

    public static readonly ReferenceType Kiosk = new(Values.Kiosk);

    public ReferenceType(string value)
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
    public static ReferenceType FromCustom(string value)
    {
        return new ReferenceType(value);
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

    public static bool operator ==(ReferenceType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ReferenceType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ReferenceType value) => value.Value;

    public static explicit operator ReferenceType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string UnknownType = "UNKNOWN_TYPE";

        public const string Location = "LOCATION";

        public const string FirstPartyIntegration = "FIRST_PARTY_INTEGRATION";

        public const string OauthApplication = "OAUTH_APPLICATION";

        public const string OnlineSite = "ONLINE_SITE";

        public const string OnlineCheckout = "ONLINE_CHECKOUT";

        public const string Invoice = "INVOICE";

        public const string GiftCard = "GIFT_CARD";

        public const string GiftCardMarketplace = "GIFT_CARD_MARKETPLACE";

        public const string RecurringSubscription = "RECURRING_SUBSCRIPTION";

        public const string OnlineBookingFlow = "ONLINE_BOOKING_FLOW";

        public const string SquareAssistant = "SQUARE_ASSISTANT";

        public const string CashLocal = "CASH_LOCAL";

        public const string PointOfSale = "POINT_OF_SALE";

        public const string Kiosk = "KIOSK";
    }
}
