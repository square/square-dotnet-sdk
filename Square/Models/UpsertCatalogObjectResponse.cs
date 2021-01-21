using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square.Http.Client;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class UpsertCatalogObjectResponse 
    {
        public UpsertCatalogObjectResponse(IList<Models.Error> errors = null,
            Models.CatalogObject catalogObject = null,
            IList<Models.CatalogIdMapping> idMappings = null)
        {
            Errors = errors;
            CatalogObject = catalogObject;
            IdMappings = idMappings;
        }

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

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors)
                .CatalogObject(CatalogObject)
                .IdMappings(IdMappings);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors;
            private Models.CatalogObject catalogObject;
            private IList<Models.CatalogIdMapping> idMappings;



            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            public Builder CatalogObject(Models.CatalogObject catalogObject)
            {
                this.catalogObject = catalogObject;
                return this;
            }

            public Builder IdMappings(IList<Models.CatalogIdMapping> idMappings)
            {
                this.idMappings = idMappings;
                return this;
            }

            public UpsertCatalogObjectResponse Build()
            {
                return new UpsertCatalogObjectResponse(errors,
                    catalogObject,
                    idMappings);
            }
        }
    }
}