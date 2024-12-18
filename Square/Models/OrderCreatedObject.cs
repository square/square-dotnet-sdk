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
    /// OrderCreatedObject.
    /// </summary>
    public class OrderCreatedObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderCreatedObject"/> class.
        /// </summary>
        /// <param name="orderCreated">order_created.</param>
        public OrderCreatedObject(
            Models.OrderCreated orderCreated = null)
        {
            this.OrderCreated = orderCreated;
        }

        /// <summary>
        /// Gets or sets OrderCreated.
        /// </summary>
        [JsonProperty("order_created", NullValueHandling = NullValueHandling.Ignore)]
        public Models.OrderCreated OrderCreated { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"OrderCreatedObject : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is OrderCreatedObject other &&
                (this.OrderCreated == null && other.OrderCreated == null ||
                 this.OrderCreated?.Equals(other.OrderCreated) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 529492832;
            hashCode = HashCode.Combine(hashCode, this.OrderCreated);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.OrderCreated = {(this.OrderCreated == null ? "null" : this.OrderCreated.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .OrderCreated(this.OrderCreated);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.OrderCreated orderCreated;

             /// <summary>
             /// OrderCreated.
             /// </summary>
             /// <param name="orderCreated"> orderCreated. </param>
             /// <returns> Builder. </returns>
            public Builder OrderCreated(Models.OrderCreated orderCreated)
            {
                this.orderCreated = orderCreated;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> OrderCreatedObject. </returns>
            public OrderCreatedObject Build()
            {
                return new OrderCreatedObject(
                    this.orderCreated);
            }
        }
    }
}