using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<FulfillmentPickupDetailsScheduleType>))]
[Serializable]
public readonly record struct FulfillmentPickupDetailsScheduleType : IStringEnum
{
    public static readonly FulfillmentPickupDetailsScheduleType Scheduled = new(Values.Scheduled);

    public static readonly FulfillmentPickupDetailsScheduleType Asap = new(Values.Asap);

    public FulfillmentPickupDetailsScheduleType(string value)
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
    public static FulfillmentPickupDetailsScheduleType FromCustom(string value)
    {
        return new FulfillmentPickupDetailsScheduleType(value);
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

    public static bool operator ==(FulfillmentPickupDetailsScheduleType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FulfillmentPickupDetailsScheduleType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FulfillmentPickupDetailsScheduleType value) =>
        value.Value;

    public static explicit operator FulfillmentPickupDetailsScheduleType(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Scheduled = "SCHEDULED";

        public const string Asap = "ASAP";
    }
}
