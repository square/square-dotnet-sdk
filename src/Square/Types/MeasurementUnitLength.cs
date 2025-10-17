using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<MeasurementUnitLength>))]
[Serializable]
public readonly record struct MeasurementUnitLength : IStringEnum
{
    public static readonly MeasurementUnitLength ImperialInch = new(Values.ImperialInch);

    public static readonly MeasurementUnitLength ImperialFoot = new(Values.ImperialFoot);

    public static readonly MeasurementUnitLength ImperialYard = new(Values.ImperialYard);

    public static readonly MeasurementUnitLength ImperialMile = new(Values.ImperialMile);

    public static readonly MeasurementUnitLength MetricMillimeter = new(Values.MetricMillimeter);

    public static readonly MeasurementUnitLength MetricCentimeter = new(Values.MetricCentimeter);

    public static readonly MeasurementUnitLength MetricMeter = new(Values.MetricMeter);

    public static readonly MeasurementUnitLength MetricKilometer = new(Values.MetricKilometer);

    public MeasurementUnitLength(string value)
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
    public static MeasurementUnitLength FromCustom(string value)
    {
        return new MeasurementUnitLength(value);
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

    public static bool operator ==(MeasurementUnitLength value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(MeasurementUnitLength value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(MeasurementUnitLength value) => value.Value;

    public static explicit operator MeasurementUnitLength(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string ImperialInch = "IMPERIAL_INCH";

        public const string ImperialFoot = "IMPERIAL_FOOT";

        public const string ImperialYard = "IMPERIAL_YARD";

        public const string ImperialMile = "IMPERIAL_MILE";

        public const string MetricMillimeter = "METRIC_MILLIMETER";

        public const string MetricCentimeter = "METRIC_CENTIMETER";

        public const string MetricMeter = "METRIC_METER";

        public const string MetricKilometer = "METRIC_KILOMETER";
    }
}
