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
    public class V1ListCategoriesResponse 
    {
        public V1ListCategoriesResponse(IList<Models.V1Category> items = null)
        {
            Items = items;
        }

        /// <summary>
        /// Getter for items
        /// </summary>
        [JsonProperty("items")]
        public IList<Models.V1Category> Items { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Items(Items);
            return builder;
        }

        public class Builder
        {
            private IList<Models.V1Category> items = new List<Models.V1Category>();

            public Builder() { }
            public Builder Items(IList<Models.V1Category> value)
            {
                items = value;
                return this;
            }

            public V1ListCategoriesResponse Build()
            {
                return new V1ListCategoriesResponse(items);
            }
        }
    }
}