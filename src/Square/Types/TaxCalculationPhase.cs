using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<TaxCalculationPhase>))]
public readonly record struct TaxCalculationPhase : IStringEnum
{
    public static readonly TaxCalculationPhase TaxSubtotalPhase = new(Values.TaxSubtotalPhase);

    public static readonly TaxCalculationPhase TaxTotalPhase = new(Values.TaxTotalPhase);

    public TaxCalculationPhase(string value)
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
    public static TaxCalculationPhase FromCustom(string value)
    {
        return new TaxCalculationPhase(value);
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

    public static bool operator ==(TaxCalculationPhase value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TaxCalculationPhase value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TaxCalculationPhase value) => value.Value;

    public static explicit operator TaxCalculationPhase(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string TaxSubtotalPhase = "TAX_SUBTOTAL_PHASE";

        public const string TaxTotalPhase = "TAX_TOTAL_PHASE";
    }
}
