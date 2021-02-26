
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
    public class InvoiceQuery 
    {
        public InvoiceQuery(Models.InvoiceFilter filter,
            Models.InvoiceSort sort = null)
        {
            Filter = filter;
            Sort = sort;
        }

        /// <summary>
        /// Describes query filters to apply.
        /// </summary>
        [JsonProperty("filter")]
        public Models.InvoiceFilter Filter { get; }

        /// <summary>
        /// Identifies the  sort field and sort order.
        /// </summary>
        [JsonProperty("sort", NullValueHandling = NullValueHandling.Ignore)]
        public Models.InvoiceSort Sort { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"InvoiceQuery : ({string.Join(", ", toStringOutput)})";
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

            return obj is InvoiceQuery other &&
                ((Filter == null && other.Filter == null) || (Filter?.Equals(other.Filter) == true)) &&
                ((Sort == null && other.Sort == null) || (Sort?.Equals(other.Sort) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -1092655669;

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
            var builder = new Builder(Filter)
                .Sort(Sort);
            return builder;
        }

        public class Builder
        {
            private Models.InvoiceFilter filter;
            private Models.InvoiceSort sort;

            public Builder(Models.InvoiceFilter filter)
            {
                this.filter = filter;
            }

            public Builder Filter(Models.InvoiceFilter filter)
            {
                this.filter = filter;
                return this;
            }

            public Builder Sort(Models.InvoiceSort sort)
            {
                this.sort = sort;
                return this;
            }

            public InvoiceQuery Build()
            {
                return new InvoiceQuery(filter,
                    sort);
            }
        }
    }
}