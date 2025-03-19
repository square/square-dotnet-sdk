using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<CatalogItemProductType>))]
public readonly record struct CatalogItemProductType : IStringEnum
{
    public static readonly CatalogItemProductType Regular = new(Values.Regular);

    public static readonly CatalogItemProductType GiftCard = new(Values.GiftCard);

    public static readonly CatalogItemProductType AppointmentsService = new(
        Values.AppointmentsService
    );

    public static readonly CatalogItemProductType FoodAndBev = new(Values.FoodAndBev);

    public static readonly CatalogItemProductType Event = new(Values.Event);

    public static readonly CatalogItemProductType Digital = new(Values.Digital);

    public static readonly CatalogItemProductType Donation = new(Values.Donation);

    public static readonly CatalogItemProductType LegacySquareOnlineService = new(
        Values.LegacySquareOnlineService
    );

    public static readonly CatalogItemProductType LegacySquareOnlineMembership = new(
        Values.LegacySquareOnlineMembership
    );

    public CatalogItemProductType(string value)
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
    public static CatalogItemProductType FromCustom(string value)
    {
        return new CatalogItemProductType(value);
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

    public static bool operator ==(CatalogItemProductType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CatalogItemProductType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CatalogItemProductType value) => value.Value;

    public static explicit operator CatalogItemProductType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string Regular = "REGULAR";

        public const string GiftCard = "GIFT_CARD";

        public const string AppointmentsService = "APPOINTMENTS_SERVICE";

        public const string FoodAndBev = "FOOD_AND_BEV";

        public const string Event = "EVENT";

        public const string Digital = "DIGITAL";

        public const string Donation = "DONATION";

        public const string LegacySquareOnlineService = "LEGACY_SQUARE_ONLINE_SERVICE";

        public const string LegacySquareOnlineMembership = "LEGACY_SQUARE_ONLINE_MEMBERSHIP";
    }
}
