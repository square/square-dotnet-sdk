
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"V1PaymentItemDetail : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"CategoryName = {(CategoryName == null ? "null" : CategoryName == string.Empty ? "" : CategoryName)}");
            toStringOutput.Add($"Sku = {(Sku == null ? "null" : Sku == string.Empty ? "" : Sku)}");
            toStringOutput.Add($"ItemId = {(ItemId == null ? "null" : ItemId == string.Empty ? "" : ItemId)}");
            toStringOutput.Add($"ItemVariationId = {(ItemVariationId == null ? "null" : ItemVariationId == string.Empty ? "" : ItemVariationId)}");
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

            return obj is V1PaymentItemDetail other &&
                ((CategoryName == null && other.CategoryName == null) || (CategoryName?.Equals(other.CategoryName) == true)) &&
                ((Sku == null && other.Sku == null) || (Sku?.Equals(other.Sku) == true)) &&
                ((ItemId == null && other.ItemId == null) || (ItemId?.Equals(other.ItemId) == true)) &&
                ((ItemVariationId == null && other.ItemVariationId == null) || (ItemVariationId?.Equals(other.ItemVariationId) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 1460876522;

            if (CategoryName != null)
            {
               hashCode += CategoryName.GetHashCode();
            }

            if (Sku != null)
            {
               hashCode += Sku.GetHashCode();
            }

            if (ItemId != null)
            {
               hashCode += ItemId.GetHashCode();
            }

            if (ItemVariationId != null)
            {
               hashCode += ItemVariationId.GetHashCode();
            }

            return hashCode;
        }

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