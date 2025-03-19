using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<BusinessBookingProfileCustomerTimezoneChoice>))]
public readonly record struct BusinessBookingProfileCustomerTimezoneChoice : IStringEnum
{
    public static readonly BusinessBookingProfileCustomerTimezoneChoice BusinessLocationTimezone =
        new(Values.BusinessLocationTimezone);

    public static readonly BusinessBookingProfileCustomerTimezoneChoice CustomerChoice = new(
        Values.CustomerChoice
    );

    public BusinessBookingProfileCustomerTimezoneChoice(string value)
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
    public static BusinessBookingProfileCustomerTimezoneChoice FromCustom(string value)
    {
        return new BusinessBookingProfileCustomerTimezoneChoice(value);
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

    public static bool operator ==(
        BusinessBookingProfileCustomerTimezoneChoice value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        BusinessBookingProfileCustomerTimezoneChoice value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(BusinessBookingProfileCustomerTimezoneChoice value) =>
        value.Value;

    public static explicit operator BusinessBookingProfileCustomerTimezoneChoice(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string BusinessLocationTimezone = "BUSINESS_LOCATION_TIMEZONE";

        public const string CustomerChoice = "CUSTOMER_CHOICE";
    }
}
