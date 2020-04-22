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
    public class OrderFulfillmentUpdatedObject 
    {
        public OrderFulfillmentUpdatedObject(Models.OrderFulfillmentUpdated orderFulfillmentUpdated = null)
        {
            OrderFulfillmentUpdated = orderFulfillmentUpdated;
        }

        /// <summary>
        /// Getter for order_fulfillment_updated
        /// </summary>
        [JsonProperty("order_fulfillment_updated")]
        public Models.OrderFulfillmentUpdated OrderFulfillmentUpdated { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .OrderFulfillmentUpdated(OrderFulfillmentUpdated);
            return builder;
        }

        public class Builder
        {
            private Models.OrderFulfillmentUpdated orderFulfillmentUpdated;

            public Builder() { }
            public Builder OrderFulfillmentUpdated(Models.OrderFulfillmentUpdated value)
            {
                orderFulfillmentUpdated = value;
                return this;
            }

            public OrderFulfillmentUpdatedObject Build()
            {
                return new OrderFulfillmentUpdatedObject(orderFulfillmentUpdated);
            }
        }
    }
}