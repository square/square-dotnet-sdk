using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<OrderFulfillmentFulfillmentLineItemApplication>))]
public readonly record struct OrderFulfillmentFulfillmentLineItemApplication : IStringEnum
{
    public static readonly OrderFulfillmentFulfillmentLineItemApplication All = new(Values.All);

    public static readonly OrderFulfillmentFulfillmentLineItemApplication EntryList = new(
        Values.EntryList
    );

    public OrderFulfillmentFulfillmentLineItemApplication(string value)
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
    public static OrderFulfillmentFulfillmentLineItemApplication FromCustom(string value)
    {
        return new OrderFulfillmentFulfillmentLineItemApplication(value);
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
        OrderFulfillmentFulfillmentLineItemApplication value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        OrderFulfillmentFulfillmentLineItemApplication value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(OrderFulfillmentFulfillmentLineItemApplication value) =>
        value.Value;

    public static explicit operator OrderFulfillmentFulfillmentLineItemApplication(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string All = "ALL";

        public const string EntryList = "ENTRY_LIST";
    }
}
