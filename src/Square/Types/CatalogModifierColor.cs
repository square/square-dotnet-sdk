using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<CatalogModifierColor>))]
[Serializable]
public readonly record struct CatalogModifierColor : IStringEnum
{
    public static readonly CatalogModifierColor Burgundy = new(Values.Burgundy);

    public static readonly CatalogModifierColor Taupe = new(Values.Taupe);

    public static readonly CatalogModifierColor Brown = new(Values.Brown);

    public static readonly CatalogModifierColor Forest = new(Values.Forest);

    public static readonly CatalogModifierColor Teal = new(Values.Teal);

    public static readonly CatalogModifierColor Sky = new(Values.Sky);

    public static readonly CatalogModifierColor Orange = new(Values.Orange);

    public static readonly CatalogModifierColor Yellow = new(Values.Yellow);

    public static readonly CatalogModifierColor Green = new(Values.Green);

    public static readonly CatalogModifierColor Blue = new(Values.Blue);

    public static readonly CatalogModifierColor Purple = new(Values.Purple);

    public static readonly CatalogModifierColor Pink = new(Values.Pink);

    public static readonly CatalogModifierColor Gold = new(Values.Gold);

    public static readonly CatalogModifierColor BurgundyDark = new(Values.BurgundyDark);

    public static readonly CatalogModifierColor RedDark = new(Values.RedDark);

    public static readonly CatalogModifierColor BrownDark = new(Values.BrownDark);

    public static readonly CatalogModifierColor ForestDark = new(Values.ForestDark);

    public static readonly CatalogModifierColor BlueBright = new(Values.BlueBright);

    public static readonly CatalogModifierColor PurpleDark = new(Values.PurpleDark);

    public static readonly CatalogModifierColor PinkBright = new(Values.PinkBright);

    public static readonly CatalogModifierColor OrangeDark = new(Values.OrangeDark);

    public static readonly CatalogModifierColor SkyDark = new(Values.SkyDark);

    public static readonly CatalogModifierColor PurpleMid = new(Values.PurpleMid);

    public CatalogModifierColor(string value)
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
    public static CatalogModifierColor FromCustom(string value)
    {
        return new CatalogModifierColor(value);
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

    public static bool operator ==(CatalogModifierColor value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CatalogModifierColor value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CatalogModifierColor value) => value.Value;

    public static explicit operator CatalogModifierColor(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Burgundy = "BURGUNDY";

        public const string Taupe = "TAUPE";

        public const string Brown = "BROWN";

        public const string Forest = "FOREST";

        public const string Teal = "TEAL";

        public const string Sky = "SKY";

        public const string Orange = "ORANGE";

        public const string Yellow = "YELLOW";

        public const string Green = "GREEN";

        public const string Blue = "BLUE";

        public const string Purple = "PURPLE";

        public const string Pink = "PINK";

        public const string Gold = "GOLD";

        public const string BurgundyDark = "BURGUNDY_DARK";

        public const string RedDark = "RED_DARK";

        public const string BrownDark = "BROWN_DARK";

        public const string ForestDark = "FOREST_DARK";

        public const string BlueBright = "BLUE_BRIGHT";

        public const string PurpleDark = "PURPLE_DARK";

        public const string PinkBright = "PINK_BRIGHT";

        public const string OrangeDark = "ORANGE_DARK";

        public const string SkyDark = "SKY_DARK";

        public const string PurpleMid = "PURPLE_MID";
    }
}
