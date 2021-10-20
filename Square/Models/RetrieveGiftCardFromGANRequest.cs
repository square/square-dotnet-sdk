namespace Square.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Utilities;

    /// <summary>
    /// RetrieveGiftCardFromGANRequest.
    /// </summary>
    public class RetrieveGiftCardFromGANRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RetrieveGiftCardFromGANRequest"/> class.
        /// </summary>
        /// <param name="gan">gan.</param>
        public RetrieveGiftCardFromGANRequest(
            string gan)
        {
            this.Gan = gan;
        }

        /// <summary>
        /// The gift card account number (GAN) of the gift card to retrieve.
        /// The maximum length of a GAN is 255 digits to account for third-party GANs that have been imported.
        /// Square-issued gift cards have 16-digit GANs.
        /// </summary>
        [JsonProperty("gan")]
        public string Gan { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"RetrieveGiftCardFromGANRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is RetrieveGiftCardFromGANRequest other &&
                ((this.Gan == null && other.Gan == null) || (this.Gan?.Equals(other.Gan) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -506152524;
            hashCode = HashCode.Combine(this.Gan);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Gan = {(this.Gan == null ? "null" : this.Gan == string.Empty ? "" : this.Gan)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Gan);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string gan;

            public Builder(
                string gan)
            {
                this.gan = gan;
            }

             /// <summary>
             /// Gan.
             /// </summary>
             /// <param name="gan"> gan. </param>
             /// <returns> Builder. </returns>
            public Builder Gan(string gan)
            {
                this.gan = gan;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> RetrieveGiftCardFromGANRequest. </returns>
            public RetrieveGiftCardFromGANRequest Build()
            {
                return new RetrieveGiftCardFromGANRequest(
                    this.gan);
            }
        }
    }
}