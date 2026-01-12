using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[JsonConverter(typeof(StringEnumSerializer<OrderServiceChargeType>))]
[Serializable]
public readonly record struct OrderServiceChargeType : IStringEnum
{
    public static readonly OrderServiceChargeType AutoGratuity = new(Values.AutoGratuity);

    public static readonly OrderServiceChargeType Custom = new(Values.Custom);

    public OrderServiceChargeType(string value)
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
    public static OrderServiceChargeType FromCustom(string value)
    {
        return new OrderServiceChargeType(value);
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

    public static bool operator ==(OrderServiceChargeType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(OrderServiceChargeType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(OrderServiceChargeType value) => value.Value;

    public static explicit operator OrderServiceChargeType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string AutoGratuity = "AUTO_GRATUITY";

        public const string Custom = "CUSTOM";
    }
}
