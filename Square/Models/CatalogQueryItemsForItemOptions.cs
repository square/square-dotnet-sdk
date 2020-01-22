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
        [JsonProperty("item_option_ids")]
        public IList<string> ItemOptionIds { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .ItemOptionIds(ItemOptionIds);
            return builder;
        }

        public class Builder
        {
            private IList<string> itemOptionIds = new List<string>();

            public Builder() { }
            public Builder ItemOptionIds(IList<string> value)
            {
                itemOptionIds = value;
                return this;
            }

            public CatalogQueryItemsForItemOptions Build()
            {
                return new CatalogQueryItemsForItemOptions(itemOptionIds);
            }
        }
    }
}