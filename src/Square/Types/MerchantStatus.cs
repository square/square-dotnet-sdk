using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<MerchantStatus>))]
public readonly record struct MerchantStatus : IStringEnum
{
    public static readonly MerchantStatus Active = new(Values.Active);

    public static readonly MerchantStatus Inactive = new(Values.Inactive);

    public MerchantStatus(string value)
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
    public static MerchantStatus FromCustom(string value)
    {
        return new MerchantStatus(value);
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

    public static bool operator ==(MerchantStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(MerchantStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(MerchantStatus value) => value.Value;

    public static explicit operator MerchantStatus(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string Active = "ACTIVE";

        public const string Inactive = "INACTIVE";
    }
}
