using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<PayoutType>))]
[Serializable]
public readonly record struct PayoutType : IStringEnum
{
    public static readonly PayoutType Batch = new(Values.Batch);

    public static readonly PayoutType Simple = new(Values.Simple);

    public PayoutType(string value)
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
    public static PayoutType FromCustom(string value)
    {
        return new PayoutType(value);
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

    public static bool operator ==(PayoutType value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(PayoutType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PayoutType value) => value.Value;

    public static explicit operator PayoutType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Batch = "BATCH";

        public const string Simple = "SIMPLE";
    }
}
