using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<EcomVisibility>))]
public readonly record struct EcomVisibility : IStringEnum
{
    public static readonly EcomVisibility Unindexed = new(Values.Unindexed);

    public static readonly EcomVisibility Unavailable = new(Values.Unavailable);

    public static readonly EcomVisibility Hidden = new(Values.Hidden);

    public static readonly EcomVisibility Visible = new(Values.Visible);

    public EcomVisibility(string value)
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
    public static EcomVisibility FromCustom(string value)
    {
        return new EcomVisibility(value);
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

    public static bool operator ==(EcomVisibility value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(EcomVisibility value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(EcomVisibility value) => value.Value;

    public static explicit operator EcomVisibility(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string Unindexed = "UNINDEXED";

        public const string Unavailable = "UNAVAILABLE";

        public const string Hidden = "HIDDEN";

        public const string Visible = "VISIBLE";
    }
}
