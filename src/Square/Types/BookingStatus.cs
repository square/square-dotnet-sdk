using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<BookingStatus>))]
[Serializable]
public readonly record struct BookingStatus : IStringEnum
{
    public static readonly BookingStatus Pending = new(Values.Pending);

    public static readonly BookingStatus CancelledByCustomer = new(Values.CancelledByCustomer);

    public static readonly BookingStatus CancelledBySeller = new(Values.CancelledBySeller);

    public static readonly BookingStatus Declined = new(Values.Declined);

    public static readonly BookingStatus Accepted = new(Values.Accepted);

    public static readonly BookingStatus NoShow = new(Values.NoShow);

    public BookingStatus(string value)
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
    public static BookingStatus FromCustom(string value)
    {
        return new BookingStatus(value);
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

    public static bool operator ==(BookingStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BookingStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BookingStatus value) => value.Value;

    public static explicit operator BookingStatus(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Pending = "PENDING";

        public const string CancelledByCustomer = "CANCELLED_BY_CUSTOMER";

        public const string CancelledBySeller = "CANCELLED_BY_SELLER";

        public const string Declined = "DECLINED";

        public const string Accepted = "ACCEPTED";

        public const string NoShow = "NO_SHOW";
    }
}
