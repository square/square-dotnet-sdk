using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[JsonConverter(typeof(StringEnumSerializer<OrderFulfillmentDeliveryDetailsScheduleType>))]
[Serializable]
public readonly record struct OrderFulfillmentDeliveryDetailsScheduleType : IStringEnum
{
    public static readonly OrderFulfillmentDeliveryDetailsScheduleType Scheduled = new(
        Values.Scheduled
    );

    public static readonly OrderFulfillmentDeliveryDetailsScheduleType Asap = new(Values.Asap);

    public OrderFulfillmentDeliveryDetailsScheduleType(string value)
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
    public static OrderFulfillmentDeliveryDetailsScheduleType FromCustom(string value)
    {
        return new OrderFulfillmentDeliveryDetailsScheduleType(value);
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
        OrderFulfillmentDeliveryDetailsScheduleType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        OrderFulfillmentDeliveryDetailsScheduleType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(OrderFulfillmentDeliveryDetailsScheduleType value) =>
        value.Value;

    public static explicit operator OrderFulfillmentDeliveryDetailsScheduleType(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Scheduled = "SCHEDULED";

        public const string Asap = "ASAP";
    }
}
