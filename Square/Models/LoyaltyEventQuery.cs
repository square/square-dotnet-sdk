
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
    public class LoyaltyEventQuery 
    {
        public LoyaltyEventQuery(Models.LoyaltyEventFilter filter = null)
        {
            Filter = filter;
        }

        /// <summary>
        /// The filtering criteria. If the request specifies multiple filters, 
        /// the endpoint uses a logical AND to evaluate them.
        /// </summary>
        [JsonProperty("filter", NullValueHandling = NullValueHandling.Ignore)]
        public Models.LoyaltyEventFilter Filter { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"LoyaltyEventQuery : ({string.Join(", ", toStringOutput)})";
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

            return obj is LoyaltyEventQuery other &&
                ((Filter == null && other.Filter == null) || (Filter?.Equals(other.Filter) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -1645224426;

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
            private Models.LoyaltyEventFilter filter;



            public Builder Filter(Models.LoyaltyEventFilter filter)
            {
                this.filter = filter;
                return this;
            }

            public LoyaltyEventQuery Build()
            {
                return new LoyaltyEventQuery(filter);
            }
        }
    }
}