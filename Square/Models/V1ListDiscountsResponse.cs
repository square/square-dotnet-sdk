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
    public class V1ListDiscountsResponse 
    {
        public V1ListDiscountsResponse(IList<Models.V1Discount> items = null)
        {
            Items = items;
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("items")]
        public IList<Models.V1Discount> Items { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Items(Items);
            return builder;
        }

        public class Builder
        {
            private IList<Models.V1Discount> items;

            public Builder() { }
            public Builder Items(IList<Models.V1Discount> value)
            {
                items = value;
                return this;
            }

            public V1ListDiscountsResponse Build()
            {
                return new V1ListDiscountsResponse(items);
            }
        }
    }
} 