using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<SubscriptionEventInfoCode>))]
public readonly record struct SubscriptionEventInfoCode : IStringEnum
{
    public static readonly SubscriptionEventInfoCode LocationNotActive = new(
        Values.LocationNotActive
    );

    public static readonly SubscriptionEventInfoCode LocationCannotAcceptPayment = new(
        Values.LocationCannotAcceptPayment
    );

    public static readonly SubscriptionEventInfoCode CustomerDeleted = new(Values.CustomerDeleted);

    public static readonly SubscriptionEventInfoCode CustomerNoEmail = new(Values.CustomerNoEmail);

    public static readonly SubscriptionEventInfoCode CustomerNoName = new(Values.CustomerNoName);

    public static readonly SubscriptionEventInfoCode UserProvided = new(Values.UserProvided);

    public SubscriptionEventInfoCode(string value)
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
    public static SubscriptionEventInfoCode FromCustom(string value)
    {
        return new SubscriptionEventInfoCode(value);
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

    public static bool operator ==(SubscriptionEventInfoCode value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SubscriptionEventInfoCode value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SubscriptionEventInfoCode value) => value.Value;

    public static explicit operator SubscriptionEventInfoCode(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string LocationNotActive = "LOCATION_NOT_ACTIVE";

        public const string LocationCannotAcceptPayment = "LOCATION_CANNOT_ACCEPT_PAYMENT";

        public const string CustomerDeleted = "CUSTOMER_DELETED";

        public const string CustomerNoEmail = "CUSTOMER_NO_EMAIL";

        public const string CustomerNoName = "CUSTOMER_NO_NAME";

        public const string UserProvided = "USER_PROVIDED";
    }
}
