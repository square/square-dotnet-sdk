using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<CatalogQuickAmountsSettingsOption>))]
public readonly record struct CatalogQuickAmountsSettingsOption : IStringEnum
{
    public static readonly CatalogQuickAmountsSettingsOption Disabled = new(Values.Disabled);

    public static readonly CatalogQuickAmountsSettingsOption Manual = new(Values.Manual);

    public static readonly CatalogQuickAmountsSettingsOption Auto = new(Values.Auto);

    public CatalogQuickAmountsSettingsOption(string value)
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
    public static CatalogQuickAmountsSettingsOption FromCustom(string value)
    {
        return new CatalogQuickAmountsSettingsOption(value);
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

    public static bool operator ==(CatalogQuickAmountsSettingsOption value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CatalogQuickAmountsSettingsOption value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CatalogQuickAmountsSettingsOption value) => value.Value;

    public static explicit operator CatalogQuickAmountsSettingsOption(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string Disabled = "DISABLED";

        public const string Manual = "MANUAL";

        public const string Auto = "AUTO";
    }
}
