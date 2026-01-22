using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[JsonConverter(typeof(StringEnumSerializer<InventoryAlertType>))]
[Serializable]
public readonly record struct InventoryAlertType : IStringEnum
{
    public static readonly InventoryAlertType None = new(Values.None);

    public static readonly InventoryAlertType LowQuantity = new(Values.LowQuantity);

    public InventoryAlertType(string value)
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
    public static InventoryAlertType FromCustom(string value)
    {
        return new InventoryAlertType(value);
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

    public static bool operator ==(InventoryAlertType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(InventoryAlertType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(InventoryAlertType value) => value.Value;

    public static explicit operator InventoryAlertType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string None = "NONE";

        public const string LowQuantity = "LOW_QUANTITY";
    }
}
