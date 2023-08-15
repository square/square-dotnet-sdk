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
    /// LoyaltyEventOrderFilter.
    /// </summary>
    public class LoyaltyEventOrderFilter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoyaltyEventOrderFilter"/> class.
        /// </summary>
        /// <param name="orderId">order_id.</param>
        public LoyaltyEventOrderFilter(
            string orderId)
        {
            this.OrderId = orderId;
        }

        /// <summary>
        /// The ID of the [order](entity:Order) associated with the event.
        /// </summary>
        [JsonProperty("order_id")]
        public string OrderId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"LoyaltyEventOrderFilter : ({string.Join(", ", toStringOutput)})";
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
            return obj is LoyaltyEventOrderFilter other &&                ((this.OrderId == null && other.OrderId == null) || (this.OrderId?.Equals(other.OrderId) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1504536925;
            hashCode = HashCode.Combine(this.OrderId);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.OrderId = {(this.OrderId == null ? "null" : this.OrderId)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.OrderId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string orderId;

            public Builder(
                string orderId)
            {
                this.orderId = orderId;
            }

             /// <summary>
             /// OrderId.
             /// </summary>
             /// <param name="orderId"> orderId. </param>
             /// <returns> Builder. </returns>
            public Builder OrderId(string orderId)
            {
                this.orderId = orderId;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> LoyaltyEventOrderFilter. </returns>
            public LoyaltyEventOrderFilter Build()
            {
                return new LoyaltyEventOrderFilter(
                    this.orderId);
            }
        }
    }
}