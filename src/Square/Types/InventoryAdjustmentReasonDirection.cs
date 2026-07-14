using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<InventoryAdjustmentReasonDirection>))]
[Serializable]
public readonly record struct InventoryAdjustmentReasonDirection : IStringEnum
{
    public static readonly InventoryAdjustmentReasonDirection Increase = new(Values.Increase);

    public static readonly InventoryAdjustmentReasonDirection Decrease = new(Values.Decrease);

    public InventoryAdjustmentReasonDirection(string value)
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
    public static InventoryAdjustmentReasonDirection FromCustom(string value)
    {
        return new InventoryAdjustmentReasonDirection(value);
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

    public static bool operator ==(InventoryAdjustmentReasonDirection value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(InventoryAdjustmentReasonDirection value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(InventoryAdjustmentReasonDirection value) => value.Value;

    public static explicit operator InventoryAdjustmentReasonDirection(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Increase = "INCREASE";

        public const string Decrease = "DECREASE";
    }
}
