using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<CubeType>))]
[Serializable]
public readonly record struct CubeType : IStringEnum
{
    public static readonly CubeType Cube = new(Values.Cube);

    public static readonly CubeType View = new(Values.View);

    public CubeType(string value)
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
    public static CubeType FromCustom(string value)
    {
        return new CubeType(value);
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

    public static bool operator ==(CubeType value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(CubeType value1, string value2) => !value1.Value.Equals(value2);

    public static explicit operator string(CubeType value) => value.Value;

    public static explicit operator CubeType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Cube = "cube";

        public const string View = "view";
    }
}
