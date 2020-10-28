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
    public class V1ListTimecardsResponse 
    {
        public V1ListTimecardsResponse(IList<Models.V1Timecard> items = null)
        {
            Items = items;
        }

        /// <summary>
        /// Getter for items
        /// </summary>
        [JsonProperty("items", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.V1Timecard> Items { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Items(Items);
            return builder;
        }

        public class Builder
        {
            private IList<Models.V1Timecard> items;



            public Builder Items(IList<Models.V1Timecard> items)
            {
                this.items = items;
                return this;
            }

            public V1ListTimecardsResponse Build()
            {
                return new V1ListTimecardsResponse(items);
            }
        }
    }
}