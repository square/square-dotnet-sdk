using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<OrderLineItemTaxType>))]
[Serializable]
public readonly record struct OrderLineItemTaxType : IStringEnum
{
    public static readonly OrderLineItemTaxType UnknownTax = new(Values.UnknownTax);

    public static readonly OrderLineItemTaxType Additive = new(Values.Additive);

    public static readonly OrderLineItemTaxType Inclusive = new(Values.Inclusive);

    public OrderLineItemTaxType(string value)
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
    public static OrderLineItemTaxType FromCustom(string value)
    {
        return new OrderLineItemTaxType(value);
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

    public static bool operator ==(OrderLineItemTaxType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(OrderLineItemTaxType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(OrderLineItemTaxType value) => value.Value;

    public static explicit operator OrderLineItemTaxType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string UnknownTax = "UNKNOWN_TAX";

        public const string Additive = "ADDITIVE";

        public const string Inclusive = "INCLUSIVE";
    }
}
