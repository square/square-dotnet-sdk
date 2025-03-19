using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<LocationType>))]
public readonly record struct LocationType : IStringEnum
{
    public static readonly LocationType Physical = new(Values.Physical);

    public static readonly LocationType Mobile = new(Values.Mobile);

    public LocationType(string value)
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
    public static LocationType FromCustom(string value)
    {
        return new LocationType(value);
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

    public static bool operator ==(LocationType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(LocationType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(LocationType value) => value.Value;

    public static explicit operator LocationType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string Physical = "PHYSICAL";

        public const string Mobile = "MOBILE";
    }
}
