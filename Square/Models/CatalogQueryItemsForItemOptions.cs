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
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogQueryItemsForItemOptions"/> class.
        /// </summary>
        /// <param name="itemOptionIds">item_option_ids.</param>
        public CatalogQueryItemsForItemOptions(
            IList<string> itemOptionIds = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "item_option_ids", false }
            };

            if (itemOptionIds != null)
            {
                shouldSerialize["item_option_ids"] = true;
                this.ItemOptionIds = itemOptionIds;
            }

        }
        internal CatalogQueryItemsForItemOptions(Dictionary<string, bool> shouldSerialize,
            IList<string> itemOptionIds = null)
        {
            this.shouldSerialize = shouldSerialize;
            ItemOptionIds = itemOptionIds;
        }

        /// <summary>
        /// A set of `CatalogItemOption` IDs to be used to find associated
        /// `CatalogItem`s. All Items that contain all of the given Item Options (in any order)
        /// will be returned.
        /// </summary>
        [JsonProperty("item_option_ids")]
        public IList<string> ItemOptionIds { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogQueryItemsForItemOptions : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeItemOptionIds()
        {
            return this.shouldSerialize["item_option_ids"];
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
            return obj is CatalogQueryItemsForItemOptions other &&                ((this.ItemOptionIds == null && other.ItemOptionIds == null) || (this.ItemOptionIds?.Equals(other.ItemOptionIds) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 447703827;
            hashCode = HashCode.Combine(this.ItemOptionIds);

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
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "item_option_ids", false },
            };

            private IList<string> itemOptionIds;

             /// <summary>
             /// ItemOptionIds.
             /// </summary>
             /// <param name="itemOptionIds"> itemOptionIds. </param>
             /// <returns> Builder. </returns>
            public Builder ItemOptionIds(IList<string> itemOptionIds)
            {
                shouldSerialize["item_option_ids"] = true;
                this.itemOptionIds = itemOptionIds;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetItemOptionIds()
            {
                this.shouldSerialize["item_option_ids"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogQueryItemsForItemOptions. </returns>
            public CatalogQueryItemsForItemOptions Build()
            {
                return new CatalogQueryItemsForItemOptions(shouldSerialize,
                    this.itemOptionIds);
            }
        }
    }
}