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
    /// OrderUpdatedObject.
    /// </summary>
    public class OrderUpdatedObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderUpdatedObject"/> class.
        /// </summary>
        /// <param name="orderUpdated">order_updated.</param>
        public OrderUpdatedObject(
            Models.OrderUpdated orderUpdated = null)
        {
            this.OrderUpdated = orderUpdated;
        }

        /// <summary>
        /// Gets or sets OrderUpdated.
        /// </summary>
        [JsonProperty("order_updated", NullValueHandling = NullValueHandling.Ignore)]
        public Models.OrderUpdated OrderUpdated { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"OrderUpdatedObject : ({string.Join(", ", toStringOutput)})";
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
            return obj is OrderUpdatedObject other &&                ((this.OrderUpdated == null && other.OrderUpdated == null) || (this.OrderUpdated?.Equals(other.OrderUpdated) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -155189447;
            hashCode = HashCode.Combine(this.OrderUpdated);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.OrderUpdated = {(this.OrderUpdated == null ? "null" : this.OrderUpdated.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .OrderUpdated(this.OrderUpdated);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.OrderUpdated orderUpdated;

             /// <summary>
             /// OrderUpdated.
             /// </summary>
             /// <param name="orderUpdated"> orderUpdated. </param>
             /// <returns> Builder. </returns>
            public Builder OrderUpdated(Models.OrderUpdated orderUpdated)
            {
                this.orderUpdated = orderUpdated;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> OrderUpdatedObject. </returns>
            public OrderUpdatedObject Build()
            {
                return new OrderUpdatedObject(
                    this.orderUpdated);
            }
        }
    }
}