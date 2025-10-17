using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<BusinessBookingProfileBookingPolicy>))]
[Serializable]
public readonly record struct BusinessBookingProfileBookingPolicy : IStringEnum
{
    public static readonly BusinessBookingProfileBookingPolicy AcceptAll = new(Values.AcceptAll);

    public static readonly BusinessBookingProfileBookingPolicy RequiresAcceptance = new(
        Values.RequiresAcceptance
    );

    public BusinessBookingProfileBookingPolicy(string value)
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
    public static BusinessBookingProfileBookingPolicy FromCustom(string value)
    {
        return new BusinessBookingProfileBookingPolicy(value);
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

    public static bool operator ==(BusinessBookingProfileBookingPolicy value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BusinessBookingProfileBookingPolicy value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BusinessBookingProfileBookingPolicy value) =>
        value.Value;

    public static explicit operator BusinessBookingProfileBookingPolicy(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string AcceptAll = "ACCEPT_ALL";

        public const string RequiresAcceptance = "REQUIRES_ACCEPTANCE";
    }
}
