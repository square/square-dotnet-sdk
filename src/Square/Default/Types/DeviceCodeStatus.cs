using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[JsonConverter(typeof(StringEnumSerializer<DeviceCodeStatus>))]
[Serializable]
public readonly record struct DeviceCodeStatus : IStringEnum
{
    public static readonly DeviceCodeStatus Unknown = new(Values.Unknown);

    public static readonly DeviceCodeStatus Unpaired = new(Values.Unpaired);

    public static readonly DeviceCodeStatus Paired = new(Values.Paired);

    public static readonly DeviceCodeStatus Expired = new(Values.Expired);

    public DeviceCodeStatus(string value)
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
    public static DeviceCodeStatus FromCustom(string value)
    {
        return new DeviceCodeStatus(value);
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

    public static bool operator ==(DeviceCodeStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DeviceCodeStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DeviceCodeStatus value) => value.Value;

    public static explicit operator DeviceCodeStatus(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Unknown = "UNKNOWN";

        public const string Unpaired = "UNPAIRED";

        public const string Paired = "PAIRED";

        public const string Expired = "EXPIRED";
    }
}
