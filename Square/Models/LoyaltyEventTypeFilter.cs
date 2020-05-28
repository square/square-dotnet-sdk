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
            public Builder Types(IList<string> value)
            {
                types = value;
                return this;
            }

            public LoyaltyEventTypeFilter Build()
            {
                return new LoyaltyEventTypeFilter(types);
            }
        }
    }
}