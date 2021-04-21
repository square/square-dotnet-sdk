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
    using Square.Http.Client;
    using Square.Utilities;

    /// <summary>
    /// RetrieveCatalogObjectResponse.
    /// </summary>
    public class RetrieveCatalogObjectResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RetrieveCatalogObjectResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="mObject">object.</param>
        /// <param name="relatedObjects">related_objects.</param>
        public RetrieveCatalogObjectResponse(
            IList<Models.Error> errors = null,
            Models.CatalogObject mObject = null,
            IList<Models.CatalogObject> relatedObjects = null)
        {
            this.Errors = errors;
            this.MObject = mObject;
            this.RelatedObjects = relatedObjects;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

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
        [JsonProperty("object", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CatalogObject MObject { get; }

        /// <summary>
        /// A list of `CatalogObject`s referenced by the object in the `object` field.
        /// </summary>
        [JsonProperty("related_objects", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.CatalogObject> RelatedObjects { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"RetrieveCatalogObjectResponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is RetrieveCatalogObjectResponse other &&
                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true)) &&
                ((this.MObject == null && other.MObject == null) || (this.MObject?.Equals(other.MObject) == true)) &&
                ((this.RelatedObjects == null && other.RelatedObjects == null) || (this.RelatedObjects?.Equals(other.RelatedObjects) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1437875617;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }

            if (this.Errors != null)
            {
               hashCode += this.Errors.GetHashCode();
            }

            if (this.MObject != null)
            {
               hashCode += this.MObject.GetHashCode();
            }

            if (this.RelatedObjects != null)
            {
               hashCode += this.RelatedObjects.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
            toStringOutput.Add($"this.MObject = {(this.MObject == null ? "null" : this.MObject.ToString())}");
            toStringOutput.Add($"this.RelatedObjects = {(this.RelatedObjects == null ? "null" : $"[{string.Join(", ", this.RelatedObjects)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(this.Errors)
                .MObject(this.MObject)
                .RelatedObjects(this.RelatedObjects);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private Models.CatalogObject mObject;
            private IList<Models.CatalogObject> relatedObjects;

             /// <summary>
             /// Errors.
             /// </summary>
             /// <param name="errors"> errors. </param>
             /// <returns> Builder. </returns>
            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
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
             /// RelatedObjects.
             /// </summary>
             /// <param name="relatedObjects"> relatedObjects. </param>
             /// <returns> Builder. </returns>
            public Builder RelatedObjects(IList<Models.CatalogObject> relatedObjects)
            {
                this.relatedObjects = relatedObjects;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> RetrieveCatalogObjectResponse. </returns>
            public RetrieveCatalogObjectResponse Build()
            {
                return new RetrieveCatalogObjectResponse(
                    this.errors,
                    this.mObject,
                    this.relatedObjects);
            }
        }
    }
}