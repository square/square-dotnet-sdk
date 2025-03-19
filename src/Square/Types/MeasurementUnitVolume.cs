using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<MeasurementUnitVolume>))]
public readonly record struct MeasurementUnitVolume : IStringEnum
{
    public static readonly MeasurementUnitVolume GenericFluidOunce = new(Values.GenericFluidOunce);

    public static readonly MeasurementUnitVolume GenericShot = new(Values.GenericShot);

    public static readonly MeasurementUnitVolume GenericCup = new(Values.GenericCup);

    public static readonly MeasurementUnitVolume GenericPint = new(Values.GenericPint);

    public static readonly MeasurementUnitVolume GenericQuart = new(Values.GenericQuart);

    public static readonly MeasurementUnitVolume GenericGallon = new(Values.GenericGallon);

    public static readonly MeasurementUnitVolume ImperialCubicInch = new(Values.ImperialCubicInch);

    public static readonly MeasurementUnitVolume ImperialCubicFoot = new(Values.ImperialCubicFoot);

    public static readonly MeasurementUnitVolume ImperialCubicYard = new(Values.ImperialCubicYard);

    public static readonly MeasurementUnitVolume MetricMilliliter = new(Values.MetricMilliliter);

    public static readonly MeasurementUnitVolume MetricLiter = new(Values.MetricLiter);

    public MeasurementUnitVolume(string value)
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
    public static MeasurementUnitVolume FromCustom(string value)
    {
        return new MeasurementUnitVolume(value);
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

    public static bool operator ==(MeasurementUnitVolume value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(MeasurementUnitVolume value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(MeasurementUnitVolume value) => value.Value;

    public static explicit operator MeasurementUnitVolume(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string GenericFluidOunce = "GENERIC_FLUID_OUNCE";

        public const string GenericShot = "GENERIC_SHOT";

        public const string GenericCup = "GENERIC_CUP";

        public const string GenericPint = "GENERIC_PINT";

        public const string GenericQuart = "GENERIC_QUART";

        public const string GenericGallon = "GENERIC_GALLON";

        public const string ImperialCubicInch = "IMPERIAL_CUBIC_INCH";

        public const string ImperialCubicFoot = "IMPERIAL_CUBIC_FOOT";

        public const string ImperialCubicYard = "IMPERIAL_CUBIC_YARD";

        public const string MetricMilliliter = "METRIC_MILLILITER";

        public const string MetricLiter = "METRIC_LITER";
    }
}
