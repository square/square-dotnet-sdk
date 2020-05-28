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
        [JsonProperty("filter")]
        public Models.LoyaltyEventFilter Filter { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Filter(Filter);
            return builder;
        }

        public class Builder
        {
            private Models.LoyaltyEventFilter filter;

            public Builder() { }
            public Builder Filter(Models.LoyaltyEventFilter value)
            {
                filter = value;
                return this;
            }

            public LoyaltyEventQuery Build()
            {
                return new LoyaltyEventQuery(filter);
            }
        }
    }
}