
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
    public class TerminalCheckoutQuery 
    {
        public TerminalCheckoutQuery(Models.TerminalCheckoutQueryFilter filter = null,
            Models.TerminalCheckoutQuerySort sort = null)
        {
            Filter = filter;
            Sort = sort;
        }

        /// <summary>
        /// Getter for filter
        /// </summary>
        [JsonProperty("filter", NullValueHandling = NullValueHandling.Ignore)]
        public Models.TerminalCheckoutQueryFilter Filter { get; }

        /// <summary>
        /// Getter for sort
        /// </summary>
        [JsonProperty("sort", NullValueHandling = NullValueHandling.Ignore)]
        public Models.TerminalCheckoutQuerySort Sort { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"TerminalCheckoutQuery : ({string.Join(", ", toStringOutput)})";
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

            return obj is TerminalCheckoutQuery other &&
                ((Filter == null && other.Filter == null) || (Filter?.Equals(other.Filter) == true)) &&
                ((Sort == null && other.Sort == null) || (Sort?.Equals(other.Sort) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 2068917898;

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
            private Models.TerminalCheckoutQueryFilter filter;
            private Models.TerminalCheckoutQuerySort sort;



            public Builder Filter(Models.TerminalCheckoutQueryFilter filter)
            {
                this.filter = filter;
                return this;
            }

            public Builder Sort(Models.TerminalCheckoutQuerySort sort)
            {
                this.sort = sort;
                return this;
            }

            public TerminalCheckoutQuery Build()
            {
                return new TerminalCheckoutQuery(filter,
                    sort);
            }
        }
    }
}