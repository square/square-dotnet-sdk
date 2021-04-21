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
    /// UpsertCatalogObjectRequest.
    /// </summary>
    public class UpsertCatalogObjectRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpsertCatalogObjectRequest"/> class.
        /// </summary>
        /// <param name="idempotencyKey">idempotency_key.</param>
        /// <param name="mObject">object.</param>
        public UpsertCatalogObjectRequest(
            string idempotencyKey,
            Models.CatalogObject mObject)
        {
            this.IdempotencyKey = idempotencyKey;
            this.MObject = mObject;
        }

        /// <summary>
        /// A value you specify that uniquely identifies this
        /// request among all your requests. A common way to create
        /// a valid idempotency key is to use a Universally unique
        /// identifier (UUID).
        /// If you're unsure whether a particular request was successful,
        /// you can reattempt it with the same idempotency key without
        /// worrying about creating duplicate objects.
        /// See [Idempotency](https://developer.squareup.com/docs/basics/api101/idempotency) for more information.
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

        /// <summary>
        /// The wrapper object for the Catalog entries of a given object type.
        /// The type of a particular `CatalogObject` is determined by the value of the
        /// `type` attribute and only the corresponding data attribute can be set on the `CatalogObject` instance.
        /// For example, the following list shows some instances of `CatalogObject` of a given `type` and
        /// their corresponding data attribute that can be set:
        /// - For a `CatalogObject` of the `ITEM` type, set the `item_data` attribute to yield the `CatalogItem` object.
        /// - For a `CatalogObject` of the `ITEM_VARIATION` type, set the `item_variation_data` attribute to yield the `CatalogItemVariation` object.
        /// - For a `CatalogObject` of the `MODIFIER` type, set the `modifier_data` attribute to yield the `CatalogModifier` object.
        /// - For a `CatalogObject` of the `MODIFIER_LIST` type, set the `modifier_list_data` attribute to yield the `CatalogModifierList` object.
        /// - For a `CatalogObject` of the `CATEGORY` type, set the `category_data` attribute to yield the `CatalogCategory` object.
        /// - For a `CatalogObject` of the `DISCOUNT` type, set the `discount_data` attribute to yield the `CatalogDiscount` object.
        /// - For a `CatalogObject` of the `TAX` type, set the `tax_data` attribute to yield the `CatalogTax` object.
        /// - For a `CatalogObject` of the `IMAGE` type, set the `image_data` attribute to yield the `CatalogImageData`  object.
        /// - For a `CatalogObject` of the `QUICK_AMOUNTS_SETTINGS` type, set the `quick_amounts_settings_data` attribute to yield the `CatalogQuickAmountsSettings` object.
        /// - For a `CatalogObject` of the `PRICING_RULE` type, set the `pricing_rule_data` attribute to yield the `CatalogPricingRule` object.
        /// - For a `CatalogObject` of the `TIME_PERIOD` type, set the `time_period_data` attribute to yield the `CatalogTimePeriod` object.
        /// - For a `CatalogObject` of the `PRODUCT_SET` type, set the `product_set_data` attribute to yield the `CatalogProductSet`  object.
        /// - For a `CatalogObject` of the `SUBSCRIPTION_PLAN` type, set the `subscription_plan_data` attribute to yield the `CatalogSubscriptionPlan` object.
        /// For a more detailed discussion of the Catalog data model, please see the
        /// [Design a Catalog](https://developer.squareup.com/docs/catalog-api/design-a-catalog) guide.
        /// </summary>
        [JsonProperty("object")]
        public Models.CatalogObject MObject { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"UpsertCatalogObjectRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is UpsertCatalogObjectRequest other &&
                ((this.IdempotencyKey == null && other.IdempotencyKey == null) || (this.IdempotencyKey?.Equals(other.IdempotencyKey) == true)) &&
                ((this.MObject == null && other.MObject == null) || (this.MObject?.Equals(other.MObject) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -153717407;

            if (this.IdempotencyKey != null)
            {
               hashCode += this.IdempotencyKey.GetHashCode();
            }

            if (this.MObject != null)
            {
               hashCode += this.MObject.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.IdempotencyKey = {(this.IdempotencyKey == null ? "null" : this.IdempotencyKey == string.Empty ? "" : this.IdempotencyKey)}");
            toStringOutput.Add($"this.MObject = {(this.MObject == null ? "null" : this.MObject.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.IdempotencyKey,
                this.MObject);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string idempotencyKey;
            private Models.CatalogObject mObject;

            public Builder(
                string idempotencyKey,
                Models.CatalogObject mObject)
            {
                this.idempotencyKey = idempotencyKey;
                this.mObject = mObject;
            }

             /// <summary>
             /// IdempotencyKey.
             /// </summary>
             /// <param name="idempotencyKey"> idempotencyKey. </param>
             /// <returns> Builder. </returns>
            public Builder IdempotencyKey(string idempotencyKey)
            {
                this.idempotencyKey = idempotencyKey;
                return this;
            }

             /// <summary>
             /// MObject.
             /// </summary>
             /// <param name="mObject"> mObject. </param>
             /// <returns> Builder. </returns>
            public Builder MObject(Models.CatalogObject mObject)
            {
                this.mObject = mObject;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> UpsertCatalogObjectRequest. </returns>
            public UpsertCatalogObjectRequest Build()
            {
                return new UpsertCatalogObjectRequest(
                    this.idempotencyKey,
                    this.mObject);
            }
        }
    }
}