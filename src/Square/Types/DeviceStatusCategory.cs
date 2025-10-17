using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<DeviceStatusCategory>))]
[Serializable]
public readonly record struct DeviceStatusCategory : IStringEnum
{
    public static readonly DeviceStatusCategory Available = new(Values.Available);

    public static readonly DeviceStatusCategory NeedsAttention = new(Values.NeedsAttention);

    public static readonly DeviceStatusCategory Offline = new(Values.Offline);

    public DeviceStatusCategory(string value)
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
    public static DeviceStatusCategory FromCustom(string value)
    {
        return new DeviceStatusCategory(value);
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

    public static bool operator ==(DeviceStatusCategory value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DeviceStatusCategory value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DeviceStatusCategory value) => value.Value;

    public static explicit operator DeviceStatusCategory(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Available = "AVAILABLE";

        public const string NeedsAttention = "NEEDS_ATTENTION";

        public const string Offline = "OFFLINE";
    }
}
