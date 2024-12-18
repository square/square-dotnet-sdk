using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIMatic.Core.Utilities.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square;
using Square.Utilities;

namespace Square.Models
{
    /// <summary>
    /// CreateOrderRequest.
    /// </summary>
    public class CreateOrderRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateOrderRequest"/> class.
        /// </summary>
        /// <param name="order">order.</param>
        /// <param name="idempotencyKey">idempotency_key.</param>
        public CreateOrderRequest(
            Models.Order order = null,
            string idempotencyKey = null)
        {
            this.Order = order;
            this.IdempotencyKey = idempotencyKey;
        }

        /// <summary>
        /// Contains all information related to a single order to process with Square,
        /// including line items that specify the products to purchase. `Order` objects also
        /// include information about any associated tenders, refunds, and returns.
        /// All Connect V2 Transactions have all been converted to Orders including all associated
        /// itemization data.
        /// </summary>
        [JsonProperty("order", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Order Order { get; }

        /// <summary>
        /// A value you specify that uniquely identifies this
        /// order among orders you have created.
        /// If you are unsure whether a particular order was created successfully,
        /// you can try it again with the same idempotency key without
        /// worrying about creating duplicate orders.
        /// For more information, see [Idempotency](https://developer.squareup.com/docs/build-basics/common-api-patterns/idempotency).
        /// </summary>
        [JsonProperty("idempotency_key", NullValueHandling = NullValueHandling.Ignore)]
        public string IdempotencyKey { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"CreateOrderRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is CreateOrderRequest other &&
                (this.Order == null && other.Order == null ||
                 this.Order?.Equals(other.Order) == true) &&
                (this.IdempotencyKey == null && other.IdempotencyKey == null ||
                 this.IdempotencyKey?.Equals(other.IdempotencyKey) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -934891871;
            hashCode = HashCode.Combine(hashCode, this.Order, this.IdempotencyKey);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Order = {(this.Order == null ? "null" : this.Order.ToString())}");
            toStringOutput.Add($"this.IdempotencyKey = {this.IdempotencyKey ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Order(this.Order)
                .IdempotencyKey(this.IdempotencyKey);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.Order order;
            private string idempotencyKey;

             /// <summary>
             /// Order.
             /// </summary>
             /// <param name="order"> order. </param>
             /// <returns> Builder. </returns>
            public Builder Order(Models.Order order)
            {
                this.order = order;
                return this;
            }

             /// <summary>
             /// IdempotencyKey.
             /// </summary>
             /// <param name="idempotencyKey"> idempotencyKey. </param>
             /// <returns> Builder. </returns>
            public Builder IdempotencyKey(string idempotencyKey)
            {
                this.idempotencyKey = idempotencyKey;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CreateOrderRequest. </returns>
            public CreateOrderRequest Build()
            {
                return new CreateOrderRequest(
                    this.order,
                    this.idempotencyKey);
            }
        }
    }
}