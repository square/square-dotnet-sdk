using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<V1OrderState>))]
[Serializable]
public readonly record struct V1OrderState : IStringEnum
{
    public static readonly V1OrderState Pending = new(Values.Pending);

    public static readonly V1OrderState Open = new(Values.Open);

    public static readonly V1OrderState Completed = new(Values.Completed);

    public static readonly V1OrderState Canceled = new(Values.Canceled);

    public static readonly V1OrderState Refunded = new(Values.Refunded);

    public static readonly V1OrderState Rejected = new(Values.Rejected);

    public V1OrderState(string value)
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
    public static V1OrderState FromCustom(string value)
    {
        return new V1OrderState(value);
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

    public static bool operator ==(V1OrderState value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(V1OrderState value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(V1OrderState value) => value.Value;

    public static explicit operator V1OrderState(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Pending = "PENDING";

        public const string Open = "OPEN";

        public const string Completed = "COMPLETED";

        public const string Canceled = "CANCELED";

        public const string Refunded = "REFUNDED";

        public const string Rejected = "REJECTED";
    }
}
