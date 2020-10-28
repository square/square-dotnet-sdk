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
    public class SearchOrdersQuery 
    {
        public SearchOrdersQuery(Models.SearchOrdersFilter filter = null,
            Models.SearchOrdersSort sort = null)
        {
            Filter = filter;
            Sort = sort;
        }

        /// <summary>
        /// Filtering criteria to use for a SearchOrders request. Multiple filters
        /// will be ANDed together.
        /// </summary>
        [JsonProperty("filter", NullValueHandling = NullValueHandling.Ignore)]
        public Models.SearchOrdersFilter Filter { get; }

        /// <summary>
        /// Sorting criteria for a SearchOrders request. Results can only be sorted
        /// by a timestamp field.
        /// </summary>
        [JsonProperty("sort", NullValueHandling = NullValueHandling.Ignore)]
        public Models.SearchOrdersSort Sort { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Filter(Filter)
                .Sort(Sort);
            return builder;
        }

        public class Builder
        {
            private Models.SearchOrdersFilter filter;
            private Models.SearchOrdersSort sort;



            public Builder Filter(Models.SearchOrdersFilter filter)
            {
                this.filter = filter;
                return this;
            }

            public Builder Sort(Models.SearchOrdersSort sort)
            {
                this.sort = sort;
                return this;
            }

            public SearchOrdersQuery Build()
            {
                return new SearchOrdersQuery(filter,
                    sort);
            }
        }
    }
}