
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
    public class CreateCatalogImageRequest 
    {
        public CreateCatalogImageRequest(string idempotencyKey,
            string objectId = null,
            Models.CatalogObject image = null)
        {
            IdempotencyKey = idempotencyKey;
            ObjectId = objectId;
            Image = image;
        }

        /// <summary>
        /// A unique string that identifies this CreateCatalogImage request.
        /// Keys can be any valid string but must be unique for every CreateCatalogImage request.
        /// See [Idempotency keys](https://developer.squareup.com/docs/basics/api101/idempotency) for more information.
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

        /// <summary>
        /// Unique ID of the `CatalogObject` to attach to this `CatalogImage`. Leave this
        /// field empty to create unattached images, for example if you are building an integration
        /// where these images can be attached to catalog items at a later time.
        /// </summary>
        [JsonProperty("object_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ObjectId { get; }

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
        [JsonProperty("image", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CatalogObject Image { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreateCatalogImageRequest : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"IdempotencyKey = {(IdempotencyKey == null ? "null" : IdempotencyKey == string.Empty ? "" : IdempotencyKey)}");
            toStringOutput.Add($"ObjectId = {(ObjectId == null ? "null" : ObjectId == string.Empty ? "" : ObjectId)}");
            toStringOutput.Add($"Image = {(Image == null ? "null" : Image.ToString())}");
        }

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

            return obj is CreateCatalogImageRequest other &&
                ((IdempotencyKey == null && other.IdempotencyKey == null) || (IdempotencyKey?.Equals(other.IdempotencyKey) == true)) &&
                ((ObjectId == null && other.ObjectId == null) || (ObjectId?.Equals(other.ObjectId) == true)) &&
                ((Image == null && other.Image == null) || (Image?.Equals(other.Image) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 1867152760;

            if (IdempotencyKey != null)
            {
               hashCode += IdempotencyKey.GetHashCode();
            }

            if (ObjectId != null)
            {
               hashCode += ObjectId.GetHashCode();
            }

            if (Image != null)
            {
               hashCode += Image.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder(IdempotencyKey)
                .ObjectId(ObjectId)
                .Image(Image);
            return builder;
        }

        public class Builder
        {
            private string idempotencyKey;
            private string objectId;
            private Models.CatalogObject image;

            public Builder(string idempotencyKey)
            {
                this.idempotencyKey = idempotencyKey;
            }

            public Builder IdempotencyKey(string idempotencyKey)
            {
                this.idempotencyKey = idempotencyKey;
                return this;
            }

            public Builder ObjectId(string objectId)
            {
                this.objectId = objectId;
                return this;
            }

            public Builder Image(Models.CatalogObject image)
            {
                this.image = image;
                return this;
            }

            public CreateCatalogImageRequest Build()
            {
                return new CreateCatalogImageRequest(idempotencyKey,
                    objectId,
                    image);
            }
        }
    }
}