using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<MeasurementUnitTime>))]
public readonly record struct MeasurementUnitTime : IStringEnum
{
    public static readonly MeasurementUnitTime GenericMillisecond = new(Values.GenericMillisecond);

    public static readonly MeasurementUnitTime GenericSecond = new(Values.GenericSecond);

    public static readonly MeasurementUnitTime GenericMinute = new(Values.GenericMinute);

    public static readonly MeasurementUnitTime GenericHour = new(Values.GenericHour);

    public static readonly MeasurementUnitTime GenericDay = new(Values.GenericDay);

    public MeasurementUnitTime(string value)
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
    public static MeasurementUnitTime FromCustom(string value)
    {
        return new MeasurementUnitTime(value);
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

    public static bool operator ==(MeasurementUnitTime value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(MeasurementUnitTime value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(MeasurementUnitTime value) => value.Value;

    public static explicit operator MeasurementUnitTime(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string GenericMillisecond = "GENERIC_MILLISECOND";

        public const string GenericSecond = "GENERIC_SECOND";

        public const string GenericMinute = "GENERIC_MINUTE";

        public const string GenericHour = "GENERIC_HOUR";

        public const string GenericDay = "GENERIC_DAY";
    }
}
