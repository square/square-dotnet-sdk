using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<OrderFulfillmentState>))]
[Serializable]
public readonly record struct OrderFulfillmentState : IStringEnum
{
    public static readonly OrderFulfillmentState Proposed = new(Values.Proposed);

    public static readonly OrderFulfillmentState Reserved = new(Values.Reserved);

    public static readonly OrderFulfillmentState Prepared = new(Values.Prepared);

    public static readonly OrderFulfillmentState Completed = new(Values.Completed);

    public static readonly OrderFulfillmentState Canceled = new(Values.Canceled);

    public static readonly OrderFulfillmentState Failed = new(Values.Failed);

    public OrderFulfillmentState(string value)
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
    public static OrderFulfillmentState FromCustom(string value)
    {
        return new OrderFulfillmentState(value);
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

    public static bool operator ==(OrderFulfillmentState value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(OrderFulfillmentState value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(OrderFulfillmentState value) => value.Value;

    public static explicit operator OrderFulfillmentState(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Proposed = "PROPOSED";

        public const string Reserved = "RESERVED";

        public const string Prepared = "PREPARED";

        public const string Completed = "COMPLETED";

        public const string Canceled = "CANCELED";

        public const string Failed = "FAILED";
    }
}
