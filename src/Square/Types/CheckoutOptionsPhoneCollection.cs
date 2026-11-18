using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<CheckoutOptionsPhoneCollection>))]
[Serializable]
public readonly record struct CheckoutOptionsPhoneCollection : IStringEnum
{
    public static readonly CheckoutOptionsPhoneCollection Required = new(Values.Required);

    public static readonly CheckoutOptionsPhoneCollection Optional = new(Values.Optional);

    public static readonly CheckoutOptionsPhoneCollection Hidden = new(Values.Hidden);

    public CheckoutOptionsPhoneCollection(string value)
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
    public static CheckoutOptionsPhoneCollection FromCustom(string value)
    {
        return new CheckoutOptionsPhoneCollection(value);
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

    public static bool operator ==(CheckoutOptionsPhoneCollection value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CheckoutOptionsPhoneCollection value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CheckoutOptionsPhoneCollection value) => value.Value;

    public static explicit operator CheckoutOptionsPhoneCollection(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Required = "REQUIRED";

        public const string Optional = "OPTIONAL";

        public const string Hidden = "HIDDEN";
    }
}
