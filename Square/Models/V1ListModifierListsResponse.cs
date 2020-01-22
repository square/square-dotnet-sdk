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
    public class V1ListModifierListsResponse 
    {
        public V1ListModifierListsResponse(IList<Models.V1ModifierList> items = null)
        {
            Items = items;
        }

        /// <summary>
        /// Getter for items
        /// </summary>
        [JsonProperty("items")]
        public IList<Models.V1ModifierList> Items { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Items(Items);
            return builder;
        }

        public class Builder
        {
            private IList<Models.V1ModifierList> items = new List<Models.V1ModifierList>();

            public Builder() { }
            public Builder Items(IList<Models.V1ModifierList> value)
            {
                items = value;
                return this;
            }

            public V1ListModifierListsResponse Build()
            {
                return new V1ListModifierListsResponse(items);
            }
        }
    }
}