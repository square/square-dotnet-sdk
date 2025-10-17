using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<OrderLineItemItemType>))]
[Serializable]
public readonly record struct OrderLineItemItemType : IStringEnum
{
    public static readonly OrderLineItemItemType Item = new(Values.Item);

    public static readonly OrderLineItemItemType CustomAmount = new(Values.CustomAmount);

    public static readonly OrderLineItemItemType GiftCard = new(Values.GiftCard);

    public OrderLineItemItemType(string value)
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
    public static OrderLineItemItemType FromCustom(string value)
    {
        return new OrderLineItemItemType(value);
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

    public static bool operator ==(OrderLineItemItemType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(OrderLineItemItemType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(OrderLineItemItemType value) => value.Value;

    public static explicit operator OrderLineItemItemType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Item = "ITEM";

        public const string CustomAmount = "CUSTOM_AMOUNT";

        public const string GiftCard = "GIFT_CARD";
    }
}
