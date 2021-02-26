
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"OrderCreatedObject : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"OrderCreated = {(OrderCreated == null ? "null" : OrderCreated.ToString())}");
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

            return obj is OrderCreatedObject other &&
                ((OrderCreated == null && other.OrderCreated == null) || (OrderCreated?.Equals(other.OrderCreated) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 529492832;

            if (OrderCreated != null)
            {
               hashCode += OrderCreated.GetHashCode();
            }

            return hashCode;
        }

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