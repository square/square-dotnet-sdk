using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<ComponentComponentType>))]
[Serializable]
public readonly record struct ComponentComponentType : IStringEnum
{
    public static readonly ComponentComponentType Application = new(Values.Application);

    public static readonly ComponentComponentType CardReader = new(Values.CardReader);

    public static readonly ComponentComponentType Battery = new(Values.Battery);

    public static readonly ComponentComponentType Wifi = new(Values.Wifi);

    public static readonly ComponentComponentType Ethernet = new(Values.Ethernet);

    public static readonly ComponentComponentType Printer = new(Values.Printer);

    public ComponentComponentType(string value)
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
    public static ComponentComponentType FromCustom(string value)
    {
        return new ComponentComponentType(value);
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

    public static bool operator ==(ComponentComponentType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ComponentComponentType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ComponentComponentType value) => value.Value;

    public static explicit operator ComponentComponentType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Application = "APPLICATION";

        public const string CardReader = "CARD_READER";

        public const string Battery = "BATTERY";

        public const string Wifi = "WIFI";

        public const string Ethernet = "ETHERNET";

        public const string Printer = "PRINTER";
    }
}
