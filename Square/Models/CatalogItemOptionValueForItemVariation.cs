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
        [JsonProperty("item_option_id")]
        public string ItemOptionId { get; }

        /// <summary>
        /// The unique id of the selected value for the item option.
        /// </summary>
        [JsonProperty("item_option_value_id")]
        public string ItemOptionValueId { get; }

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

            public Builder() { }
            public Builder ItemOptionId(string value)
            {
                itemOptionId = value;
                return this;
            }

            public Builder ItemOptionValueId(string value)
            {
                itemOptionValueId = value;
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