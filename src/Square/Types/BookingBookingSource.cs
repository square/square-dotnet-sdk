using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<BookingBookingSource>))]
[Serializable]
public readonly record struct BookingBookingSource : IStringEnum
{
    public static readonly BookingBookingSource FirstPartyMerchant = new(Values.FirstPartyMerchant);

    public static readonly BookingBookingSource FirstPartyBuyer = new(Values.FirstPartyBuyer);

    public static readonly BookingBookingSource ThirdPartyBuyer = new(Values.ThirdPartyBuyer);

    public static readonly BookingBookingSource Api = new(Values.Api);

    public BookingBookingSource(string value)
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
    public static BookingBookingSource FromCustom(string value)
    {
        return new BookingBookingSource(value);
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

    public static bool operator ==(BookingBookingSource value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BookingBookingSource value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BookingBookingSource value) => value.Value;

    public static explicit operator BookingBookingSource(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string FirstPartyMerchant = "FIRST_PARTY_MERCHANT";

        public const string FirstPartyBuyer = "FIRST_PARTY_BUYER";

        public const string ThirdPartyBuyer = "THIRD_PARTY_BUYER";

        public const string Api = "API";
    }
}
