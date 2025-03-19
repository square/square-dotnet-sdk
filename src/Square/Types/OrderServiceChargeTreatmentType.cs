using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<OrderServiceChargeTreatmentType>))]
public readonly record struct OrderServiceChargeTreatmentType : IStringEnum
{
    public static readonly OrderServiceChargeTreatmentType LineItemTreatment = new(
        Values.LineItemTreatment
    );

    public static readonly OrderServiceChargeTreatmentType ApportionedTreatment = new(
        Values.ApportionedTreatment
    );

    public OrderServiceChargeTreatmentType(string value)
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
    public static OrderServiceChargeTreatmentType FromCustom(string value)
    {
        return new OrderServiceChargeTreatmentType(value);
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

    public static bool operator ==(OrderServiceChargeTreatmentType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(OrderServiceChargeTreatmentType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(OrderServiceChargeTreatmentType value) => value.Value;

    public static explicit operator OrderServiceChargeTreatmentType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string LineItemTreatment = "LINE_ITEM_TREATMENT";

        public const string ApportionedTreatment = "APPORTIONED_TREATMENT";
    }
}
