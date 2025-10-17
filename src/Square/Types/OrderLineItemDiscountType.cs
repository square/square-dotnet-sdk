using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<OrderLineItemDiscountType>))]
[Serializable]
public readonly record struct OrderLineItemDiscountType : IStringEnum
{
    public static readonly OrderLineItemDiscountType UnknownDiscount = new(Values.UnknownDiscount);

    public static readonly OrderLineItemDiscountType FixedPercentage = new(Values.FixedPercentage);

    public static readonly OrderLineItemDiscountType FixedAmount = new(Values.FixedAmount);

    public static readonly OrderLineItemDiscountType VariablePercentage = new(
        Values.VariablePercentage
    );

    public static readonly OrderLineItemDiscountType VariableAmount = new(Values.VariableAmount);

    public OrderLineItemDiscountType(string value)
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
    public static OrderLineItemDiscountType FromCustom(string value)
    {
        return new OrderLineItemDiscountType(value);
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

    public static bool operator ==(OrderLineItemDiscountType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(OrderLineItemDiscountType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(OrderLineItemDiscountType value) => value.Value;

    public static explicit operator OrderLineItemDiscountType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string UnknownDiscount = "UNKNOWN_DISCOUNT";

        public const string FixedPercentage = "FIXED_PERCENTAGE";

        public const string FixedAmount = "FIXED_AMOUNT";

        public const string VariablePercentage = "VARIABLE_PERCENTAGE";

        public const string VariableAmount = "VARIABLE_AMOUNT";
    }
}
