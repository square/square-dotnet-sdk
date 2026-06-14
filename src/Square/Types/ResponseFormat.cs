using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<ResponseFormat>))]
[Serializable]
public readonly record struct ResponseFormat : IStringEnum
{
    public static readonly ResponseFormat Default = new(Values.Default);

    public static readonly ResponseFormat Compact = new(Values.Compact);

    public static readonly ResponseFormat Columnar = new(Values.Columnar);

    public ResponseFormat(string value)
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
    public static ResponseFormat FromCustom(string value)
    {
        return new ResponseFormat(value);
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

    public static bool operator ==(ResponseFormat value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ResponseFormat value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ResponseFormat value) => value.Value;

    public static explicit operator ResponseFormat(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Default = "default";

        public const string Compact = "compact";

        public const string Columnar = "columnar";
    }
}
