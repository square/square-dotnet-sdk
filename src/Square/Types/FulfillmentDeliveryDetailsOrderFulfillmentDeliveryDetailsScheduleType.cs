using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(
    typeof(StringEnumSerializer<FulfillmentDeliveryDetailsOrderFulfillmentDeliveryDetailsScheduleType>)
)]
public readonly record struct FulfillmentDeliveryDetailsOrderFulfillmentDeliveryDetailsScheduleType
    : IStringEnum
{
    public static readonly FulfillmentDeliveryDetailsOrderFulfillmentDeliveryDetailsScheduleType Scheduled =
        new(Values.Scheduled);

    public static readonly FulfillmentDeliveryDetailsOrderFulfillmentDeliveryDetailsScheduleType Asap =
        new(Values.Asap);

    public FulfillmentDeliveryDetailsOrderFulfillmentDeliveryDetailsScheduleType(string value)
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
    public static FulfillmentDeliveryDetailsOrderFulfillmentDeliveryDetailsScheduleType FromCustom(
        string value
    )
    {
        return new FulfillmentDeliveryDetailsOrderFulfillmentDeliveryDetailsScheduleType(value);
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
        FulfillmentDeliveryDetailsOrderFulfillmentDeliveryDetailsScheduleType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        FulfillmentDeliveryDetailsOrderFulfillmentDeliveryDetailsScheduleType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        FulfillmentDeliveryDetailsOrderFulfillmentDeliveryDetailsScheduleType value
    ) => value.Value;

    public static explicit operator FulfillmentDeliveryDetailsOrderFulfillmentDeliveryDetailsScheduleType(
        string value
    ) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string Scheduled = "SCHEDULED";

        public const string Asap = "ASAP";
    }
}
