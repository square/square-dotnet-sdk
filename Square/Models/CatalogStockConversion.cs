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
    /// CatalogStockConversion.
    /// </summary>
    public class CatalogStockConversion
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogStockConversion"/> class.
        /// </summary>
        /// <param name="stockableItemVariationId">stockable_item_variation_id.</param>
        /// <param name="stockableQuantity">stockable_quantity.</param>
        /// <param name="nonstockableQuantity">nonstockable_quantity.</param>
        public CatalogStockConversion(
            string stockableItemVariationId,
            string stockableQuantity,
            string nonstockableQuantity)
        {
            this.StockableItemVariationId = stockableItemVariationId;
            this.StockableQuantity = stockableQuantity;
            this.NonstockableQuantity = nonstockableQuantity;
        }

        /// <summary>
        /// References to the stockable [CatalogItemVariation](entity:CatalogItemVariation)
        /// for this stock conversion. Selling, receiving or recounting the non-stockable `CatalogItemVariation`
        /// defined with a stock conversion results in adjustments of this stockable `CatalogItemVariation`.
        /// This immutable field must reference a stockable `CatalogItemVariation`
        /// that shares the parent [CatalogItem](entity:CatalogItem) of the converted `CatalogItemVariation.`
        /// </summary>
        [JsonProperty("stockable_item_variation_id")]
        public string StockableItemVariationId { get; }

        /// <summary>
        /// The quantity of the stockable item variation (as identified by `stockable_item_variation_id`)
        /// equivalent to the non-stockable item variation quantity (as specified in `nonstockable_quantity`)
        /// as defined by this stock conversion.  It accepts a decimal number in a string format that can take
        /// up to 10 digits before the decimal point and up to 5 digits after the decimal point.
        /// </summary>
        [JsonProperty("stockable_quantity")]
        public string StockableQuantity { get; }

        /// <summary>
        /// The converted equivalent quantity of the non-stockable [CatalogItemVariation](entity:CatalogItemVariation)
        /// in its measurement unit. The `stockable_quantity` value and this `nonstockable_quantity` value together
        /// define the conversion ratio between stockable item variation and the non-stockable item variation.
        /// It accepts a decimal number in a string format that can take up to 10 digits before the decimal point
        /// and up to 5 digits after the decimal point.
        /// </summary>
        [JsonProperty("nonstockable_quantity")]
        public string NonstockableQuantity { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogStockConversion : ({string.Join(", ", toStringOutput)})";
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
            return obj is CatalogStockConversion other &&                ((this.StockableItemVariationId == null && other.StockableItemVariationId == null) || (this.StockableItemVariationId?.Equals(other.StockableItemVariationId) == true)) &&
                ((this.StockableQuantity == null && other.StockableQuantity == null) || (this.StockableQuantity?.Equals(other.StockableQuantity) == true)) &&
                ((this.NonstockableQuantity == null && other.NonstockableQuantity == null) || (this.NonstockableQuantity?.Equals(other.NonstockableQuantity) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -670296029;
            hashCode = HashCode.Combine(this.StockableItemVariationId, this.StockableQuantity, this.NonstockableQuantity);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.StockableItemVariationId = {(this.StockableItemVariationId == null ? "null" : this.StockableItemVariationId)}");
            toStringOutput.Add($"this.StockableQuantity = {(this.StockableQuantity == null ? "null" : this.StockableQuantity)}");
            toStringOutput.Add($"this.NonstockableQuantity = {(this.NonstockableQuantity == null ? "null" : this.NonstockableQuantity)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.StockableItemVariationId,
                this.StockableQuantity,
                this.NonstockableQuantity);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string stockableItemVariationId;
            private string stockableQuantity;
            private string nonstockableQuantity;

            /// <summary>
            /// Initialize Builder for CatalogStockConversion.
            /// </summary>
            /// <param name="stockableItemVariationId"> stockableItemVariationId. </param>
            /// <param name="stockableQuantity"> stockableQuantity. </param>
            /// <param name="nonstockableQuantity"> nonstockableQuantity. </param>
            public Builder(
                string stockableItemVariationId,
                string stockableQuantity,
                string nonstockableQuantity)
            {
                this.stockableItemVariationId = stockableItemVariationId;
                this.stockableQuantity = stockableQuantity;
                this.nonstockableQuantity = nonstockableQuantity;
            }

             /// <summary>
             /// StockableItemVariationId.
             /// </summary>
             /// <param name="stockableItemVariationId"> stockableItemVariationId. </param>
             /// <returns> Builder. </returns>
            public Builder StockableItemVariationId(string stockableItemVariationId)
            {
                this.stockableItemVariationId = stockableItemVariationId;
                return this;
            }

             /// <summary>
             /// StockableQuantity.
             /// </summary>
             /// <param name="stockableQuantity"> stockableQuantity. </param>
             /// <returns> Builder. </returns>
            public Builder StockableQuantity(string stockableQuantity)
            {
                this.stockableQuantity = stockableQuantity;
                return this;
            }

             /// <summary>
             /// NonstockableQuantity.
             /// </summary>
             /// <param name="nonstockableQuantity"> nonstockableQuantity. </param>
             /// <returns> Builder. </returns>
            public Builder NonstockableQuantity(string nonstockableQuantity)
            {
                this.nonstockableQuantity = nonstockableQuantity;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogStockConversion. </returns>
            public CatalogStockConversion Build()
            {
                return new CatalogStockConversion(
                    this.stockableItemVariationId,
                    this.stockableQuantity,
                    this.nonstockableQuantity);
            }
        }
    }
}