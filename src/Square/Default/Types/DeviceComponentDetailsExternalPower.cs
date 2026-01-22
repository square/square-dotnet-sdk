using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[JsonConverter(typeof(StringEnumSerializer<DeviceComponentDetailsExternalPower>))]
[Serializable]
public readonly record struct DeviceComponentDetailsExternalPower : IStringEnum
{
    public static readonly DeviceComponentDetailsExternalPower AvailableCharging = new(
        Values.AvailableCharging
    );

    public static readonly DeviceComponentDetailsExternalPower AvailableNotInUse = new(
        Values.AvailableNotInUse
    );

    public static readonly DeviceComponentDetailsExternalPower Unavailable = new(
        Values.Unavailable
    );

    public static readonly DeviceComponentDetailsExternalPower AvailableInsufficient = new(
        Values.AvailableInsufficient
    );

    public DeviceComponentDetailsExternalPower(string value)
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
    public static DeviceComponentDetailsExternalPower FromCustom(string value)
    {
        return new DeviceComponentDetailsExternalPower(value);
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

    public static bool operator ==(DeviceComponentDetailsExternalPower value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DeviceComponentDetailsExternalPower value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DeviceComponentDetailsExternalPower value) =>
        value.Value;

    public static explicit operator DeviceComponentDetailsExternalPower(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string AvailableCharging = "AVAILABLE_CHARGING";

        public const string AvailableNotInUse = "AVAILABLE_NOT_IN_USE";

        public const string Unavailable = "UNAVAILABLE";

        public const string AvailableInsufficient = "AVAILABLE_INSUFFICIENT";
    }
}
