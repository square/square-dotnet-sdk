using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<OrderLineItemTaxScope>))]
public readonly record struct OrderLineItemTaxScope : IStringEnum
{
    public static readonly OrderLineItemTaxScope OtherTaxScope = new(Values.OtherTaxScope);

    public static readonly OrderLineItemTaxScope LineItem = new(Values.LineItem);

    public static readonly OrderLineItemTaxScope Order = new(Values.Order);

    public OrderLineItemTaxScope(string value)
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
    public static OrderLineItemTaxScope FromCustom(string value)
    {
        return new OrderLineItemTaxScope(value);
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

    public static bool operator ==(OrderLineItemTaxScope value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(OrderLineItemTaxScope value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(OrderLineItemTaxScope value) => value.Value;

    public static explicit operator OrderLineItemTaxScope(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string OtherTaxScope = "OTHER_TAX_SCOPE";

        public const string LineItem = "LINE_ITEM";

        public const string Order = "ORDER";
    }
}
