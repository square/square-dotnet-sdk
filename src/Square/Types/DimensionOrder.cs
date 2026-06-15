using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<DimensionOrder>))]
[Serializable]
public readonly record struct DimensionOrder : IStringEnum
{
    public static readonly DimensionOrder Asc = new(Values.Asc);

    public static readonly DimensionOrder Desc = new(Values.Desc);

    public DimensionOrder(string value)
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
    public static DimensionOrder FromCustom(string value)
    {
        return new DimensionOrder(value);
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

    public static bool operator ==(DimensionOrder value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DimensionOrder value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DimensionOrder value) => value.Value;

    public static explicit operator DimensionOrder(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Asc = "asc";

        public const string Desc = "desc";
    }
}
