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
    public class OrderUpdatedObject 
    {
        public OrderUpdatedObject(Models.OrderUpdated orderUpdated = null)
        {
            OrderUpdated = orderUpdated;
        }

        /// <summary>
        /// Getter for order_updated
        /// </summary>
        [JsonProperty("order_updated")]
        public Models.OrderUpdated OrderUpdated { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .OrderUpdated(OrderUpdated);
            return builder;
        }

        public class Builder
        {
            private Models.OrderUpdated orderUpdated;

            public Builder() { }
            public Builder OrderUpdated(Models.OrderUpdated value)
            {
                orderUpdated = value;
                return this;
            }

            public OrderUpdatedObject Build()
            {
                return new OrderUpdatedObject(orderUpdated);
            }
        }
    }
}