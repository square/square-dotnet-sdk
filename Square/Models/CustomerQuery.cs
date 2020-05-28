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
    public class CustomerQuery 
    {
        public CustomerQuery(Models.CustomerFilter filter = null,
            Models.CustomerSort sort = null)
        {
            Filter = filter;
            Sort = sort;
        }

        /// <summary>
        /// Represents a set of `CustomerQuery` filters used to limit the set of
        /// `Customers` returned by `SearchCustomers`.
        /// </summary>
        [JsonProperty("filter")]
        public Models.CustomerFilter Filter { get; }

        /// <summary>
        /// Specifies how searched customers profiles are sorted, including the sort key and sort order.
        /// </summary>
        [JsonProperty("sort")]
        public Models.CustomerSort Sort { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Filter(Filter)
                .Sort(Sort);
            return builder;
        }

        public class Builder
        {
            private Models.CustomerFilter filter;
            private Models.CustomerSort sort;

            public Builder() { }
            public Builder Filter(Models.CustomerFilter value)
            {
                filter = value;
                return this;
            }

            public Builder Sort(Models.CustomerSort value)
            {
                sort = value;
                return this;
            }

            public CustomerQuery Build()
            {
                return new CustomerQuery(filter,
                    sort);
            }
        }
    }
}