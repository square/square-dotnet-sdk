
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
    public class TerminalRefundQuery 
    {
        public TerminalRefundQuery(Models.TerminalRefundQueryFilter filter = null,
            Models.TerminalRefundQuerySort sort = null)
        {
            Filter = filter;
            Sort = sort;
        }

        /// <summary>
        /// Getter for filter
        /// </summary>
        [JsonProperty("filter", NullValueHandling = NullValueHandling.Ignore)]
        public Models.TerminalRefundQueryFilter Filter { get; }

        /// <summary>
        /// Getter for sort
        /// </summary>
        [JsonProperty("sort", NullValueHandling = NullValueHandling.Ignore)]
        public Models.TerminalRefundQuerySort Sort { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"TerminalRefundQuery : ({string.Join(", ", toStringOutput)})";
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

            return obj is TerminalRefundQuery other &&
                ((Filter == null && other.Filter == null) || (Filter?.Equals(other.Filter) == true)) &&
                ((Sort == null && other.Sort == null) || (Sort?.Equals(other.Sort) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 460808272;

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
            private Models.TerminalRefundQueryFilter filter;
            private Models.TerminalRefundQuerySort sort;



            public Builder Filter(Models.TerminalRefundQueryFilter filter)
            {
                this.filter = filter;
                return this;
            }

            public Builder Sort(Models.TerminalRefundQuerySort sort)
            {
                this.sort = sort;
                return this;
            }

            public TerminalRefundQuery Build()
            {
                return new TerminalRefundQuery(filter,
                    sort);
            }
        }
    }
}