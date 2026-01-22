using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[JsonConverter(typeof(StringEnumSerializer<SubscriptionCadence>))]
[Serializable]
public readonly record struct SubscriptionCadence : IStringEnum
{
    public static readonly SubscriptionCadence Daily = new(Values.Daily);

    public static readonly SubscriptionCadence Weekly = new(Values.Weekly);

    public static readonly SubscriptionCadence EveryTwoWeeks = new(Values.EveryTwoWeeks);

    public static readonly SubscriptionCadence ThirtyDays = new(Values.ThirtyDays);

    public static readonly SubscriptionCadence SixtyDays = new(Values.SixtyDays);

    public static readonly SubscriptionCadence NinetyDays = new(Values.NinetyDays);

    public static readonly SubscriptionCadence Monthly = new(Values.Monthly);

    public static readonly SubscriptionCadence EveryTwoMonths = new(Values.EveryTwoMonths);

    public static readonly SubscriptionCadence Quarterly = new(Values.Quarterly);

    public static readonly SubscriptionCadence EveryFourMonths = new(Values.EveryFourMonths);

    public static readonly SubscriptionCadence EverySixMonths = new(Values.EverySixMonths);

    public static readonly SubscriptionCadence Annual = new(Values.Annual);

    public static readonly SubscriptionCadence EveryTwoYears = new(Values.EveryTwoYears);

    public SubscriptionCadence(string value)
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
    public static SubscriptionCadence FromCustom(string value)
    {
        return new SubscriptionCadence(value);
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

    public static bool operator ==(SubscriptionCadence value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SubscriptionCadence value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SubscriptionCadence value) => value.Value;

    public static explicit operator SubscriptionCadence(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Daily = "DAILY";

        public const string Weekly = "WEEKLY";

        public const string EveryTwoWeeks = "EVERY_TWO_WEEKS";

        public const string ThirtyDays = "THIRTY_DAYS";

        public const string SixtyDays = "SIXTY_DAYS";

        public const string NinetyDays = "NINETY_DAYS";

        public const string Monthly = "MONTHLY";

        public const string EveryTwoMonths = "EVERY_TWO_MONTHS";

        public const string Quarterly = "QUARTERLY";

        public const string EveryFourMonths = "EVERY_FOUR_MONTHS";

        public const string EverySixMonths = "EVERY_SIX_MONTHS";

        public const string Annual = "ANNUAL";

        public const string EveryTwoYears = "EVERY_TWO_YEARS";
    }
}
