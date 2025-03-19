using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<MeasurementUnitArea>))]
public readonly record struct MeasurementUnitArea : IStringEnum
{
    public static readonly MeasurementUnitArea ImperialAcre = new(Values.ImperialAcre);

    public static readonly MeasurementUnitArea ImperialSquareInch = new(Values.ImperialSquareInch);

    public static readonly MeasurementUnitArea ImperialSquareFoot = new(Values.ImperialSquareFoot);

    public static readonly MeasurementUnitArea ImperialSquareYard = new(Values.ImperialSquareYard);

    public static readonly MeasurementUnitArea ImperialSquareMile = new(Values.ImperialSquareMile);

    public static readonly MeasurementUnitArea MetricSquareCentimeter = new(
        Values.MetricSquareCentimeter
    );

    public static readonly MeasurementUnitArea MetricSquareMeter = new(Values.MetricSquareMeter);

    public static readonly MeasurementUnitArea MetricSquareKilometer = new(
        Values.MetricSquareKilometer
    );

    public MeasurementUnitArea(string value)
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
    public static MeasurementUnitArea FromCustom(string value)
    {
        return new MeasurementUnitArea(value);
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

    public static bool operator ==(MeasurementUnitArea value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(MeasurementUnitArea value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(MeasurementUnitArea value) => value.Value;

    public static explicit operator MeasurementUnitArea(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string ImperialAcre = "IMPERIAL_ACRE";

        public const string ImperialSquareInch = "IMPERIAL_SQUARE_INCH";

        public const string ImperialSquareFoot = "IMPERIAL_SQUARE_FOOT";

        public const string ImperialSquareYard = "IMPERIAL_SQUARE_YARD";

        public const string ImperialSquareMile = "IMPERIAL_SQUARE_MILE";

        public const string MetricSquareCentimeter = "METRIC_SQUARE_CENTIMETER";

        public const string MetricSquareMeter = "METRIC_SQUARE_METER";

        public const string MetricSquareKilometer = "METRIC_SQUARE_KILOMETER";
    }
}
