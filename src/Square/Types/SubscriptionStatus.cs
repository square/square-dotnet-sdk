using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<SubscriptionStatus>))]
public readonly record struct SubscriptionStatus : IStringEnum
{
    public static readonly SubscriptionStatus Pending = new(Values.Pending);

    public static readonly SubscriptionStatus Active = new(Values.Active);

    public static readonly SubscriptionStatus Canceled = new(Values.Canceled);

    public static readonly SubscriptionStatus Deactivated = new(Values.Deactivated);

    public static readonly SubscriptionStatus Paused = new(Values.Paused);

    public SubscriptionStatus(string value)
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
    public static SubscriptionStatus FromCustom(string value)
    {
        return new SubscriptionStatus(value);
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

    public static bool operator ==(SubscriptionStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SubscriptionStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SubscriptionStatus value) => value.Value;

    public static explicit operator SubscriptionStatus(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string Pending = "PENDING";

        public const string Active = "ACTIVE";

        public const string Canceled = "CANCELED";

        public const string Deactivated = "DEACTIVATED";

        public const string Paused = "PAUSED";
    }
}
