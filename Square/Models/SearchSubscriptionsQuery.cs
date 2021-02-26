
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
        [JsonProperty("filter", NullValueHandling = NullValueHandling.Ignore)]
        public Models.SearchSubscriptionsFilter Filter { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SearchSubscriptionsQuery : ({string.Join(", ", toStringOutput)})";
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

            return obj is SearchSubscriptionsQuery other &&
                ((Filter == null && other.Filter == null) || (Filter?.Equals(other.Filter) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -1048089078;

            if (Filter != null)
            {
               hashCode += Filter.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Filter(Filter);
            return builder;
        }

        public class Builder
        {
            private Models.SearchSubscriptionsFilter filter;



            public Builder Filter(Models.SearchSubscriptionsFilter filter)
            {
                this.filter = filter;
                return this;
            }

            public SearchSubscriptionsQuery Build()
            {
                return new SearchSubscriptionsQuery(filter);
            }
        }
    }
}