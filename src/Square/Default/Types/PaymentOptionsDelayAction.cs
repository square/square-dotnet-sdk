using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[JsonConverter(typeof(StringEnumSerializer<PaymentOptionsDelayAction>))]
[Serializable]
public readonly record struct PaymentOptionsDelayAction : IStringEnum
{
    public static readonly PaymentOptionsDelayAction Cancel = new(Values.Cancel);

    public static readonly PaymentOptionsDelayAction Complete = new(Values.Complete);

    public PaymentOptionsDelayAction(string value)
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
    public static PaymentOptionsDelayAction FromCustom(string value)
    {
        return new PaymentOptionsDelayAction(value);
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

    public static bool operator ==(PaymentOptionsDelayAction value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PaymentOptionsDelayAction value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PaymentOptionsDelayAction value) => value.Value;

    public static explicit operator PaymentOptionsDelayAction(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Cancel = "CANCEL";

        public const string Complete = "COMPLETE";
    }
}
