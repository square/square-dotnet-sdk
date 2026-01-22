using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[JsonConverter(typeof(StringEnumSerializer<ChannelStatus>))]
[Serializable]
public readonly record struct ChannelStatus : IStringEnum
{
    public static readonly ChannelStatus Active = new(Values.Active);

    public static readonly ChannelStatus Inactive = new(Values.Inactive);

    public ChannelStatus(string value)
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
    public static ChannelStatus FromCustom(string value)
    {
        return new ChannelStatus(value);
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

    public static bool operator ==(ChannelStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ChannelStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ChannelStatus value) => value.Value;

    public static explicit operator ChannelStatus(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Active = "ACTIVE";

        public const string Inactive = "INACTIVE";
    }
}
