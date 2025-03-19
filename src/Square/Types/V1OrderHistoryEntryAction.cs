using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<V1OrderHistoryEntryAction>))]
public readonly record struct V1OrderHistoryEntryAction : IStringEnum
{
    public static readonly V1OrderHistoryEntryAction OrderPlaced = new(Values.OrderPlaced);

    public static readonly V1OrderHistoryEntryAction Declined = new(Values.Declined);

    public static readonly V1OrderHistoryEntryAction PaymentReceived = new(Values.PaymentReceived);

    public static readonly V1OrderHistoryEntryAction Canceled = new(Values.Canceled);

    public static readonly V1OrderHistoryEntryAction Completed = new(Values.Completed);

    public static readonly V1OrderHistoryEntryAction Refunded = new(Values.Refunded);

    public static readonly V1OrderHistoryEntryAction Expired = new(Values.Expired);

    public V1OrderHistoryEntryAction(string value)
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
    public static V1OrderHistoryEntryAction FromCustom(string value)
    {
        return new V1OrderHistoryEntryAction(value);
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

    public static bool operator ==(V1OrderHistoryEntryAction value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(V1OrderHistoryEntryAction value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(V1OrderHistoryEntryAction value) => value.Value;

    public static explicit operator V1OrderHistoryEntryAction(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string OrderPlaced = "ORDER_PLACED";

        public const string Declined = "DECLINED";

        public const string PaymentReceived = "PAYMENT_RECEIVED";

        public const string Canceled = "CANCELED";

        public const string Completed = "COMPLETED";

        public const string Refunded = "REFUNDED";

        public const string Expired = "EXPIRED";
    }
}
