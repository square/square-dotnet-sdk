using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<SimpleFormat>))]
[Serializable]
public readonly record struct SimpleFormat : IStringEnum
{
    public static readonly SimpleFormat Percent = new(Values.Percent);

    public static readonly SimpleFormat Currency = new(Values.Currency);

    public static readonly SimpleFormat Number = new(Values.Number);

    public static readonly SimpleFormat ImageUrl = new(Values.ImageUrl);

    public static readonly SimpleFormat Id = new(Values.Id);

    public static readonly SimpleFormat Link = new(Values.Link);

    public SimpleFormat(string value)
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
    public static SimpleFormat FromCustom(string value)
    {
        return new SimpleFormat(value);
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

    public static bool operator ==(SimpleFormat value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SimpleFormat value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SimpleFormat value) => value.Value;

    public static explicit operator SimpleFormat(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Percent = "percent";

        public const string Currency = "currency";

        public const string Number = "number";

        public const string ImageUrl = "imageUrl";

        public const string Id = "id";

        public const string Link = "link";
    }
}
