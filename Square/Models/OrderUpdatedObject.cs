
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
        [JsonProperty("order_updated", NullValueHandling = NullValueHandling.Ignore)]
        public Models.OrderUpdated OrderUpdated { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"OrderUpdatedObject : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"OrderUpdated = {(OrderUpdated == null ? "null" : OrderUpdated.ToString())}");
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

            return obj is OrderUpdatedObject other &&
                ((OrderUpdated == null && other.OrderUpdated == null) || (OrderUpdated?.Equals(other.OrderUpdated) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -155189447;

            if (OrderUpdated != null)
            {
               hashCode += OrderUpdated.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .OrderUpdated(OrderUpdated);
            return builder;
        }

        public class Builder
        {
            private Models.OrderUpdated orderUpdated;



            public Builder OrderUpdated(Models.OrderUpdated orderUpdated)
            {
                this.orderUpdated = orderUpdated;
                return this;
            }

            public OrderUpdatedObject Build()
            {
                return new OrderUpdatedObject(orderUpdated);
            }
        }
    }
}