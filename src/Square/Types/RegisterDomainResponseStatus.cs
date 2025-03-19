using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<RegisterDomainResponseStatus>))]
public readonly record struct RegisterDomainResponseStatus : IStringEnum
{
    public static readonly RegisterDomainResponseStatus Pending = new(Values.Pending);

    public static readonly RegisterDomainResponseStatus Verified = new(Values.Verified);

    public RegisterDomainResponseStatus(string value)
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
    public static RegisterDomainResponseStatus FromCustom(string value)
    {
        return new RegisterDomainResponseStatus(value);
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

    public static bool operator ==(RegisterDomainResponseStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(RegisterDomainResponseStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(RegisterDomainResponseStatus value) => value.Value;

    public static explicit operator RegisterDomainResponseStatus(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string Pending = "PENDING";

        public const string Verified = "VERIFIED";
    }
}
