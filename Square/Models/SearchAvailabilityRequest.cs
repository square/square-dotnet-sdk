
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
    public class SearchAvailabilityRequest 
    {
        public SearchAvailabilityRequest(Models.SearchAvailabilityQuery query)
        {
            Query = query;
        }

        /// <summary>
        /// Query conditions to search for availabilities of bookings.
        /// </summary>
        [JsonProperty("query")]
        public Models.SearchAvailabilityQuery Query { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SearchAvailabilityRequest : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Query = {(Query == null ? "null" : Query.ToString())}");
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

            return obj is SearchAvailabilityRequest other &&
                ((Query == null && other.Query == null) || (Query?.Equals(other.Query) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -1074083477;

            if (Query != null)
            {
               hashCode += Query.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder(Query);
            return builder;
        }

        public class Builder
        {
            private Models.SearchAvailabilityQuery query;

            public Builder(Models.SearchAvailabilityQuery query)
            {
                this.query = query;
            }

            public Builder Query(Models.SearchAvailabilityQuery query)
            {
                this.query = query;
                return this;
            }

            public SearchAvailabilityRequest Build()
            {
                return new SearchAvailabilityRequest(query);
            }
        }
    }
}