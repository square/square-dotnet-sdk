
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
    public class CatalogQueryItemsForItemOptions 
    {
        public CatalogQueryItemsForItemOptions(IList<string> itemOptionIds = null)
        {
            ItemOptionIds = itemOptionIds;
        }

        /// <summary>
        /// A set of `CatalogItemOption` IDs to be used to find associated
        /// `CatalogItem`s. All Items that contain all of the given Item Options (in any order)
        /// will be returned.
        /// </summary>
        [JsonProperty("item_option_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> ItemOptionIds { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogQueryItemsForItemOptions : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"ItemOptionIds = {(ItemOptionIds == null ? "null" : $"[{ string.Join(", ", ItemOptionIds)} ]")}");
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

            return obj is CatalogQueryItemsForItemOptions other &&
                ((ItemOptionIds == null && other.ItemOptionIds == null) || (ItemOptionIds?.Equals(other.ItemOptionIds) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 447703827;

            if (ItemOptionIds != null)
            {
               hashCode += ItemOptionIds.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .ItemOptionIds(ItemOptionIds);
            return builder;
        }

        public class Builder
        {
            private IList<string> itemOptionIds;



            public Builder ItemOptionIds(IList<string> itemOptionIds)
            {
                this.itemOptionIds = itemOptionIds;
                return this;
            }

            public CatalogQueryItemsForItemOptions Build()
            {
                return new CatalogQueryItemsForItemOptions(itemOptionIds);
            }
        }
    }
}