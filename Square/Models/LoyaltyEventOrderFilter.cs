
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"LoyaltyEventOrderFilter : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"OrderId = {(OrderId == null ? "null" : OrderId == string.Empty ? "" : OrderId)}");
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

            return obj is LoyaltyEventOrderFilter other &&
                ((OrderId == null && other.OrderId == null) || (OrderId?.Equals(other.OrderId) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 1504536925;

            if (OrderId != null)
            {
               hashCode += OrderId.GetHashCode();
            }

            return hashCode;
        }

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

            public Builder OrderId(string orderId)
            {
                this.orderId = orderId;
                return this;
            }

            public LoyaltyEventOrderFilter Build()
            {
                return new LoyaltyEventOrderFilter(orderId);
            }
        }
    }
}