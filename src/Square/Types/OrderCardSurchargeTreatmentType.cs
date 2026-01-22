using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<OrderCardSurchargeTreatmentType>))]
[Serializable]
public readonly record struct OrderCardSurchargeTreatmentType : IStringEnum
{
    public static readonly OrderCardSurchargeTreatmentType LineItemTreatment = new(
        Values.LineItemTreatment
    );

    public static readonly OrderCardSurchargeTreatmentType ApportionedTreatment = new(
        Values.ApportionedTreatment
    );

    public OrderCardSurchargeTreatmentType(string value)
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
    public static OrderCardSurchargeTreatmentType FromCustom(string value)
    {
        return new OrderCardSurchargeTreatmentType(value);
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

    public static bool operator ==(OrderCardSurchargeTreatmentType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(OrderCardSurchargeTreatmentType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(OrderCardSurchargeTreatmentType value) => value.Value;

    public static explicit operator OrderCardSurchargeTreatmentType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string LineItemTreatment = "LINE_ITEM_TREATMENT";

        public const string ApportionedTreatment = "APPORTIONED_TREATMENT";
    }
}
