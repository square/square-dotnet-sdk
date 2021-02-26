
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
    public class SearchAvailabilityQuery 
    {
        public SearchAvailabilityQuery(Models.SearchAvailabilityFilter filter)
        {
            Filter = filter;
        }

        /// <summary>
        /// A query filter to search for availabilities by.
        /// </summary>
        [JsonProperty("filter")]
        public Models.SearchAvailabilityFilter Filter { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SearchAvailabilityQuery : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Filter = {(Filter == null ? "null" : Filter.ToString())}");
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

            return obj is SearchAvailabilityQuery other &&
                ((Filter == null && other.Filter == null) || (Filter?.Equals(other.Filter) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 2004874460;

            if (Filter != null)
            {
               hashCode += Filter.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder(Filter);
            return builder;
        }

        public class Builder
        {
            private Models.SearchAvailabilityFilter filter;

            public Builder(Models.SearchAvailabilityFilter filter)
            {
                this.filter = filter;
            }

            public Builder Filter(Models.SearchAvailabilityFilter filter)
            {
                this.filter = filter;
                return this;
            }

            public SearchAvailabilityQuery Build()
            {
                return new SearchAvailabilityQuery(filter);
            }
        }
    }
}