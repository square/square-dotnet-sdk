using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<CatalogObjectType>))]
public readonly record struct CatalogObjectType : IStringEnum
{
    public static readonly CatalogObjectType Item = new(Values.Item);

    public static readonly CatalogObjectType Image = new(Values.Image);

    public static readonly CatalogObjectType Category = new(Values.Category);

    public static readonly CatalogObjectType ItemVariation = new(Values.ItemVariation);

    public static readonly CatalogObjectType Tax = new(Values.Tax);

    public static readonly CatalogObjectType Discount = new(Values.Discount);

    public static readonly CatalogObjectType ModifierList = new(Values.ModifierList);

    public static readonly CatalogObjectType Modifier = new(Values.Modifier);

    public static readonly CatalogObjectType PricingRule = new(Values.PricingRule);

    public static readonly CatalogObjectType ProductSet = new(Values.ProductSet);

    public static readonly CatalogObjectType TimePeriod = new(Values.TimePeriod);

    public static readonly CatalogObjectType MeasurementUnit = new(Values.MeasurementUnit);

    public static readonly CatalogObjectType SubscriptionPlanVariation = new(
        Values.SubscriptionPlanVariation
    );

    public static readonly CatalogObjectType ItemOption = new(Values.ItemOption);

    public static readonly CatalogObjectType ItemOptionVal = new(Values.ItemOptionVal);

    public static readonly CatalogObjectType CustomAttributeDefinition = new(
        Values.CustomAttributeDefinition
    );

    public static readonly CatalogObjectType QuickAmountsSettings = new(
        Values.QuickAmountsSettings
    );

    public static readonly CatalogObjectType SubscriptionPlan = new(Values.SubscriptionPlan);

    public static readonly CatalogObjectType AvailabilityPeriod = new(Values.AvailabilityPeriod);

    public CatalogObjectType(string value)
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
    public static CatalogObjectType FromCustom(string value)
    {
        return new CatalogObjectType(value);
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

    public static bool operator ==(CatalogObjectType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CatalogObjectType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CatalogObjectType value) => value.Value;

    public static explicit operator CatalogObjectType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string Item = "ITEM";

        public const string Image = "IMAGE";

        public const string Category = "CATEGORY";

        public const string ItemVariation = "ITEM_VARIATION";

        public const string Tax = "TAX";

        public const string Discount = "DISCOUNT";

        public const string ModifierList = "MODIFIER_LIST";

        public const string Modifier = "MODIFIER";

        public const string PricingRule = "PRICING_RULE";

        public const string ProductSet = "PRODUCT_SET";

        public const string TimePeriod = "TIME_PERIOD";

        public const string MeasurementUnit = "MEASUREMENT_UNIT";

        public const string SubscriptionPlanVariation = "SUBSCRIPTION_PLAN_VARIATION";

        public const string ItemOption = "ITEM_OPTION";

        public const string ItemOptionVal = "ITEM_OPTION_VAL";

        public const string CustomAttributeDefinition = "CUSTOM_ATTRIBUTE_DEFINITION";

        public const string QuickAmountsSettings = "QUICK_AMOUNTS_SETTINGS";

        public const string SubscriptionPlan = "SUBSCRIPTION_PLAN";

        public const string AvailabilityPeriod = "AVAILABILITY_PERIOD";
    }
}
