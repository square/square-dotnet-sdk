using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<OrderLineItemDiscountScope>))]
[Serializable]
public readonly record struct OrderLineItemDiscountScope : IStringEnum
{
    public static readonly OrderLineItemDiscountScope OtherDiscountScope = new(
        Values.OtherDiscountScope
    );

    public static readonly OrderLineItemDiscountScope LineItem = new(Values.LineItem);

    public static readonly OrderLineItemDiscountScope Order = new(Values.Order);

    public OrderLineItemDiscountScope(string value)
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
    public static OrderLineItemDiscountScope FromCustom(string value)
    {
        return new OrderLineItemDiscountScope(value);
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

    public static bool operator ==(OrderLineItemDiscountScope value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(OrderLineItemDiscountScope value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(OrderLineItemDiscountScope value) => value.Value;

    public static explicit operator OrderLineItemDiscountScope(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string OtherDiscountScope = "OTHER_DISCOUNT_SCOPE";

        public const string LineItem = "LINE_ITEM";

        public const string Order = "ORDER";
    }
}
