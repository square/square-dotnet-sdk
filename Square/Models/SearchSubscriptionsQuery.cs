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
    public class SearchSubscriptionsQuery 
    {
        public SearchSubscriptionsQuery(Models.SearchSubscriptionsFilter filter = null)
        {
            Filter = filter;
        }

        /// <summary>
        /// Represents a set of SearchSubscriptionsQuery filters used to limit the set of Subscriptions returned by SearchSubscriptions.
        /// </summary>
        [JsonProperty("filter")]
        public Models.SearchSubscriptionsFilter Filter { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Filter(Filter);
            return builder;
        }

        public class Builder
        {
            private Models.SearchSubscriptionsFilter filter;

            public Builder() { }
            public Builder Filter(Models.SearchSubscriptionsFilter value)
            {
                filter = value;
                return this;
            }

            public SearchSubscriptionsQuery Build()
            {
                return new SearchSubscriptionsQuery(filter);
            }
        }
    }
}