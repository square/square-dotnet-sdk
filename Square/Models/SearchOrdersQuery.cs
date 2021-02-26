
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SearchOrdersQuery : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Filter = {(Filter == null ? "null" : Filter.ToString())}");
            toStringOutput.Add($"Sort = {(Sort == null ? "null" : Sort.ToString())}");
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }

            return obj is SearchOrdersQuery other &&
                ((Filter == null && other.Filter == null) || (Filter?.Equals(other.Filter) == true)) &&
                ((Sort == null && other.Sort == null) || (Sort?.Equals(other.Sort) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 1642985281;

            if (Filter != null)
            {
               hashCode += Filter.GetHashCode();
            }

            if (Sort != null)
            {
               hashCode += Sort.GetHashCode();
            }

            return hashCode;
        }

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