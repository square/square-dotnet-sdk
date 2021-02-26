
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
    public class CatalogItemOptionValueForItemVariation 
    {
        public CatalogItemOptionValueForItemVariation(string itemOptionId = null,
            string itemOptionValueId = null)
        {
            ItemOptionId = itemOptionId;
            ItemOptionValueId = itemOptionValueId;
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogItemOptionValueForItemVariation : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"ItemOptionId = {(ItemOptionId == null ? "null" : ItemOptionId == string.Empty ? "" : ItemOptionId)}");
            toStringOutput.Add($"ItemOptionValueId = {(ItemOptionValueId == null ? "null" : ItemOptionValueId == string.Empty ? "" : ItemOptionValueId)}");
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

            return obj is CatalogItemOptionValueForItemVariation other &&
                ((ItemOptionId == null && other.ItemOptionId == null) || (ItemOptionId?.Equals(other.ItemOptionId) == true)) &&
                ((ItemOptionValueId == null && other.ItemOptionValueId == null) || (ItemOptionValueId?.Equals(other.ItemOptionValueId) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -727857243;

            if (ItemOptionId != null)
            {
               hashCode += ItemOptionId.GetHashCode();
            }

            if (ItemOptionValueId != null)
            {
               hashCode += ItemOptionValueId.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .ItemOptionId(ItemOptionId)
                .ItemOptionValueId(ItemOptionValueId);
            return builder;
        }

        public class Builder
        {
            private string itemOptionId;
            private string itemOptionValueId;



            public Builder ItemOptionId(string itemOptionId)
            {
                this.itemOptionId = itemOptionId;
                return this;
            }

            public Builder ItemOptionValueId(string itemOptionValueId)
            {
                this.itemOptionValueId = itemOptionValueId;
                return this;
            }

            public CatalogItemOptionValueForItemVariation Build()
            {
                return new CatalogItemOptionValueForItemVariation(itemOptionId,
                    itemOptionValueId);
            }
        }
    }
}