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
    public class OrderLineItemPricingBlocklistsBlockedTax 
    {
        public OrderLineItemPricingBlocklistsBlockedTax(string uid = null,
            string taxUid = null,
            string taxCatalogObjectId = null)
        {
            Uid = uid;
            TaxUid = taxUid;
            TaxCatalogObjectId = taxCatalogObjectId;
        }

        /// <summary>
        /// Unique ID of the `BlockedTax` within the order.
        /// </summary>
        [JsonProperty("uid", NullValueHandling = NullValueHandling.Ignore)]
        public string Uid { get; }

        /// <summary>
        /// The `uid` of the tax that should be blocked. Use this field to block 
        /// ad-hoc taxes. For catalog taxes use the `tax_catalog_object_id` field.
        /// </summary>
        [JsonProperty("tax_uid", NullValueHandling = NullValueHandling.Ignore)]
        public string TaxUid { get; }

        /// <summary>
        /// The `catalog_object_id` of the tax that should be blocked. 
        /// Use this field to block catalog taxes. For ad-hoc taxes use the 
        /// `tax_uid` field.
        /// </summary>
        [JsonProperty("tax_catalog_object_id", NullValueHandling = NullValueHandling.Ignore)]
        public string TaxCatalogObjectId { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Uid(Uid)
                .TaxUid(TaxUid)
                .TaxCatalogObjectId(TaxCatalogObjectId);
            return builder;
        }

        public class Builder
        {
            private string uid;
            private string taxUid;
            private string taxCatalogObjectId;



            public Builder Uid(string uid)
            {
                this.uid = uid;
                return this;
            }

            public Builder TaxUid(string taxUid)
            {
                this.taxUid = taxUid;
                return this;
            }

            public Builder TaxCatalogObjectId(string taxCatalogObjectId)
            {
                this.taxCatalogObjectId = taxCatalogObjectId;
                return this;
            }

            public OrderLineItemPricingBlocklistsBlockedTax Build()
            {
                return new OrderLineItemPricingBlocklistsBlockedTax(uid,
                    taxUid,
                    taxCatalogObjectId);
            }
        }
    }
}