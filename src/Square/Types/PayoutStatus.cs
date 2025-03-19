using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<PayoutStatus>))]
public readonly record struct PayoutStatus : IStringEnum
{
    public static readonly PayoutStatus Sent = new(Values.Sent);

    public static readonly PayoutStatus Failed = new(Values.Failed);

    public static readonly PayoutStatus Paid = new(Values.Paid);

    public PayoutStatus(string value)
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
    public static PayoutStatus FromCustom(string value)
    {
        return new PayoutStatus(value);
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

    public static bool operator ==(PayoutStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PayoutStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PayoutStatus value) => value.Value;

    public static explicit operator PayoutStatus(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string Sent = "SENT";

        public const string Failed = "FAILED";

        public const string Paid = "PAID";
    }
}
