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
    public class OrderLineItemPricingBlocklistsBlockedDiscount 
    {
        public OrderLineItemPricingBlocklistsBlockedDiscount(string uid = null,
            string discountUid = null,
            string discountCatalogObjectId = null)
        {
            Uid = uid;
            DiscountUid = discountUid;
            DiscountCatalogObjectId = discountCatalogObjectId;
        }

        /// <summary>
        /// Unique ID of the `BlockedDiscount` within the order.
        /// </summary>
        [JsonProperty("uid", NullValueHandling = NullValueHandling.Ignore)]
        public string Uid { get; }

        /// <summary>
        /// The `uid` of the discount that should be blocked. Use this field to block 
        /// ad-hoc discounts. For catalog discounts use the `discount_catalog_object_id` field.
        /// </summary>
        [JsonProperty("discount_uid", NullValueHandling = NullValueHandling.Ignore)]
        public string DiscountUid { get; }

        /// <summary>
        /// The `catalog_object_id` of the discount that should be blocked. 
        /// Use this field to block catalog discounts. For ad-hoc discounts use the 
        /// `discount_uid` field.
        /// </summary>
        [JsonProperty("discount_catalog_object_id", NullValueHandling = NullValueHandling.Ignore)]
        public string DiscountCatalogObjectId { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Uid(Uid)
                .DiscountUid(DiscountUid)
                .DiscountCatalogObjectId(DiscountCatalogObjectId);
            return builder;
        }

        public class Builder
        {
            private string uid;
            private string discountUid;
            private string discountCatalogObjectId;



            public Builder Uid(string uid)
            {
                this.uid = uid;
                return this;
            }

            public Builder DiscountUid(string discountUid)
            {
                this.discountUid = discountUid;
                return this;
            }

            public Builder DiscountCatalogObjectId(string discountCatalogObjectId)
            {
                this.discountCatalogObjectId = discountCatalogObjectId;
                return this;
            }

            public OrderLineItemPricingBlocklistsBlockedDiscount Build()
            {
                return new OrderLineItemPricingBlocklistsBlockedDiscount(uid,
                    discountUid,
                    discountCatalogObjectId);
            }
        }
    }
}