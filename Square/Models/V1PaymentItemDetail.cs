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
    /// V1PaymentItemDetail.
    /// </summary>
    public class V1PaymentItemDetail
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="V1PaymentItemDetail"/> class.
        /// </summary>
        /// <param name="categoryName">category_name.</param>
        /// <param name="sku">sku.</param>
        /// <param name="itemId">item_id.</param>
        /// <param name="itemVariationId">item_variation_id.</param>
        public V1PaymentItemDetail(
            string categoryName = null,
            string sku = null,
            string itemId = null,
            string itemVariationId = null)
        {
            this.CategoryName = categoryName;
            this.Sku = sku;
            this.ItemId = itemId;
            this.ItemVariationId = itemVariationId;
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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"V1PaymentItemDetail : ({string.Join(", ", toStringOutput)})";
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

            return obj is V1PaymentItemDetail other &&
                ((this.CategoryName == null && other.CategoryName == null) || (this.CategoryName?.Equals(other.CategoryName) == true)) &&
                ((this.Sku == null && other.Sku == null) || (this.Sku?.Equals(other.Sku) == true)) &&
                ((this.ItemId == null && other.ItemId == null) || (this.ItemId?.Equals(other.ItemId) == true)) &&
                ((this.ItemVariationId == null && other.ItemVariationId == null) || (this.ItemVariationId?.Equals(other.ItemVariationId) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1460876522;

            if (this.CategoryName != null)
            {
               hashCode += this.CategoryName.GetHashCode();
            }

            if (this.Sku != null)
            {
               hashCode += this.Sku.GetHashCode();
            }

            if (this.ItemId != null)
            {
               hashCode += this.ItemId.GetHashCode();
            }

            if (this.ItemVariationId != null)
            {
               hashCode += this.ItemVariationId.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.CategoryName = {(this.CategoryName == null ? "null" : this.CategoryName == string.Empty ? "" : this.CategoryName)}");
            toStringOutput.Add($"this.Sku = {(this.Sku == null ? "null" : this.Sku == string.Empty ? "" : this.Sku)}");
            toStringOutput.Add($"this.ItemId = {(this.ItemId == null ? "null" : this.ItemId == string.Empty ? "" : this.ItemId)}");
            toStringOutput.Add($"this.ItemVariationId = {(this.ItemVariationId == null ? "null" : this.ItemVariationId == string.Empty ? "" : this.ItemVariationId)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .CategoryName(this.CategoryName)
                .Sku(this.Sku)
                .ItemId(this.ItemId)
                .ItemVariationId(this.ItemVariationId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string categoryName;
            private string sku;
            private string itemId;
            private string itemVariationId;

             /// <summary>
             /// CategoryName.
             /// </summary>
             /// <param name="categoryName"> categoryName. </param>
             /// <returns> Builder. </returns>
            public Builder CategoryName(string categoryName)
            {
                this.categoryName = categoryName;
                return this;
            }

             /// <summary>
             /// Sku.
             /// </summary>
             /// <param name="sku"> sku. </param>
             /// <returns> Builder. </returns>
            public Builder Sku(string sku)
            {
                this.sku = sku;
                return this;
            }

             /// <summary>
             /// ItemId.
             /// </summary>
             /// <param name="itemId"> itemId. </param>
             /// <returns> Builder. </returns>
            public Builder ItemId(string itemId)
            {
                this.itemId = itemId;
                return this;
            }

             /// <summary>
             /// ItemVariationId.
             /// </summary>
             /// <param name="itemVariationId"> itemVariationId. </param>
             /// <returns> Builder. </returns>
            public Builder ItemVariationId(string itemVariationId)
            {
                this.itemVariationId = itemVariationId;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> V1PaymentItemDetail. </returns>
            public V1PaymentItemDetail Build()
            {
                return new V1PaymentItemDetail(
                    this.categoryName,
                    this.sku,
                    this.itemId,
                    this.itemVariationId);
            }
        }
    }
}