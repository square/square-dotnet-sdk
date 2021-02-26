
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
        [JsonProperty("order_fulfillment_updated", NullValueHandling = NullValueHandling.Ignore)]
        public Models.OrderFulfillmentUpdated OrderFulfillmentUpdated { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"OrderFulfillmentUpdatedObject : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"OrderFulfillmentUpdated = {(OrderFulfillmentUpdated == null ? "null" : OrderFulfillmentUpdated.ToString())}");
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

            return obj is OrderFulfillmentUpdatedObject other &&
                ((OrderFulfillmentUpdated == null && other.OrderFulfillmentUpdated == null) || (OrderFulfillmentUpdated?.Equals(other.OrderFulfillmentUpdated) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -1493216062;

            if (OrderFulfillmentUpdated != null)
            {
               hashCode += OrderFulfillmentUpdated.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .OrderFulfillmentUpdated(OrderFulfillmentUpdated);
            return builder;
        }

        public class Builder
        {
            private Models.OrderFulfillmentUpdated orderFulfillmentUpdated;



            public Builder OrderFulfillmentUpdated(Models.OrderFulfillmentUpdated orderFulfillmentUpdated)
            {
                this.orderFulfillmentUpdated = orderFulfillmentUpdated;
                return this;
            }

            public OrderFulfillmentUpdatedObject Build()
            {
                return new OrderFulfillmentUpdatedObject(orderFulfillmentUpdated);
            }
        }
    }
}