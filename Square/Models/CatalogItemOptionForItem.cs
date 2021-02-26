
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
    public class CatalogItemOptionForItem 
    {
        public CatalogItemOptionForItem(string itemOptionId = null)
        {
            ItemOptionId = itemOptionId;
        }

        /// <summary>
        /// The unique id of the item option, used to form the dimensions of the item option matrix in a specified order.
        /// </summary>
        [JsonProperty("item_option_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ItemOptionId { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogItemOptionForItem : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"ItemOptionId = {(ItemOptionId == null ? "null" : ItemOptionId == string.Empty ? "" : ItemOptionId)}");
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

            return obj is CatalogItemOptionForItem other &&
                ((ItemOptionId == null && other.ItemOptionId == null) || (ItemOptionId?.Equals(other.ItemOptionId) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 1801897765;

            if (ItemOptionId != null)
            {
               hashCode += ItemOptionId.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .ItemOptionId(ItemOptionId);
            return builder;
        }

        public class Builder
        {
            private string itemOptionId;



            public Builder ItemOptionId(string itemOptionId)
            {
                this.itemOptionId = itemOptionId;
                return this;
            }

            public CatalogItemOptionForItem Build()
            {
                return new CatalogItemOptionForItem(itemOptionId);
            }
        }
    }
}