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
    /// Create an instance of CatalogObject with <see cref="CatalogObject.DiningOption"/>.
    /// </summary>
    public CatalogObject(CatalogObject.DiningOption value)
    {
        Type = "DINING_OPTION";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of CatalogObject with <see cref="CatalogObject.TaxExemption"/>.
    /// </summary>
    public CatalogObject(CatalogObject.TaxExemption value)
    {
        Type = "TAX_EXEMPTION";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of CatalogObject with <see cref="CatalogObject.ServiceCharge"/>.
    /// </summary>
    public CatalogObject(CatalogObject.ServiceCharge value)
    {
        Type = "SERVICE_CHARGE";
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
    /// Create an instance of CatalogObject with <see cref="CatalogObject.SubscriptionPlan"/>.
    /// </summary>
    public CatalogObject(CatalogObject.SubscriptionPlan value)
    {
        Type = "SUBSCRIPTION_PLAN";
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
    /// Create an instance of CatalogObject with <see cref="CatalogObject.Component"/>.
    /// </summary>
    public CatalogObject(CatalogObject.Component value)
    {
        Type = "COMPONENT";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of CatalogObject with <see cref="CatalogObject.Composition"/>.
    /// </summary>
    public CatalogObject(CatalogObject.Composition value)
    {
        Type = "COMPOSITION";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of CatalogObject with <see cref="CatalogObject.Resource"/>.
    /// </summary>
    public CatalogObject(CatalogObject.Resource value)
    {
        Type = "RESOURCE";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of CatalogObject with <see cref="CatalogObject.CheckoutLink"/>.
    /// </summary>
    public CatalogObject(CatalogObject.CheckoutLink value)
    {
        Type = "CHECKOUT_LINK";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of CatalogObject with <see cref="CatalogObject.Address"/>.
    /// </summary>
    public CatalogObject(CatalogObject.Address value)
    {
        Type = "ADDRESS";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of CatalogObject with <see cref="CatalogObject.SubscriptionProduct"/>.
    /// </summary>
    public CatalogObject(CatalogObject.SubscriptionProduct value)
    {
        Type = "SUBSCRIPTION_PRODUCT";
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
    /// Returns true if <see cref="Type"/> is "DINING_OPTION"
    /// </summary>
    public bool IsDiningOption => Type == "DINING_OPTION";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "TAX_EXEMPTION"
    /// </summary>
    public bool IsTaxExemption => Type == "TAX_EXEMPTION";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "SERVICE_CHARGE"
    /// </summary>
    public bool IsServiceCharge => Type == "SERVICE_CHARGE";

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
    /// Returns true if <see cref="Type"/> is "SUBSCRIPTION_PLAN"
    /// </summary>
    public bool IsSubscriptionPlan => Type == "SUBSCRIPTION_PLAN";

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
    /// Returns true if <see cref="Type"/> is "COMPONENT"
    /// </summary>
    public bool IsComponent => Type == "COMPONENT";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "COMPOSITION"
    /// </summary>
    public bool IsComposition => Type == "COMPOSITION";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "RESOURCE"
    /// </summary>
    public bool IsResource => Type == "RESOURCE";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "CHECKOUT_LINK"
    /// </summary>
    public bool IsCheckoutLink => Type == "CHECKOUT_LINK";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "ADDRESS"
    /// </summary>
    public bool IsAddress => Type == "ADDRESS";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "SUBSCRIPTION_PRODUCT"
    /// </summary>
    public bool IsSubscriptionProduct => Type == "SUBSCRIPTION_PRODUCT";

    /// <summary>
    /// Returns the value as a <see cref="Square.CatalogObjectItem"/> if <see cref="Type"/> is 'ITEM', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'ITEM'.</exception>
    public Square.CatalogObjectItem AsItem() =>
        IsItem
            ? (Square.CatalogObjectItem)Value!
            : throw new Exception("CatalogObject.Type is not 'ITEM'");

    /// <summary>
    /// Returns the value as a <see cref="Square.CatalogObjectImage"/> if <see cref="Type"/> is 'IMAGE', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'IMAGE'.</exception>
    public Square.CatalogObjectImage AsImage() =>
        IsImage
            ? (Square.CatalogObjectImage)Value!
            : throw new Exception("CatalogObject.Type is not 'IMAGE'");

    /// <summary>
    /// Returns the value as a <see cref="Square.CatalogObjectCategory"/> if <see cref="Type"/> is 'CATEGORY', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'CATEGORY'.</exception>
    public Square.CatalogObjectCategory AsCategory() =>
        IsCategory
            ? (Square.CatalogObjectCategory)Value!
            : throw new Exception("CatalogObject.Type is not 'CATEGORY'");

    /// <summary>
    /// Returns the value as a <see cref="Square.CatalogObjectItemVariation"/> if <see cref="Type"/> is 'ITEM_VARIATION', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'ITEM_VARIATION'.</exception>
    public Square.CatalogObjectItemVariation AsItemVariation() =>
        IsItemVariation
            ? (Square.CatalogObjectItemVariation)Value!
            : throw new Exception("CatalogObject.Type is not 'ITEM_VARIATION'");

    /// <summary>
    /// Returns the value as a <see cref="Square.CatalogObjectTax"/> if <see cref="Type"/> is 'TAX', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'TAX'.</exception>
    public Square.CatalogObjectTax AsTax() =>
        IsTax
            ? (Square.CatalogObjectTax)Value!
            : throw new Exception("CatalogObject.Type is not 'TAX'");

    /// <summary>
    /// Returns the value as a <see cref="Square.CatalogObjectDiscount"/> if <see cref="Type"/> is 'DISCOUNT', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'DISCOUNT'.</exception>
    public Square.CatalogObjectDiscount AsDiscount() =>
        IsDiscount
            ? (Square.CatalogObjectDiscount)Value!
            : throw new Exception("CatalogObject.Type is not 'DISCOUNT'");

    /// <summary>
    /// Returns the value as a <see cref="Square.CatalogObjectModifierList"/> if <see cref="Type"/> is 'MODIFIER_LIST', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'MODIFIER_LIST'.</exception>
    public Square.CatalogObjectModifierList AsModifierList() =>
        IsModifierList
            ? (Square.CatalogObjectModifierList)Value!
            : throw new Exception("CatalogObject.Type is not 'MODIFIER_LIST'");

    /// <summary>
    /// Returns the value as a <see cref="Square.CatalogObjectModifier"/> if <see cref="Type"/> is 'MODIFIER', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'MODIFIER'.</exception>
    public Square.CatalogObjectModifier AsModifier() =>
        IsModifier
            ? (Square.CatalogObjectModifier)Value!
            : throw new Exception("CatalogObject.Type is not 'MODIFIER'");

    /// <summary>
    /// Returns the value as a <see cref="Square.CatalogObjectDiningOption"/> if <see cref="Type"/> is 'DINING_OPTION', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'DINING_OPTION'.</exception>
    public Square.CatalogObjectDiningOption AsDiningOption() =>
        IsDiningOption
            ? (Square.CatalogObjectDiningOption)Value!
            : throw new Exception("CatalogObject.Type is not 'DINING_OPTION'");

    /// <summary>
    /// Returns the value as a <see cref="Square.CatalogObjectTaxExemption"/> if <see cref="Type"/> is 'TAX_EXEMPTION', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'TAX_EXEMPTION'.</exception>
    public Square.CatalogObjectTaxExemption AsTaxExemption() =>
        IsTaxExemption
            ? (Square.CatalogObjectTaxExemption)Value!
            : throw new Exception("CatalogObject.Type is not 'TAX_EXEMPTION'");

    /// <summary>
    /// Returns the value as a <see cref="Square.CatalogObjectServiceCharge"/> if <see cref="Type"/> is 'SERVICE_CHARGE', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'SERVICE_CHARGE'.</exception>
    public Square.CatalogObjectServiceCharge AsServiceCharge() =>
        IsServiceCharge
            ? (Square.CatalogObjectServiceCharge)Value!
            : throw new Exception("CatalogObject.Type is not 'SERVICE_CHARGE'");

    /// <summary>
    /// Returns the value as a <see cref="Square.CatalogObjectPricingRule"/> if <see cref="Type"/> is 'PRICING_RULE', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'PRICING_RULE'.</exception>
    public Square.CatalogObjectPricingRule AsPricingRule() =>
        IsPricingRule
            ? (Square.CatalogObjectPricingRule)Value!
            : throw new Exception("CatalogObject.Type is not 'PRICING_RULE'");

    /// <summary>
    /// Returns the value as a <see cref="Square.CatalogObjectProductSet"/> if <see cref="Type"/> is 'PRODUCT_SET', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'PRODUCT_SET'.</exception>
    public Square.CatalogObjectProductSet AsProductSet() =>
        IsProductSet
            ? (Square.CatalogObjectProductSet)Value!
            : throw new Exception("CatalogObject.Type is not 'PRODUCT_SET'");

    /// <summary>
    /// Returns the value as a <see cref="Square.CatalogObjectTimePeriod"/> if <see cref="Type"/> is 'TIME_PERIOD', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'TIME_PERIOD'.</exception>
    public Square.CatalogObjectTimePeriod AsTimePeriod() =>
        IsTimePeriod
            ? (Square.CatalogObjectTimePeriod)Value!
            : throw new Exception("CatalogObject.Type is not 'TIME_PERIOD'");

    /// <summary>
    /// Returns the value as a <see cref="Square.CatalogObjectMeasurementUnit"/> if <see cref="Type"/> is 'MEASUREMENT_UNIT', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'MEASUREMENT_UNIT'.</exception>
    public Square.CatalogObjectMeasurementUnit AsMeasurementUnit() =>
        IsMeasurementUnit
            ? (Square.CatalogObjectMeasurementUnit)Value!
            : throw new Exception("CatalogObject.Type is not 'MEASUREMENT_UNIT'");

    /// <summary>
    /// Returns the value as a <see cref="Square.CatalogObjectSubscriptionPlan"/> if <see cref="Type"/> is 'SUBSCRIPTION_PLAN', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'SUBSCRIPTION_PLAN'.</exception>
    public Square.CatalogObjectSubscriptionPlan AsSubscriptionPlan() =>
        IsSubscriptionPlan
            ? (Square.CatalogObjectSubscriptionPlan)Value!
            : throw new Exception("CatalogObject.Type is not 'SUBSCRIPTION_PLAN'");

    /// <summary>
    /// Returns the value as a <see cref="Square.CatalogObjectItemOption"/> if <see cref="Type"/> is 'ITEM_OPTION', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'ITEM_OPTION'.</exception>
    public Square.CatalogObjectItemOption AsItemOption() =>
        IsItemOption
            ? (Square.CatalogObjectItemOption)Value!
            : throw new Exception("CatalogObject.Type is not 'ITEM_OPTION'");

    /// <summary>
    /// Returns the value as a <see cref="Square.CatalogObjectItemOptionValue"/> if <see cref="Type"/> is 'ITEM_OPTION_VAL', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'ITEM_OPTION_VAL'.</exception>
    public Square.CatalogObjectItemOptionValue AsItemOptionVal() =>
        IsItemOptionVal
            ? (Square.CatalogObjectItemOptionValue)Value!
            : throw new Exception("CatalogObject.Type is not 'ITEM_OPTION_VAL'");

    /// <summary>
    /// Returns the value as a <see cref="Square.CatalogObjectCustomAttributeDefinition"/> if <see cref="Type"/> is 'CUSTOM_ATTRIBUTE_DEFINITION', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'CUSTOM_ATTRIBUTE_DEFINITION'.</exception>
    public Square.CatalogObjectCustomAttributeDefinition AsCustomAttributeDefinition() =>
        IsCustomAttributeDefinition
            ? (Square.CatalogObjectCustomAttributeDefinition)Value!
            : throw new Exception("CatalogObject.Type is not 'CUSTOM_ATTRIBUTE_DEFINITION'");

    /// <summary>
    /// Returns the value as a <see cref="Square.CatalogObjectQuickAmountsSettings"/> if <see cref="Type"/> is 'QUICK_AMOUNTS_SETTINGS', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'QUICK_AMOUNTS_SETTINGS'.</exception>
    public Square.CatalogObjectQuickAmountsSettings AsQuickAmountsSettings() =>
        IsQuickAmountsSettings
            ? (Square.CatalogObjectQuickAmountsSettings)Value!
            : throw new Exception("CatalogObject.Type is not 'QUICK_AMOUNTS_SETTINGS'");

    /// <summary>
    /// Returns the value as a <see cref="Square.CatalogObjectComponent"/> if <see cref="Type"/> is 'COMPONENT', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'COMPONENT'.</exception>
    public Square.CatalogObjectComponent AsComponent() =>
        IsComponent
            ? (Square.CatalogObjectComponent)Value!
            : throw new Exception("CatalogObject.Type is not 'COMPONENT'");

    /// <summary>
    /// Returns the value as a <see cref="Square.CatalogObjectComposition"/> if <see cref="Type"/> is 'COMPOSITION', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'COMPOSITION'.</exception>
    public Square.CatalogObjectComposition AsComposition() =>
        IsComposition
            ? (Square.CatalogObjectComposition)Value!
            : throw new Exception("CatalogObject.Type is not 'COMPOSITION'");

    /// <summary>
    /// Returns the value as a <see cref="Square.CatalogObjectResource"/> if <see cref="Type"/> is 'RESOURCE', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'RESOURCE'.</exception>
    public Square.CatalogObjectResource AsResource() =>
        IsResource
            ? (Square.CatalogObjectResource)Value!
            : throw new Exception("CatalogObject.Type is not 'RESOURCE'");

    /// <summary>
    /// Returns the value as a <see cref="Square.CatalogObjectCheckoutLink"/> if <see cref="Type"/> is 'CHECKOUT_LINK', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'CHECKOUT_LINK'.</exception>
    public Square.CatalogObjectCheckoutLink AsCheckoutLink() =>
        IsCheckoutLink
            ? (Square.CatalogObjectCheckoutLink)Value!
            : throw new Exception("CatalogObject.Type is not 'CHECKOUT_LINK'");

    /// <summary>
    /// Returns the value as a <see cref="Square.CatalogObjectAddress"/> if <see cref="Type"/> is 'ADDRESS', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'ADDRESS'.</exception>
    public Square.CatalogObjectAddress AsAddress() =>
        IsAddress
            ? (Square.CatalogObjectAddress)Value!
            : throw new Exception("CatalogObject.Type is not 'ADDRESS'");

    /// <summary>
    /// Returns the value as a <see cref="Square.CatalogObjectSubscriptionProduct"/> if <see cref="Type"/> is 'SUBSCRIPTION_PRODUCT', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'SUBSCRIPTION_PRODUCT'.</exception>
    public Square.CatalogObjectSubscriptionProduct AsSubscriptionProduct() =>
        IsSubscriptionProduct
            ? (Square.CatalogObjectSubscriptionProduct)Value!
            : throw new Exception("CatalogObject.Type is not 'SUBSCRIPTION_PRODUCT'");

    public T Match<T>(
        Func<Square.CatalogObjectItem, T> onItem,
        Func<Square.CatalogObjectImage, T> onImage,
        Func<Square.CatalogObjectCategory, T> onCategory,
        Func<Square.CatalogObjectItemVariation, T> onItemVariation,
        Func<Square.CatalogObjectTax, T> onTax,
        Func<Square.CatalogObjectDiscount, T> onDiscount,
        Func<Square.CatalogObjectModifierList, T> onModifierList,
        Func<Square.CatalogObjectModifier, T> onModifier,
        Func<Square.CatalogObjectDiningOption, T> onDiningOption,
        Func<Square.CatalogObjectTaxExemption, T> onTaxExemption,
        Func<Square.CatalogObjectServiceCharge, T> onServiceCharge,
        Func<Square.CatalogObjectPricingRule, T> onPricingRule,
        Func<Square.CatalogObjectProductSet, T> onProductSet,
        Func<Square.CatalogObjectTimePeriod, T> onTimePeriod,
        Func<Square.CatalogObjectMeasurementUnit, T> onMeasurementUnit,
        Func<Square.CatalogObjectSubscriptionPlan, T> onSubscriptionPlan,
        Func<Square.CatalogObjectItemOption, T> onItemOption,
        Func<Square.CatalogObjectItemOptionValue, T> onItemOptionVal,
        Func<Square.CatalogObjectCustomAttributeDefinition, T> onCustomAttributeDefinition,
        Func<Square.CatalogObjectQuickAmountsSettings, T> onQuickAmountsSettings,
        Func<Square.CatalogObjectComponent, T> onComponent,
        Func<Square.CatalogObjectComposition, T> onComposition,
        Func<Square.CatalogObjectResource, T> onResource,
        Func<Square.CatalogObjectCheckoutLink, T> onCheckoutLink,
        Func<Square.CatalogObjectAddress, T> onAddress,
        Func<Square.CatalogObjectSubscriptionProduct, T> onSubscriptionProduct,
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
            "DINING_OPTION" => onDiningOption(AsDiningOption()),
            "TAX_EXEMPTION" => onTaxExemption(AsTaxExemption()),
            "SERVICE_CHARGE" => onServiceCharge(AsServiceCharge()),
            "PRICING_RULE" => onPricingRule(AsPricingRule()),
            "PRODUCT_SET" => onProductSet(AsProductSet()),
            "TIME_PERIOD" => onTimePeriod(AsTimePeriod()),
            "MEASUREMENT_UNIT" => onMeasurementUnit(AsMeasurementUnit()),
            "SUBSCRIPTION_PLAN" => onSubscriptionPlan(AsSubscriptionPlan()),
            "ITEM_OPTION" => onItemOption(AsItemOption()),
            "ITEM_OPTION_VAL" => onItemOptionVal(AsItemOptionVal()),
            "CUSTOM_ATTRIBUTE_DEFINITION" => onCustomAttributeDefinition(
                AsCustomAttributeDefinition()
            ),
            "QUICK_AMOUNTS_SETTINGS" => onQuickAmountsSettings(AsQuickAmountsSettings()),
            "COMPONENT" => onComponent(AsComponent()),
            "COMPOSITION" => onComposition(AsComposition()),
            "RESOURCE" => onResource(AsResource()),
            "CHECKOUT_LINK" => onCheckoutLink(AsCheckoutLink()),
            "ADDRESS" => onAddress(AsAddress()),
            "SUBSCRIPTION_PRODUCT" => onSubscriptionProduct(AsSubscriptionProduct()),
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
        Action<Square.CatalogObjectDiningOption> onDiningOption,
        Action<Square.CatalogObjectTaxExemption> onTaxExemption,
        Action<Square.CatalogObjectServiceCharge> onServiceCharge,
        Action<Square.CatalogObjectPricingRule> onPricingRule,
        Action<Square.CatalogObjectProductSet> onProductSet,
        Action<Square.CatalogObjectTimePeriod> onTimePeriod,
        Action<Square.CatalogObjectMeasurementUnit> onMeasurementUnit,
        Action<Square.CatalogObjectSubscriptionPlan> onSubscriptionPlan,
        Action<Square.CatalogObjectItemOption> onItemOption,
        Action<Square.CatalogObjectItemOptionValue> onItemOptionVal,
        Action<Square.CatalogObjectCustomAttributeDefinition> onCustomAttributeDefinition,
        Action<Square.CatalogObjectQuickAmountsSettings> onQuickAmountsSettings,
        Action<Square.CatalogObjectComponent> onComponent,
        Action<Square.CatalogObjectComposition> onComposition,
        Action<Square.CatalogObjectResource> onResource,
        Action<Square.CatalogObjectCheckoutLink> onCheckoutLink,
        Action<Square.CatalogObjectAddress> onAddress,
        Action<Square.CatalogObjectSubscriptionProduct> onSubscriptionProduct,
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
            case "DINING_OPTION":
                onDiningOption(AsDiningOption());
                break;
            case "TAX_EXEMPTION":
                onTaxExemption(AsTaxExemption());
                break;
            case "SERVICE_CHARGE":
                onServiceCharge(AsServiceCharge());
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
            case "SUBSCRIPTION_PLAN":
                onSubscriptionPlan(AsSubscriptionPlan());
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
            case "COMPONENT":
                onComponent(AsComponent());
                break;
            case "COMPOSITION":
                onComposition(AsComposition());
                break;
            case "RESOURCE":
                onResource(AsResource());
                break;
            case "CHECKOUT_LINK":
                onCheckoutLink(AsCheckoutLink());
                break;
            case "ADDRESS":
                onAddress(AsAddress());
                break;
            case "SUBSCRIPTION_PRODUCT":
                onSubscriptionProduct(AsSubscriptionProduct());
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
    /// Attempts to cast the value to a <see cref="Square.CatalogObjectDiningOption"/> and returns true if successful.
    /// </summary>
    public bool TryAsDiningOption(out Square.CatalogObjectDiningOption? value)
    {
        if (Type == "DINING_OPTION")
        {
            value = (Square.CatalogObjectDiningOption)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Square.CatalogObjectTaxExemption"/> and returns true if successful.
    /// </summary>
    public bool TryAsTaxExemption(out Square.CatalogObjectTaxExemption? value)
    {
        if (Type == "TAX_EXEMPTION")
        {
            value = (Square.CatalogObjectTaxExemption)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Square.CatalogObjectServiceCharge"/> and returns true if successful.
    /// </summary>
    public bool TryAsServiceCharge(out Square.CatalogObjectServiceCharge? value)
    {
        if (Type == "SERVICE_CHARGE")
        {
            value = (Square.CatalogObjectServiceCharge)Value!;
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
    /// Attempts to cast the value to a <see cref="Square.CatalogObjectComponent"/> and returns true if successful.
    /// </summary>
    public bool TryAsComponent(out Square.CatalogObjectComponent? value)
    {
        if (Type == "COMPONENT")
        {
            value = (Square.CatalogObjectComponent)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Square.CatalogObjectComposition"/> and returns true if successful.
    /// </summary>
    public bool TryAsComposition(out Square.CatalogObjectComposition? value)
    {
        if (Type == "COMPOSITION")
        {
            value = (Square.CatalogObjectComposition)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Square.CatalogObjectResource"/> and returns true if successful.
    /// </summary>
    public bool TryAsResource(out Square.CatalogObjectResource? value)
    {
        if (Type == "RESOURCE")
        {
            value = (Square.CatalogObjectResource)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Square.CatalogObjectCheckoutLink"/> and returns true if successful.
    /// </summary>
    public bool TryAsCheckoutLink(out Square.CatalogObjectCheckoutLink? value)
    {
        if (Type == "CHECKOUT_LINK")
        {
            value = (Square.CatalogObjectCheckoutLink)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Square.CatalogObjectAddress"/> and returns true if successful.
    /// </summary>
    public bool TryAsAddress(out Square.CatalogObjectAddress? value)
    {
        if (Type == "ADDRESS")
        {
            value = (Square.CatalogObjectAddress)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Square.CatalogObjectSubscriptionProduct"/> and returns true if successful.
    /// </summary>
    public bool TryAsSubscriptionProduct(out Square.CatalogObjectSubscriptionProduct? value)
    {
        if (Type == "SUBSCRIPTION_PRODUCT")
        {
            value = (Square.CatalogObjectSubscriptionProduct)Value!;
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

    public static implicit operator CatalogObject(CatalogObject.DiningOption value) => new(value);

    public static implicit operator CatalogObject(CatalogObject.TaxExemption value) => new(value);

    public static implicit operator CatalogObject(CatalogObject.ServiceCharge value) => new(value);

    public static implicit operator CatalogObject(CatalogObject.PricingRule value) => new(value);

    public static implicit operator CatalogObject(CatalogObject.ProductSet value) => new(value);

    public static implicit operator CatalogObject(CatalogObject.TimePeriod value) => new(value);

    public static implicit operator CatalogObject(CatalogObject.MeasurementUnit value) =>
        new(value);

    public static implicit operator CatalogObject(CatalogObject.SubscriptionPlan value) =>
        new(value);

    public static implicit operator CatalogObject(CatalogObject.ItemOption value) => new(value);

    public static implicit operator CatalogObject(CatalogObject.ItemOptionVal value) => new(value);

    public static implicit operator CatalogObject(CatalogObject.CustomAttributeDefinition value) =>
        new(value);

    public static implicit operator CatalogObject(CatalogObject.QuickAmountsSettings value) =>
        new(value);

    public static implicit operator CatalogObject(CatalogObject.Component value) => new(value);

    public static implicit operator CatalogObject(CatalogObject.Composition value) => new(value);

    public static implicit operator CatalogObject(CatalogObject.Resource value) => new(value);

    public static implicit operator CatalogObject(CatalogObject.CheckoutLink value) => new(value);

    public static implicit operator CatalogObject(CatalogObject.Address value) => new(value);

    public static implicit operator CatalogObject(CatalogObject.SubscriptionProduct value) =>
        new(value);

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
                "ITEM" => json.Deserialize<Square.CatalogObjectItem>(options)
                    ?? throw new JsonException("Failed to deserialize Square.CatalogObjectItem"),
                "IMAGE" => json.Deserialize<Square.CatalogObjectImage>(options)
                    ?? throw new JsonException("Failed to deserialize Square.CatalogObjectImage"),
                "CATEGORY" => json.Deserialize<Square.CatalogObjectCategory>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize Square.CatalogObjectCategory"
                    ),
                "ITEM_VARIATION" => json.Deserialize<Square.CatalogObjectItemVariation>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize Square.CatalogObjectItemVariation"
                    ),
                "TAX" => json.Deserialize<Square.CatalogObjectTax>(options)
                    ?? throw new JsonException("Failed to deserialize Square.CatalogObjectTax"),
                "DISCOUNT" => json.Deserialize<Square.CatalogObjectDiscount>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize Square.CatalogObjectDiscount"
                    ),
                "MODIFIER_LIST" => json.Deserialize<Square.CatalogObjectModifierList>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize Square.CatalogObjectModifierList"
                    ),
                "MODIFIER" => json.Deserialize<Square.CatalogObjectModifier>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize Square.CatalogObjectModifier"
                    ),
                "DINING_OPTION" => json.Deserialize<Square.CatalogObjectDiningOption>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize Square.CatalogObjectDiningOption"
                    ),
                "TAX_EXEMPTION" => json.Deserialize<Square.CatalogObjectTaxExemption>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize Square.CatalogObjectTaxExemption"
                    ),
                "SERVICE_CHARGE" => json.Deserialize<Square.CatalogObjectServiceCharge>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize Square.CatalogObjectServiceCharge"
                    ),
                "PRICING_RULE" => json.Deserialize<Square.CatalogObjectPricingRule>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize Square.CatalogObjectPricingRule"
                    ),
                "PRODUCT_SET" => json.Deserialize<Square.CatalogObjectProductSet>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize Square.CatalogObjectProductSet"
                    ),
                "TIME_PERIOD" => json.Deserialize<Square.CatalogObjectTimePeriod>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize Square.CatalogObjectTimePeriod"
                    ),
                "MEASUREMENT_UNIT" => json.Deserialize<Square.CatalogObjectMeasurementUnit>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize Square.CatalogObjectMeasurementUnit"
                    ),
                "SUBSCRIPTION_PLAN" => json.Deserialize<Square.CatalogObjectSubscriptionPlan>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize Square.CatalogObjectSubscriptionPlan"
                    ),
                "ITEM_OPTION" => json.Deserialize<Square.CatalogObjectItemOption>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize Square.CatalogObjectItemOption"
                    ),
                "ITEM_OPTION_VAL" => json.Deserialize<Square.CatalogObjectItemOptionValue>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize Square.CatalogObjectItemOptionValue"
                    ),
                "CUSTOM_ATTRIBUTE_DEFINITION" =>
                    json.Deserialize<Square.CatalogObjectCustomAttributeDefinition>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize Square.CatalogObjectCustomAttributeDefinition"
                        ),
                "QUICK_AMOUNTS_SETTINGS" =>
                    json.Deserialize<Square.CatalogObjectQuickAmountsSettings>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize Square.CatalogObjectQuickAmountsSettings"
                        ),
                "COMPONENT" => json.Deserialize<Square.CatalogObjectComponent>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize Square.CatalogObjectComponent"
                    ),
                "COMPOSITION" => json.Deserialize<Square.CatalogObjectComposition>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize Square.CatalogObjectComposition"
                    ),
                "RESOURCE" => json.Deserialize<Square.CatalogObjectResource>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize Square.CatalogObjectResource"
                    ),
                "CHECKOUT_LINK" => json.Deserialize<Square.CatalogObjectCheckoutLink>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize Square.CatalogObjectCheckoutLink"
                    ),
                "ADDRESS" => json.Deserialize<Square.CatalogObjectAddress>(options)
                    ?? throw new JsonException("Failed to deserialize Square.CatalogObjectAddress"),
                "SUBSCRIPTION_PRODUCT" => json.Deserialize<Square.CatalogObjectSubscriptionProduct>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize Square.CatalogObjectSubscriptionProduct"
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
                    "DINING_OPTION" => JsonSerializer.SerializeToNode(value.Value, options),
                    "TAX_EXEMPTION" => JsonSerializer.SerializeToNode(value.Value, options),
                    "SERVICE_CHARGE" => JsonSerializer.SerializeToNode(value.Value, options),
                    "PRICING_RULE" => JsonSerializer.SerializeToNode(value.Value, options),
                    "PRODUCT_SET" => JsonSerializer.SerializeToNode(value.Value, options),
                    "TIME_PERIOD" => JsonSerializer.SerializeToNode(value.Value, options),
                    "MEASUREMENT_UNIT" => JsonSerializer.SerializeToNode(value.Value, options),
                    "SUBSCRIPTION_PLAN" => JsonSerializer.SerializeToNode(value.Value, options),
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
                    "COMPONENT" => JsonSerializer.SerializeToNode(value.Value, options),
                    "COMPOSITION" => JsonSerializer.SerializeToNode(value.Value, options),
                    "RESOURCE" => JsonSerializer.SerializeToNode(value.Value, options),
                    "CHECKOUT_LINK" => JsonSerializer.SerializeToNode(value.Value, options),
                    "ADDRESS" => JsonSerializer.SerializeToNode(value.Value, options),
                    "SUBSCRIPTION_PRODUCT" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }
    }

    /// <summary>
    /// Discriminated union type for ITEM
    /// </summary>
    public struct Item
    {
        public Item(Square.CatalogObjectItem value)
        {
            Value = value;
        }

        internal Square.CatalogObjectItem Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator Item(Square.CatalogObjectItem value) => new(value);
    }

    /// <summary>
    /// Discriminated union type for IMAGE
    /// </summary>
    public struct Image
    {
        public Image(Square.CatalogObjectImage value)
        {
            Value = value;
        }

        internal Square.CatalogObjectImage Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator Image(Square.CatalogObjectImage value) => new(value);
    }

    /// <summary>
    /// Discriminated union type for CATEGORY
    /// </summary>
    public struct Category
    {
        public Category(Square.CatalogObjectCategory value)
        {
            Value = value;
        }

        internal Square.CatalogObjectCategory Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator Category(Square.CatalogObjectCategory value) => new(value);
    }

    /// <summary>
    /// Discriminated union type for ITEM_VARIATION
    /// </summary>
    public struct ItemVariation
    {
        public ItemVariation(Square.CatalogObjectItemVariation value)
        {
            Value = value;
        }

        internal Square.CatalogObjectItemVariation Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator ItemVariation(Square.CatalogObjectItemVariation value) =>
            new(value);
    }

    /// <summary>
    /// Discriminated union type for TAX
    /// </summary>
    public struct Tax
    {
        public Tax(Square.CatalogObjectTax value)
        {
            Value = value;
        }

        internal Square.CatalogObjectTax Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator Tax(Square.CatalogObjectTax value) => new(value);
    }

    /// <summary>
    /// Discriminated union type for DISCOUNT
    /// </summary>
    public struct Discount
    {
        public Discount(Square.CatalogObjectDiscount value)
        {
            Value = value;
        }

        internal Square.CatalogObjectDiscount Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator Discount(Square.CatalogObjectDiscount value) => new(value);
    }

    /// <summary>
    /// Discriminated union type for MODIFIER_LIST
    /// </summary>
    public struct ModifierList
    {
        public ModifierList(Square.CatalogObjectModifierList value)
        {
            Value = value;
        }

        internal Square.CatalogObjectModifierList Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator ModifierList(Square.CatalogObjectModifierList value) =>
            new(value);
    }

    /// <summary>
    /// Discriminated union type for MODIFIER
    /// </summary>
    public struct Modifier
    {
        public Modifier(Square.CatalogObjectModifier value)
        {
            Value = value;
        }

        internal Square.CatalogObjectModifier Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator Modifier(Square.CatalogObjectModifier value) => new(value);
    }

    /// <summary>
    /// Discriminated union type for DINING_OPTION
    /// </summary>
    public struct DiningOption
    {
        public DiningOption(Square.CatalogObjectDiningOption value)
        {
            Value = value;
        }

        internal Square.CatalogObjectDiningOption Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator DiningOption(Square.CatalogObjectDiningOption value) =>
            new(value);
    }

    /// <summary>
    /// Discriminated union type for TAX_EXEMPTION
    /// </summary>
    public struct TaxExemption
    {
        public TaxExemption(Square.CatalogObjectTaxExemption value)
        {
            Value = value;
        }

        internal Square.CatalogObjectTaxExemption Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator TaxExemption(Square.CatalogObjectTaxExemption value) =>
            new(value);
    }

    /// <summary>
    /// Discriminated union type for SERVICE_CHARGE
    /// </summary>
    public struct ServiceCharge
    {
        public ServiceCharge(Square.CatalogObjectServiceCharge value)
        {
            Value = value;
        }

        internal Square.CatalogObjectServiceCharge Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator ServiceCharge(Square.CatalogObjectServiceCharge value) =>
            new(value);
    }

    /// <summary>
    /// Discriminated union type for PRICING_RULE
    /// </summary>
    public struct PricingRule
    {
        public PricingRule(Square.CatalogObjectPricingRule value)
        {
            Value = value;
        }

        internal Square.CatalogObjectPricingRule Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator PricingRule(Square.CatalogObjectPricingRule value) =>
            new(value);
    }

    /// <summary>
    /// Discriminated union type for PRODUCT_SET
    /// </summary>
    public struct ProductSet
    {
        public ProductSet(Square.CatalogObjectProductSet value)
        {
            Value = value;
        }

        internal Square.CatalogObjectProductSet Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator ProductSet(Square.CatalogObjectProductSet value) =>
            new(value);
    }

    /// <summary>
    /// Discriminated union type for TIME_PERIOD
    /// </summary>
    public struct TimePeriod
    {
        public TimePeriod(Square.CatalogObjectTimePeriod value)
        {
            Value = value;
        }

        internal Square.CatalogObjectTimePeriod Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator TimePeriod(Square.CatalogObjectTimePeriod value) =>
            new(value);
    }

    /// <summary>
    /// Discriminated union type for MEASUREMENT_UNIT
    /// </summary>
    public struct MeasurementUnit
    {
        public MeasurementUnit(Square.CatalogObjectMeasurementUnit value)
        {
            Value = value;
        }

        internal Square.CatalogObjectMeasurementUnit Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator MeasurementUnit(
            Square.CatalogObjectMeasurementUnit value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for SUBSCRIPTION_PLAN
    /// </summary>
    public struct SubscriptionPlan
    {
        public SubscriptionPlan(Square.CatalogObjectSubscriptionPlan value)
        {
            Value = value;
        }

        internal Square.CatalogObjectSubscriptionPlan Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator SubscriptionPlan(
            Square.CatalogObjectSubscriptionPlan value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for ITEM_OPTION
    /// </summary>
    public struct ItemOption
    {
        public ItemOption(Square.CatalogObjectItemOption value)
        {
            Value = value;
        }

        internal Square.CatalogObjectItemOption Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator ItemOption(Square.CatalogObjectItemOption value) =>
            new(value);
    }

    /// <summary>
    /// Discriminated union type for ITEM_OPTION_VAL
    /// </summary>
    public struct ItemOptionVal
    {
        public ItemOptionVal(Square.CatalogObjectItemOptionValue value)
        {
            Value = value;
        }

        internal Square.CatalogObjectItemOptionValue Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator ItemOptionVal(Square.CatalogObjectItemOptionValue value) =>
            new(value);
    }

    /// <summary>
    /// Discriminated union type for CUSTOM_ATTRIBUTE_DEFINITION
    /// </summary>
    public struct CustomAttributeDefinition
    {
        public CustomAttributeDefinition(Square.CatalogObjectCustomAttributeDefinition value)
        {
            Value = value;
        }

        internal Square.CatalogObjectCustomAttributeDefinition Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator CustomAttributeDefinition(
            Square.CatalogObjectCustomAttributeDefinition value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for QUICK_AMOUNTS_SETTINGS
    /// </summary>
    public struct QuickAmountsSettings
    {
        public QuickAmountsSettings(Square.CatalogObjectQuickAmountsSettings value)
        {
            Value = value;
        }

        internal Square.CatalogObjectQuickAmountsSettings Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator QuickAmountsSettings(
            Square.CatalogObjectQuickAmountsSettings value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for COMPONENT
    /// </summary>
    public struct Component
    {
        public Component(Square.CatalogObjectComponent value)
        {
            Value = value;
        }

        internal Square.CatalogObjectComponent Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator Component(Square.CatalogObjectComponent value) =>
            new(value);
    }

    /// <summary>
    /// Discriminated union type for COMPOSITION
    /// </summary>
    public struct Composition
    {
        public Composition(Square.CatalogObjectComposition value)
        {
            Value = value;
        }

        internal Square.CatalogObjectComposition Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator Composition(Square.CatalogObjectComposition value) =>
            new(value);
    }

    /// <summary>
    /// Discriminated union type for RESOURCE
    /// </summary>
    public struct Resource
    {
        public Resource(Square.CatalogObjectResource value)
        {
            Value = value;
        }

        internal Square.CatalogObjectResource Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator Resource(Square.CatalogObjectResource value) => new(value);
    }

    /// <summary>
    /// Discriminated union type for CHECKOUT_LINK
    /// </summary>
    public struct CheckoutLink
    {
        public CheckoutLink(Square.CatalogObjectCheckoutLink value)
        {
            Value = value;
        }

        internal Square.CatalogObjectCheckoutLink Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator CheckoutLink(Square.CatalogObjectCheckoutLink value) =>
            new(value);
    }

    /// <summary>
    /// Discriminated union type for ADDRESS
    /// </summary>
    public struct Address
    {
        public Address(Square.CatalogObjectAddress value)
        {
            Value = value;
        }

        internal Square.CatalogObjectAddress Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator Address(Square.CatalogObjectAddress value) => new(value);
    }

    /// <summary>
    /// Discriminated union type for SUBSCRIPTION_PRODUCT
    /// </summary>
    public struct SubscriptionProduct
    {
        public SubscriptionProduct(Square.CatalogObjectSubscriptionProduct value)
        {
            Value = value;
        }

        internal Square.CatalogObjectSubscriptionProduct Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator SubscriptionProduct(
            Square.CatalogObjectSubscriptionProduct value
        ) => new(value);
    }
}
