using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<CheckoutLocationSettingsBrandingButtonShape>))]
public readonly record struct CheckoutLocationSettingsBrandingButtonShape : IStringEnum
{
    public static readonly CheckoutLocationSettingsBrandingButtonShape Squared = new(
        Values.Squared
    );

    public static readonly CheckoutLocationSettingsBrandingButtonShape Rounded = new(
        Values.Rounded
    );

    public static readonly CheckoutLocationSettingsBrandingButtonShape Pill = new(Values.Pill);

    public CheckoutLocationSettingsBrandingButtonShape(string value)
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
    public static CheckoutLocationSettingsBrandingButtonShape FromCustom(string value)
    {
        return new CheckoutLocationSettingsBrandingButtonShape(value);
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
        CheckoutLocationSettingsBrandingButtonShape value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CheckoutLocationSettingsBrandingButtonShape value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(CheckoutLocationSettingsBrandingButtonShape value) =>
        value.Value;

    public static explicit operator CheckoutLocationSettingsBrandingButtonShape(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string Squared = "SQUARED";

        public const string Rounded = "ROUNDED";

        public const string Pill = "PILL";
    }
}
