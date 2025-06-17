using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<OrderFulfillmentType>))]
public readonly record struct OrderFulfillmentType : IStringEnum
{
    public static readonly OrderFulfillmentType Pickup = new(Values.Pickup);

    public static readonly OrderFulfillmentType Shipment = new(Values.Shipment);

    public static readonly OrderFulfillmentType Delivery = new(Values.Delivery);

    public OrderFulfillmentType(string value)
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
    public static OrderFulfillmentType FromCustom(string value)
    {
        return new OrderFulfillmentType(value);
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

    public static bool operator ==(OrderFulfillmentType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(OrderFulfillmentType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(OrderFulfillmentType value) => value.Value;

    public static explicit operator OrderFulfillmentType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string Pickup = "PICKUP";

        public const string Shipment = "SHIPMENT";

        public const string Delivery = "DELIVERY";
    }
}
