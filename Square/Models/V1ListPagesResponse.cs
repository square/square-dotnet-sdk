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
    public class V1ListPagesResponse 
    {
        public V1ListPagesResponse(IList<Models.V1Page> items = null)
        {
            Items = items;
        }

        /// <summary>
        /// Getter for items
        /// </summary>
        [JsonProperty("items", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.V1Page> Items { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Items(Items);
            return builder;
        }

        public class Builder
        {
            private IList<Models.V1Page> items;



            public Builder Items(IList<Models.V1Page> items)
            {
                this.items = items;
                return this;
            }

            public V1ListPagesResponse Build()
            {
                return new V1ListPagesResponse(items);
            }
        }
    }
}