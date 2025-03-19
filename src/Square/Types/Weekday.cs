using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<Weekday>))]
public readonly record struct Weekday : IStringEnum
{
    public static readonly Weekday Mon = new(Values.Mon);

    public static readonly Weekday Tue = new(Values.Tue);

    public static readonly Weekday Wed = new(Values.Wed);

    public static readonly Weekday Thu = new(Values.Thu);

    public static readonly Weekday Fri = new(Values.Fri);

    public static readonly Weekday Sat = new(Values.Sat);

    public static readonly Weekday Sun = new(Values.Sun);

    public Weekday(string value)
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
    public static Weekday FromCustom(string value)
    {
        return new Weekday(value);
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

    public static bool operator ==(Weekday value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(Weekday value1, string value2) => !value1.Value.Equals(value2);

    public static explicit operator string(Weekday value) => value.Value;

    public static explicit operator Weekday(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string Mon = "MON";

        public const string Tue = "TUE";

        public const string Wed = "WED";

        public const string Thu = "THU";

        public const string Fri = "FRI";

        public const string Sat = "SAT";

        public const string Sun = "SUN";
    }
}
