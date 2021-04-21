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
    /// CatalogQueryItemVariationsForItemOptionValues.
    /// </summary>
    public class CatalogQueryItemVariationsForItemOptionValues
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogQueryItemVariationsForItemOptionValues"/> class.
        /// </summary>
        /// <param name="itemOptionValueIds">item_option_value_ids.</param>
        public CatalogQueryItemVariationsForItemOptionValues(
            IList<string> itemOptionValueIds = null)
        {
            this.ItemOptionValueIds = itemOptionValueIds;
        }

        /// <summary>
        /// A set of `CatalogItemOptionValue` IDs to be used to find associated
        /// `CatalogItemVariation`s. All ItemVariations that contain all of the given
        /// Item Option Values (in any order) will be returned.
        /// </summary>
        [JsonProperty("item_option_value_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> ItemOptionValueIds { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogQueryItemVariationsForItemOptionValues : ({string.Join(", ", toStringOutput)})";
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

            return obj is CatalogQueryItemVariationsForItemOptionValues other &&
                ((this.ItemOptionValueIds == null && other.ItemOptionValueIds == null) || (this.ItemOptionValueIds?.Equals(other.ItemOptionValueIds) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 465531151;

            if (this.ItemOptionValueIds != null)
            {
               hashCode += this.ItemOptionValueIds.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.ItemOptionValueIds = {(this.ItemOptionValueIds == null ? "null" : $"[{string.Join(", ", this.ItemOptionValueIds)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .ItemOptionValueIds(this.ItemOptionValueIds);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<string> itemOptionValueIds;

             /// <summary>
             /// ItemOptionValueIds.
             /// </summary>
             /// <param name="itemOptionValueIds"> itemOptionValueIds. </param>
             /// <returns> Builder. </returns>
            public Builder ItemOptionValueIds(IList<string> itemOptionValueIds)
            {
                this.itemOptionValueIds = itemOptionValueIds;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogQueryItemVariationsForItemOptionValues. </returns>
            public CatalogQueryItemVariationsForItemOptionValues Build()
            {
                return new CatalogQueryItemVariationsForItemOptionValues(
                    this.itemOptionValueIds);
            }
        }
    }
}