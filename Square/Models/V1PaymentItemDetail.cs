namespace Square.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using APIMatic.Core.Utilities.Converters;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Utilities;

    /// <summary>
    /// V1PaymentItemDetail.
    /// </summary>
    public class V1PaymentItemDetail
    {
        private readonly Dictionary<string, bool> shouldSerialize;
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
            shouldSerialize = new Dictionary<string, bool>
            {
                { "category_name", false },
                { "sku", false },
                { "item_id", false },
                { "item_variation_id", false }
            };

            if (categoryName != null)
            {
                shouldSerialize["category_name"] = true;
                this.CategoryName = categoryName;
            }

            if (sku != null)
            {
                shouldSerialize["sku"] = true;
                this.Sku = sku;
            }

            if (itemId != null)
            {
                shouldSerialize["item_id"] = true;
                this.ItemId = itemId;
            }

            if (itemVariationId != null)
            {
                shouldSerialize["item_variation_id"] = true;
                this.ItemVariationId = itemVariationId;
            }

        }
        internal V1PaymentItemDetail(Dictionary<string, bool> shouldSerialize,
            string categoryName = null,
            string sku = null,
            string itemId = null,
            string itemVariationId = null)
        {
            this.shouldSerialize = shouldSerialize;
            CategoryName = categoryName;
            Sku = sku;
            ItemId = itemId;
            ItemVariationId = itemVariationId;
        }

        /// <summary>
        /// The name of the item's merchant-defined category, if any.
        /// </summary>
        [JsonProperty("category_name")]
        public string CategoryName { get; }

        /// <summary>
        /// The item's merchant-defined SKU, if any.
        /// </summary>
        [JsonProperty("sku")]
        public string Sku { get; }

        /// <summary>
        /// The unique ID of the item purchased, if any.
        /// </summary>
        [JsonProperty("item_id")]
        public string ItemId { get; }

        /// <summary>
        /// The unique ID of the item variation purchased, if any.
        /// </summary>
        [JsonProperty("item_variation_id")]
        public string ItemVariationId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"V1PaymentItemDetail : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCategoryName()
        {
            return this.shouldSerialize["category_name"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSku()
        {
            return this.shouldSerialize["sku"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeItemId()
        {
            return this.shouldSerialize["item_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeItemVariationId()
        {
            return this.shouldSerialize["item_variation_id"];
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
            return obj is V1PaymentItemDetail other &&                ((this.CategoryName == null && other.CategoryName == null) || (this.CategoryName?.Equals(other.CategoryName) == true)) &&
                ((this.Sku == null && other.Sku == null) || (this.Sku?.Equals(other.Sku) == true)) &&
                ((this.ItemId == null && other.ItemId == null) || (this.ItemId?.Equals(other.ItemId) == true)) &&
                ((this.ItemVariationId == null && other.ItemVariationId == null) || (this.ItemVariationId?.Equals(other.ItemVariationId) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1460876522;
            hashCode = HashCode.Combine(this.CategoryName, this.Sku, this.ItemId, this.ItemVariationId);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.CategoryName = {(this.CategoryName == null ? "null" : this.CategoryName)}");
            toStringOutput.Add($"this.Sku = {(this.Sku == null ? "null" : this.Sku)}");
            toStringOutput.Add($"this.ItemId = {(this.ItemId == null ? "null" : this.ItemId)}");
            toStringOutput.Add($"this.ItemVariationId = {(this.ItemVariationId == null ? "null" : this.ItemVariationId)}");
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
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "category_name", false },
                { "sku", false },
                { "item_id", false },
                { "item_variation_id", false },
            };

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
                shouldSerialize["category_name"] = true;
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
                shouldSerialize["sku"] = true;
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
                shouldSerialize["item_id"] = true;
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
                shouldSerialize["item_variation_id"] = true;
                this.itemVariationId = itemVariationId;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetCategoryName()
            {
                this.shouldSerialize["category_name"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetSku()
            {
                this.shouldSerialize["sku"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetItemId()
            {
                this.shouldSerialize["item_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetItemVariationId()
            {
                this.shouldSerialize["item_variation_id"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> V1PaymentItemDetail. </returns>
            public V1PaymentItemDetail Build()
            {
                return new V1PaymentItemDetail(shouldSerialize,
                    this.categoryName,
                    this.sku,
                    this.itemId,
                    this.itemVariationId);
            }
        }
    }
}