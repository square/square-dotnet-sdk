using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<OrderState>))]
public readonly record struct OrderState : IStringEnum
{
    public static readonly OrderState Open = new(Values.Open);

    public static readonly OrderState Completed = new(Values.Completed);

    public static readonly OrderState Canceled = new(Values.Canceled);

    public static readonly OrderState Draft = new(Values.Draft);

    public OrderState(string value)
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
    public static OrderState FromCustom(string value)
    {
        return new OrderState(value);
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

    public static bool operator ==(OrderState value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(OrderState value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(OrderState value) => value.Value;

    public static explicit operator OrderState(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string Open = "OPEN";

        public const string Completed = "COMPLETED";

        public const string Canceled = "CANCELED";

        public const string Draft = "DRAFT";
    }
}
