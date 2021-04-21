namespace Square.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Utilities;

    /// <summary>
    /// CatalogObject.
    /// </summary>
    public class CatalogObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogObject"/> class.
        /// </summary>
        /// <param name="type">type.</param>
        /// <param name="id">id.</param>
        /// <param name="updatedAt">updated_at.</param>
        /// <param name="version">version.</param>
        /// <param name="isDeleted">is_deleted.</param>
        /// <param name="customAttributeValues">custom_attribute_values.</param>
        /// <param name="catalogV1Ids">catalog_v1_ids.</param>
        /// <param name="presentAtAllLocations">present_at_all_locations.</param>
        /// <param name="presentAtLocationIds">present_at_location_ids.</param>
        /// <param name="absentAtLocationIds">absent_at_location_ids.</param>
        /// <param name="imageId">image_id.</param>
        /// <param name="itemData">item_data.</param>
        /// <param name="categoryData">category_data.</param>
        /// <param name="itemVariationData">item_variation_data.</param>
        /// <param name="taxData">tax_data.</param>
        /// <param name="discountData">discount_data.</param>
        /// <param name="modifierListData">modifier_list_data.</param>
        /// <param name="modifierData">modifier_data.</param>
        /// <param name="timePeriodData">time_period_data.</param>
        /// <param name="productSetData">product_set_data.</param>
        /// <param name="pricingRuleData">pricing_rule_data.</param>
        /// <param name="imageData">image_data.</param>
        /// <param name="measurementUnitData">measurement_unit_data.</param>
        /// <param name="subscriptionPlanData">subscription_plan_data.</param>
        /// <param name="itemOptionData">item_option_data.</param>
        /// <param name="itemOptionValueData">item_option_value_data.</param>
        /// <param name="customAttributeDefinitionData">custom_attribute_definition_data.</param>
        /// <param name="quickAmountsSettingsData">quick_amounts_settings_data.</param>
        public CatalogObject(
            string type,
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
            this.Type = type;
            this.Id = id;
            this.UpdatedAt = updatedAt;
            this.Version = version;
            this.IsDeleted = isDeleted;
            this.CustomAttributeValues = customAttributeValues;
            this.CatalogV1Ids = catalogV1Ids;
            this.PresentAtAllLocations = presentAtAllLocations;
            this.PresentAtLocationIds = presentAtLocationIds;
            this.AbsentAtLocationIds = absentAtLocationIds;
            this.ImageId = imageId;
            this.ItemData = itemData;
            this.CategoryData = categoryData;
            this.ItemVariationData = itemVariationData;
            this.TaxData = taxData;
            this.DiscountData = discountData;
            this.ModifierListData = modifierListData;
            this.ModifierData = modifierData;
            this.TimePeriodData = timePeriodData;
            this.ProductSetData = productSetData;
            this.PricingRuleData = pricingRuleData;
            this.ImageData = imageData;
            this.MeasurementUnitData = measurementUnitData;
            this.SubscriptionPlanData = subscriptionPlanData;
            this.ItemOptionData = itemOptionData;
            this.ItemOptionValueData = itemOptionValueData;
            this.CustomAttributeDefinitionData = customAttributeDefinitionData;
            this.QuickAmountsSettingsData = quickAmountsSettingsData;
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
        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedAt { get; }

        /// <summary>
        /// The version of the object. When updating an object, the version supplied
        /// must match the version in the database, otherwise the write will be rejected as conflicting.
        /// </summary>
        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        public long? Version { get; }

        /// <summary>
        /// If `true`, the object has been deleted from the database. Must be `false` for new objects
        /// being inserted. When deleted, the `updated_at` field will equal the deletion time.
        /// </summary>
        [JsonProperty("is_deleted", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsDeleted { get; }

        /// <summary>
        /// A map (key-value pairs) of application-defined custom attribute values. The value of a key-value pair
        /// is a [CatalogCustomAttributeValue]($m/CatalogCustomAttributeValue) object. The key is the `key` attribute
        /// value defined in the associated [CatalogCustomAttributeDefinition]($m/CatalogCustomAttributeDefinition)
        /// object defined by the application making the request.
        /// If the `CatalogCustomAttributeDefinition` object is
        /// defined by another application, the `CatalogCustomAttributeDefinition`'s key attribute value is prefixed by
        /// the defining application ID. For example, if the `CatalogCustomAttributeDefinition` has a `key` attribute of
        /// `"cocoa_brand"` and the defining application ID is `"abcd1234"`, the key in the map is `"abcd1234:cocoa_brand"`
        /// if the application making the request is different from the application defining the custom attribute definition.
        /// Otherwise, the key used in the map is simply `"cocoa_brand"`.
        /// Application-defined custom attributes that are set at a global (location-independent) level.
        /// Custom attribute values are intended to store additional information about a catalog object
        /// or associations with an entity in another system. Do not use custom attributes
        /// to store any sensitive information (personally identifiable information, card details, etc.).
        /// </summary>
        [JsonProperty("custom_attribute_values", NullValueHandling = NullValueHandling.Ignore)]
        public IDictionary<string, Models.CatalogCustomAttributeValue> CustomAttributeValues { get; }

        /// <summary>
        /// The Connect v1 IDs for this object at each location where it is present, where they
        /// differ from the object's Connect V2 ID. The field will only be present for objects that
        /// have been created or modified by legacy APIs.
        /// </summary>
        [JsonProperty("catalog_v1_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.CatalogV1Id> CatalogV1Ids { get; }

        /// <summary>
        /// If `true`, this object is present at all locations (including future locations), except where specified in
        /// the `absent_at_location_ids` field. If `false`, this object is not present at any locations (including future locations),
        /// except where specified in the `present_at_location_ids` field. If not specified, defaults to `true`.
        /// </summary>
        [JsonProperty("present_at_all_locations", NullValueHandling = NullValueHandling.Ignore)]
        public bool? PresentAtAllLocations { get; }

        /// <summary>
        /// A list of locations where the object is present, even if `present_at_all_locations` is `false`.
        /// This can include locations that are deactivated.
        /// </summary>
        [JsonProperty("present_at_location_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> PresentAtLocationIds { get; }

        /// <summary>
        /// A list of locations where the object is not present, even if `present_at_all_locations` is `true`.
        /// This can include locations that are deactivated.
        /// </summary>
        [JsonProperty("absent_at_location_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> AbsentAtLocationIds { get; }

        /// <summary>
        /// Identifies the `CatalogImage` attached to this `CatalogObject`.
        /// </summary>
        [JsonProperty("image_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ImageId { get; }

        /// <summary>
        /// A [CatalogObject]($m/CatalogObject) instance of the `ITEM` type, also referred to as an item, in the catalog.
        /// </summary>
        [JsonProperty("item_data", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CatalogItem ItemData { get; }

        /// <summary>
        /// A category to which a `CatalogItem` instance belongs.
        /// </summary>
        [JsonProperty("category_data", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CatalogCategory CategoryData { get; }

        /// <summary>
        /// An item variation (i.e., product) in the Catalog object model. Each item
        /// may have a maximum of 250 item variations.
        /// </summary>
        [JsonProperty("item_variation_data", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CatalogItemVariation ItemVariationData { get; }

        /// <summary>
        /// A tax applicable to an item.
        /// </summary>
        [JsonProperty("tax_data", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CatalogTax TaxData { get; }

        /// <summary>
        /// A discount applicable to items.
        /// </summary>
        [JsonProperty("discount_data", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CatalogDiscount DiscountData { get; }

        /// <summary>
        /// A list of modifiers applicable to items at the time of sale.
        /// For example, a "Condiments" modifier list applicable to a "Hot Dog" item
        /// may contain "Ketchup", "Mustard", and "Relish" modifiers.
        /// Use the `selection_type` field to specify whether or not multiple selections from
        /// the modifier list are allowed.
        /// </summary>
        [JsonProperty("modifier_list_data", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CatalogModifierList ModifierListData { get; }

        /// <summary>
        /// A modifier applicable to items at the time of sale.
        /// </summary>
        [JsonProperty("modifier_data", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CatalogModifier ModifierData { get; }

        /// <summary>
        /// Represents a time period - either a single period or a repeating period.
        /// </summary>
        [JsonProperty("time_period_data", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CatalogTimePeriod TimePeriodData { get; }

        /// <summary>
        /// Represents a collection of catalog objects for the purpose of applying a
        /// `PricingRule`. Including a catalog object will include all of its subtypes.
        /// For example, including a category in a product set will include all of its
        /// items and associated item variations in the product set. Including an item in
        /// a product set will also include its item variations.
        /// </summary>
        [JsonProperty("product_set_data", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CatalogProductSet ProductSetData { get; }

        /// <summary>
        /// Defines how discounts are automatically applied to a set of items that match the pricing rule
        /// during the active time period.
        /// </summary>
        [JsonProperty("pricing_rule_data", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CatalogPricingRule PricingRuleData { get; }

        /// <summary>
        /// An image file to use in Square catalogs. It can be associated with catalog
        /// items, item variations, and categories.
        /// </summary>
        [JsonProperty("image_data", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CatalogImage ImageData { get; }

        /// <summary>
        /// Represents the unit used to measure a `CatalogItemVariation` and
        /// specifies the precision for decimal quantities.
        /// </summary>
        [JsonProperty("measurement_unit_data", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CatalogMeasurementUnit MeasurementUnitData { get; }

        /// <summary>
        /// Describes a subscription plan. For more information, see
        /// [Set Up and Manage a Subscription Plan](https://developer.squareup.com/docs/subscriptions-api/setup-plan).
        /// </summary>
        [JsonProperty("subscription_plan_data", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CatalogSubscriptionPlan SubscriptionPlanData { get; }

        /// <summary>
        /// A group of variations for a `CatalogItem`.
        /// </summary>
        [JsonProperty("item_option_data", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CatalogItemOption ItemOptionData { get; }

        /// <summary>
        /// An enumerated value that can link a
        /// `CatalogItemVariation` to an item option as one of
        /// its item option values.
        /// </summary>
        [JsonProperty("item_option_value_data", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CatalogItemOptionValue ItemOptionValueData { get; }

        /// <summary>
        /// Contains information defining a custom attribute. Custom attributes are
        /// intended to store additional information about a catalog object or to associate a
        /// catalog object with an entity in another system. Do not use custom attributes
        /// to store any sensitive information (personally identifiable information, card details, etc.).
        /// [Read more about custom attributes](https://developer.squareup.com/docs/catalog-api/add-custom-attributes)
        /// </summary>
        [JsonProperty("custom_attribute_definition_data", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CatalogCustomAttributeDefinition CustomAttributeDefinitionData { get; }

        /// <summary>
        /// A parent Catalog Object model represents a set of Quick Amounts and the settings control the amounts.
        /// </summary>
        [JsonProperty("quick_amounts_settings_data", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CatalogQuickAmountsSettings QuickAmountsSettingsData { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogObject : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }

            return obj is CatalogObject other &&
                ((this.Type == null && other.Type == null) || (this.Type?.Equals(other.Type) == true)) &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.UpdatedAt == null && other.UpdatedAt == null) || (this.UpdatedAt?.Equals(other.UpdatedAt) == true)) &&
                ((this.Version == null && other.Version == null) || (this.Version?.Equals(other.Version) == true)) &&
                ((this.IsDeleted == null && other.IsDeleted == null) || (this.IsDeleted?.Equals(other.IsDeleted) == true)) &&
                ((this.CustomAttributeValues == null && other.CustomAttributeValues == null) || (this.CustomAttributeValues?.Equals(other.CustomAttributeValues) == true)) &&
                ((this.CatalogV1Ids == null && other.CatalogV1Ids == null) || (this.CatalogV1Ids?.Equals(other.CatalogV1Ids) == true)) &&
                ((this.PresentAtAllLocations == null && other.PresentAtAllLocations == null) || (this.PresentAtAllLocations?.Equals(other.PresentAtAllLocations) == true)) &&
                ((this.PresentAtLocationIds == null && other.PresentAtLocationIds == null) || (this.PresentAtLocationIds?.Equals(other.PresentAtLocationIds) == true)) &&
                ((this.AbsentAtLocationIds == null && other.AbsentAtLocationIds == null) || (this.AbsentAtLocationIds?.Equals(other.AbsentAtLocationIds) == true)) &&
                ((this.ImageId == null && other.ImageId == null) || (this.ImageId?.Equals(other.ImageId) == true)) &&
                ((this.ItemData == null && other.ItemData == null) || (this.ItemData?.Equals(other.ItemData) == true)) &&
                ((this.CategoryData == null && other.CategoryData == null) || (this.CategoryData?.Equals(other.CategoryData) == true)) &&
                ((this.ItemVariationData == null && other.ItemVariationData == null) || (this.ItemVariationData?.Equals(other.ItemVariationData) == true)) &&
                ((this.TaxData == null && other.TaxData == null) || (this.TaxData?.Equals(other.TaxData) == true)) &&
                ((this.DiscountData == null && other.DiscountData == null) || (this.DiscountData?.Equals(other.DiscountData) == true)) &&
                ((this.ModifierListData == null && other.ModifierListData == null) || (this.ModifierListData?.Equals(other.ModifierListData) == true)) &&
                ((this.ModifierData == null && other.ModifierData == null) || (this.ModifierData?.Equals(other.ModifierData) == true)) &&
                ((this.TimePeriodData == null && other.TimePeriodData == null) || (this.TimePeriodData?.Equals(other.TimePeriodData) == true)) &&
                ((this.ProductSetData == null && other.ProductSetData == null) || (this.ProductSetData?.Equals(other.ProductSetData) == true)) &&
                ((this.PricingRuleData == null && other.PricingRuleData == null) || (this.PricingRuleData?.Equals(other.PricingRuleData) == true)) &&
                ((this.ImageData == null && other.ImageData == null) || (this.ImageData?.Equals(other.ImageData) == true)) &&
                ((this.MeasurementUnitData == null && other.MeasurementUnitData == null) || (this.MeasurementUnitData?.Equals(other.MeasurementUnitData) == true)) &&
                ((this.SubscriptionPlanData == null && other.SubscriptionPlanData == null) || (this.SubscriptionPlanData?.Equals(other.SubscriptionPlanData) == true)) &&
                ((this.ItemOptionData == null && other.ItemOptionData == null) || (this.ItemOptionData?.Equals(other.ItemOptionData) == true)) &&
                ((this.ItemOptionValueData == null && other.ItemOptionValueData == null) || (this.ItemOptionValueData?.Equals(other.ItemOptionValueData) == true)) &&
                ((this.CustomAttributeDefinitionData == null && other.CustomAttributeDefinitionData == null) || (this.CustomAttributeDefinitionData?.Equals(other.CustomAttributeDefinitionData) == true)) &&
                ((this.QuickAmountsSettingsData == null && other.QuickAmountsSettingsData == null) || (this.QuickAmountsSettingsData?.Equals(other.QuickAmountsSettingsData) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1814270990;

            if (this.Type != null)
            {
               hashCode += this.Type.GetHashCode();
            }

            if (this.Id != null)
            {
               hashCode += this.Id.GetHashCode();
            }

            if (this.UpdatedAt != null)
            {
               hashCode += this.UpdatedAt.GetHashCode();
            }

            if (this.Version != null)
            {
               hashCode += this.Version.GetHashCode();
            }

            if (this.IsDeleted != null)
            {
               hashCode += this.IsDeleted.GetHashCode();
            }

            if (this.CustomAttributeValues != null)
            {
               hashCode += this.CustomAttributeValues.GetHashCode();
            }

            if (this.CatalogV1Ids != null)
            {
               hashCode += this.CatalogV1Ids.GetHashCode();
            }

            if (this.PresentAtAllLocations != null)
            {
               hashCode += this.PresentAtAllLocations.GetHashCode();
            }

            if (this.PresentAtLocationIds != null)
            {
               hashCode += this.PresentAtLocationIds.GetHashCode();
            }

            if (this.AbsentAtLocationIds != null)
            {
               hashCode += this.AbsentAtLocationIds.GetHashCode();
            }

            if (this.ImageId != null)
            {
               hashCode += this.ImageId.GetHashCode();
            }

            if (this.ItemData != null)
            {
               hashCode += this.ItemData.GetHashCode();
            }

            if (this.CategoryData != null)
            {
               hashCode += this.CategoryData.GetHashCode();
            }

            if (this.ItemVariationData != null)
            {
               hashCode += this.ItemVariationData.GetHashCode();
            }

            if (this.TaxData != null)
            {
               hashCode += this.TaxData.GetHashCode();
            }

            if (this.DiscountData != null)
            {
               hashCode += this.DiscountData.GetHashCode();
            }

            if (this.ModifierListData != null)
            {
               hashCode += this.ModifierListData.GetHashCode();
            }

            if (this.ModifierData != null)
            {
               hashCode += this.ModifierData.GetHashCode();
            }

            if (this.TimePeriodData != null)
            {
               hashCode += this.TimePeriodData.GetHashCode();
            }

            if (this.ProductSetData != null)
            {
               hashCode += this.ProductSetData.GetHashCode();
            }

            if (this.PricingRuleData != null)
            {
               hashCode += this.PricingRuleData.GetHashCode();
            }

            if (this.ImageData != null)
            {
               hashCode += this.ImageData.GetHashCode();
            }

            if (this.MeasurementUnitData != null)
            {
               hashCode += this.MeasurementUnitData.GetHashCode();
            }

            if (this.SubscriptionPlanData != null)
            {
               hashCode += this.SubscriptionPlanData.GetHashCode();
            }

            if (this.ItemOptionData != null)
            {
               hashCode += this.ItemOptionData.GetHashCode();
            }

            if (this.ItemOptionValueData != null)
            {
               hashCode += this.ItemOptionValueData.GetHashCode();
            }

            if (this.CustomAttributeDefinitionData != null)
            {
               hashCode += this.CustomAttributeDefinitionData.GetHashCode();
            }

            if (this.QuickAmountsSettingsData != null)
            {
               hashCode += this.QuickAmountsSettingsData.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Type = {(this.Type == null ? "null" : this.Type.ToString())}");
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id == string.Empty ? "" : this.Id)}");
            toStringOutput.Add($"this.UpdatedAt = {(this.UpdatedAt == null ? "null" : this.UpdatedAt == string.Empty ? "" : this.UpdatedAt)}");
            toStringOutput.Add($"this.Version = {(this.Version == null ? "null" : this.Version.ToString())}");
            toStringOutput.Add($"this.IsDeleted = {(this.IsDeleted == null ? "null" : this.IsDeleted.ToString())}");
            toStringOutput.Add($"CustomAttributeValues = {(this.CustomAttributeValues == null ? "null" : this.CustomAttributeValues.ToString())}");
            toStringOutput.Add($"this.CatalogV1Ids = {(this.CatalogV1Ids == null ? "null" : $"[{string.Join(", ", this.CatalogV1Ids)} ]")}");
            toStringOutput.Add($"this.PresentAtAllLocations = {(this.PresentAtAllLocations == null ? "null" : this.PresentAtAllLocations.ToString())}");
            toStringOutput.Add($"this.PresentAtLocationIds = {(this.PresentAtLocationIds == null ? "null" : $"[{string.Join(", ", this.PresentAtLocationIds)} ]")}");
            toStringOutput.Add($"this.AbsentAtLocationIds = {(this.AbsentAtLocationIds == null ? "null" : $"[{string.Join(", ", this.AbsentAtLocationIds)} ]")}");
            toStringOutput.Add($"this.ImageId = {(this.ImageId == null ? "null" : this.ImageId == string.Empty ? "" : this.ImageId)}");
            toStringOutput.Add($"this.ItemData = {(this.ItemData == null ? "null" : this.ItemData.ToString())}");
            toStringOutput.Add($"this.CategoryData = {(this.CategoryData == null ? "null" : this.CategoryData.ToString())}");
            toStringOutput.Add($"this.ItemVariationData = {(this.ItemVariationData == null ? "null" : this.ItemVariationData.ToString())}");
            toStringOutput.Add($"this.TaxData = {(this.TaxData == null ? "null" : this.TaxData.ToString())}");
            toStringOutput.Add($"this.DiscountData = {(this.DiscountData == null ? "null" : this.DiscountData.ToString())}");
            toStringOutput.Add($"this.ModifierListData = {(this.ModifierListData == null ? "null" : this.ModifierListData.ToString())}");
            toStringOutput.Add($"this.ModifierData = {(this.ModifierData == null ? "null" : this.ModifierData.ToString())}");
            toStringOutput.Add($"this.TimePeriodData = {(this.TimePeriodData == null ? "null" : this.TimePeriodData.ToString())}");
            toStringOutput.Add($"this.ProductSetData = {(this.ProductSetData == null ? "null" : this.ProductSetData.ToString())}");
            toStringOutput.Add($"this.PricingRuleData = {(this.PricingRuleData == null ? "null" : this.PricingRuleData.ToString())}");
            toStringOutput.Add($"this.ImageData = {(this.ImageData == null ? "null" : this.ImageData.ToString())}");
            toStringOutput.Add($"this.MeasurementUnitData = {(this.MeasurementUnitData == null ? "null" : this.MeasurementUnitData.ToString())}");
            toStringOutput.Add($"this.SubscriptionPlanData = {(this.SubscriptionPlanData == null ? "null" : this.SubscriptionPlanData.ToString())}");
            toStringOutput.Add($"this.ItemOptionData = {(this.ItemOptionData == null ? "null" : this.ItemOptionData.ToString())}");
            toStringOutput.Add($"this.ItemOptionValueData = {(this.ItemOptionValueData == null ? "null" : this.ItemOptionValueData.ToString())}");
            toStringOutput.Add($"this.CustomAttributeDefinitionData = {(this.CustomAttributeDefinitionData == null ? "null" : this.CustomAttributeDefinitionData.ToString())}");
            toStringOutput.Add($"this.QuickAmountsSettingsData = {(this.QuickAmountsSettingsData == null ? "null" : this.QuickAmountsSettingsData.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Type,
                this.Id)
                .UpdatedAt(this.UpdatedAt)
                .Version(this.Version)
                .IsDeleted(this.IsDeleted)
                .CustomAttributeValues(this.CustomAttributeValues)
                .CatalogV1Ids(this.CatalogV1Ids)
                .PresentAtAllLocations(this.PresentAtAllLocations)
                .PresentAtLocationIds(this.PresentAtLocationIds)
                .AbsentAtLocationIds(this.AbsentAtLocationIds)
                .ImageId(this.ImageId)
                .ItemData(this.ItemData)
                .CategoryData(this.CategoryData)
                .ItemVariationData(this.ItemVariationData)
                .TaxData(this.TaxData)
                .DiscountData(this.DiscountData)
                .ModifierListData(this.ModifierListData)
                .ModifierData(this.ModifierData)
                .TimePeriodData(this.TimePeriodData)
                .ProductSetData(this.ProductSetData)
                .PricingRuleData(this.PricingRuleData)
                .ImageData(this.ImageData)
                .MeasurementUnitData(this.MeasurementUnitData)
                .SubscriptionPlanData(this.SubscriptionPlanData)
                .ItemOptionData(this.ItemOptionData)
                .ItemOptionValueData(this.ItemOptionValueData)
                .CustomAttributeDefinitionData(this.CustomAttributeDefinitionData)
                .QuickAmountsSettingsData(this.QuickAmountsSettingsData);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string type;
            private string id;
            private string updatedAt;
            private long? version;
            private bool? isDeleted;
            private IDictionary<string, Models.CatalogCustomAttributeValue> customAttributeValues;
            private IList<Models.CatalogV1Id> catalogV1Ids;
            private bool? presentAtAllLocations;
            private IList<string> presentAtLocationIds;
            private IList<string> absentAtLocationIds;
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

            public Builder(
                string type,
                string id)
            {
                this.type = type;
                this.id = id;
            }

             /// <summary>
             /// Type.
             /// </summary>
             /// <param name="type"> type. </param>
             /// <returns> Builder. </returns>
            public Builder Type(string type)
            {
                this.type = type;
                return this;
            }

             /// <summary>
             /// Id.
             /// </summary>
             /// <param name="id"> id. </param>
             /// <returns> Builder. </returns>
            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

             /// <summary>
             /// UpdatedAt.
             /// </summary>
             /// <param name="updatedAt"> updatedAt. </param>
             /// <returns> Builder. </returns>
            public Builder UpdatedAt(string updatedAt)
            {
                this.updatedAt = updatedAt;
                return this;
            }

             /// <summary>
             /// Version.
             /// </summary>
             /// <param name="version"> version. </param>
             /// <returns> Builder. </returns>
            public Builder Version(long? version)
            {
                this.version = version;
                return this;
            }

             /// <summary>
             /// IsDeleted.
             /// </summary>
             /// <param name="isDeleted"> isDeleted. </param>
             /// <returns> Builder. </returns>
            public Builder IsDeleted(bool? isDeleted)
            {
                this.isDeleted = isDeleted;
                return this;
            }

             /// <summary>
             /// CustomAttributeValues.
             /// </summary>
             /// <param name="customAttributeValues"> customAttributeValues. </param>
             /// <returns> Builder. </returns>
            public Builder CustomAttributeValues(IDictionary<string, Models.CatalogCustomAttributeValue> customAttributeValues)
            {
                this.customAttributeValues = customAttributeValues;
                return this;
            }

             /// <summary>
             /// CatalogV1Ids.
             /// </summary>
             /// <param name="catalogV1Ids"> catalogV1Ids. </param>
             /// <returns> Builder. </returns>
            public Builder CatalogV1Ids(IList<Models.CatalogV1Id> catalogV1Ids)
            {
                this.catalogV1Ids = catalogV1Ids;
                return this;
            }

             /// <summary>
             /// PresentAtAllLocations.
             /// </summary>
             /// <param name="presentAtAllLocations"> presentAtAllLocations. </param>
             /// <returns> Builder. </returns>
            public Builder PresentAtAllLocations(bool? presentAtAllLocations)
            {
                this.presentAtAllLocations = presentAtAllLocations;
                return this;
            }

             /// <summary>
             /// PresentAtLocationIds.
             /// </summary>
             /// <param name="presentAtLocationIds"> presentAtLocationIds. </param>
             /// <returns> Builder. </returns>
            public Builder PresentAtLocationIds(IList<string> presentAtLocationIds)
            {
                this.presentAtLocationIds = presentAtLocationIds;
                return this;
            }

             /// <summary>
             /// AbsentAtLocationIds.
             /// </summary>
             /// <param name="absentAtLocationIds"> absentAtLocationIds. </param>
             /// <returns> Builder. </returns>
            public Builder AbsentAtLocationIds(IList<string> absentAtLocationIds)
            {
                this.absentAtLocationIds = absentAtLocationIds;
                return this;
            }

             /// <summary>
             /// ImageId.
             /// </summary>
             /// <param name="imageId"> imageId. </param>
             /// <returns> Builder. </returns>
            public Builder ImageId(string imageId)
            {
                this.imageId = imageId;
                return this;
            }

             /// <summary>
             /// ItemData.
             /// </summary>
             /// <param name="itemData"> itemData. </param>
             /// <returns> Builder. </returns>
            public Builder ItemData(Models.CatalogItem itemData)
            {
                this.itemData = itemData;
                return this;
            }

             /// <summary>
             /// CategoryData.
             /// </summary>
             /// <param name="categoryData"> categoryData. </param>
             /// <returns> Builder. </returns>
            public Builder CategoryData(Models.CatalogCategory categoryData)
            {
                this.categoryData = categoryData;
                return this;
            }

             /// <summary>
             /// ItemVariationData.
             /// </summary>
             /// <param name="itemVariationData"> itemVariationData. </param>
             /// <returns> Builder. </returns>
            public Builder ItemVariationData(Models.CatalogItemVariation itemVariationData)
            {
                this.itemVariationData = itemVariationData;
                return this;
            }

             /// <summary>
             /// TaxData.
             /// </summary>
             /// <param name="taxData"> taxData. </param>
             /// <returns> Builder. </returns>
            public Builder TaxData(Models.CatalogTax taxData)
            {
                this.taxData = taxData;
                return this;
            }

             /// <summary>
             /// DiscountData.
             /// </summary>
             /// <param name="discountData"> discountData. </param>
             /// <returns> Builder. </returns>
            public Builder DiscountData(Models.CatalogDiscount discountData)
            {
                this.discountData = discountData;
                return this;
            }

             /// <summary>
             /// ModifierListData.
             /// </summary>
             /// <param name="modifierListData"> modifierListData. </param>
             /// <returns> Builder. </returns>
            public Builder ModifierListData(Models.CatalogModifierList modifierListData)
            {
                this.modifierListData = modifierListData;
                return this;
            }

             /// <summary>
             /// ModifierData.
             /// </summary>
             /// <param name="modifierData"> modifierData. </param>
             /// <returns> Builder. </returns>
            public Builder ModifierData(Models.CatalogModifier modifierData)
            {
                this.modifierData = modifierData;
                return this;
            }

             /// <summary>
             /// TimePeriodData.
             /// </summary>
             /// <param name="timePeriodData"> timePeriodData. </param>
             /// <returns> Builder. </returns>
            public Builder TimePeriodData(Models.CatalogTimePeriod timePeriodData)
            {
                this.timePeriodData = timePeriodData;
                return this;
            }

             /// <summary>
             /// ProductSetData.
             /// </summary>
             /// <param name="productSetData"> productSetData. </param>
             /// <returns> Builder. </returns>
            public Builder ProductSetData(Models.CatalogProductSet productSetData)
            {
                this.productSetData = productSetData;
                return this;
            }

             /// <summary>
             /// PricingRuleData.
             /// </summary>
             /// <param name="pricingRuleData"> pricingRuleData. </param>
             /// <returns> Builder. </returns>
            public Builder PricingRuleData(Models.CatalogPricingRule pricingRuleData)
            {
                this.pricingRuleData = pricingRuleData;
                return this;
            }

             /// <summary>
             /// ImageData.
             /// </summary>
             /// <param name="imageData"> imageData. </param>
             /// <returns> Builder. </returns>
            public Builder ImageData(Models.CatalogImage imageData)
            {
                this.imageData = imageData;
                return this;
            }

             /// <summary>
             /// MeasurementUnitData.
             /// </summary>
             /// <param name="measurementUnitData"> measurementUnitData. </param>
             /// <returns> Builder. </returns>
            public Builder MeasurementUnitData(Models.CatalogMeasurementUnit measurementUnitData)
            {
                this.measurementUnitData = measurementUnitData;
                return this;
            }

             /// <summary>
             /// SubscriptionPlanData.
             /// </summary>
             /// <param name="subscriptionPlanData"> subscriptionPlanData. </param>
             /// <returns> Builder. </returns>
            public Builder SubscriptionPlanData(Models.CatalogSubscriptionPlan subscriptionPlanData)
            {
                this.subscriptionPlanData = subscriptionPlanData;
                return this;
            }

             /// <summary>
             /// ItemOptionData.
             /// </summary>
             /// <param name="itemOptionData"> itemOptionData. </param>
             /// <returns> Builder. </returns>
            public Builder ItemOptionData(Models.CatalogItemOption itemOptionData)
            {
                this.itemOptionData = itemOptionData;
                return this;
            }

             /// <summary>
             /// ItemOptionValueData.
             /// </summary>
             /// <param name="itemOptionValueData"> itemOptionValueData. </param>
             /// <returns> Builder. </returns>
            public Builder ItemOptionValueData(Models.CatalogItemOptionValue itemOptionValueData)
            {
                this.itemOptionValueData = itemOptionValueData;
                return this;
            }

             /// <summary>
             /// CustomAttributeDefinitionData.
             /// </summary>
             /// <param name="customAttributeDefinitionData"> customAttributeDefinitionData. </param>
             /// <returns> Builder. </returns>
            public Builder CustomAttributeDefinitionData(Models.CatalogCustomAttributeDefinition customAttributeDefinitionData)
            {
                this.customAttributeDefinitionData = customAttributeDefinitionData;
                return this;
            }

             /// <summary>
             /// QuickAmountsSettingsData.
             /// </summary>
             /// <param name="quickAmountsSettingsData"> quickAmountsSettingsData. </param>
             /// <returns> Builder. </returns>
            public Builder QuickAmountsSettingsData(Models.CatalogQuickAmountsSettings quickAmountsSettingsData)
            {
                this.quickAmountsSettingsData = quickAmountsSettingsData;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogObject. </returns>
            public CatalogObject Build()
            {
                return new CatalogObject(
                    this.type,
                    this.id,
                    this.updatedAt,
                    this.version,
                    this.isDeleted,
                    this.customAttributeValues,
                    this.catalogV1Ids,
                    this.presentAtAllLocations,
                    this.presentAtLocationIds,
                    this.absentAtLocationIds,
                    this.imageId,
                    this.itemData,
                    this.categoryData,
                    this.itemVariationData,
                    this.taxData,
                    this.discountData,
                    this.modifierListData,
                    this.modifierData,
                    this.timePeriodData,
                    this.productSetData,
                    this.pricingRuleData,
                    this.imageData,
                    this.measurementUnitData,
                    this.subscriptionPlanData,
                    this.itemOptionData,
                    this.itemOptionValueData,
                    this.customAttributeDefinitionData,
                    this.quickAmountsSettingsData);
            }
        }
    }
}