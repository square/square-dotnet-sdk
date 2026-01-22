using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[JsonConverter(typeof(StringEnumSerializer<VendorStatus>))]
[Serializable]
public readonly record struct VendorStatus : IStringEnum
{
    public static readonly VendorStatus Active = new(Values.Active);

    public static readonly VendorStatus Inactive = new(Values.Inactive);

    public VendorStatus(string value)
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
    public static VendorStatus FromCustom(string value)
    {
        return new VendorStatus(value);
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

    public static bool operator ==(VendorStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(VendorStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(VendorStatus value) => value.Value;

    public static explicit operator VendorStatus(string value) => new(value);

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
