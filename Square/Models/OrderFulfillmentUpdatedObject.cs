namespace Square.Models
{
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

    /// <summary>
    /// OrderFulfillmentUpdatedObject.
    /// </summary>
    public class OrderFulfillmentUpdatedObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderFulfillmentUpdatedObject"/> class.
        /// </summary>
        /// <param name="orderFulfillmentUpdated">order_fulfillment_updated.</param>
        public OrderFulfillmentUpdatedObject(
            Models.OrderFulfillmentUpdated orderFulfillmentUpdated = null)
        {
            this.OrderFulfillmentUpdated = orderFulfillmentUpdated;
        }

        /// <summary>
        /// Gets or sets OrderFulfillmentUpdated.
        /// </summary>
        [JsonProperty("order_fulfillment_updated", NullValueHandling = NullValueHandling.Ignore)]
        public Models.OrderFulfillmentUpdated OrderFulfillmentUpdated { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"OrderFulfillmentUpdatedObject : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
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
            return obj is OrderFulfillmentUpdatedObject other &&                ((this.OrderFulfillmentUpdated == null && other.OrderFulfillmentUpdated == null) || (this.OrderFulfillmentUpdated?.Equals(other.OrderFulfillmentUpdated) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1493216062;
            hashCode = HashCode.Combine(this.OrderFulfillmentUpdated);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.OrderFulfillmentUpdated = {(this.OrderFulfillmentUpdated == null ? "null" : this.OrderFulfillmentUpdated.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .OrderFulfillmentUpdated(this.OrderFulfillmentUpdated);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.OrderFulfillmentUpdated orderFulfillmentUpdated;

             /// <summary>
             /// OrderFulfillmentUpdated.
             /// </summary>
             /// <param name="orderFulfillmentUpdated"> orderFulfillmentUpdated. </param>
             /// <returns> Builder. </returns>
            public Builder OrderFulfillmentUpdated(Models.OrderFulfillmentUpdated orderFulfillmentUpdated)
            {
                this.orderFulfillmentUpdated = orderFulfillmentUpdated;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> OrderFulfillmentUpdatedObject. </returns>
            public OrderFulfillmentUpdatedObject Build()
            {
                return new OrderFulfillmentUpdatedObject(
                    this.orderFulfillmentUpdated);
            }
        }
    }
}