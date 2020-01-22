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
        [JsonProperty("item_option_value_ids")]
        public IList<string> ItemOptionValueIds { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .ItemOptionValueIds(ItemOptionValueIds);
            return builder;
        }

        public class Builder
        {
            private IList<string> itemOptionValueIds = new List<string>();

            public Builder() { }
            public Builder ItemOptionValueIds(IList<string> value)
            {
                itemOptionValueIds = value;
                return this;
            }

            public CatalogQueryItemVariationsForItemOptionValues Build()
            {
                return new CatalogQueryItemVariationsForItemOptionValues(itemOptionValueIds);
            }
        }
    }
}