using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class CatalogObject 
    {
        public CatalogObject(string type,
            string id,
            string updatedAt = null,
            long? version = null,
            bool? isDeleted = null,
            IDictionary<string, Models.CatalogCustomAttributeValue> customAttributeValues = null,
            IList<Models.CatalogV1Id> catalogV1Ids = null,
            bool? presentAtAllLocations = null,
            IList<string> presentAtLocationIds = null,
            IList<string> absentAtLocationIds = null,
            string imageId = null,
            Models.CatalogItem itemData = null,
            Models.CatalogCategory categoryData = null,
            Models.CatalogItemVariation itemVariationData = null,
            Models.CatalogTax taxData = null,
            Models.CatalogDiscount discountData = null,
            Models.CatalogModifierList modifierListData = null,
            Models.CatalogModifier modifierData = null,
            Models.CatalogTimePeriod timePeriodData = null,
            Models.CatalogProductSet productSetData = null,
            Models.CatalogPricingRule pricingRuleData = null,
            Models.CatalogImage imageData = null,
            Models.CatalogMeasurementUnit measurementUnitData = null,
            Models.CatalogSubscriptionPlan subscriptionPlanData = null,
            Models.CatalogItemOption itemOptionData = null,
            Models.CatalogItemOptionValue itemOptionValueData = null,
            Models.CatalogCustomAttributeDefinition customAttributeDefinitionData = null,
            Models.CatalogQuickAmountsSettings quickAmountsSettingsData = null)
        {
            Type = type;
            Id = id;
            UpdatedAt = updatedAt;
            Version = version;
            IsDeleted = isDeleted;
            CustomAttributeValues = customAttributeValues;
            CatalogV1Ids = catalogV1Ids;
            PresentAtAllLocations = presentAtAllLocations;
            PresentAtLocationIds = presentAtLocationIds;
            AbsentAtLocationIds = absentAtLocationIds;
            ImageId = imageId;
            ItemData = itemData;
            CategoryData = categoryData;
            ItemVariationData = itemVariationData;
            TaxData = taxData;
            DiscountData = discountData;
            ModifierListData = modifierListData;
            ModifierData = modifierData;
            TimePeriodData = timePeriodData;
            ProductSetData = productSetData;
            PricingRuleData = pricingRuleData;
            ImageData = imageData;
            MeasurementUnitData = measurementUnitData;
            SubscriptionPlanData = subscriptionPlanData;
            ItemOptionData = itemOptionData;
            ItemOptionValueData = itemOptionValueData;
            CustomAttributeDefinitionData = customAttributeDefinitionData;
            QuickAmountsSettingsData = quickAmountsSettingsData;
        }

        /// <summary>
        /// Possible types of CatalogObjects returned from the Catalog, each
        /// containing type-specific properties in the `*_data` field corresponding to the object type.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; }

        /// <summary>
        /// An identifier to reference this object in the catalog. When a new `CatalogObject`
        /// is inserted, the client should set the id to a temporary identifier starting with
        /// a "`#`" character. Other objects being inserted or updated within the same request
        /// may use this identifier to refer to the new object.
        /// When the server receives the new object, it will supply a unique identifier that
        /// replaces the temporary identifier for all future references.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; }

        /// <summary>
        /// Last modification [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates) in RFC 3339 format, e.g., `"2016-08-15T23:59:33.123Z"`
        /// would indicate the UTC time (denoted by `Z`) of August 15, 2016 at 23:59:33 and 123 milliseconds.
        /// </summary>
        [JsonProperty("updated_at")]
        public string UpdatedAt { get; }

        /// <summary>
        /// The version of the object. When updating an object, the version supplied
        /// must match the version in the database, otherwise the write will be rejected as conflicting.
        /// </summary>
        [JsonProperty("version")]
        public long? Version { get; }

        /// <summary>
        /// If `true`, the object has been deleted from the database. Must be `false` for new objects
        /// being inserted. When deleted, the `updated_at` field will equal the deletion time.
        /// </summary>
        [JsonProperty("is_deleted")]
        public bool? IsDeleted { get; }

        /// <summary>
        /// A map (key-value pairs) of application-defined custom attribute values. The value of a key-value pair 
        /// is a [CatalogCustomAttributeValue](#type-CatalogCustomAttributeValue) object. The key is the `key` attribute 
        /// value defined in the associated [CatalogCustomAttributeDefinition](#type-CatalogCustomAttributeDefinition) 
        /// object defined by the application making the request. 
        /// If the `CatalogCustomAttributeDefinition` object is 
        /// defined by another application, the `CatalogCustomAttributeDefinition`'s key attribute value is prefixed by 
        /// the defining application ID. For example, if the `CatalogCustomAttributeDefinition` has a `key` attribute of 
        /// "cocoa_brand" and the defining application ID is "abcd1234", the key in the map is "abcd1234:cocoa_brand" if the
        /// application making the request is different from the application defining the custom attribute definition. 
        /// Otherwise, the key used in the map is simply "cocoa-brand".
        /// Application-defined custom attributes that are set at a global (location-independent) level.
        /// Custom attribute values are intended to store additional information about a catalog object
        /// or associations with an entity in another system. Do not use custom attributes
        /// to store any sensitive information (personally identifiable information, card details, etc.).
        /// </summary>
        [JsonProperty("custom_attribute_values")]
        public IDictionary<string, Models.CatalogCustomAttributeValue> CustomAttributeValues { get; }

        /// <summary>
        /// The Connect v1 IDs for this object at each location where it is present, where they
        /// differ from the object's Connect V2 ID. The field will only be present for objects that
        /// have been created or modified by legacy APIs.
        /// </summary>
        [JsonProperty("catalog_v1_ids")]
        public IList<Models.CatalogV1Id> CatalogV1Ids { get; }

        /// <summary>
        /// If `true`, this object is present at all locations (including future locations), except where specified in
        /// the `absent_at_location_ids` field. If `false`, this object is not present at any locations (including future locations),
        /// except where specified in the `present_at_location_ids` field. If not specified, defaults to `true`.
        /// </summary>
        [JsonProperty("present_at_all_locations")]
        public bool? PresentAtAllLocations { get; }

        /// <summary>
        /// A list of locations where the object is present, even if `present_at_all_locations` is `false`.
        /// </summary>
        [JsonProperty("present_at_location_ids")]
        public IList<string> PresentAtLocationIds { get; }

        /// <summary>
        /// A list of locations where the object is not present, even if `present_at_all_locations` is `true`.
        /// </summary>
        [JsonProperty("absent_at_location_ids")]
        public IList<string> AbsentAtLocationIds { get; }

        /// <summary>
        /// Identifies the `CatalogImage` attached to this `CatalogObject`.
        /// </summary>
        [JsonProperty("image_id")]
        public string ImageId { get; }

        /// <summary>
        /// An [CatalogObject](#type-CatalogObject) instance of the `ITEM` type, also referred to as an item, in the catalog.
        /// </summary>
        [JsonProperty("item_data")]
        public Models.CatalogItem ItemData { get; }

        /// <summary>
        /// A category to which a `CatalogItem` instance belongs.
        /// </summary>
        [JsonProperty("category_data")]
        public Models.CatalogCategory CategoryData { get; }

        /// <summary>
        /// An item variation (i.e., product) in the Catalog object model. Each item
        /// may have a maximum of 250 item variations.
        /// </summary>
        [JsonProperty("item_variation_data")]
        public Models.CatalogItemVariation ItemVariationData { get; }

        /// <summary>
        /// A tax applicable to an item.
        /// </summary>
        [JsonProperty("tax_data")]
        public Models.CatalogTax TaxData { get; }

        /// <summary>
        /// A discount applicable to items.
        /// </summary>
        [JsonProperty("discount_data")]
        public Models.CatalogDiscount DiscountData { get; }

        /// <summary>
        /// A list of modifiers applicable to items at the time of sale.
        /// For example, a "Condiments" modifier list applicable to a "Hot Dog" item
        /// may contain "Ketchup", "Mustard", and "Relish" modifiers.
        /// Use the `selection_type` field to specify whether or not multiple selections from
        /// the modifier list are allowed.
        /// </summary>
        [JsonProperty("modifier_list_data")]
        public Models.CatalogModifierList ModifierListData { get; }

        /// <summary>
        /// A modifier applicable to items at the time of sale.
        /// </summary>
        [JsonProperty("modifier_data")]
        public Models.CatalogModifier ModifierData { get; }

        /// <summary>
        /// Represents a time period - either a single period or a repeating period.
        /// </summary>
        [JsonProperty("time_period_data")]
        public Models.CatalogTimePeriod TimePeriodData { get; }

        /// <summary>
        /// Represents a collection of catalog objects for the purpose of applying a
        /// `PricingRule`. Including a catalog object will include all of its subtypes.
        /// For example, including a category in a product set will include all of its
        /// items and associated item variations in the product set. Including an item in
        /// a product set will also include its item variations.
        /// </summary>
        [JsonProperty("product_set_data")]
        public Models.CatalogProductSet ProductSetData { get; }

        /// <summary>
        /// Defines how discounts are automatically applied to a set of items that match the pricing rule 
        /// during the active time period.
        /// </summary>
        [JsonProperty("pricing_rule_data")]
        public Models.CatalogPricingRule PricingRuleData { get; }

        /// <summary>
        /// An image file to use in Square catalogs. It can be associated with catalog
        /// items, item variations, and categories.
        /// </summary>
        [JsonProperty("image_data")]
        public Models.CatalogImage ImageData { get; }

        /// <summary>
        /// Represents the unit used to measure a `CatalogItemVariation` and
        /// specifies the precision for decimal quantities.
        /// </summary>
        [JsonProperty("measurement_unit_data")]
        public Models.CatalogMeasurementUnit MeasurementUnitData { get; }

        /// <summary>
        /// Describes a subscription plan. For more information, see
        /// [Set Up and Manage a Subscription Plan](https://developer.squareup.com/docs/docs/subscriptions-api/setup-plan).
        /// </summary>
        [JsonProperty("subscription_plan_data")]
        public Models.CatalogSubscriptionPlan SubscriptionPlanData { get; }

        /// <summary>
        /// A group of variations for a `CatalogItem`.
        /// </summary>
        [JsonProperty("item_option_data")]
        public Models.CatalogItemOption ItemOptionData { get; }

        /// <summary>
        /// An enumerated value that can link a
        /// `CatalogItemVariation` to an item option as one of
        /// its item option values.
        /// </summary>
        [JsonProperty("item_option_value_data")]
        public Models.CatalogItemOptionValue ItemOptionValueData { get; }

        /// <summary>
        /// Contains information defining a custom attribute. Custom attributes are
        /// intended to store additional information about a catalog object or to associate a
        /// catalog object with an entity in another system. Do not use custom attributes
        /// to store any sensitive information (personally identifiable information, card details, etc.).
        /// [Read more about custom attributes](https://developer.squareup.com/docs/catalog-api/add-custom-attributes)
        /// </summary>
        [JsonProperty("custom_attribute_definition_data")]
        public Models.CatalogCustomAttributeDefinition CustomAttributeDefinitionData { get; }

        /// <summary>
        /// A parent Catalog Object model represents a set of Quick Amounts and the settings control the amounts.
        /// </summary>
        [JsonProperty("quick_amounts_settings_data")]
        public Models.CatalogQuickAmountsSettings QuickAmountsSettingsData { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(Type,
                Id)
                .UpdatedAt(UpdatedAt)
                .Version(Version)
                .IsDeleted(IsDeleted)
                .CustomAttributeValues(CustomAttributeValues)
                .CatalogV1Ids(CatalogV1Ids)
                .PresentAtAllLocations(PresentAtAllLocations)
                .PresentAtLocationIds(PresentAtLocationIds)
                .AbsentAtLocationIds(AbsentAtLocationIds)
                .ImageId(ImageId)
                .ItemData(ItemData)
                .CategoryData(CategoryData)
                .ItemVariationData(ItemVariationData)
                .TaxData(TaxData)
                .DiscountData(DiscountData)
                .ModifierListData(ModifierListData)
                .ModifierData(ModifierData)
                .TimePeriodData(TimePeriodData)
                .ProductSetData(ProductSetData)
                .PricingRuleData(PricingRuleData)
                .ImageData(ImageData)
                .MeasurementUnitData(MeasurementUnitData)
                .SubscriptionPlanData(SubscriptionPlanData)
                .ItemOptionData(ItemOptionData)
                .ItemOptionValueData(ItemOptionValueData)
                .CustomAttributeDefinitionData(CustomAttributeDefinitionData)
                .QuickAmountsSettingsData(QuickAmountsSettingsData);
            return builder;
        }

        public class Builder
        {
            private string type;
            private string id;
            private string updatedAt;
            private long? version;
            private bool? isDeleted;
            private IDictionary<string, Models.CatalogCustomAttributeValue> customAttributeValues = new Dictionary<string, Models.CatalogCustomAttributeValue>();
            private IList<Models.CatalogV1Id> catalogV1Ids = new List<Models.CatalogV1Id>();
            private bool? presentAtAllLocations;
            private IList<string> presentAtLocationIds = new List<string>();
            private IList<string> absentAtLocationIds = new List<string>();
            private string imageId;
            private Models.CatalogItem itemData;
            private Models.CatalogCategory categoryData;
            private Models.CatalogItemVariation itemVariationData;
            private Models.CatalogTax taxData;
            private Models.CatalogDiscount discountData;
            private Models.CatalogModifierList modifierListData;
            private Models.CatalogModifier modifierData;
            private Models.CatalogTimePeriod timePeriodData;
            private Models.CatalogProductSet productSetData;
            private Models.CatalogPricingRule pricingRuleData;
            private Models.CatalogImage imageData;
            private Models.CatalogMeasurementUnit measurementUnitData;
            private Models.CatalogSubscriptionPlan subscriptionPlanData;
            private Models.CatalogItemOption itemOptionData;
            private Models.CatalogItemOptionValue itemOptionValueData;
            private Models.CatalogCustomAttributeDefinition customAttributeDefinitionData;
            private Models.CatalogQuickAmountsSettings quickAmountsSettingsData;

            public Builder(string type,
                string id)
            {
                this.type = type;
                this.id = id;
            }
            public Builder Type(string value)
            {
                type = value;
                return this;
            }

            public Builder Id(string value)
            {
                id = value;
                return this;
            }

            public Builder UpdatedAt(string value)
            {
                updatedAt = value;
                return this;
            }

            public Builder Version(long? value)
            {
                version = value;
                return this;
            }

            public Builder IsDeleted(bool? value)
            {
                isDeleted = value;
                return this;
            }

            public Builder CustomAttributeValues(IDictionary<string, Models.CatalogCustomAttributeValue> value)
            {
                customAttributeValues = value;
                return this;
            }

            public Builder CatalogV1Ids(IList<Models.CatalogV1Id> value)
            {
                catalogV1Ids = value;
                return this;
            }

            public Builder PresentAtAllLocations(bool? value)
            {
                presentAtAllLocations = value;
                return this;
            }

            public Builder PresentAtLocationIds(IList<string> value)
            {
                presentAtLocationIds = value;
                return this;
            }

            public Builder AbsentAtLocationIds(IList<string> value)
            {
                absentAtLocationIds = value;
                return this;
            }

            public Builder ImageId(string value)
            {
                imageId = value;
                return this;
            }

            public Builder ItemData(Models.CatalogItem value)
            {
                itemData = value;
                return this;
            }

            public Builder CategoryData(Models.CatalogCategory value)
            {
                categoryData = value;
                return this;
            }

            public Builder ItemVariationData(Models.CatalogItemVariation value)
            {
                itemVariationData = value;
                return this;
            }

            public Builder TaxData(Models.CatalogTax value)
            {
                taxData = value;
                return this;
            }

            public Builder DiscountData(Models.CatalogDiscount value)
            {
                discountData = value;
                return this;
            }

            public Builder ModifierListData(Models.CatalogModifierList value)
            {
                modifierListData = value;
                return this;
            }

            public Builder ModifierData(Models.CatalogModifier value)
            {
                modifierData = value;
                return this;
            }

            public Builder TimePeriodData(Models.CatalogTimePeriod value)
            {
                timePeriodData = value;
                return this;
            }

            public Builder ProductSetData(Models.CatalogProductSet value)
            {
                productSetData = value;
                return this;
            }

            public Builder PricingRuleData(Models.CatalogPricingRule value)
            {
                pricingRuleData = value;
                return this;
            }

            public Builder ImageData(Models.CatalogImage value)
            {
                imageData = value;
                return this;
            }

            public Builder MeasurementUnitData(Models.CatalogMeasurementUnit value)
            {
                measurementUnitData = value;
                return this;
            }

            public Builder SubscriptionPlanData(Models.CatalogSubscriptionPlan value)
            {
                subscriptionPlanData = value;
                return this;
            }

            public Builder ItemOptionData(Models.CatalogItemOption value)
            {
                itemOptionData = value;
                return this;
            }

            public Builder ItemOptionValueData(Models.CatalogItemOptionValue value)
            {
                itemOptionValueData = value;
                return this;
            }

            public Builder CustomAttributeDefinitionData(Models.CatalogCustomAttributeDefinition value)
            {
                customAttributeDefinitionData = value;
                return this;
            }

            public Builder QuickAmountsSettingsData(Models.CatalogQuickAmountsSettings value)
            {
                quickAmountsSettingsData = value;
                return this;
            }

            public CatalogObject Build()
            {
                return new CatalogObject(type,
                    id,
                    updatedAt,
                    version,
                    isDeleted,
                    customAttributeValues,
                    catalogV1Ids,
                    presentAtAllLocations,
                    presentAtLocationIds,
                    absentAtLocationIds,
                    imageId,
                    itemData,
                    categoryData,
                    itemVariationData,
                    taxData,
                    discountData,
                    modifierListData,
                    modifierData,
                    timePeriodData,
                    productSetData,
                    pricingRuleData,
                    imageData,
                    measurementUnitData,
                    subscriptionPlanData,
                    itemOptionData,
                    itemOptionValueData,
                    customAttributeDefinitionData,
                    quickAmountsSettingsData);
            }
        }
    }
}