using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[JsonConverter(typeof(StringEnumSerializer<MeasurementUnitWeight>))]
[Serializable]
public readonly record struct MeasurementUnitWeight : IStringEnum
{
    public static readonly MeasurementUnitWeight ImperialWeightOunce = new(
        Values.ImperialWeightOunce
    );

    public static readonly MeasurementUnitWeight ImperialPound = new(Values.ImperialPound);

    public static readonly MeasurementUnitWeight ImperialStone = new(Values.ImperialStone);

    public static readonly MeasurementUnitWeight MetricMilligram = new(Values.MetricMilligram);

    public static readonly MeasurementUnitWeight MetricGram = new(Values.MetricGram);

    public static readonly MeasurementUnitWeight MetricKilogram = new(Values.MetricKilogram);

    public MeasurementUnitWeight(string value)
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
    public static MeasurementUnitWeight FromCustom(string value)
    {
        return new MeasurementUnitWeight(value);
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

    public static bool operator ==(MeasurementUnitWeight value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(MeasurementUnitWeight value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(MeasurementUnitWeight value) => value.Value;

    public static explicit operator MeasurementUnitWeight(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string ImperialWeightOunce = "IMPERIAL_WEIGHT_OUNCE";

        public const string ImperialPound = "IMPERIAL_POUND";

        public const string ImperialStone = "IMPERIAL_STONE";

        public const string MetricMilligram = "METRIC_MILLIGRAM";

        public const string MetricGram = "METRIC_GRAM";

        public const string MetricKilogram = "METRIC_KILOGRAM";
    }
}
