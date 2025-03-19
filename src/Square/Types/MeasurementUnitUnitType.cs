using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<MeasurementUnitUnitType>))]
public readonly record struct MeasurementUnitUnitType : IStringEnum
{
    public static readonly MeasurementUnitUnitType TypeCustom = new(Values.TypeCustom);

    public static readonly MeasurementUnitUnitType TypeArea = new(Values.TypeArea);

    public static readonly MeasurementUnitUnitType TypeLength = new(Values.TypeLength);

    public static readonly MeasurementUnitUnitType TypeVolume = new(Values.TypeVolume);

    public static readonly MeasurementUnitUnitType TypeWeight = new(Values.TypeWeight);

    public static readonly MeasurementUnitUnitType TypeGeneric = new(Values.TypeGeneric);

    public MeasurementUnitUnitType(string value)
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
    public static MeasurementUnitUnitType FromCustom(string value)
    {
        return new MeasurementUnitUnitType(value);
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

    public static bool operator ==(MeasurementUnitUnitType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(MeasurementUnitUnitType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(MeasurementUnitUnitType value) => value.Value;

    public static explicit operator MeasurementUnitUnitType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string TypeCustom = "TYPE_CUSTOM";

        public const string TypeArea = "TYPE_AREA";

        public const string TypeLength = "TYPE_LENGTH";

        public const string TypeVolume = "TYPE_VOLUME";

        public const string TypeWeight = "TYPE_WEIGHT";

        public const string TypeGeneric = "TYPE_GENERIC";
    }
}
