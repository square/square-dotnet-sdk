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
    public class V1ListItemsResponse 
    {
        public V1ListItemsResponse(IList<Models.V1Item> items = null)
        {
            Items = items;
        }

        /// <summary>
        /// Getter for items
        /// </summary>
        [JsonProperty("items", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.V1Item> Items { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Items(Items);
            return builder;
        }

        public class Builder
        {
            private IList<Models.V1Item> items;



            public Builder Items(IList<Models.V1Item> items)
            {
                this.items = items;
                return this;
            }

            public V1ListItemsResponse Build()
            {
                return new V1ListItemsResponse(items);
            }
        }
    }
}