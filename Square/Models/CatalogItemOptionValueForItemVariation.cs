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
    /// CatalogItemOptionValueForItemVariation.
    /// </summary>
    public class CatalogItemOptionValueForItemVariation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogItemOptionValueForItemVariation"/> class.
        /// </summary>
        /// <param name="itemOptionId">item_option_id.</param>
        /// <param name="itemOptionValueId">item_option_value_id.</param>
        public CatalogItemOptionValueForItemVariation(
            string itemOptionId = null,
            string itemOptionValueId = null)
        {
            this.ItemOptionId = itemOptionId;
            this.ItemOptionValueId = itemOptionValueId;
        }

        /// <summary>
        /// The unique id of an item option.
        /// </summary>
        [JsonProperty("item_option_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ItemOptionId { get; }

        /// <summary>
        /// The unique id of the selected value for the item option.
        /// </summary>
        [JsonProperty("item_option_value_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ItemOptionValueId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogItemOptionValueForItemVariation : ({string.Join(", ", toStringOutput)})";
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

            return obj is CatalogItemOptionValueForItemVariation other &&
                ((this.ItemOptionId == null && other.ItemOptionId == null) || (this.ItemOptionId?.Equals(other.ItemOptionId) == true)) &&
                ((this.ItemOptionValueId == null && other.ItemOptionValueId == null) || (this.ItemOptionValueId?.Equals(other.ItemOptionValueId) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -727857243;
            hashCode = HashCode.Combine(this.ItemOptionId, this.ItemOptionValueId);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.ItemOptionId = {(this.ItemOptionId == null ? "null" : this.ItemOptionId == string.Empty ? "" : this.ItemOptionId)}");
            toStringOutput.Add($"this.ItemOptionValueId = {(this.ItemOptionValueId == null ? "null" : this.ItemOptionValueId == string.Empty ? "" : this.ItemOptionValueId)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .ItemOptionId(this.ItemOptionId)
                .ItemOptionValueId(this.ItemOptionValueId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string itemOptionId;
            private string itemOptionValueId;

             /// <summary>
             /// ItemOptionId.
             /// </summary>
             /// <param name="itemOptionId"> itemOptionId. </param>
             /// <returns> Builder. </returns>
            public Builder ItemOptionId(string itemOptionId)
            {
                this.itemOptionId = itemOptionId;
                return this;
            }

             /// <summary>
             /// ItemOptionValueId.
             /// </summary>
             /// <param name="itemOptionValueId"> itemOptionValueId. </param>
             /// <returns> Builder. </returns>
            public Builder ItemOptionValueId(string itemOptionValueId)
            {
                this.itemOptionValueId = itemOptionValueId;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogItemOptionValueForItemVariation. </returns>
            public CatalogItemOptionValueForItemVariation Build()
            {
                return new CatalogItemOptionValueForItemVariation(
                    this.itemOptionId,
                    this.itemOptionValueId);
            }
        }
    }
}