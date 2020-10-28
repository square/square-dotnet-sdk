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
    public class SearchOrdersFulfillmentFilter 
    {
        public SearchOrdersFulfillmentFilter(IList<string> fulfillmentTypes = null,
            IList<string> fulfillmentStates = null)
        {
            FulfillmentTypes = fulfillmentTypes;
            FulfillmentStates = fulfillmentStates;
        }

        /// <summary>
        /// List of [fulfillment types](#type-orderfulfillmenttype) to filter
        /// for. Will return orders if any of its fulfillments match any of the fulfillment types
        /// listed in this field.
        /// See [OrderFulfillmentType](#type-orderfulfillmenttype) for possible values
        /// </summary>
        [JsonProperty("fulfillment_types", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> FulfillmentTypes { get; }

        /// <summary>
        /// List of [fulfillment states](#type-orderfulfillmentstate) to filter
        /// for. Will return orders if any of its fulfillments match any of the
        /// fulfillment states listed in this field.
        /// See [OrderFulfillmentState](#type-orderfulfillmentstate) for possible values
        /// </summary>
        [JsonProperty("fulfillment_states", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> FulfillmentStates { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .FulfillmentTypes(FulfillmentTypes)
                .FulfillmentStates(FulfillmentStates);
            return builder;
        }

        public class Builder
        {
            private IList<string> fulfillmentTypes;
            private IList<string> fulfillmentStates;



            public Builder FulfillmentTypes(IList<string> fulfillmentTypes)
            {
                this.fulfillmentTypes = fulfillmentTypes;
                return this;
            }

            public Builder FulfillmentStates(IList<string> fulfillmentStates)
            {
                this.fulfillmentStates = fulfillmentStates;
                return this;
            }

            public SearchOrdersFulfillmentFilter Build()
            {
                return new SearchOrdersFulfillmentFilter(fulfillmentTypes,
                    fulfillmentStates);
            }
        }
    }
}