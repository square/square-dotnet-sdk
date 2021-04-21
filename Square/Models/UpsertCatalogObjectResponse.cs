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
    /// UpsertCatalogObjectResponse.
    /// </summary>
    public class UpsertCatalogObjectResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpsertCatalogObjectResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="catalogObject">catalog_object.</param>
        /// <param name="idMappings">id_mappings.</param>
        public UpsertCatalogObjectResponse(
            IList<Models.Error> errors = null,
            Models.CatalogObject catalogObject = null,
            IList<Models.CatalogIdMapping> idMappings = null)
        {
            this.Errors = errors;
            this.CatalogObject = catalogObject;
            this.IdMappings = idMappings;
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
        [JsonProperty("catalog_object", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CatalogObject CatalogObject { get; }

        /// <summary>
        /// The mapping between client and server IDs for this upsert.
        /// </summary>
        [JsonProperty("id_mappings", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.CatalogIdMapping> IdMappings { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"UpsertCatalogObjectResponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is UpsertCatalogObjectResponse other &&
                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true)) &&
                ((this.CatalogObject == null && other.CatalogObject == null) || (this.CatalogObject?.Equals(other.CatalogObject) == true)) &&
                ((this.IdMappings == null && other.IdMappings == null) || (this.IdMappings?.Equals(other.IdMappings) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -133578961;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }

            if (this.Errors != null)
            {
               hashCode += this.Errors.GetHashCode();
            }

            if (this.CatalogObject != null)
            {
               hashCode += this.CatalogObject.GetHashCode();
            }

            if (this.IdMappings != null)
            {
               hashCode += this.IdMappings.GetHashCode();
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
            toStringOutput.Add($"this.CatalogObject = {(this.CatalogObject == null ? "null" : this.CatalogObject.ToString())}");
            toStringOutput.Add($"this.IdMappings = {(this.IdMappings == null ? "null" : $"[{string.Join(", ", this.IdMappings)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(this.Errors)
                .CatalogObject(this.CatalogObject)
                .IdMappings(this.IdMappings);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private Models.CatalogObject catalogObject;
            private IList<Models.CatalogIdMapping> idMappings;

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
             /// CatalogObject.
             /// </summary>
             /// <param name="catalogObject"> catalogObject. </param>
             /// <returns> Builder. </returns>
            public Builder CatalogObject(Models.CatalogObject catalogObject)
            {
                this.catalogObject = catalogObject;
                return this;
            }

             /// <summary>
             /// IdMappings.
             /// </summary>
             /// <param name="idMappings"> idMappings. </param>
             /// <returns> Builder. </returns>
            public Builder IdMappings(IList<Models.CatalogIdMapping> idMappings)
            {
                this.idMappings = idMappings;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> UpsertCatalogObjectResponse. </returns>
            public UpsertCatalogObjectResponse Build()
            {
                return new UpsertCatalogObjectResponse(
                    this.errors,
                    this.catalogObject,
                    this.idMappings);
            }
        }
    }
}