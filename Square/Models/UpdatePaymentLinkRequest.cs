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
    /// UpdatePaymentLinkRequest.
    /// </summary>
    public class UpdatePaymentLinkRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdatePaymentLinkRequest"/> class.
        /// </summary>
        /// <param name="paymentLink">payment_link.</param>
        public UpdatePaymentLinkRequest(
            Models.PaymentLink paymentLink)
        {
            this.PaymentLink = paymentLink;
        }

        /// <summary>
        /// Gets or sets PaymentLink.
        /// </summary>
        [JsonProperty("payment_link")]
        public Models.PaymentLink PaymentLink { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"UpdatePaymentLinkRequest : ({string.Join(", ", toStringOutput)})";
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
            return obj is UpdatePaymentLinkRequest other &&                ((this.PaymentLink == null && other.PaymentLink == null) || (this.PaymentLink?.Equals(other.PaymentLink) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 298778105;
            hashCode = HashCode.Combine(this.PaymentLink);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.PaymentLink = {(this.PaymentLink == null ? "null" : this.PaymentLink.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.PaymentLink);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.PaymentLink paymentLink;

            /// <summary>
            /// Initialize Builder for UpdatePaymentLinkRequest.
            /// </summary>
            /// <param name="paymentLink"> paymentLink. </param>
            public Builder(
                Models.PaymentLink paymentLink)
            {
                this.paymentLink = paymentLink;
            }

             /// <summary>
             /// PaymentLink.
             /// </summary>
             /// <param name="paymentLink"> paymentLink. </param>
             /// <returns> Builder. </returns>
            public Builder PaymentLink(Models.PaymentLink paymentLink)
            {
                this.paymentLink = paymentLink;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> UpdatePaymentLinkRequest. </returns>
            public UpdatePaymentLinkRequest Build()
            {
                return new UpdatePaymentLinkRequest(
                    this.paymentLink);
            }
        }
    }
}