// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// The wrapper object for the catalog entries of a given object type.
///
/// Depending on the `type` attribute value, a `CatalogObject` instance assumes a type-specific data to yield the corresponding type of catalog object.
///
/// For example, if `type=ITEM`, the `CatalogObject` instance must have the ITEM-specific data set on the `item_data` attribute. The resulting `CatalogObject` instance is also a `CatalogItem` instance.
///
/// In general, if `type=&lt;OBJECT_TYPE&gt;`, the `CatalogObject` instance must have the `&lt;OBJECT_TYPE&gt;`-specific data set on the `&lt;object_type&gt;_data` attribute. The resulting `CatalogObject` instance is also a `Catalog&lt;ObjectType&gt;` instance.
///
/// For a more detailed discussion of the Catalog data model, please see the
/// [Design a Catalog](https://developer.squareup.com/docs/catalog-api/design-a-catalog) guide.
/// </summary>
[JsonConverter(typeof(CatalogObject.JsonConverter))]
[Serializable]
public record CatalogObject
{
    internal CatalogObject(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of CatalogObject with <see cref="CatalogObject.Item"/>.
    /// </summary>
    public CatalogObject(CatalogObject.Item value)
    {
        Type = "ITEM";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of CatalogObject with <see cref="CatalogObject.Image"/>.
    /// </summary>
    public CatalogObject(CatalogObject.Image value)
    {
        Type = "IMAGE";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of CatalogObject with <see cref="CatalogObject.Category"/>.
    /// </summary>
    public CatalogObject(CatalogObject.Category value)
    {
        Type = "CATEGORY";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of CatalogObject with <see cref="CatalogObject.ItemVariation"/>.
    /// </summary>
    public CatalogObject(CatalogObject.ItemVariation value)
    {
        Type = "ITEM_VARIATION";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of CatalogObject with <see cref="CatalogObject.Tax"/>.
    /// </summary>
    public CatalogObject(CatalogObject.Tax value)
    {
        Type = "TAX";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of CatalogObject with <see cref="CatalogObject.Discount"/>.
    /// </summary>
    public CatalogObject(CatalogObject.Discount value)
    {
        Type = "DISCOUNT";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of CatalogObject with <see cref="CatalogObject.ModifierList"/>.
    /// </summary>
    public CatalogObject(CatalogObject.ModifierList value)
    {
        Type = "MODIFIER_LIST";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of CatalogObject with <see cref="CatalogObject.Modifier"/>.
    /// </summary>
    public CatalogObject(CatalogObject.Modifier value)
    {
        Type = "MODIFIER";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of CatalogObject with <see cref="CatalogObject.PricingRule"/>.
    /// </summary>
    public CatalogObject(CatalogObject.PricingRule value)
    {
        Type = "PRICING_RULE";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of CatalogObject with <see cref="CatalogObject.ProductSet"/>.
    /// </summary>
    public CatalogObject(CatalogObject.ProductSet value)
    {
        Type = "PRODUCT_SET";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of CatalogObject with <see cref="CatalogObject.TimePeriod"/>.
    /// </summary>
    public CatalogObject(CatalogObject.TimePeriod value)
    {
        Type = "TIME_PERIOD";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of CatalogObject with <see cref="CatalogObject.MeasurementUnit"/>.
    /// </summary>
    public CatalogObject(CatalogObject.MeasurementUnit value)
    {
        Type = "MEASUREMENT_UNIT";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of CatalogObject with <see cref="CatalogObject.SubscriptionPlanVariation"/>.
    /// </summary>
    public CatalogObject(CatalogObject.SubscriptionPlanVariation value)
    {
        Type = "SUBSCRIPTION_PLAN_VARIATION";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of CatalogObject with <see cref="CatalogObject.ItemOption"/>.
    /// </summary>
    public CatalogObject(CatalogObject.ItemOption value)
    {
        Type = "ITEM_OPTION";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of CatalogObject with <see cref="CatalogObject.ItemOptionVal"/>.
    /// </summary>
    public CatalogObject(CatalogObject.ItemOptionVal value)
    {
        Type = "ITEM_OPTION_VAL";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of CatalogObject with <see cref="CatalogObject.CustomAttributeDefinition"/>.
    /// </summary>
    public CatalogObject(CatalogObject.CustomAttributeDefinition value)
    {
        Type = "CUSTOM_ATTRIBUTE_DEFINITION";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of CatalogObject with <see cref="CatalogObject.QuickAmountsSettings"/>.
    /// </summary>
    public CatalogObject(CatalogObject.QuickAmountsSettings value)
    {
        Type = "QUICK_AMOUNTS_SETTINGS";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of CatalogObject with <see cref="CatalogObject.SubscriptionPlan"/>.
    /// </summary>
    public CatalogObject(CatalogObject.SubscriptionPlan value)
    {
        Type = "SUBSCRIPTION_PLAN";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of CatalogObject with <see cref="CatalogObject.AvailabilityPeriod"/>.
    /// </summary>
    public CatalogObject(CatalogObject.AvailabilityPeriod value)
    {
        Type = "AVAILABILITY_PERIOD";
        Value = value.Value;
    }

    /// <summary>
    /// Discriminant value
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; internal set; }

    /// <summary>
    /// Discriminated union value
    /// </summary>
    public object? Value { get; internal set; }

    /// <summary>
    /// Returns true if <see cref="Type"/> is "ITEM"
    /// </summary>
    public bool IsItem => Type == "ITEM";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "IMAGE"
    /// </summary>
    public bool IsImage => Type == "IMAGE";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "CATEGORY"
    /// </summary>
    public bool IsCategory => Type == "CATEGORY";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "ITEM_VARIATION"
    /// </summary>
    public bool IsItemVariation => Type == "ITEM_VARIATION";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "TAX"
    /// </summary>
    public bool IsTax => Type == "TAX";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "DISCOUNT"
    /// </summary>
    public bool IsDiscount => Type == "DISCOUNT";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "MODIFIER_LIST"
    /// </summary>
    public bool IsModifierList => Type == "MODIFIER_LIST";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "MODIFIER"
    /// </summary>
    public bool IsModifier => Type == "MODIFIER";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "PRICING_RULE"
    /// </summary>
    public bool IsPricingRule => Type == "PRICING_RULE";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "PRODUCT_SET"
    /// </summary>
    public bool IsProductSet => Type == "PRODUCT_SET";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "TIME_PERIOD"
    /// </summary>
    public bool IsTimePeriod => Type == "TIME_PERIOD";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "MEASUREMENT_UNIT"
    /// </summary>
    public bool IsMeasurementUnit => Type == "MEASUREMENT_UNIT";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "SUBSCRIPTION_PLAN_VARIATION"
    /// </summary>
    public bool IsSubscriptionPlanVariation => Type == "SUBSCRIPTION_PLAN_VARIATION";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "ITEM_OPTION"
    /// </summary>
    public bool IsItemOption => Type == "ITEM_OPTION";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "ITEM_OPTION_VAL"
    /// </summary>
    public bool IsItemOptionVal => Type == "ITEM_OPTION_VAL";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "CUSTOM_ATTRIBUTE_DEFINITION"
    /// </summary>
    public bool IsCustomAttributeDefinition => Type == "CUSTOM_ATTRIBUTE_DEFINITION";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "QUICK_AMOUNTS_SETTINGS"
    /// </summary>
    public bool IsQuickAmountsSettings => Type == "QUICK_AMOUNTS_SETTINGS";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "SUBSCRIPTION_PLAN"
    /// </summary>
    public bool IsSubscriptionPlan => Type == "SUBSCRIPTION_PLAN";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "AVAILABILITY_PERIOD"
    /// </summary>
    public bool IsAvailabilityPeriod => Type == "AVAILABILITY_PERIOD";

    /// <summary>
    /// Returns the value as a <see cref="Square.CatalogObjectItem"/> if <see cref="Type"/> is 'ITEM', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'ITEM'.</exception>
    public Square.CatalogObjectItem AsItem() =>
        IsItem
            ? (Square.CatalogObjectItem)Value!
            : throw new System.Exception("CatalogObject.Type is not 'ITEM'");

    /// <summary>
    /// Returns the value as a <see cref="Square.CatalogObjectImage"/> if <see cref="Type"/> is 'IMAGE', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'IMAGE'.</exception>
    public Square.CatalogObjectImage AsImage() =>
        IsImage
            ? (Square.CatalogObjectImage)Value!
            : throw new System.Exception("CatalogObject.Type is not 'IMAGE'");

    /// <summary>
    /// Returns the value as a <see cref="Square.CatalogObjectCategory"/> if <see cref="Type"/> is 'CATEGORY', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'CATEGORY'.</exception>
    public Square.CatalogObjectCategory AsCategory() =>
        IsCategory
            ? (Square.CatalogObjectCategory)Value!
            : throw new System.Exception("CatalogObject.Type is not 'CATEGORY'");

    /// <summary>
    /// Returns the value as a <see cref="Square.CatalogObjectItemVariation"/> if <see cref="Type"/> is 'ITEM_VARIATION', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'ITEM_VARIATION'.</exception>
    public Square.CatalogObjectItemVariation AsItemVariation() =>
        IsItemVariation
            ? (Square.CatalogObjectItemVariation)Value!
            : throw new System.Exception("CatalogObject.Type is not 'ITEM_VARIATION'");

    /// <summary>
    /// Returns the value as a <see cref="Square.CatalogObjectTax"/> if <see cref="Type"/> is 'TAX', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'TAX'.</exception>
    public Square.CatalogObjectTax AsTax() =>
        IsTax
            ? (Square.CatalogObjectTax)Value!
            : throw new System.Exception("CatalogObject.Type is not 'TAX'");

    /// <summary>
    /// Returns the value as a <see cref="Square.CatalogObjectDiscount"/> if <see cref="Type"/> is 'DISCOUNT', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'DISCOUNT'.</exception>
    public Square.CatalogObjectDiscount AsDiscount() =>
        IsDiscount
            ? (Square.CatalogObjectDiscount)Value!
            : throw new System.Exception("CatalogObject.Type is not 'DISCOUNT'");

    /// <summary>
    /// Returns the value as a <see cref="Square.CatalogObjectModifierList"/> if <see cref="Type"/> is 'MODIFIER_LIST', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'MODIFIER_LIST'.</exception>
    public Square.CatalogObjectModifierList AsModifierList() =>
        IsModifierList
            ? (Square.CatalogObjectModifierList)Value!
            : throw new System.Exception("CatalogObject.Type is not 'MODIFIER_LIST'");

    /// <summary>
    /// Returns the value as a <see cref="Square.CatalogObjectModifier"/> if <see cref="Type"/> is 'MODIFIER', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'MODIFIER'.</exception>
    public Square.CatalogObjectModifier AsModifier() =>
        IsModifier
            ? (Square.CatalogObjectModifier)Value!
            : throw new System.Exception("CatalogObject.Type is not 'MODIFIER'");

    /// <summary>
    /// Returns the value as a <see cref="Square.CatalogObjectPricingRule"/> if <see cref="Type"/> is 'PRICING_RULE', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'PRICING_RULE'.</exception>
    public Square.CatalogObjectPricingRule AsPricingRule() =>
        IsPricingRule
            ? (Square.CatalogObjectPricingRule)Value!
            : throw new System.Exception("CatalogObject.Type is not 'PRICING_RULE'");

    /// <summary>
    /// Returns the value as a <see cref="Square.CatalogObjectProductSet"/> if <see cref="Type"/> is 'PRODUCT_SET', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'PRODUCT_SET'.</exception>
    public Square.CatalogObjectProductSet AsProductSet() =>
        IsProductSet
            ? (Square.CatalogObjectProductSet)Value!
            : throw new System.Exception("CatalogObject.Type is not 'PRODUCT_SET'");

    /// <summary>
    /// Returns the value as a <see cref="Square.CatalogObjectTimePeriod"/> if <see cref="Type"/> is 'TIME_PERIOD', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'TIME_PERIOD'.</exception>
    public Square.CatalogObjectTimePeriod AsTimePeriod() =>
        IsTimePeriod
            ? (Square.CatalogObjectTimePeriod)Value!
            : throw new System.Exception("CatalogObject.Type is not 'TIME_PERIOD'");

    /// <summary>
    /// Returns the value as a <see cref="Square.CatalogObjectMeasurementUnit"/> if <see cref="Type"/> is 'MEASUREMENT_UNIT', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'MEASUREMENT_UNIT'.</exception>
    public Square.CatalogObjectMeasurementUnit AsMeasurementUnit() =>
        IsMeasurementUnit
            ? (Square.CatalogObjectMeasurementUnit)Value!
            : throw new System.Exception("CatalogObject.Type is not 'MEASUREMENT_UNIT'");

    /// <summary>
    /// Returns the value as a <see cref="Square.CatalogObjectSubscriptionPlanVariation"/> if <see cref="Type"/> is 'SUBSCRIPTION_PLAN_VARIATION', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'SUBSCRIPTION_PLAN_VARIATION'.</exception>
    public Square.CatalogObjectSubscriptionPlanVariation AsSubscriptionPlanVariation() =>
        IsSubscriptionPlanVariation
            ? (Square.CatalogObjectSubscriptionPlanVariation)Value!
            : throw new System.Exception("CatalogObject.Type is not 'SUBSCRIPTION_PLAN_VARIATION'");

    /// <summary>
    /// Returns the value as a <see cref="Square.CatalogObjectItemOption"/> if <see cref="Type"/> is 'ITEM_OPTION', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'ITEM_OPTION'.</exception>
    public Square.CatalogObjectItemOption AsItemOption() =>
        IsItemOption
            ? (Square.CatalogObjectItemOption)Value!
            : throw new System.Exception("CatalogObject.Type is not 'ITEM_OPTION'");

    /// <summary>
    /// Returns the value as a <see cref="Square.CatalogObjectItemOptionValue"/> if <see cref="Type"/> is 'ITEM_OPTION_VAL', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'ITEM_OPTION_VAL'.</exception>
    public Square.CatalogObjectItemOptionValue AsItemOptionVal() =>
        IsItemOptionVal
            ? (Square.CatalogObjectItemOptionValue)Value!
            : throw new System.Exception("CatalogObject.Type is not 'ITEM_OPTION_VAL'");

    /// <summary>
    /// Returns the value as a <see cref="Square.CatalogObjectCustomAttributeDefinition"/> if <see cref="Type"/> is 'CUSTOM_ATTRIBUTE_DEFINITION', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'CUSTOM_ATTRIBUTE_DEFINITION'.</exception>
    public Square.CatalogObjectCustomAttributeDefinition AsCustomAttributeDefinition() =>
        IsCustomAttributeDefinition
            ? (Square.CatalogObjectCustomAttributeDefinition)Value!
            : throw new System.Exception("CatalogObject.Type is not 'CUSTOM_ATTRIBUTE_DEFINITION'");

    /// <summary>
    /// Returns the value as a <see cref="Square.CatalogObjectQuickAmountsSettings"/> if <see cref="Type"/> is 'QUICK_AMOUNTS_SETTINGS', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'QUICK_AMOUNTS_SETTINGS'.</exception>
    public Square.CatalogObjectQuickAmountsSettings AsQuickAmountsSettings() =>
        IsQuickAmountsSettings
            ? (Square.CatalogObjectQuickAmountsSettings)Value!
            : throw new System.Exception("CatalogObject.Type is not 'QUICK_AMOUNTS_SETTINGS'");

    /// <summary>
    /// Returns the value as a <see cref="Square.CatalogObjectSubscriptionPlan"/> if <see cref="Type"/> is 'SUBSCRIPTION_PLAN', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'SUBSCRIPTION_PLAN'.</exception>
    public Square.CatalogObjectSubscriptionPlan AsSubscriptionPlan() =>
        IsSubscriptionPlan
            ? (Square.CatalogObjectSubscriptionPlan)Value!
            : throw new System.Exception("CatalogObject.Type is not 'SUBSCRIPTION_PLAN'");

    /// <summary>
    /// Returns the value as a <see cref="Square.CatalogObjectAvailabilityPeriod"/> if <see cref="Type"/> is 'AVAILABILITY_PERIOD', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'AVAILABILITY_PERIOD'.</exception>
    public Square.CatalogObjectAvailabilityPeriod AsAvailabilityPeriod() =>
        IsAvailabilityPeriod
            ? (Square.CatalogObjectAvailabilityPeriod)Value!
            : throw new System.Exception("CatalogObject.Type is not 'AVAILABILITY_PERIOD'");

    public T Match<T>(
        Func<Square.CatalogObjectItem, T> onItem,
        Func<Square.CatalogObjectImage, T> onImage,
        Func<Square.CatalogObjectCategory, T> onCategory,
        Func<Square.CatalogObjectItemVariation, T> onItemVariation,
        Func<Square.CatalogObjectTax, T> onTax,
        Func<Square.CatalogObjectDiscount, T> onDiscount,
        Func<Square.CatalogObjectModifierList, T> onModifierList,
        Func<Square.CatalogObjectModifier, T> onModifier,
        Func<Square.CatalogObjectPricingRule, T> onPricingRule,
        Func<Square.CatalogObjectProductSet, T> onProductSet,
        Func<Square.CatalogObjectTimePeriod, T> onTimePeriod,
        Func<Square.CatalogObjectMeasurementUnit, T> onMeasurementUnit,
        Func<Square.CatalogObjectSubscriptionPlanVariation, T> onSubscriptionPlanVariation,
        Func<Square.CatalogObjectItemOption, T> onItemOption,
        Func<Square.CatalogObjectItemOptionValue, T> onItemOptionVal,
        Func<Square.CatalogObjectCustomAttributeDefinition, T> onCustomAttributeDefinition,
        Func<Square.CatalogObjectQuickAmountsSettings, T> onQuickAmountsSettings,
        Func<Square.CatalogObjectSubscriptionPlan, T> onSubscriptionPlan,
        Func<Square.CatalogObjectAvailabilityPeriod, T> onAvailabilityPeriod,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "ITEM" => onItem(AsItem()),
            "IMAGE" => onImage(AsImage()),
            "CATEGORY" => onCategory(AsCategory()),
            "ITEM_VARIATION" => onItemVariation(AsItemVariation()),
            "TAX" => onTax(AsTax()),
            "DISCOUNT" => onDiscount(AsDiscount()),
            "MODIFIER_LIST" => onModifierList(AsModifierList()),
            "MODIFIER" => onModifier(AsModifier()),
            "PRICING_RULE" => onPricingRule(AsPricingRule()),
            "PRODUCT_SET" => onProductSet(AsProductSet()),
            "TIME_PERIOD" => onTimePeriod(AsTimePeriod()),
            "MEASUREMENT_UNIT" => onMeasurementUnit(AsMeasurementUnit()),
            "SUBSCRIPTION_PLAN_VARIATION" => onSubscriptionPlanVariation(
                AsSubscriptionPlanVariation()
            ),
            "ITEM_OPTION" => onItemOption(AsItemOption()),
            "ITEM_OPTION_VAL" => onItemOptionVal(AsItemOptionVal()),
            "CUSTOM_ATTRIBUTE_DEFINITION" => onCustomAttributeDefinition(
                AsCustomAttributeDefinition()
            ),
            "QUICK_AMOUNTS_SETTINGS" => onQuickAmountsSettings(AsQuickAmountsSettings()),
            "SUBSCRIPTION_PLAN" => onSubscriptionPlan(AsSubscriptionPlan()),
            "AVAILABILITY_PERIOD" => onAvailabilityPeriod(AsAvailabilityPeriod()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<Square.CatalogObjectItem> onItem,
        Action<Square.CatalogObjectImage> onImage,
        Action<Square.CatalogObjectCategory> onCategory,
        Action<Square.CatalogObjectItemVariation> onItemVariation,
        Action<Square.CatalogObjectTax> onTax,
        Action<Square.CatalogObjectDiscount> onDiscount,
        Action<Square.CatalogObjectModifierList> onModifierList,
        Action<Square.CatalogObjectModifier> onModifier,
        Action<Square.CatalogObjectPricingRule> onPricingRule,
        Action<Square.CatalogObjectProductSet> onProductSet,
        Action<Square.CatalogObjectTimePeriod> onTimePeriod,
        Action<Square.CatalogObjectMeasurementUnit> onMeasurementUnit,
        Action<Square.CatalogObjectSubscriptionPlanVariation> onSubscriptionPlanVariation,
        Action<Square.CatalogObjectItemOption> onItemOption,
        Action<Square.CatalogObjectItemOptionValue> onItemOptionVal,
        Action<Square.CatalogObjectCustomAttributeDefinition> onCustomAttributeDefinition,
        Action<Square.CatalogObjectQuickAmountsSettings> onQuickAmountsSettings,
        Action<Square.CatalogObjectSubscriptionPlan> onSubscriptionPlan,
        Action<Square.CatalogObjectAvailabilityPeriod> onAvailabilityPeriod,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "ITEM":
                onItem(AsItem());
                break;
            case "IMAGE":
                onImage(AsImage());
                break;
            case "CATEGORY":
                onCategory(AsCategory());
                break;
            case "ITEM_VARIATION":
                onItemVariation(AsItemVariation());
                break;
            case "TAX":
                onTax(AsTax());
                break;
            case "DISCOUNT":
                onDiscount(AsDiscount());
                break;
            case "MODIFIER_LIST":
                onModifierList(AsModifierList());
                break;
            case "MODIFIER":
                onModifier(AsModifier());
                break;
            case "PRICING_RULE":
                onPricingRule(AsPricingRule());
                break;
            case "PRODUCT_SET":
                onProductSet(AsProductSet());
                break;
            case "TIME_PERIOD":
                onTimePeriod(AsTimePeriod());
                break;
            case "MEASUREMENT_UNIT":
                onMeasurementUnit(AsMeasurementUnit());
                break;
            case "SUBSCRIPTION_PLAN_VARIATION":
                onSubscriptionPlanVariation(AsSubscriptionPlanVariation());
                break;
            case "ITEM_OPTION":
                onItemOption(AsItemOption());
                break;
            case "ITEM_OPTION_VAL":
                onItemOptionVal(AsItemOptionVal());
                break;
            case "CUSTOM_ATTRIBUTE_DEFINITION":
                onCustomAttributeDefinition(AsCustomAttributeDefinition());
                break;
            case "QUICK_AMOUNTS_SETTINGS":
                onQuickAmountsSettings(AsQuickAmountsSettings());
                break;
            case "SUBSCRIPTION_PLAN":
                onSubscriptionPlan(AsSubscriptionPlan());
                break;
            case "AVAILABILITY_PERIOD":
                onAvailabilityPeriod(AsAvailabilityPeriod());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Square.CatalogObjectItem"/> and returns true if successful.
    /// </summary>
    public bool TryAsItem(out Square.CatalogObjectItem? value)
    {
        if (Type == "ITEM")
        {
            value = (Square.CatalogObjectItem)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Square.CatalogObjectImage"/> and returns true if successful.
    /// </summary>
    public bool TryAsImage(out Square.CatalogObjectImage? value)
    {
        if (Type == "IMAGE")
        {
            value = (Square.CatalogObjectImage)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Square.CatalogObjectCategory"/> and returns true if successful.
    /// </summary>
    public bool TryAsCategory(out Square.CatalogObjectCategory? value)
    {
        if (Type == "CATEGORY")
        {
            value = (Square.CatalogObjectCategory)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Square.CatalogObjectItemVariation"/> and returns true if successful.
    /// </summary>
    public bool TryAsItemVariation(out Square.CatalogObjectItemVariation? value)
    {
        if (Type == "ITEM_VARIATION")
        {
            value = (Square.CatalogObjectItemVariation)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Square.CatalogObjectTax"/> and returns true if successful.
    /// </summary>
    public bool TryAsTax(out Square.CatalogObjectTax? value)
    {
        if (Type == "TAX")
        {
            value = (Square.CatalogObjectTax)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Square.CatalogObjectDiscount"/> and returns true if successful.
    /// </summary>
    public bool TryAsDiscount(out Square.CatalogObjectDiscount? value)
    {
        if (Type == "DISCOUNT")
        {
            value = (Square.CatalogObjectDiscount)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Square.CatalogObjectModifierList"/> and returns true if successful.
    /// </summary>
    public bool TryAsModifierList(out Square.CatalogObjectModifierList? value)
    {
        if (Type == "MODIFIER_LIST")
        {
            value = (Square.CatalogObjectModifierList)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Square.CatalogObjectModifier"/> and returns true if successful.
    /// </summary>
    public bool TryAsModifier(out Square.CatalogObjectModifier? value)
    {
        if (Type == "MODIFIER")
        {
            value = (Square.CatalogObjectModifier)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Square.CatalogObjectPricingRule"/> and returns true if successful.
    /// </summary>
    public bool TryAsPricingRule(out Square.CatalogObjectPricingRule? value)
    {
        if (Type == "PRICING_RULE")
        {
            value = (Square.CatalogObjectPricingRule)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Square.CatalogObjectProductSet"/> and returns true if successful.
    /// </summary>
    public bool TryAsProductSet(out Square.CatalogObjectProductSet? value)
    {
        if (Type == "PRODUCT_SET")
        {
            value = (Square.CatalogObjectProductSet)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Square.CatalogObjectTimePeriod"/> and returns true if successful.
    /// </summary>
    public bool TryAsTimePeriod(out Square.CatalogObjectTimePeriod? value)
    {
        if (Type == "TIME_PERIOD")
        {
            value = (Square.CatalogObjectTimePeriod)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Square.CatalogObjectMeasurementUnit"/> and returns true if successful.
    /// </summary>
    public bool TryAsMeasurementUnit(out Square.CatalogObjectMeasurementUnit? value)
    {
        if (Type == "MEASUREMENT_UNIT")
        {
            value = (Square.CatalogObjectMeasurementUnit)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Square.CatalogObjectSubscriptionPlanVariation"/> and returns true if successful.
    /// </summary>
    public bool TryAsSubscriptionPlanVariation(
        out Square.CatalogObjectSubscriptionPlanVariation? value
    )
    {
        if (Type == "SUBSCRIPTION_PLAN_VARIATION")
        {
            value = (Square.CatalogObjectSubscriptionPlanVariation)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Square.CatalogObjectItemOption"/> and returns true if successful.
    /// </summary>
    public bool TryAsItemOption(out Square.CatalogObjectItemOption? value)
    {
        if (Type == "ITEM_OPTION")
        {
            value = (Square.CatalogObjectItemOption)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Square.CatalogObjectItemOptionValue"/> and returns true if successful.
    /// </summary>
    public bool TryAsItemOptionVal(out Square.CatalogObjectItemOptionValue? value)
    {
        if (Type == "ITEM_OPTION_VAL")
        {
            value = (Square.CatalogObjectItemOptionValue)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Square.CatalogObjectCustomAttributeDefinition"/> and returns true if successful.
    /// </summary>
    public bool TryAsCustomAttributeDefinition(
        out Square.CatalogObjectCustomAttributeDefinition? value
    )
    {
        if (Type == "CUSTOM_ATTRIBUTE_DEFINITION")
        {
            value = (Square.CatalogObjectCustomAttributeDefinition)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Square.CatalogObjectQuickAmountsSettings"/> and returns true if successful.
    /// </summary>
    public bool TryAsQuickAmountsSettings(out Square.CatalogObjectQuickAmountsSettings? value)
    {
        if (Type == "QUICK_AMOUNTS_SETTINGS")
        {
            value = (Square.CatalogObjectQuickAmountsSettings)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Square.CatalogObjectSubscriptionPlan"/> and returns true if successful.
    /// </summary>
    public bool TryAsSubscriptionPlan(out Square.CatalogObjectSubscriptionPlan? value)
    {
        if (Type == "SUBSCRIPTION_PLAN")
        {
            value = (Square.CatalogObjectSubscriptionPlan)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Square.CatalogObjectAvailabilityPeriod"/> and returns true if successful.
    /// </summary>
    public bool TryAsAvailabilityPeriod(out Square.CatalogObjectAvailabilityPeriod? value)
    {
        if (Type == "AVAILABILITY_PERIOD")
        {
            value = (Square.CatalogObjectAvailabilityPeriod)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator CatalogObject(CatalogObject.Item value) => new(value);

    public static implicit operator CatalogObject(CatalogObject.Image value) => new(value);

    public static implicit operator CatalogObject(CatalogObject.Category value) => new(value);

    public static implicit operator CatalogObject(CatalogObject.ItemVariation value) => new(value);

    public static implicit operator CatalogObject(CatalogObject.Tax value) => new(value);

    public static implicit operator CatalogObject(CatalogObject.Discount value) => new(value);

    public static implicit operator CatalogObject(CatalogObject.ModifierList value) => new(value);

    public static implicit operator CatalogObject(CatalogObject.Modifier value) => new(value);

    public static implicit operator CatalogObject(CatalogObject.PricingRule value) => new(value);

    public static implicit operator CatalogObject(CatalogObject.ProductSet value) => new(value);

    public static implicit operator CatalogObject(CatalogObject.TimePeriod value) => new(value);

    public static implicit operator CatalogObject(CatalogObject.MeasurementUnit value) =>
        new(value);

    public static implicit operator CatalogObject(CatalogObject.SubscriptionPlanVariation value) =>
        new(value);

    public static implicit operator CatalogObject(CatalogObject.ItemOption value) => new(value);

    public static implicit operator CatalogObject(CatalogObject.ItemOptionVal value) => new(value);

    public static implicit operator CatalogObject(CatalogObject.CustomAttributeDefinition value) =>
        new(value);

    public static implicit operator CatalogObject(CatalogObject.QuickAmountsSettings value) =>
        new(value);

    public static implicit operator CatalogObject(CatalogObject.SubscriptionPlan value) =>
        new(value);

    public static implicit operator CatalogObject(CatalogObject.AvailabilityPeriod value) =>
        new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<CatalogObject>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(CatalogObject).IsAssignableFrom(typeToConvert);

        public override CatalogObject Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var json = JsonElement.ParseValue(ref reader);
            if (!json.TryGetProperty("type", out var discriminatorElement))
            {
                throw new JsonException("Missing discriminator property 'type'");
            }
            if (discriminatorElement.ValueKind != JsonValueKind.String)
            {
                if (discriminatorElement.ValueKind == JsonValueKind.Null)
                {
                    throw new JsonException("Discriminator property 'type' is null");
                }

                throw new JsonException(
                    $"Discriminator property 'type' is not a string, instead is {discriminatorElement.ToString()}"
                );
            }

            var discriminator =
                discriminatorElement.GetString()
                ?? throw new JsonException("Discriminator property 'type' is null");

            var value = discriminator switch
            {
                "ITEM" => json.Deserialize<Square.CatalogObjectItem?>(options)
                    ?? throw new JsonException("Failed to deserialize Square.CatalogObjectItem"),
                "IMAGE" => json.Deserialize<Square.CatalogObjectImage?>(options)
                    ?? throw new JsonException("Failed to deserialize Square.CatalogObjectImage"),
                "CATEGORY" => json.Deserialize<Square.CatalogObjectCategory?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize Square.CatalogObjectCategory"
                    ),
                "ITEM_VARIATION" => json.Deserialize<Square.CatalogObjectItemVariation?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize Square.CatalogObjectItemVariation"
                    ),
                "TAX" => json.Deserialize<Square.CatalogObjectTax?>(options)
                    ?? throw new JsonException("Failed to deserialize Square.CatalogObjectTax"),
                "DISCOUNT" => json.Deserialize<Square.CatalogObjectDiscount?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize Square.CatalogObjectDiscount"
                    ),
                "MODIFIER_LIST" => json.Deserialize<Square.CatalogObjectModifierList?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize Square.CatalogObjectModifierList"
                    ),
                "MODIFIER" => json.Deserialize<Square.CatalogObjectModifier?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize Square.CatalogObjectModifier"
                    ),
                "PRICING_RULE" => json.Deserialize<Square.CatalogObjectPricingRule?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize Square.CatalogObjectPricingRule"
                    ),
                "PRODUCT_SET" => json.Deserialize<Square.CatalogObjectProductSet?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize Square.CatalogObjectProductSet"
                    ),
                "TIME_PERIOD" => json.Deserialize<Square.CatalogObjectTimePeriod?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize Square.CatalogObjectTimePeriod"
                    ),
                "MEASUREMENT_UNIT" => json.Deserialize<Square.CatalogObjectMeasurementUnit?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize Square.CatalogObjectMeasurementUnit"
                    ),
                "SUBSCRIPTION_PLAN_VARIATION" =>
                    json.Deserialize<Square.CatalogObjectSubscriptionPlanVariation?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize Square.CatalogObjectSubscriptionPlanVariation"
                        ),
                "ITEM_OPTION" => json.Deserialize<Square.CatalogObjectItemOption?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize Square.CatalogObjectItemOption"
                    ),
                "ITEM_OPTION_VAL" => json.Deserialize<Square.CatalogObjectItemOptionValue?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize Square.CatalogObjectItemOptionValue"
                    ),
                "CUSTOM_ATTRIBUTE_DEFINITION" =>
                    json.Deserialize<Square.CatalogObjectCustomAttributeDefinition?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize Square.CatalogObjectCustomAttributeDefinition"
                        ),
                "QUICK_AMOUNTS_SETTINGS" =>
                    json.Deserialize<Square.CatalogObjectQuickAmountsSettings?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize Square.CatalogObjectQuickAmountsSettings"
                        ),
                "SUBSCRIPTION_PLAN" => json.Deserialize<Square.CatalogObjectSubscriptionPlan?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize Square.CatalogObjectSubscriptionPlan"
                    ),
                "AVAILABILITY_PERIOD" => json.Deserialize<Square.CatalogObjectAvailabilityPeriod?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize Square.CatalogObjectAvailabilityPeriod"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new CatalogObject(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CatalogObject value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "ITEM" => JsonSerializer.SerializeToNode(value.Value, options),
                    "IMAGE" => JsonSerializer.SerializeToNode(value.Value, options),
                    "CATEGORY" => JsonSerializer.SerializeToNode(value.Value, options),
                    "ITEM_VARIATION" => JsonSerializer.SerializeToNode(value.Value, options),
                    "TAX" => JsonSerializer.SerializeToNode(value.Value, options),
                    "DISCOUNT" => JsonSerializer.SerializeToNode(value.Value, options),
                    "MODIFIER_LIST" => JsonSerializer.SerializeToNode(value.Value, options),
                    "MODIFIER" => JsonSerializer.SerializeToNode(value.Value, options),
                    "PRICING_RULE" => JsonSerializer.SerializeToNode(value.Value, options),
                    "PRODUCT_SET" => JsonSerializer.SerializeToNode(value.Value, options),
                    "TIME_PERIOD" => JsonSerializer.SerializeToNode(value.Value, options),
                    "MEASUREMENT_UNIT" => JsonSerializer.SerializeToNode(value.Value, options),
                    "SUBSCRIPTION_PLAN_VARIATION" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "ITEM_OPTION" => JsonSerializer.SerializeToNode(value.Value, options),
                    "ITEM_OPTION_VAL" => JsonSerializer.SerializeToNode(value.Value, options),
                    "CUSTOM_ATTRIBUTE_DEFINITION" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "QUICK_AMOUNTS_SETTINGS" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "SUBSCRIPTION_PLAN" => JsonSerializer.SerializeToNode(value.Value, options),
                    "AVAILABILITY_PERIOD" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }
    }

    /// <summary>
    /// Discriminated union type for ITEM
    /// </summary>
    [Serializable]
    public struct Item
    {
        public Item(Square.CatalogObjectItem value)
        {
            Value = value;
        }

        internal Square.CatalogObjectItem Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator CatalogObject.Item(Square.CatalogObjectItem value) =>
            new(value);
    }

    /// <summary>
    /// Discriminated union type for IMAGE
    /// </summary>
    [Serializable]
    public struct Image
    {
        public Image(Square.CatalogObjectImage value)
        {
            Value = value;
        }

        internal Square.CatalogObjectImage Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator CatalogObject.Image(Square.CatalogObjectImage value) =>
            new(value);
    }

    /// <summary>
    /// Discriminated union type for CATEGORY
    /// </summary>
    [Serializable]
    public struct Category
    {
        public Category(Square.CatalogObjectCategory value)
        {
            Value = value;
        }

        internal Square.CatalogObjectCategory Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator CatalogObject.Category(
            Square.CatalogObjectCategory value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for ITEM_VARIATION
    /// </summary>
    [Serializable]
    public struct ItemVariation
    {
        public ItemVariation(Square.CatalogObjectItemVariation value)
        {
            Value = value;
        }

        internal Square.CatalogObjectItemVariation Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator CatalogObject.ItemVariation(
            Square.CatalogObjectItemVariation value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for TAX
    /// </summary>
    [Serializable]
    public struct Tax
    {
        public Tax(Square.CatalogObjectTax value)
        {
            Value = value;
        }

        internal Square.CatalogObjectTax Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator CatalogObject.Tax(Square.CatalogObjectTax value) =>
            new(value);
    }

    /// <summary>
    /// Discriminated union type for DISCOUNT
    /// </summary>
    [Serializable]
    public struct Discount
    {
        public Discount(Square.CatalogObjectDiscount value)
        {
            Value = value;
        }

        internal Square.CatalogObjectDiscount Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator CatalogObject.Discount(
            Square.CatalogObjectDiscount value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for MODIFIER_LIST
    /// </summary>
    [Serializable]
    public struct ModifierList
    {
        public ModifierList(Square.CatalogObjectModifierList value)
        {
            Value = value;
        }

        internal Square.CatalogObjectModifierList Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator CatalogObject.ModifierList(
            Square.CatalogObjectModifierList value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for MODIFIER
    /// </summary>
    [Serializable]
    public struct Modifier
    {
        public Modifier(Square.CatalogObjectModifier value)
        {
            Value = value;
        }

        internal Square.CatalogObjectModifier Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator CatalogObject.Modifier(
            Square.CatalogObjectModifier value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for PRICING_RULE
    /// </summary>
    [Serializable]
    public struct PricingRule
    {
        public PricingRule(Square.CatalogObjectPricingRule value)
        {
            Value = value;
        }

        internal Square.CatalogObjectPricingRule Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator CatalogObject.PricingRule(
            Square.CatalogObjectPricingRule value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for PRODUCT_SET
    /// </summary>
    [Serializable]
    public struct ProductSet
    {
        public ProductSet(Square.CatalogObjectProductSet value)
        {
            Value = value;
        }

        internal Square.CatalogObjectProductSet Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator CatalogObject.ProductSet(
            Square.CatalogObjectProductSet value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for TIME_PERIOD
    /// </summary>
    [Serializable]
    public struct TimePeriod
    {
        public TimePeriod(Square.CatalogObjectTimePeriod value)
        {
            Value = value;
        }

        internal Square.CatalogObjectTimePeriod Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator CatalogObject.TimePeriod(
            Square.CatalogObjectTimePeriod value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for MEASUREMENT_UNIT
    /// </summary>
    [Serializable]
    public struct MeasurementUnit
    {
        public MeasurementUnit(Square.CatalogObjectMeasurementUnit value)
        {
            Value = value;
        }

        internal Square.CatalogObjectMeasurementUnit Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator CatalogObject.MeasurementUnit(
            Square.CatalogObjectMeasurementUnit value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for SUBSCRIPTION_PLAN_VARIATION
    /// </summary>
    [Serializable]
    public struct SubscriptionPlanVariation
    {
        public SubscriptionPlanVariation(Square.CatalogObjectSubscriptionPlanVariation value)
        {
            Value = value;
        }

        internal Square.CatalogObjectSubscriptionPlanVariation Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator CatalogObject.SubscriptionPlanVariation(
            Square.CatalogObjectSubscriptionPlanVariation value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for ITEM_OPTION
    /// </summary>
    [Serializable]
    public struct ItemOption
    {
        public ItemOption(Square.CatalogObjectItemOption value)
        {
            Value = value;
        }

        internal Square.CatalogObjectItemOption Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator CatalogObject.ItemOption(
            Square.CatalogObjectItemOption value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for ITEM_OPTION_VAL
    /// </summary>
    [Serializable]
    public struct ItemOptionVal
    {
        public ItemOptionVal(Square.CatalogObjectItemOptionValue value)
        {
            Value = value;
        }

        internal Square.CatalogObjectItemOptionValue Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator CatalogObject.ItemOptionVal(
            Square.CatalogObjectItemOptionValue value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for CUSTOM_ATTRIBUTE_DEFINITION
    /// </summary>
    [Serializable]
    public struct CustomAttributeDefinition
    {
        public CustomAttributeDefinition(Square.CatalogObjectCustomAttributeDefinition value)
        {
            Value = value;
        }

        internal Square.CatalogObjectCustomAttributeDefinition Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator CatalogObject.CustomAttributeDefinition(
            Square.CatalogObjectCustomAttributeDefinition value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for QUICK_AMOUNTS_SETTINGS
    /// </summary>
    [Serializable]
    public struct QuickAmountsSettings
    {
        public QuickAmountsSettings(Square.CatalogObjectQuickAmountsSettings value)
        {
            Value = value;
        }

        internal Square.CatalogObjectQuickAmountsSettings Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator CatalogObject.QuickAmountsSettings(
            Square.CatalogObjectQuickAmountsSettings value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for SUBSCRIPTION_PLAN
    /// </summary>
    [Serializable]
    public struct SubscriptionPlan
    {
        public SubscriptionPlan(Square.CatalogObjectSubscriptionPlan value)
        {
            Value = value;
        }

        internal Square.CatalogObjectSubscriptionPlan Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator CatalogObject.SubscriptionPlan(
            Square.CatalogObjectSubscriptionPlan value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for AVAILABILITY_PERIOD
    /// </summary>
    [Serializable]
    public struct AvailabilityPeriod
    {
        public AvailabilityPeriod(Square.CatalogObjectAvailabilityPeriod value)
        {
            Value = value;
        }

        internal Square.CatalogObjectAvailabilityPeriod Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator CatalogObject.AvailabilityPeriod(
            Square.CatalogObjectAvailabilityPeriod value
        ) => new(value);
    }
}
