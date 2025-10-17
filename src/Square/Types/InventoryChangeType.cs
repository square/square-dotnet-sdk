using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<InventoryChangeType>))]
[Serializable]
public readonly record struct InventoryChangeType : IStringEnum
{
    public static readonly InventoryChangeType PhysicalCount = new(Values.PhysicalCount);

    public static readonly InventoryChangeType Adjustment = new(Values.Adjustment);

    public static readonly InventoryChangeType Transfer = new(Values.Transfer);

    public InventoryChangeType(string value)
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
    public static InventoryChangeType FromCustom(string value)
    {
        return new InventoryChangeType(value);
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

    public static bool operator ==(InventoryChangeType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(InventoryChangeType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(InventoryChangeType value) => value.Value;

    public static explicit operator InventoryChangeType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string PhysicalCount = "PHYSICAL_COUNT";

        public const string Adjustment = "ADJUSTMENT";

        public const string Transfer = "TRANSFER";
    }
}
