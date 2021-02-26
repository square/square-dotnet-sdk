
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
    public class CatalogQueryItemVariationsForItemOptionValues 
    {
        public CatalogQueryItemVariationsForItemOptionValues(IList<string> itemOptionValueIds = null)
        {
            ItemOptionValueIds = itemOptionValueIds;
        }

        /// <summary>
        /// A set of `CatalogItemOptionValue` IDs to be used to find associated
        /// `CatalogItemVariation`s. All ItemVariations that contain all of the given
        /// Item Option Values (in any order) will be returned.
        /// </summary>
        [JsonProperty("item_option_value_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> ItemOptionValueIds { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogQueryItemVariationsForItemOptionValues : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"ItemOptionValueIds = {(ItemOptionValueIds == null ? "null" : $"[{ string.Join(", ", ItemOptionValueIds)} ]")}");
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

            return obj is CatalogQueryItemVariationsForItemOptionValues other &&
                ((ItemOptionValueIds == null && other.ItemOptionValueIds == null) || (ItemOptionValueIds?.Equals(other.ItemOptionValueIds) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 465531151;

            if (ItemOptionValueIds != null)
            {
               hashCode += ItemOptionValueIds.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .ItemOptionValueIds(ItemOptionValueIds);
            return builder;
        }

        public class Builder
        {
            private IList<string> itemOptionValueIds;



            public Builder ItemOptionValueIds(IList<string> itemOptionValueIds)
            {
                this.itemOptionValueIds = itemOptionValueIds;
                return this;
            }

            public CatalogQueryItemVariationsForItemOptionValues Build()
            {
                return new CatalogQueryItemVariationsForItemOptionValues(itemOptionValueIds);
            }
        }
    }
}