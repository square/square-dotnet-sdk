
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
        [JsonProperty("filter", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CustomerFilter Filter { get; }

        /// <summary>
        /// Specifies how searched customers profiles are sorted, including the sort key and sort order.
        /// </summary>
        [JsonProperty("sort", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CustomerSort Sort { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CustomerQuery : ({string.Join(", ", toStringOutput)})";
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

            return obj is CustomerQuery other &&
                ((Filter == null && other.Filter == null) || (Filter?.Equals(other.Filter) == true)) &&
                ((Sort == null && other.Sort == null) || (Sort?.Equals(other.Sort) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 1206368426;

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
            private Models.CustomerFilter filter;
            private Models.CustomerSort sort;



            public Builder Filter(Models.CustomerFilter filter)
            {
                this.filter = filter;
                return this;
            }

            public Builder Sort(Models.CustomerSort sort)
            {
                this.sort = sort;
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