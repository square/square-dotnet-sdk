
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
    public class LoyaltyEventTypeFilter 
    {
        public LoyaltyEventTypeFilter(IList<string> types)
        {
            Types = types;
        }

        /// <summary>
        /// The loyalty event types used to filter the result.
        /// If multiple values are specified, the endpoint uses a 
        /// logical OR to combine them.
        /// See [LoyaltyEventType](#type-loyaltyeventtype) for possible values
        /// </summary>
        [JsonProperty("types")]
        public IList<string> Types { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"LoyaltyEventTypeFilter : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Types = {(Types == null ? "null" : $"[{ string.Join(", ", Types)} ]")}");
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

            return obj is LoyaltyEventTypeFilter other &&
                ((Types == null && other.Types == null) || (Types?.Equals(other.Types) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 474693041;

            if (Types != null)
            {
               hashCode += Types.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder(Types);
            return builder;
        }

        public class Builder
        {
            private IList<string> types;

            public Builder(IList<string> types)
            {
                this.types = types;
            }

            public Builder Types(IList<string> types)
            {
                this.types = types;
                return this;
            }

            public LoyaltyEventTypeFilter Build()
            {
                return new LoyaltyEventTypeFilter(types);
            }
        }
    }
}