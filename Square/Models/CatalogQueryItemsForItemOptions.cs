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
    /// CatalogQueryItemsForItemOptions.
    /// </summary>
    public class CatalogQueryItemsForItemOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogQueryItemsForItemOptions"/> class.
        /// </summary>
        /// <param name="itemOptionIds">item_option_ids.</param>
        public CatalogQueryItemsForItemOptions(
            IList<string> itemOptionIds = null)
        {
            this.ItemOptionIds = itemOptionIds;
        }

        /// <summary>
        /// A set of `CatalogItemOption` IDs to be used to find associated
        /// `CatalogItem`s. All Items that contain all of the given Item Options (in any order)
        /// will be returned.
        /// </summary>
        [JsonProperty("item_option_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> ItemOptionIds { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogQueryItemsForItemOptions : ({string.Join(", ", toStringOutput)})";
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

            return obj is CatalogQueryItemsForItemOptions other &&
                ((this.ItemOptionIds == null && other.ItemOptionIds == null) || (this.ItemOptionIds?.Equals(other.ItemOptionIds) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 447703827;

            if (this.ItemOptionIds != null)
            {
               hashCode += this.ItemOptionIds.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.ItemOptionIds = {(this.ItemOptionIds == null ? "null" : $"[{string.Join(", ", this.ItemOptionIds)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .ItemOptionIds(this.ItemOptionIds);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<string> itemOptionIds;

             /// <summary>
             /// ItemOptionIds.
             /// </summary>
             /// <param name="itemOptionIds"> itemOptionIds. </param>
             /// <returns> Builder. </returns>
            public Builder ItemOptionIds(IList<string> itemOptionIds)
            {
                this.itemOptionIds = itemOptionIds;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogQueryItemsForItemOptions. </returns>
            public CatalogQueryItemsForItemOptions Build()
            {
                return new CatalogQueryItemsForItemOptions(
                    this.itemOptionIds);
            }
        }
    }
}