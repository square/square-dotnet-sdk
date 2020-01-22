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
        [JsonProperty("item_option_id")]
        public string ItemOptionId { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .ItemOptionId(ItemOptionId);
            return builder;
        }

        public class Builder
        {
            private string itemOptionId;

            public Builder() { }
            public Builder ItemOptionId(string value)
            {
                itemOptionId = value;
                return this;
            }

            public CatalogItemOptionForItem Build()
            {
                return new CatalogItemOptionForItem(itemOptionId);
            }
        }
    }
}