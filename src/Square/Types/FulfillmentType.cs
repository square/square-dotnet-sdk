using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<FulfillmentType>))]
[Serializable]
public readonly record struct FulfillmentType : IStringEnum
{
    public static readonly FulfillmentType Pickup = new(Values.Pickup);

    public static readonly FulfillmentType Shipment = new(Values.Shipment);

    public static readonly FulfillmentType Delivery = new(Values.Delivery);

    public FulfillmentType(string value)
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
    public static FulfillmentType FromCustom(string value)
    {
        return new FulfillmentType(value);
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

    public static bool operator ==(FulfillmentType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FulfillmentType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FulfillmentType value) => value.Value;

    public static explicit operator FulfillmentType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Pickup = "PICKUP";

        public const string Shipment = "SHIPMENT";

        public const string Delivery = "DELIVERY";
    }
}
