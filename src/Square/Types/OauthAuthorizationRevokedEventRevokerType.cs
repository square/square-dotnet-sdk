using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<OauthAuthorizationRevokedEventRevokerType>))]
public readonly record struct OauthAuthorizationRevokedEventRevokerType : IStringEnum
{
    public static readonly OauthAuthorizationRevokedEventRevokerType Application = new(
        Values.Application
    );

    public static readonly OauthAuthorizationRevokedEventRevokerType Merchant = new(
        Values.Merchant
    );

    public static readonly OauthAuthorizationRevokedEventRevokerType Square = new(Values.Square);

    public OauthAuthorizationRevokedEventRevokerType(string value)
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
    public static OauthAuthorizationRevokedEventRevokerType FromCustom(string value)
    {
        return new OauthAuthorizationRevokedEventRevokerType(value);
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

    public static bool operator ==(
        OauthAuthorizationRevokedEventRevokerType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        OauthAuthorizationRevokedEventRevokerType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(OauthAuthorizationRevokedEventRevokerType value) =>
        value.Value;

    public static explicit operator OauthAuthorizationRevokedEventRevokerType(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string Application = "APPLICATION";

        public const string Merchant = "MERCHANT";

        public const string Square = "SQUARE";
    }
}
