
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
    public class CreateOrderRequest 
    {
        public CreateOrderRequest(Models.Order order = null,
            string idempotencyKey = null)
        {
            Order = order;
            IdempotencyKey = idempotencyKey;
        }

        /// <summary>
        /// Contains all information related to a single order to process with Square,
        /// including line items that specify the products to purchase. Order objects also
        /// include information on any associated tenders, refunds, and returns.
        /// All Connect V2 Transactions have all been converted to Orders including all associated
        /// itemization data.
        /// </summary>
        [JsonProperty("order", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Order Order { get; }

        /// <summary>
        /// A value you specify that uniquely identifies this
        /// order among orders you've created.
        /// If you're unsure whether a particular order was created successfully,
        /// you can reattempt it with the same idempotency key without
        /// worrying about creating duplicate orders.
        /// See [Idempotency](https://developer.squareup.com/docs/basics/api101/idempotency) for more information.
        /// </summary>
        [JsonProperty("idempotency_key", NullValueHandling = NullValueHandling.Ignore)]
        public string IdempotencyKey { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreateOrderRequest : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Order = {(Order == null ? "null" : Order.ToString())}");
            toStringOutput.Add($"IdempotencyKey = {(IdempotencyKey == null ? "null" : IdempotencyKey == string.Empty ? "" : IdempotencyKey)}");
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

            return obj is CreateOrderRequest other &&
                ((Order == null && other.Order == null) || (Order?.Equals(other.Order) == true)) &&
                ((IdempotencyKey == null && other.IdempotencyKey == null) || (IdempotencyKey?.Equals(other.IdempotencyKey) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -934891871;

            if (Order != null)
            {
               hashCode += Order.GetHashCode();
            }

            if (IdempotencyKey != null)
            {
               hashCode += IdempotencyKey.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Order(Order)
                .IdempotencyKey(IdempotencyKey);
            return builder;
        }

        public class Builder
        {
            private Models.Order order;
            private string idempotencyKey;



            public Builder Order(Models.Order order)
            {
                this.order = order;
                return this;
            }

            public Builder IdempotencyKey(string idempotencyKey)
            {
                this.idempotencyKey = idempotencyKey;
                return this;
            }

            public CreateOrderRequest Build()
            {
                return new CreateOrderRequest(order,
                    idempotencyKey);
            }
        }
    }
}