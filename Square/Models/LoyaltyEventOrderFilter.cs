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
    public class LoyaltyEventOrderFilter 
    {
        public LoyaltyEventOrderFilter(string orderId)
        {
            OrderId = orderId;
        }

        /// <summary>
        /// The ID of the [order](#type-Order) associated with the event.
        /// </summary>
        [JsonProperty("order_id")]
        public string OrderId { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(OrderId);
            return builder;
        }

        public class Builder
        {
            private string orderId;

            public Builder(string orderId)
            {
                this.orderId = orderId;
            }
            public Builder OrderId(string value)
            {
                orderId = value;
                return this;
            }

            public LoyaltyEventOrderFilter Build()
            {
                return new LoyaltyEventOrderFilter(orderId);
            }
        }
    }
}