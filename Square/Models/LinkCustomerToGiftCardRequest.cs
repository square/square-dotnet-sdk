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
    /// LinkCustomerToGiftCardRequest.
    /// </summary>
    public class LinkCustomerToGiftCardRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LinkCustomerToGiftCardRequest"/> class.
        /// </summary>
        /// <param name="customerId">customer_id.</param>
        public LinkCustomerToGiftCardRequest(
            string customerId)
        {
            this.CustomerId = customerId;
        }

        /// <summary>
        /// The ID of the customer to link to the gift card.
        /// </summary>
        [JsonProperty("customer_id")]
        public string CustomerId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"LinkCustomerToGiftCardRequest : ({string.Join(", ", toStringOutput)})";
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
            return obj is LinkCustomerToGiftCardRequest other &&                ((this.CustomerId == null && other.CustomerId == null) || (this.CustomerId?.Equals(other.CustomerId) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 225193807;
            hashCode = HashCode.Combine(this.CustomerId);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.CustomerId = {(this.CustomerId == null ? "null" : this.CustomerId)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.CustomerId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string customerId;

            public Builder(
                string customerId)
            {
                this.customerId = customerId;
            }

             /// <summary>
             /// CustomerId.
             /// </summary>
             /// <param name="customerId"> customerId. </param>
             /// <returns> Builder. </returns>
            public Builder CustomerId(string customerId)
            {
                this.customerId = customerId;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> LinkCustomerToGiftCardRequest. </returns>
            public LinkCustomerToGiftCardRequest Build()
            {
                return new LinkCustomerToGiftCardRequest(
                    this.customerId);
            }
        }
    }
}