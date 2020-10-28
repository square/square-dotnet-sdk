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
    public class V1PaymentItemDetail 
    {
        public V1PaymentItemDetail(string categoryName = null,
            string sku = null,
            string itemId = null,
            string itemVariationId = null)
        {
            CategoryName = categoryName;
            Sku = sku;
            ItemId = itemId;
            ItemVariationId = itemVariationId;
        }

        /// <summary>
        /// The name of the item's merchant-defined category, if any.
        /// </summary>
        [JsonProperty("category_name", NullValueHandling = NullValueHandling.Ignore)]
        public string CategoryName { get; }

        /// <summary>
        /// The item's merchant-defined SKU, if any.
        /// </summary>
        [JsonProperty("sku", NullValueHandling = NullValueHandling.Ignore)]
        public string Sku { get; }

        /// <summary>
        /// The unique ID of the item purchased, if any.
        /// </summary>
        [JsonProperty("item_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ItemId { get; }

        /// <summary>
        /// The unique ID of the item variation purchased, if any.
        /// </summary>
        [JsonProperty("item_variation_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ItemVariationId { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .CategoryName(CategoryName)
                .Sku(Sku)
                .ItemId(ItemId)
                .ItemVariationId(ItemVariationId);
            return builder;
        }

        public class Builder
        {
            private string categoryName;
            private string sku;
            private string itemId;
            private string itemVariationId;



            public Builder CategoryName(string categoryName)
            {
                this.categoryName = categoryName;
                return this;
            }

            public Builder Sku(string sku)
            {
                this.sku = sku;
                return this;
            }

            public Builder ItemId(string itemId)
            {
                this.itemId = itemId;
                return this;
            }

            public Builder ItemVariationId(string itemVariationId)
            {
                this.itemVariationId = itemVariationId;
                return this;
            }

            public V1PaymentItemDetail Build()
            {
                return new V1PaymentItemDetail(categoryName,
                    sku,
                    itemId,
                    itemVariationId);
            }
        }
    }
}