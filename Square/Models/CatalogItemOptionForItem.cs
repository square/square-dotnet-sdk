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
    /// CatalogItemOptionForItem.
    /// </summary>
    public class CatalogItemOptionForItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogItemOptionForItem"/> class.
        /// </summary>
        /// <param name="itemOptionId">item_option_id.</param>
        public CatalogItemOptionForItem(
            string itemOptionId = null)
        {
            this.ItemOptionId = itemOptionId;
        }

        /// <summary>
        /// The unique id of the item option, used to form the dimensions of the item option matrix in a specified order.
        /// </summary>
        [JsonProperty("item_option_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ItemOptionId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogItemOptionForItem : ({string.Join(", ", toStringOutput)})";
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

            return obj is CatalogItemOptionForItem other &&
                ((this.ItemOptionId == null && other.ItemOptionId == null) || (this.ItemOptionId?.Equals(other.ItemOptionId) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1801897765;

            if (this.ItemOptionId != null)
            {
               hashCode += this.ItemOptionId.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.ItemOptionId = {(this.ItemOptionId == null ? "null" : this.ItemOptionId == string.Empty ? "" : this.ItemOptionId)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .ItemOptionId(this.ItemOptionId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string itemOptionId;

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
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogItemOptionForItem. </returns>
            public CatalogItemOptionForItem Build()
            {
                return new CatalogItemOptionForItem(
                    this.itemOptionId);
            }
        }
    }
}