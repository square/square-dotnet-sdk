using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[JsonConverter(typeof(StringEnumSerializer<OrderServiceChargeScope>))]
[Serializable]
public readonly record struct OrderServiceChargeScope : IStringEnum
{
    public static readonly OrderServiceChargeScope OtherServiceChargeScope = new(
        Values.OtherServiceChargeScope
    );

    public static readonly OrderServiceChargeScope LineItem = new(Values.LineItem);

    public static readonly OrderServiceChargeScope Order = new(Values.Order);

    public OrderServiceChargeScope(string value)
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
    public static OrderServiceChargeScope FromCustom(string value)
    {
        return new OrderServiceChargeScope(value);
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

    public static bool operator ==(OrderServiceChargeScope value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(OrderServiceChargeScope value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(OrderServiceChargeScope value) => value.Value;

    public static explicit operator OrderServiceChargeScope(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string OtherServiceChargeScope = "OTHER_SERVICE_CHARGE_SCOPE";

        public const string LineItem = "LINE_ITEM";

        public const string Order = "ORDER";
    }
}
