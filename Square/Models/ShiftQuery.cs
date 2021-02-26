
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
    public class ShiftQuery 
    {
        public ShiftQuery(Models.ShiftFilter filter = null,
            Models.ShiftSort sort = null)
        {
            Filter = filter;
            Sort = sort;
        }

        /// <summary>
        /// Defines a filter used in a search for `Shift` records. `AND` logic is
        /// used by Square's servers to apply each filter property specified.
        /// </summary>
        [JsonProperty("filter", NullValueHandling = NullValueHandling.Ignore)]
        public Models.ShiftFilter Filter { get; }

        /// <summary>
        /// Sets the sort order of search results.
        /// </summary>
        [JsonProperty("sort", NullValueHandling = NullValueHandling.Ignore)]
        public Models.ShiftSort Sort { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ShiftQuery : ({string.Join(", ", toStringOutput)})";
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

            return obj is ShiftQuery other &&
                ((Filter == null && other.Filter == null) || (Filter?.Equals(other.Filter) == true)) &&
                ((Sort == null && other.Sort == null) || (Sort?.Equals(other.Sort) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 1635925970;

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
            private Models.ShiftFilter filter;
            private Models.ShiftSort sort;



            public Builder Filter(Models.ShiftFilter filter)
            {
                this.filter = filter;
                return this;
            }

            public Builder Sort(Models.ShiftSort sort)
            {
                this.sort = sort;
                return this;
            }

            public ShiftQuery Build()
            {
                return new ShiftQuery(filter,
                    sort);
            }
        }
    }
}