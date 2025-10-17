using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<V1UpdateOrderRequestAction>))]
[Serializable]
public readonly record struct V1UpdateOrderRequestAction : IStringEnum
{
    public static readonly V1UpdateOrderRequestAction Complete = new(Values.Complete);

    public static readonly V1UpdateOrderRequestAction Cancel = new(Values.Cancel);

    public static readonly V1UpdateOrderRequestAction Refund = new(Values.Refund);

    public V1UpdateOrderRequestAction(string value)
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
    public static V1UpdateOrderRequestAction FromCustom(string value)
    {
        return new V1UpdateOrderRequestAction(value);
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

    public static bool operator ==(V1UpdateOrderRequestAction value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(V1UpdateOrderRequestAction value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(V1UpdateOrderRequestAction value) => value.Value;

    public static explicit operator V1UpdateOrderRequestAction(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Complete = "COMPLETE";

        public const string Cancel = "CANCEL";

        public const string Refund = "REFUND";
    }
}
