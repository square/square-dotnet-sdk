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
using Square.Legacy;
using Square.Legacy.Utilities;

namespace Square.Legacy.Models
{
    /// <summary>
    /// UnlinkCustomerFromGiftCardRequest.
    /// </summary>
    public class UnlinkCustomerFromGiftCardRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnlinkCustomerFromGiftCardRequest"/> class.
        /// </summary>
        /// <param name="customerId">customer_id.</param>
        public UnlinkCustomerFromGiftCardRequest(string customerId)
        {
            this.CustomerId = customerId;
        }

        /// <summary>
        /// The ID of the customer to unlink from the gift card.
        /// </summary>
        [JsonProperty("customer_id")]
        public string CustomerId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"UnlinkCustomerFromGiftCardRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is UnlinkCustomerFromGiftCardRequest other
                && (
                    this.CustomerId == null && other.CustomerId == null
                    || this.CustomerId?.Equals(other.CustomerId) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -459860487;
            hashCode = HashCode.Combine(hashCode, this.CustomerId);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.CustomerId = {this.CustomerId ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(this.CustomerId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string customerId;

            /// <summary>
            /// Initialize Builder for UnlinkCustomerFromGiftCardRequest.
            /// </summary>
            /// <param name="customerId"> customerId. </param>
            public Builder(string customerId)
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
            /// <returns> UnlinkCustomerFromGiftCardRequest. </returns>
            public UnlinkCustomerFromGiftCardRequest Build()
            {
                return new UnlinkCustomerFromGiftCardRequest(this.customerId);
            }
        }
    }
}
