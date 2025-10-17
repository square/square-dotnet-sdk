using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<CatalogQuickAmountType>))]
[Serializable]
public readonly record struct CatalogQuickAmountType : IStringEnum
{
    public static readonly CatalogQuickAmountType QuickAmountTypeManual = new(
        Values.QuickAmountTypeManual
    );

    public static readonly CatalogQuickAmountType QuickAmountTypeAuto = new(
        Values.QuickAmountTypeAuto
    );

    public CatalogQuickAmountType(string value)
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
    public static CatalogQuickAmountType FromCustom(string value)
    {
        return new CatalogQuickAmountType(value);
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

    public static bool operator ==(CatalogQuickAmountType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CatalogQuickAmountType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CatalogQuickAmountType value) => value.Value;

    public static explicit operator CatalogQuickAmountType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string QuickAmountTypeManual = "QUICK_AMOUNT_TYPE_MANUAL";

        public const string QuickAmountTypeAuto = "QUICK_AMOUNT_TYPE_AUTO";
    }
}
