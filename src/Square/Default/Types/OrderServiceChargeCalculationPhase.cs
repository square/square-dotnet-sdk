using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[JsonConverter(typeof(StringEnumSerializer<OrderServiceChargeCalculationPhase>))]
[Serializable]
public readonly record struct OrderServiceChargeCalculationPhase : IStringEnum
{
    public static readonly OrderServiceChargeCalculationPhase SubtotalPhase = new(
        Values.SubtotalPhase
    );

    public static readonly OrderServiceChargeCalculationPhase TotalPhase = new(Values.TotalPhase);

    public static readonly OrderServiceChargeCalculationPhase ApportionedPercentagePhase = new(
        Values.ApportionedPercentagePhase
    );

    public static readonly OrderServiceChargeCalculationPhase ApportionedAmountPhase = new(
        Values.ApportionedAmountPhase
    );

    public OrderServiceChargeCalculationPhase(string value)
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
    public static OrderServiceChargeCalculationPhase FromCustom(string value)
    {
        return new OrderServiceChargeCalculationPhase(value);
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

    public static bool operator ==(OrderServiceChargeCalculationPhase value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(OrderServiceChargeCalculationPhase value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(OrderServiceChargeCalculationPhase value) => value.Value;

    public static explicit operator OrderServiceChargeCalculationPhase(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string SubtotalPhase = "SUBTOTAL_PHASE";

        public const string TotalPhase = "TOTAL_PHASE";

        public const string ApportionedPercentagePhase = "APPORTIONED_PERCENTAGE_PHASE";

        public const string ApportionedAmountPhase = "APPORTIONED_AMOUNT_PHASE";
    }
}
