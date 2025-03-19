using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<CheckoutLocationSettingsBrandingHeaderType>))]
public readonly record struct CheckoutLocationSettingsBrandingHeaderType : IStringEnum
{
    public static readonly CheckoutLocationSettingsBrandingHeaderType BusinessName = new(
        Values.BusinessName
    );

    public static readonly CheckoutLocationSettingsBrandingHeaderType FramedLogo = new(
        Values.FramedLogo
    );

    public static readonly CheckoutLocationSettingsBrandingHeaderType FullWidthLogo = new(
        Values.FullWidthLogo
    );

    public CheckoutLocationSettingsBrandingHeaderType(string value)
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
    public static CheckoutLocationSettingsBrandingHeaderType FromCustom(string value)
    {
        return new CheckoutLocationSettingsBrandingHeaderType(value);
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
        CheckoutLocationSettingsBrandingHeaderType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CheckoutLocationSettingsBrandingHeaderType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(CheckoutLocationSettingsBrandingHeaderType value) =>
        value.Value;

    public static explicit operator CheckoutLocationSettingsBrandingHeaderType(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string BusinessName = "BUSINESS_NAME";

        public const string FramedLogo = "FRAMED_LOGO";

        public const string FullWidthLogo = "FULL_WIDTH_LOGO";
    }
}
