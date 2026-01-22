using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[JsonConverter(typeof(StringEnumSerializer<DeviceAttributesDeviceType>))]
[Serializable]
public readonly record struct DeviceAttributesDeviceType : IStringEnum
{
    public static readonly DeviceAttributesDeviceType Terminal = new(Values.Terminal);

    public static readonly DeviceAttributesDeviceType Handheld = new(Values.Handheld);

    public DeviceAttributesDeviceType(string value)
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
    public static DeviceAttributesDeviceType FromCustom(string value)
    {
        return new DeviceAttributesDeviceType(value);
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

    public static bool operator ==(DeviceAttributesDeviceType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DeviceAttributesDeviceType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DeviceAttributesDeviceType value) => value.Value;

    public static explicit operator DeviceAttributesDeviceType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Terminal = "TERMINAL";

        public const string Handheld = "HANDHELD";
    }
}
