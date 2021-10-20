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
    /// CompletePaymentRequest.
    /// </summary>
    public class CompletePaymentRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompletePaymentRequest"/> class.
        /// </summary>
        /// <param name="versionToken">version_token.</param>
        public CompletePaymentRequest(
            string versionToken = null)
        {
            this.VersionToken = versionToken;
        }

        /// <summary>
        /// Used for optimistic concurrency. This opaque token identifies the current `Payment`
        /// version that the caller expects. If the server has a different version of the Payment,
        /// the update fails and a response with a VERSION_MISMATCH error is returned.
        /// </summary>
        [JsonProperty("version_token", NullValueHandling = NullValueHandling.Ignore)]
        public string VersionToken { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CompletePaymentRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is CompletePaymentRequest other &&
                ((this.VersionToken == null && other.VersionToken == null) || (this.VersionToken?.Equals(other.VersionToken) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 916056243;
            hashCode = HashCode.Combine(this.VersionToken);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.VersionToken = {(this.VersionToken == null ? "null" : this.VersionToken == string.Empty ? "" : this.VersionToken)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .VersionToken(this.VersionToken);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string versionToken;

             /// <summary>
             /// VersionToken.
             /// </summary>
             /// <param name="versionToken"> versionToken. </param>
             /// <returns> Builder. </returns>
            public Builder VersionToken(string versionToken)
            {
                this.versionToken = versionToken;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CompletePaymentRequest. </returns>
            public CompletePaymentRequest Build()
            {
                return new CompletePaymentRequest(
                    this.versionToken);
            }
        }
    }
}