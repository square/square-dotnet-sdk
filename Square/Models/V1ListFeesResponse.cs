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
    public class V1ListFeesResponse 
    {
        public V1ListFeesResponse(IList<Models.V1Fee> items = null)
        {
            Items = items;
        }

        /// <summary>
        /// Getter for items
        /// </summary>
        [JsonProperty("items")]
        public IList<Models.V1Fee> Items { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Items(Items);
            return builder;
        }

        public class Builder
        {
            private IList<Models.V1Fee> items = new List<Models.V1Fee>();

            public Builder() { }
            public Builder Items(IList<Models.V1Fee> value)
            {
                items = value;
                return this;
            }

            public V1ListFeesResponse Build()
            {
                return new V1ListFeesResponse(items);
            }
        }
    }
}