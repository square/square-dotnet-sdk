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
    public class OrderCreatedObject 
    {
        public OrderCreatedObject(Models.OrderCreated orderCreated = null)
        {
            OrderCreated = orderCreated;
        }

        /// <summary>
        /// Getter for order_created
        /// </summary>
        [JsonProperty("order_created", NullValueHandling = NullValueHandling.Ignore)]
        public Models.OrderCreated OrderCreated { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .OrderCreated(OrderCreated);
            return builder;
        }

        public class Builder
        {
            private Models.OrderCreated orderCreated;



            public Builder OrderCreated(Models.OrderCreated orderCreated)
            {
                this.orderCreated = orderCreated;
                return this;
            }

            public OrderCreatedObject Build()
            {
                return new OrderCreatedObject(orderCreated);
            }
        }
    }
}